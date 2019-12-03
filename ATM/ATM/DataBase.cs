using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace ATM
{
    public class DataBase
    {
        private readonly string Endereco = "C:\\Users\\Isaque\\Desktop\\UCL\\UCL.Xml";
        XmlSerializer xs;
        List<BankAccount> account_list;

        public DataBase()
        {
            CreateXML();
            account_list = new List<BankAccount>();
            xs = new XmlSerializer(typeof(List<BankAccount>));
        }

        public void CreateAccount(BankAccount account)
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

        public void SaveBalance(int account, Decimal balance)
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

        public decimal CheckBalance(int account)
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

        private void CreateXML()
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
