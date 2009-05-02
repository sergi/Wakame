using System;

public partial class Tag
{
    private string tagName;
    private decimal splitAmount;

    public string TagName
    {
        get { return tagName; }
        set { tagName = value; }
    }

    public decimal SplitAmount
    {
        get { return splitAmount; }
        set { splitAmount = value; }
    }
}