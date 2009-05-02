using System;

public partial class Merchant
{
    private string merchantName;
    private string rating;
    private int score;

    public string MerchantName
    {
        get { return merchantName; }
        set { merchantName = value; }
    }

    public string Rating
    {
        get { return rating; }
        set { rating = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }
}