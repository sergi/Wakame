using System;
using System.Collections.Generic;

public partial class Transaction
{
    private int accountId;
    private DateTime transactionDate;
    private decimal amount;
    private string rawName;
    private string memo;
    private string merchantId;
    private string merchantName;
    private List<Merchant> merchants;
    private List<Tag> tags;

    public int AccountId
    {
        get { return accountId; }
        set { accountId = value; }
    }

    public DateTime TransactionDate
    {
        get { return transactionDate; }
        set { transactionDate = value; }
    }

    public decimal Amount
    {
        get { return amount; }
        set { amount = value; }
    }

    public string RawName
    {
        get { return rawName; }
        set { rawName = value; }
    }

    public string Memo
    {
        get { return memo; }
        set { memo = value; }
    }

    public List<Merchant> Merchants
    {
        get
        {
            if (merchants == null) merchants = new List<Merchant>();
            return merchants;
        }
    }

    public List<Tag> Tags
    {
        get
        {
            if (tags == null) tags = new List<Tag>();
            return tags;
        }
    }

    public string MerchantId
    {
        get { return merchantId; }
        set { merchantId = value; }
    }

    public string MerchantName
    {
        get { return merchantName; }
        set { merchantName = value; }
    }
}