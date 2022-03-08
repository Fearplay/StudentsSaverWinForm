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
            StartPosition = FormStartPosition.CenterScreen;
        }

      

        private void xmlButton_Click(object sender, EventArgs e) 
        {
            this.Hide();
            XmlForm xmlForm = new XmlForm(this);
            xmlForm.ShowDialog(); 
            this.Close();
        }

        

        private void textButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            TextForm textForm = new TextForm(this);
            textForm.ShowDialog();
            this.Close();
        }
    }
}
