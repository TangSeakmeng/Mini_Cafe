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
    enum Status { Availble, Unavailble, TakeAway }
    enum Pay { Paid, UnPaid }

    public partial class TableSelection : Form
    {
        MyButton[] tableButtons = new MyButton[25];

        public TableSelection()
        {
            InitializeComponent();

            tableButtons[0] = new MyButton(ref btnSeat1);
            tableButtons[1] = new MyButton(ref btnSeat2);
            tableButtons[2] = new MyButton(ref btnSeat3);
            tableButtons[3] = new MyButton(ref btnSeat4);
            tableButtons[4] = new MyButton(ref btnSeat5);
            tableButtons[5] = new MyButton(ref btnSeat6);
            tableButtons[6] = new MyButton(ref btnSeat7);
            tableButtons[7] = new MyButton(ref btnSeat8);
            tableButtons[8] = new MyButton(ref btnSeat9);
            tableButtons[9] = new MyButton(ref btnSeat10);
            tableButtons[10] = new MyButton(ref btnSeat11);
            tableButtons[11] = new MyButton(ref btnSeat12);
            tableButtons[12] = new MyButton(ref btnSeat13);
            tableButtons[13] = new MyButton(ref btnSeat14);
            tableButtons[14] = new MyButton(ref btnSeat15);
            tableButtons[15] = new MyButton(ref btnSeat16);
            tableButtons[16] = new MyButton(ref btnSeat17);
            tableButtons[17] = new MyButton(ref btnSeat18);
            tableButtons[18] = new MyButton(ref btnSeat19);
            tableButtons[19] = new MyButton(ref btnSeat20);
            tableButtons[20] = new MyButton(ref btnSeat21);
            tableButtons[21] = new MyButton(ref btnSeat22);
            tableButtons[22] = new MyButton(ref btnSeat23);
            tableButtons[23] = new MyButton(ref btnSeat24);
            tableButtons[24] = new MyButton(ref btnSeat25);
        }

        private void btnSeat_Click(object sender, EventArgs e)
        {

            MyButton Table = new MyButton();
            Table.BtnTable = (Button)sender;

            if (Table.BtnTable.BackColor == Color.ForestGreen)
            {
                AddOrder addOrders = new AddOrder();
                DialogResult option = addOrders.ShowDialog(this);

                if (option == DialogResult.OK)
                {
                    //call drink selection form
                    Table.SetPayStatus((int)Status.Unavailble, (int)Pay.UnPaid);
                }
                else if (option == DialogResult.No)
                {
                    //Call drink selction form
                    Table.SetPayStatus((int)Status.TakeAway, (int)Pay.Paid);
                }
            }
            else if (Table.BtnTable.BackColor == Color.DarkSlateGray)
            {
                DialogResult pay = MessageBox.Show("Do you want to pay ?", "", MessageBoxButtons.YesNo);
                if (pay == DialogResult.Yes)
                {
                    //Call Calculate form
                    Table.SetPayStatus((int)Status.Unavailble, (int)Pay.Paid);
                }
            }
            else if (Table.BtnTable.BackColor == Color.Gold)
            {
                DialogResult pay = MessageBox.Show("Finish ?", "", MessageBoxButtons.YesNo);
                if (pay == DialogResult.Yes)
                {
                    Table.SetPayStatus((int)Status.Availble, (int)Pay.Paid);
                }
            }
            else if (Table.BtnTable.BackColor == Color.Red)
            {
                DialogResult pay = MessageBox.Show("Finish ?", "", MessageBoxButtons.YesNo);
                if (pay == DialogResult.Yes)
                {
                    Table.SetPayStatus((int)Status.Availble, (int)Pay.Paid);
                }
            }
        }

        private void btnSeat_MouseEnter(object sender, EventArgs e)
        {
            MyButton Table = new MyButton();
            Table.BtnTable = (Button)sender;
            labelTable.Text = "Table: " + Table.BtnTable.Text;

            if (Table.BtnTable.BackColor == Color.ForestGreen)
            {
                labelStatus.Text = "Status: Availble";
            }
            else if (Table.BtnTable.BackColor == Color.DarkSlateGray)
            {
                labelStatus.Text = "Status: Unavailble/UnPaid";
            }
            else if (Table.BtnTable.BackColor == Color.Gold)
            {
                labelStatus.Text = "Status: Unavailble/Paid";
            }
            else if (Table.BtnTable.BackColor == Color.Red)
            {
                labelStatus.Text = "Status: Take Away/Paid";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            MainForm main = new MainForm();
            main.ShowDialog();
        }

        private void TableSelection_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
