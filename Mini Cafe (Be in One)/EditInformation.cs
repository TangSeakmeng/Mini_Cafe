using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Cafe__Be_in_One_
{
    public partial class EditInformation : Form
    {
        public EditInformation()
        {
            InitializeComponent();

            

            ucCashiers cashierUC = new ucCashiers(listCashier);
            panel1.Controls.Clear();
            panel1.Controls.Add(cashierUC);
        }

        private void EditInformation_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            EditInformation editInformation = new EditInformation();
            editInformation.ShowDialog();
        }

        static HttpClient client = new HttpClient();
        static HttpClient client1 = new HttpClient();
        static List<Cashier> listCashier = new List<Cashier>();
        static List<Drink> listDrink = new List<Drink>();
        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://3.13.30.90/");
            string path = "api/cashier?api_token=Oq5CAKdgG1KPwbL0ynX1d938ZCHMe5B7KBVvSe55PKmXK0NpufpWOyNSrWzF";
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {

                var abc = await response.Content.ReadAsStringAsync();
                var l = JsonConvert.DeserializeObject<List<Cashier>>(abc);
                foreach (var temp in l)
                {
                    Cashier cashier = new Cashier();
                    cashier.full_name = temp.full_name;
                    cashier.email = temp.email;
                    cashier.first_name = temp.first_name;
                    cashier.last_name = temp.last_name;
                    cashier.last_login_ip = temp.last_login_ip;
                    cashier.created_at = temp.created_at;
                    cashier.id = temp.id;
                    listCashier.Add(cashier);
                }
            }
            client1.BaseAddress = new Uri("http://3.13.30.90/");
            string path1 = "api/product?api_token=Oq5CAKdgG1KPwbL0ynX1d938ZCHMe5B7KBVvSe55PKmXK0NpufpWOyNSrWzF";
            HttpResponseMessage response1 = await client1.GetAsync(path1);

            if (response1.IsSuccessStatusCode)
            {
                var abc1 = await response1.Content.ReadAsStringAsync();
                var l1 = JsonConvert.DeserializeObject<List<Drink>>(abc1);
                foreach (var a in l1)
                {
                    Drink drink = new Drink();
                    drink.id = a.id;
                    drink.code = a.code;
                    drink.name = a.name;
                    drink.image = a.image;
                    drink.note = a.note;
                    drink.updated_at = a.updated_at;
                    listDrink.Add(drink);
                }
            }
        }
        private void BtCashier_Click(object sender, EventArgs e)
        {
            RunAsync();
            label2.Text = "Cashier information";
            ucCashiers cashierUC = new ucCashiers(listCashier);
            panel1.Controls.Clear();
            int n = 0;
            for (int i = 1; i <= listCashier.Count; i++)
            {
                n = cashierUC.dgvCashier.Rows.Add();
                cashierUC.dgvCashier.Rows[n].Cells[0].Value = i;
                cashierUC.dgvCashier.Rows[n].Cells[1].Value = listCashier[i - 1].full_name;
                cashierUC.dgvCashier.Rows[n].Cells[2].Value = listCashier[i - 1].email;

            }
            panel1.Controls.Add(cashierUC);
        }

        private void BtDrinks_Click(object sender, EventArgs e)
        {
            RunAsync();
            label2.Text = "Drink information";
            ucDrinks ucDrinks = new ucDrinks(listDrink);
            panel1.Controls.Clear();
            int n = 0;
            for (int i = 1; i <= listDrink.Count; i++)
            {
                n = ucDrinks.dgvDrink.Rows.Add();
                ucDrinks.dgvDrink.Rows[n].Cells[0].Value = i;
                ucDrinks.dgvDrink.Rows[n].Cells[1].Value = listDrink[i - 1].code;
                ucDrinks.dgvDrink.Rows[n].Cells[2].Value = listDrink[i - 1].name;
                ucDrinks.dgvDrink.Rows[n].Cells[3].Value = i;
            }
            panel1.Controls.Add(ucDrinks);
        }
    }
}
