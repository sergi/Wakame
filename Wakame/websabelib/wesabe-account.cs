using System.Xml.Serialization;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(ElementName="accounts",Namespace="", IsNullable=false)]
public partial class Accounts
{
    
    private Account[] itemsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("account", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public Account[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class Account
{
    
    private string accountnumberField;
    
    private string nameField;
    
    private string accounttypeField;
    
    private string currencyField;
    
    private int idField;
    
    private FinancialInstitution financialinstitutionField;
    
    private float currentbalanceField;
    
    private System.DateTime lastuploadedatField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("account-number", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string accountnumber {
        get {
            return this.accountnumberField;
        }
        set {
            this.accountnumberField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("account-type", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string accounttype {
        get {
            return this.accounttypeField;
        }
        set {
            this.accounttypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("currency", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string Currency
    {
        get {
            return this.currencyField;
        }
        set {
            this.currencyField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("id", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public int ID
    {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("financial-institution", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public FinancialInstitution financialInstitution {
        get {
            return this.financialinstitutionField;
        }
        set {
            this.financialinstitutionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("current-balance", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public float currentBalance {
        get {
            return this.currentbalanceField;
        }
        set {
            this.currentbalanceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("last-uploaded-at", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public System.DateTime lastUploadedAt {
        get {
            return this.lastuploadedatField;
        }
        set {
            this.lastuploadedatField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class FinancialInstitution {
    
    private string idField;
    
    private string nameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
}
