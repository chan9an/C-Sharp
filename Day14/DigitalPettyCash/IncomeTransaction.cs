using System;

namespace DigitalPettyCash;

public class IncomeTransaction : Transaction
{
    public string Source { get; set; }

    public override string GetSummary()
    {
        return "Income: " + Amount + " | Source: " + Source;
    }
}

