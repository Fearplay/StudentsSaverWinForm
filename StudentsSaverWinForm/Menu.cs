using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsSaverWinForm
{
    public partial class Menu : Form
    {

        private Form CallingForm = null;
        public Menu(Form callingForm) : this()
        {
            this.CallingForm = callingForm;
        }
        public Menu()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;//Zařídí aby se okno načetlo uprostřed
        }

      

        private void xmlButton_Click(object sender, EventArgs e) //metoda pro kliknutí na xml button
        {
            this.Hide();//menu se skryje
            XmlForm xmlForm = new XmlForm(this);//vytvoří se xmlForm
            xmlForm.ShowDialog(); //objeví se xmlForm
            this.Close();//menu se zavře
        }

        

        private void textButton_Click(object sender, EventArgs e)
        {
            this.Hide();//menu se skryje
            TextForm textForm = new TextForm(this);//vytvoří se textForm
            textForm.ShowDialog();//objeví se textForm
            this.Close();//menu se zavře
        }
    }
}
