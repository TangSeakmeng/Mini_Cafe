using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Cafe__Be_in_One_
{
    public partial class EditDrink : Form
    {
        public bool isCancel = true;

        public EditDrink(Drink d)
        {
            InitializeComponent();

            tbCode.Text = d.code;
            tbtName.Text = d.name;
            tbNote.Text = d.note;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Edit Success");
            isCancel = false;
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            isCancel = true;
            this.Close();
        }
    }
}
