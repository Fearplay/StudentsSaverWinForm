using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace StudentsSaverWinForm
{
    public partial class XmlForm : Form
    {

        Person person;
        String nazev;
        List<String> oborList; 

        private Form CallingForm = null;
        public XmlForm(Form callingForm) : this()
        {
            this.CallingForm = callingForm;
        }

        public XmlForm()
        {
            InitializeComponent();
            person = new Person();
            oborList = new List<String>(); 
            oborList.Add("INFO"); 
            oborList.Add("info");
            oborList.Add("Informatika");
            oborList.Add("INFORMATIKA");
            oborList.Add("informatika");
            oborList.Add("Systémové inženýrství");
            oborList.Add("Systemove inzenyrstvi");
            oborList.Add("SI");
            oborList.Add("si");
            StartPosition = FormStartPosition.CenterScreen;


        }

        private void saveFile() 
        {

            XDocument xDocument = XDocument.Load($"{nazev}.xml"); 
            XElement root = xDocument.Element("Škola"); 
            IEnumerable<XElement> rows = root.Descendants("Student"); 
            XElement firstRow = rows.First(); 


            firstRow.AddBeforeSelf( 
           new XElement("Student",
           new XElement("Jméno", person.Name), 
           new XElement("Příjmení", person.Prijmeni), 
           new XElement("Věk", "" + person.Vek),
           new XElement("Obor", person.Obor)));
            xDocument.Save($"{nazev}.xml"); 
        }

        private void createFileInCreate()
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings(); 
            xmlWriterSettings.Indent = true; 
            xmlWriterSettings.NewLineOnAttributes = true; 
            using (XmlWriter xmlWriter = XmlWriter.Create($"{nazev}.xml", xmlWriterSettings)) 
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Škola"); 
                xmlWriter.WriteStartElement("Student"); 
                xmlWriter.WriteElementString("Jméno", person.Name); 
                xmlWriter.WriteElementString("Příjmení", person.Prijmeni);
                xmlWriter.WriteElementString("Věk", "" + person.Vek);
                xmlWriter.WriteElementString("Obor", person.Obor);
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Flush();
                xmlWriter.Close();
            }
        }

        private void createFile() 
        {


            if (File.Exists($"{nazev}.xml") == false) 
            {
                createFileInCreate(); 
            }
            else 
            {
                saveFile(); 
            }


        }

        private void loadFile()
        {



            try
            {
                nazev = nazevTextBox.Text; 
                DataSet ds = new DataSet(); 

                ds.ReadXml($"{nazev}.xml"); 

                vysledekView.DataSource = ds.Tables[0];
            }
            catch (Exception) 
            {

                MessageBox.Show("Soubor nenalezen!"); 
            }

        }

        private void createSaveButton_Click(object sender, EventArgs e)
        {

            try 
            {
                person.Name = jmenoTextBox.Text; 
                person.Prijmeni = prijmeniTextBox.Text;
                person.Vek = int.Parse(vekTextBox.Text);
                person.Obor = oborTextBox.Text;
                nazev = nazevTextBox.Text;
                if (String.IsNullOrEmpty(jmenoTextBox.Text)) 
                {
                    MessageBox.Show("Vyplňte jméno!");
                }
                else if (String.IsNullOrEmpty(prijmeniTextBox.Text)) 
                {
                    MessageBox.Show("Vyplňte příjmení!");
                }
                else if (String.IsNullOrEmpty(oborTextBox.Text))
                {
                    MessageBox.Show("Vyplňte obor!");
                }
                else if (String.IsNullOrEmpty(nazev))
                {
                    MessageBox.Show("Vyplňte název souboru!");
                }
                else if (person.Vek < 18 || person.Vek > 100) 
                {
                    MessageBox.Show("Věk lze od 18 do 100");
                }
                else if (!oborList.Contains(person.Obor)) 
                {
                    MessageBox.Show("Na výběr je pouze Informatika nebo Systémové inženýrství!");
                }
                else
                {
                    createFile();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vyplňte věk!");
            }
        }

        private void loadButton_Click(object sender, EventArgs e) 
        {

            loadFile(); 
        }
        private void menuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu(this);
            menu.ShowDialog();
            this.Close();
        }

        private void nazevTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back); 
        }


        private void jmenoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void prijmeniTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        private void vekTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void oborTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }


    }
}
