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

namespace StudentsSaverWinForm
{
    public partial class TextForm : Form
    {
        /*
         * většina komentářů je stejná jak pro TextForm tak i pro XmlForm, a proto všechno nevypisuji znovu
         * přeci jen programátoři si snaží ulehčit svou práci.
         */

        String nazev;
        Person person;//vytváříme proměnnou pro třídu Person
        List<String> oborList;
        private Form CallingForm = null;
        public TextForm(Form callingForm) : this() //konstruktor pro fungování přehazování forms
        {
            this.CallingForm = callingForm;
        }
        public TextForm()
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
            StartPosition = FormStartPosition.CenterScreen;//Zařídí aby se okno načetlo uprostřed
        }

        private void createFileInFile()//metoda pro vytvoření soubor
        {
            StreamWriter sw = new StreamWriter($"{nazev}.txt"); //vytvoříme náš soubor s txt příponou
            sw.Write("Jméno: " + person.Name + ", ");//vypíšeme do toho souboru jmén, které jsme zadali
            sw.Write("Příjmení: " + person.Prijmeni + ", ");
            sw.Write("Věk: " + person.Vek + ", ");
            sw.Write("Obor: " + person.Obor + " ");
            sw.Write("\n"); //odřádkování hodí nás to na nový řádek
            sw.Close(); //důležité uzavře náš soubor
        }
        private void saveTextFile()//metoda pro uložení souboru
        {
            StreamWriter sw = new StreamWriter($"{nazev}.txt", true);//true značí, že chceme append tedy přidat
            sw.Write("Jméno: " + person.Name + ", "); //naše jméno
            sw.Write("Příjmení: " + person.Prijmeni + ", ");
            sw.Write("Věk: " + person.Vek + ", ");
            sw.Write("Obor: " + person.Obor + " ");
            sw.Write("\n");
            sw.Close();//zase uzavře
        }
        private void loadTextFile() //metoda pro načítání souboru
        {
            try//máme ve vyjímce pro případ, že by soubor neexistoval
            {
                nazev = nazevTextBox.Text;
                StreamReader sr = new StreamReader($"{nazev}.txt");//čteme z našeho souboru
                vysledekTextBox.Text = sr.ReadToEnd();//vypisujeme do našeho text boxu vše co je v sr až do konce
                sr.Close();//uzavřeme
            }
            catch (Exception)//odchycení
            {
                MessageBox.Show("Soubor neexistuje!"); //vypisování chybové hlášky
            }
        }

        private void createTextFile() //metoda pro zjištování jestli uložit nebo vytvořit soubor
        {

            if (!File.Exists($"{nazev}.txt"))//pokud soubor s názvem neexistuje
            {
                createFileInFile(); //vytvoříme ho
            }
            else//pokud existuje
            {
                saveTextFile();//uložíme ho
            }
        }

        private void createButton_Click(object sender, EventArgs e) //metoda pro kliknutí na create/save button
        {
            try//odchycení výjimky pro vek
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
                    createTextFile();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vyplňte věk!");
            }
        }

        private void loadButton_Click(object sender, EventArgs e) //metoda pro load button
        {
            loadTextFile();


        }
        private void menuButton_Click(object sender, EventArgs e)//menu
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

