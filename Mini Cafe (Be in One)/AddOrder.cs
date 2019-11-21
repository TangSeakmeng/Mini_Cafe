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
    public partial class AddOrder : Form
    {
        bool isDineIn = false, isTakeAway = false;

        public AddOrder()
        {
            InitializeComponent();
        }

        private void DineInRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            isDineIn = true;
            isTakeAway = false;
        }

        private void TakeAwayRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            isTakeAway = true;
            isDineIn = false;
        }

        private void btnAddOrders_Click(object sender, EventArgs e)
        {
            if (isDineIn)
            {
                DialogResult = DialogResult.OK;
            }
            else if (isTakeAway)
            {
                DialogResult = DialogResult.No;
            }
            //DialogResult = DialogResult.OK;

            ChooseOrder choose = new ChooseOrder();
            choose.ShowDialog();
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            TableSelection table = new TableSelection();
            table.ShowDialog();
        }
    }
}
