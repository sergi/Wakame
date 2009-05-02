using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace wesabelib
{
    // http://www.mono-project.com/UsingTrustedRootsRespectfully

    public class wesabe_rest : ICertificatePolicy
    {
        static wesabe_rest()
        {
            //ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
        }

        public bool CheckValidationResult (
              System.Net.ServicePoint srvPoint,
              System.Security.Cryptography.X509Certificates.X509Certificate certificate,
              System.Net.WebRequest request,
              int certificateProblem
        )
        {
            return true;
        }


        // The following method is invoked by the RemoteCertificateValidationDelegate.
        /*public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None &&
                certificate.Subject == @"CN=www.wesabe.com, OU=Thawte SSL123 certificate, OU=Go to https://www.thawte.com/repository/index.html, OU=Domain Validated, O=www.wesabe.com")
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }*/
        
        /*
        public static List<T> GetDataList(string url)
        {
        }
        
        public static List<T> GetDataList(string user, string password, string url)
        {
        }

*/
        public static Accounts getAccounts(string user, string password)
        {
            ServicePointManager.CertificatePolicy = new wesabe_rest ();

            HttpWebRequest webrequest =
                (HttpWebRequest)WebRequest.Create("https://www.wesabe.com/accounts.xml");
            webrequest.KeepAlive = false;
            webrequest.Method = "GET";

            //I should have been able to use the CredentialCache,
            // but the API isn't challenging and requesting auth.
            // Failure always turns into a 302 redirected, \
            // so we add the headers preemptively.
            webrequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user+":"+password)));

            using(HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse())
            {
                using(Stream s = webresponse.GetResponseStream())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Accounts));
                    Accounts a = serializer.Deserialize(s) as Accounts;
                    return a;
                }
            }
        }

        public static List<Transaction> getTransactions(string user, string password, int accountId)
        {
            /*XmlReader requestXML;
            if (cachedRequest != null)
            {
                requestXML = cachedRequest;
            }
            else
            {*/
                HttpWebRequest webrequest =
                    (HttpWebRequest)WebRequest.Create(string.Format("https://www.wesabe.com/accounts/show/{0}.xml", accountId.ToString()));
                webrequest.KeepAlive = false;
                webrequest.Method = "GET";

                //I should have been able to use the CredentialCache,
                // but the API isn't challenging and requesting auth.
                // Failure always turns into a 302 redirected, \
                // so we add the headers preemptively.
                webrequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));

                using (HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse())
                {
                    using (Stream s = webresponse.GetResponseStream())
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(XmlDocument));
                        XmlDocument doc = serializer.Deserialize(s) as XmlDocument;

                        List<Transaction> transactions = new List<Transaction>();
                        XmlNodeList nodes = doc.SelectNodes("/account/txactions/txaction");

                        foreach(XmlNode node in nodes)
                        {
                            Transaction t = new Transaction();

                            t.AccountId = accountId;

                            XmlNode date = node["date"];
                            if (date != null) t.TransactionDate = Convert.ToDateTime(date.InnerText);

                            XmlNode amount = node["amount"];
                            Console.WriteLine(amount.InnerText);
                            if (amount != null) t.Amount = Convert.ToDecimal(amount.InnerText);

                            XmlNode rawName = node["raw-name"];
                            if (rawName != null) t.RawName = rawName.InnerText;

                            XmlNode memo = node["memo"];
                            if (memo != null) t.Memo = memo.InnerText;

                            XmlNode merchant = node.SelectSingleNode("/merchant");
                            if (merchant != null)
                            {
                                t.MerchantId = merchant["id"].InnerText;
                                t.MerchantName = merchant["name"].InnerText;
                            }

                            transactions.Add(t);
                        }

                        return transactions;
                    }
                }
            //}
        }
    }
}
