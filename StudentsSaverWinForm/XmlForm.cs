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
        List<String> oborList; //proměnná pro Stringovskej list

        private Form CallingForm = null;
        public XmlForm(Form callingForm) : this()
        {
            this.CallingForm = callingForm;
        }

        public XmlForm()
        {
            InitializeComponent();
            person = new Person();
            oborList = new List<String>(); //inicializování proměnný
            oborList.Add("INFO"); //přidávání možností pro Obor do našeho listu
            oborList.Add("info");
            oborList.Add("Informatika");
            oborList.Add("INFORMATIKA");
            oborList.Add("informatika");
            oborList.Add("Systémové inženýrství");
            oborList.Add("Systemove inzenyrstvi");
            oborList.Add("SI");
            oborList.Add("si");
            StartPosition = FormStartPosition.CenterScreen; //Zařídí aby se okno načetlo uprostřed



        }

        private void saveFile() //metoda pro uložení souboru
        {

            XDocument xDocument = XDocument.Load($"{nazev}.xml"); //načte dokument s naším názvem
            XElement root = xDocument.Element("Škola"); //vytvoří se root, který je nejvyšší s názvem škola a do toho rooto se budou ukládat naše ostatní elementy, které vytvoříme
            IEnumerable<XElement> rows = root.Descendants("Student"); //do proměnné rows uložíme potomky pod naším rootem s názvem Student
            XElement firstRow = rows.First(); //do firstRow se uloží první řádek


            firstRow.AddBeforeSelf( //do prvního řádku budeme ukládat vždy to první a to starší půjde pod to novější
           new XElement("Student",//nový element s názvem potomka
           new XElement("Jméno", person.Name), //nový element String, ve kterým se objeví námi vypsané jméno
           new XElement("Příjmení", person.Prijmeni), // --||-- (jen místo jména příjmení atd..)
           new XElement("Věk", "" + person.Vek),
           new XElement("Obor", person.Obor)));
            xDocument.Save($"{nazev}.xml"); //document se uloží s naším názvem
        }

        private void createFileInCreate() //metoda pro vytvoření nového xml souboru
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings(); //uložíme XmlWriterSettings, ve kterým můžeme upravovat preference
            xmlWriterSettings.Indent = true; //odrážky se nastaví na true, takže v souboru budou odrážky
            xmlWriterSettings.NewLineOnAttributes = true; //Atribut bude na novém řádku
            using (XmlWriter xmlWriter = XmlWriter.Create($"{nazev}.xml", xmlWriterSettings)) //vytvoříme nový xml soubour s naším názvem a s našema preferencema
            {
                xmlWriter.WriteStartDocument();//začnememe psát Document '<?xml version="1.0" encoding="UTF-8"?>'
                xmlWriter.WriteStartElement("Škola"); //Vytvoříme začátečnický element s názvem Škola
                xmlWriter.WriteStartElement("Student"); //potomek s názvem Student
                xmlWriter.WriteElementString("Jméno", person.Name); //začátečnický Element se jménem, který jsme zvolili
                xmlWriter.WriteElementString("Příjmení", person.Prijmeni);
                xmlWriter.WriteElementString("Věk", "" + person.Vek);
                xmlWriter.WriteElementString("Obor", person.Obor);
                xmlWriter.WriteEndElement();//vypíšeme do dokumentu </Student>
                xmlWriter.WriteEndElement();//vypíšeme do dokumentu </Škola>
                xmlWriter.WriteEndDocument();//Ukončujeme náš dokument
                xmlWriter.Flush();//podobné close je to tu jen pro případ, ale nemusí to tu být
                xmlWriter.Close();//nejdůležitější musíme uzavřít jinak by se vyhodila chyba
            }
        }

        private void createFile() //metoda vytvoření souboru
        {


            if (File.Exists($"{nazev}.xml") == false) //pokud neexistuje soubor v naší 'cestě'  (nemusí být false může bát jen '!')
            {
                createFileInCreate(); //vytvoří se soubour
            }
            else //pokud existuje
            {
                saveFile(); //pouze se soubor uloží takže se jen připísou hodnoty
            }


        }

        private void loadFile() // metoda pro načítání souboru
        {



            try//blok ve kterým hlídáme naše chyby
            {
                nazev = nazevTextBox.Text; // sem vkládáme název souboru pro případ, že uživatel napíše pouze jméno souboru a dá load
                DataSet ds = new DataSet(); //vytvoříme dataSet

                ds.ReadXml($"{nazev}.xml"); //do toho přidáme čtení našeho xml souboru

                vysledekView.DataSource = ds.Tables[0];//vypíšeme následně do našeho dataGridView
            }
            catch (Exception) //ohlídá chyby
            {

                MessageBox.Show("Soubor nenalezen!"); //pokud bude chyba na straně load vypíše se 'soubor nenalezen!'
            }

        }

        private void createSaveButton_Click(object sender, EventArgs e)//metoda po kliknutí na create/save button
        {

            try //blok vyjímky
            {
                person.Name = jmenoTextBox.Text; //ukládáme do person.Name náš text, který vypisujeme do textboxu s jménem
                person.Prijmeni = prijmeniTextBox.Text;
                person.Vek = int.Parse(vekTextBox.Text);
                person.Obor = oborTextBox.Text;
                nazev = nazevTextBox.Text;
                if (String.IsNullOrEmpty(jmenoTextBox.Text)) //pokud náš textBox do kterýho píšeme jméno bude prrázdný nebo null ak se vypíše chybová hláška
                {
                    MessageBox.Show("Vyplňte jméno!");
                }
                else if (String.IsNullOrEmpty(prijmeniTextBox.Text)) //můžeme napsat klidně person.Prijmeni
                {
                    MessageBox.Show("Vyplňte příjmení!");//vypíše se pokud podmínka bude splněna
                }
                else if (String.IsNullOrEmpty(oborTextBox.Text))
                {
                    MessageBox.Show("Vyplňte obor!");
                }
                else if (String.IsNullOrEmpty(nazev))
                {
                    MessageBox.Show("Vyplňte název souboru!");
                }
                else if (person.Vek < 18 || person.Vek > 100) //pokud věk bude menší než 18 nebo větší než 100 
                {
                    MessageBox.Show("Věk lze od 18 do 100");//vypíše se chybová hláška
                }
                else if (!oborList.Contains(person.Obor)) //pokud náš List s oborama neobsahuje to co napíšeme do obor text boxu 
                {
                    MessageBox.Show("Na výběr je pouze Informatika nebo Systémové inženýrství!");//vypíše se chybová hláška
                }
                else//pokud není jiný problém
                {
                    createFile();//vytvoří se náš soubor
                }
            }
            catch (Exception)//pokud věk nebude vyplněný vypíše tuto chybovou hlášku
            {
                MessageBox.Show("Vyplňte věk!");
            }
        }

        private void loadButton_Click(object sender, EventArgs e) //metoda pro kliknutí na load button
        {

            loadFile(); //načte se soubor
        }
        private void menuButton_Click(object sender, EventArgs e) //metoda pro kliknutí na menu button
        {
            this.Hide();//schová se tento form
            Menu menu = new Menu(this);//vytvoří se nová form s názvem Menu
            menu.ShowDialog();//objeví se menu
            this.Close();//tato forma se uzavře
        }

        private void nazevTextBox_KeyPress(object sender, KeyPressEventArgs e) //metoda po té co v našem název text boxu zmáčkneme klávesovou zkratku
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back); //pokud naše klávesa není písmeno tak nám to nic nenapíše
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
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);//toto nám nedovolí psát nic jiného než čísla
        }

        private void oborTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }


    }
}
