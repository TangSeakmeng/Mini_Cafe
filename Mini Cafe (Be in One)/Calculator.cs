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
    public partial class Calculator : Form
    {
        public double Total { get; set; } = 10.5;
        double i = 0;

        public Calculator()
        {
            InitializeComponent();
        }

        public Calculator(double total)
        {
            InitializeComponent();

            Total = total;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            i = Convert.ToDouble(textBox_Result.Text);
            double z = i - Total;
            label4.Text = ($"{"$ " + z} ");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBox_Result.Text != string.Empty)
            {
                int txtlength = textBox_Result.Text.Length;
                if (txtlength != 1)

                {
                    textBox_Result.Text = textBox_Result.Text.Remove(txtlength - 1);
                }
                else
                {
                    textBox_Result.Text = ("0.00").ToString();
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            MainForm main = new MainForm();
            main.ShowDialog();
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0.00";
            label4.Text = null;
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            label2.Text = Total.ToString("$#,##0.00");
            this.CenterToScreen();
        }

        private void btn1_click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0.00")
                textBox_Result.Clear();
            Button button = (Button)sender;
            textBox_Result.Text = textBox_Result.Text + button.Text;

        }

        private void textBox_Result_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
