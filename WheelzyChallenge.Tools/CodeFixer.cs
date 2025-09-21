using System.Text;
using System.Text.RegularExpressions;

namespace WheelyChallenge.Tools;

public static class CodeFixer
{
    public static void Run(string rootFolder)
    {
        var files = Directory.EnumerateFiles(rootFolder, "*.cs", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            var original = File.ReadAllText(file, Encoding.UTF8);
            var updated = ProcessText(original);

            if (!string.Equals(original, updated, StringComparison.Ordinal))
            {
                File.WriteAllText(file, updated, Encoding.UTF8);
                Console.WriteLine($"Fixed: {file}");
            }
        }
    }

    public static string ProcessText(string source)
    {
        var s = source;

        s = AppendAsyncSuffixToAsyncMethods(s);
        s = NormalizeVmDtoTokens(s);
        s = EnsureBlankLineBetweenMethods(s);

        return s;
    }


    private static string AppendAsyncSuffixToAsyncMethods(string source)
    {
        var rx = new Regex(
            @"(?ms)^(?<ws>\s*)" +
            @"(?<access>(?:public|private|protected|internal)\s+)?" +
            @"(?<mods>(?:(?:static|sealed|virtual|override|new)\s+)*)?" +
            @"async\s+" +
            @"(?<ret>Task(?:<[^>\r\n]+>)?|ValueTask(?:<[^>\r\n]+>)?|void)\s+" +
            @"(?<name>[A-Za-z_]\w*)" +
            @"(?<open>\s*\()",
            RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.Compiled);

        return rx.Replace(source, m =>
        {
            var ws = m.Groups["ws"].Value;
            var access = m.Groups["access"].Value;
            var mods = m.Groups["mods"].Value;
            var ret = m.Groups["ret"].Value;
            var name = m.Groups["name"].Value;
            var open = m.Groups["open"].Value;

            if (name.EndsWith("Async", StringComparison.Ordinal))
                return m.Value;

            var newName = name + "Async";
            return $"{ws}{access}{mods}async {ret} {newName}{open}";
        });
    }

    private static string NormalizeVmDtoTokens(string source)
    {
        var rules = new (Regex find, string repl)[]
        {
            (new Regex(@"\bVm\b"), "VM"),
            (new Regex(@"\bVms\b"), "VMs"),
            (new Regex(@"\bDto\b"), "DTO"),
            (new Regex(@"\bDtos\b"), "DTOs"),
        };

        var s = source;
        foreach (var (find, repl) in rules)
            s = find.Replace(s, repl);

        return s;
    }

    private static string EnsureBlankLineBetweenMethods(string source)
    {
        var lines = source.Replace("\r\n", "\n").Split('\n');
        var result = new List<string>(lines.Length);

        for (int i = 0; i < lines.Length; i++)
        {
            result.Add(lines[i]);

            if (i < lines.Length - 1)
            {
                var current = lines[i].TrimEnd();
                var next = lines[i + 1].TrimStart();

                bool closesBlock = current.EndsWith("}");
                bool looksLikeMethodStart =
                    next.StartsWith("[") ||
                    Regex.IsMatch(next, @"^(public|private|protected|internal|static|sealed|virtual|override|async)\b");

                bool alreadyHasBlank = string.IsNullOrWhiteSpace(lines[i + 1]);

                if (closesBlock && looksLikeMethodStart && !alreadyHasBlank)
                {
                    result.Add(string.Empty);
                }
            }
        }

        return string.Join("\n", result).Replace("\n", Environment.NewLine);
    }
}
