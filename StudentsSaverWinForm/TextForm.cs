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
      

        String nazev;
        Person person;
        List<String> oborList;
        private Form CallingForm = null;
        public TextForm(Form callingForm) : this() 
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
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void createFileInFile()
        {
            StreamWriter sw = new StreamWriter($"{nazev}.txt"); 
            sw.Write("Jméno: " + person.Name + ", ");
            sw.Write("Příjmení: " + person.Prijmeni + ", ");
            sw.Write("Věk: " + person.Vek + ", ");
            sw.Write("Obor: " + person.Obor + " ");
            sw.Write("\n"); 
            sw.Close(); 
        }
        private void saveTextFile()
        {
            StreamWriter sw = new StreamWriter($"{nazev}.txt", true);
            sw.Write("Jméno: " + person.Name + ", "); 
            sw.Write("Příjmení: " + person.Prijmeni + ", ");
            sw.Write("Věk: " + person.Vek + ", ");
            sw.Write("Obor: " + person.Obor + " ");
            sw.Write("\n");
            sw.Close();
        }
        private void loadTextFile()
        {
            try
            {
                nazev = nazevTextBox.Text;
                StreamReader sr = new StreamReader($"{nazev}.txt");
                vysledekTextBox.Text = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Soubor neexistuje!"); 
            }
        }

        private void createTextFile() 
        {

            if (!File.Exists($"{nazev}.txt"))
            {
                createFileInFile(); 
            }
            else
            {
                saveTextFile();
            }
        }

        private void createButton_Click(object sender, EventArgs e) 
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
                    createTextFile();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vyplňte věk!");
            }
        }

        private void loadButton_Click(object sender, EventArgs e) 
        {
            loadTextFile();


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

