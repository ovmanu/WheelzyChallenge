using WheelyChallenge.Tools;
using Xunit;

namespace WheelyChallenge.Tools.Tests;

public class CodeFixerTests
{
    [Fact]
    public void Appends_Async_Suffix_When_Missing()
    {
        var input = """
        public class C {
            public async Task DoWork() { await Task.Delay(1); }
            private async ValueTask<int> GetNumber() { return 1; }
            protected async void Fire() { }
            public async Task AlreadyAsync() { }
        }
        """;

        var output = CodeFixer.ProcessText(input);

        Assert.Contains("DoWorkAsync()", output);
        Assert.Contains("GetNumberAsync()", output);
        Assert.Contains("FireAsync()", output);
        Assert.Contains("AlreadyAsync()", output);
        Assert.DoesNotContain("AlreadyAsyncAsync()", output);
    }

    [Theory]
    [InlineData("Vm", "VM")]
    [InlineData("Vms", "VMs")]
    [InlineData("Dto", "DTO")]
    [InlineData("Dtos", "DTOs")]
    public void Normalizes_Tokens(string before, string after)
    {
        var input = $"public class {before} {{ int x; }} // {before} word";
        var output = CodeFixer.ProcessText(input);
        Assert.Contains(after, output);
        Assert.DoesNotContain($" {before} ", output);
    }

    [Fact]
    public void Inserts_Blank_Line_Between_Methods()
    {
        var input = """
        public class C
        {
            public void A() { }
            public void B() { }
        }
        """;

        var output = CodeFixer.ProcessText(input);

        var lines = output.Split(Environment.NewLine);
        var idxA = Array.FindIndex(lines, l => l.Contains("public void A()"));

        var idxB = Array.FindIndex(lines, l => l.Contains("public void B()"));

        Assert.True(idxB - idxA >= 2, "A blanlink should exist");
    }
}
