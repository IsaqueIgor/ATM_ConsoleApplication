using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

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

        public void CreateAccount(string name, int account, int pin, decimal balance)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Endereco);

            XmlNode Account = doc.CreateElement("Account");

            XmlNode Name = doc.CreateElement("Name");
            Name.InnerText = name;
            Account.AppendChild(Name);

            XmlNode AccountNumber = doc.CreateElement("AccountNumber");
            AccountNumber.InnerText = account.ToString();
            Account.AppendChild(AccountNumber);

            XmlNode Pin = doc.CreateElement("Pin");
            Pin.InnerText = pin.ToString() ;
            Account.AppendChild(Pin);

            XmlNode Balance = doc.CreateElement("Balance");
            Balance.InnerText = balance.ToString();
            Account.AppendChild(Balance);

            doc.DocumentElement.AppendChild(Account);

            doc.Save(Endereco);
        }

        public void SaveBalance(int account, Decimal balance)
        {
            var xDoc = XDocument.Load(Endereco);
            var node = xDoc.Descendants("Bank").FirstOrDefault(us => us.Element("Account").Value == account.ToString());

            if (node == null)
            {
                Console.WriteLine("Account not Found!");
                xDoc.Save(Endereco);
            }
            else
            {
                node.SetElementValue("Balance", balance);
            }

            xDoc.Save(Endereco);
        }

        private void CreateXML()
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
