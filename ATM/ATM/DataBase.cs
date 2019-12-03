using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ATM
{
    public static class DataBase
    {
        private static readonly string Endereco = "C:\\Users\\Isaque\\Desktop\\UCL\\UCL.Xml";

        public static void Init()
        {
            if (!File.Exists(Endereco))
            {
                CreateXML();
            }
        }

        public static void CreateAccount(BankAccount account)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Endereco);

            XmlNode Account = doc.CreateElement("Account");

            XmlNode Name = doc.CreateElement("Name");
            Name.InnerText = account.Name;
            Account.AppendChild(Name);

            XmlNode AccountNumber = doc.CreateElement("AccountNumber");
            AccountNumber.InnerText = account.AccountNumber.ToString();
            Account.AppendChild(AccountNumber);

            XmlNode Pin = doc.CreateElement("Pin");
            Pin.InnerText = account.Pin.ToString();
            Account.AppendChild(Pin);

            XmlNode Balance = doc.CreateElement("Balance");
            Balance.InnerText = account.AccountBalance.ToString();
            Account.AppendChild(Balance);

            doc.DocumentElement.AppendChild(Account);

            doc.Save(Endereco);
        }

        public static void SaveBalance(int account, Decimal balance)
        {
            var xDoc = XDocument.Load(Endereco);

            var node = xDoc.Descendants("Accounts").FirstOrDefault(us => us.Element("Account").Value == account.ToString());

            foreach (var childElem in xDoc.XPathSelectElements("//Account"))
            {
                string childName = childElem.Element("AccountNumber").Value;

                if (childName == account.ToString())
                {
                    var currentBalance =  Decimal.Parse(childElem.Element("Balance").Value);

                    childElem.SetElementValue("Balance", balance+currentBalance);
                }
            }

            xDoc.Save(Endereco);
        }

        public static decimal CheckBalance(int account)
        {
            var xDoc = XDocument.Load(Endereco);

            foreach (var childElem in xDoc.XPathSelectElements("//Account"))
            {
                string childName = childElem.Element("AccountNumber").Value;

                if (childName == account.ToString())
                {
                    return Decimal.Parse(childElem.Element("Balance").Value);
                }
            }

            Console.WriteLine("Account not Found!");
            return 0;
        }

        private static void CreateXML()
        {
            if (!File.Exists(Endereco))
            {
                XmlTextWriter xwriter = new XmlTextWriter(Endereco, Encoding.UTF8);
                xwriter.Formatting = Formatting.Indented;
                xwriter.WriteStartElement("Accounts");
                xwriter.WriteStartElement("Account");
                xwriter.WriteString("");
                xwriter.WriteEndElement();
                xwriter.WriteStartElement("Name");
                xwriter.WriteString("");
                xwriter.WriteEndElement();
                xwriter.WriteStartElement("Pin");
                xwriter.WriteString("");
                xwriter.WriteEndElement();
                xwriter.WriteStartElement("Balance");
                xwriter.WriteString("0");
                xwriter.WriteEndElement();
                xwriter.WriteEndElement();
                xwriter.Close();
            }

        }
    }
}
