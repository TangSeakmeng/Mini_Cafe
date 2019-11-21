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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        async Task<string> GetToken(string userName, string passWord)
        {
            var pairs = new List<KeyValuePair<string, string>>
                    {

                        new KeyValuePair<string, string>( "email", userName ),
                        new KeyValuePair<string, string> ( "password", passWord )
                    };
            var content = new FormUrlEncodedContent(pairs);
            string res;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://3.13.30.90/");
                var response = await client.PostAsync("api/api_login", content);
                res = await response.Content.ReadAsStringAsync();
                string contentType = response.Content.Headers.GetValues("Content-Type").First();
                if (contentType != "application/json") return null;


            }

            Debug.WriteLine(res);
            return res;
        }

        private async void Login_Click(object sender, EventArgs e)
        {
            string username = email.Text;
            string Password = password.Text;
            if (await GetToken(username, Password) == null)
            {
                MessageBox.Show("\t\tEmail Or Passoword is in correct \t\t\n\n\t \t     please try again");
            }
            else
            {
                MessageBox.Show("Login Successfully", "Log In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                MainForm main = new MainForm();
                main.ShowDialog();
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
