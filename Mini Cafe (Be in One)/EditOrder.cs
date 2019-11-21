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
    public partial class EditOrder : Form
    {
        public EditOrder()
        {
            InitializeComponent();

            cbbSugar.SelectedIndex = 0;
            cbbZone.SelectedIndex = 0;

            isOrder = false;
        }

        public EditOrder(string size, int qty, string cream, string sugar_level, string zone)
        {
            InitializeComponent();

            if (size == "Regular")
            {
                rdbRegular.Checked = true;
            }
            else if (size == "Large")
            {
                rdbLarge.Checked = true;
            }

            nudQuantity.Value = qty;

            if (cream == "Yes")
            {
                ckbCream.Checked = true;
            }
            else
            {
                ckbCream.Checked = false;
            }

            cbbSugar.SelectedItem = sugar_level;
            cbbZone.SelectedItem = zone;
        }

        private void EditOrder_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        public bool getRegularOrLarge()
        {
            return regularOrLarge;
        }

        public bool getCream()
        {
            return cream;
        }

        public string getSugar_Level()
        {
            return sugar_level;
        }

        public string getZone()
        {
            return zone;
        }

        public int getQuantity()
        {
            return quantity;
        }

        private bool regularOrLarge;
        private bool cream;
        private string sugar_level;
        private string zone;
        private int quantity;

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rdbRegular.Checked == true)
                regularOrLarge = true;
            else if (rdbLarge.Checked == true)
                regularOrLarge = false;

            if (ckbCream.Checked == true)
                cream = true;
            else
                cream = false;

            sugar_level = cbbSugar.SelectedItem.ToString();
            zone = cbbZone.SelectedItem.ToString();
            quantity = int.Parse(nudQuantity.Value.ToString());

            this.Dispose();

            isOrder = true;
        }

        private bool isOrder;

        public bool getIsOrder()
        {
            return isOrder;
        }
    }
}
