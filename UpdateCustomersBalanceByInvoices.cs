

//OLD METHOD
public void OldUpdateCustomersBalanceByInvoices(List<Invoice> invoices)
{
    foreach (var invoice in invoices)
    {
        var customer =
        dbContext.Customers.SingleOrDefault(invoice.CustomerId.Value);
        customer.Balance -= invoice.Total;
        dbContext.SaveChanges();
    }
}


//NEW VERSION
public void UpdateCustomersBalanceByInvoices(List<Invoice> invoices)
{
    var customerIds = invoices.Select(i => i.CustomerId.Value).Distinct().ToList();

    var customers = dbContext.Customers
        .Where(c => customerIds.Contains(c.Id))
        .ToDictionary(c => c.Id);

    foreach (var invoice in invoices)
    {
        if (customers.TryGetValue(invoice.CustomerId.Value, out var customer))
        {
            customer.Balance -= invoice.Total;
        }
    }

    dbContext.SaveChanges();
}
