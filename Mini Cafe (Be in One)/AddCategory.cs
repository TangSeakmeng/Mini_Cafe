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
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        async Task AddCat(string note, string name)
        {

            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>( "note",note),
                new KeyValuePair<string, string> ( "name", name )
            };
            var content = new FormUrlEncodedContent(pairs);
            string res;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://3.13.30.90/");
                var response = await client.PostAsync("api/category/store?api_token=Oq5CAKdgG1KPwbL0ynX1d938ZCHMe5B7KBVvSe55PKmXK0NpufpWOyNSrWzF", content);
                res = await response.Content.ReadAsStringAsync();
            }

            Debug.WriteLine(res);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string note = textBox1.Text;
            string name = textBox2.Text;
            button1.Enabled = false;
            await AddCat(note, name);
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            MainForm main = new MainForm();
            main.ShowDialog();
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
