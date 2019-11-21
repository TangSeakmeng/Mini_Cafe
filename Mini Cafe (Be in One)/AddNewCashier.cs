using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Cafe__Be_in_One_
{
    public partial class AddNewCashier : Form
    {
        public AddNewCashier()
        {
            InitializeComponent();
        }

        async Task AddCashier(string first_name, string last_name, string email, string password, string password_confirmation)
        {
            var pair = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("first_name", first_name),
                new KeyValuePair<string, string>("last_name", last_name),
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("password_confirmation", password_confirmation),
            };
            var content = new FormUrlEncodedContent(pair);
            string res;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://3.13.30.90/");
                var response = await client.PostAsync("api/cashier/store?api_token=Oq5CAKdgG1KPwbL0ynX1d938ZCHMe5B7KBVvSe55PKmXK0NpufpWOyNSrWzF", content);
                res = await response.Content.ReadAsStringAsync();
            }

            Debug.WriteLine(res);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void buttonOk_Click(object sender, EventArgs e)
        {
            string first_name = textBox1.Text;
            string last_name = textBox2.Text;
            string email = textBox3.Text;
            string password = textBox4.Text;
            string password_confirmation = textBox6.Text;

            buttonOk.Enabled = false;
            await AddCashier(first_name, last_name, email, password, password_confirmation);
            buttonOk.Enabled = true;

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(opnfd.FileName);
            }
        }
    }
}
