using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Cafe__Be_in_One_
{
    public partial class ChooseOrder : Form
    {
        UserControl1 userControl1;

        public ChooseOrder()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            client.BaseAddress = new Uri("http://3.13.30.90/");

            await RunAsyncCategory();

            btnHotDrink.Image = Properties.Resources.mocca_frappe;
            btnColdDrink.Image = Properties.Resources.mocca_frappe;
            btnFrappe.Image = Properties.Resources.mocca_frappe;
        }

        static HttpClient client = new HttpClient();

        private static List<Product> listproducts = new List<Product>();
        private static List<Category> listcategory = new List<Category>();

        //private ConcurrentDictionary<string, string> listCategory = new ConcurrentDictionary<string, string>();
        static string category_id = "";

        async Task RunAsyncCategory()
        {
            string path = "api/category?api_token=Oq5CAKdgG1KPwbL0ynX1d938ZCHMe5B7KBVvSe55PKmXK0NpufpWOyNSrWzF";
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var abc = await response.Content.ReadAsStringAsync();
                var l = JsonConvert.DeserializeObject<List<Category>>(abc);
                foreach (var temp in l)
                {
                    //listCategory[temp.id] = temp.name;

                    Category category = new Category();
                    category.id = temp.id;
                    category.name = temp.name;
                    category.image = temp.image;
                    listcategory.Add(category);

                    //MessageBox.Show(category.image);
                }
            }

            downloadImageForButton();
        }

        async Task RunAsync()
        {
            string path = "api/category/products_list/" + category_id + "?api_token=Oq5CAKdgG1KPwbL0ynX1d938ZCHMe5B7KBVvSe55PKmXK0NpufpWOyNSrWzF";
            //path = "api/category/products_list/1?api_token=Oq5CAKdgG1KPwbL0ynX1d938ZCHMe5B7KBVvSe55PKmXK0NpufpWOyNSrWzF";
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var abc = await response.Content.ReadAsStringAsync();
                var l = JsonConvert.DeserializeObject<List<Product>>(abc);
                foreach (var temp in l)
                {
                    Product product = new Product();
                    product.name = temp.name;
                    product.image = temp.image;
                    product.price = temp.price;
                    listproducts.Add(product);
                    imageList1.Images.Add(Properties.Resources.mocca_frappe);
                }
            }

            //MessageBox.Show(listproducts[0].name);

            downloadImage();
        }

        public async void downloadImage()
        {
            string url = "http://3.13.30.90";

            int imageIndex = 0;

            foreach (var temp in listproducts)
            {
                using (var wc = new WebClient())
                {
                    using (var imgStream = new MemoryStream(await wc.DownloadDataTaskAsync(url + temp.image)))
                    {
                        //imageList1.Images[imageIndex] = (Image.FromStream(imgStream));
                        UserControl1 uc = flowLayoutPanel1.Controls[imageIndex] as UserControl1;
                        uc.pictureBoxImage.Image = Image.FromStream(imgStream);
                        imageIndex++;

                        break;
                    }
                }
            }

            //pictureBox1.Image = listImage[0];
            //MessageBox.Show(listproducts[0].name);
            //MessageBox.Show(url + listproducts[0].image);
        }

        public async void downloadImageForButton()
        {
            string url = "http://3.13.30.90";

            foreach (var temp in listcategory)
            {
                using (var wc = new WebClient())
                {
                    if (temp.image != "" && temp.image != null)
                    {
                        using (var imgStream = new MemoryStream(await wc.DownloadDataTaskAsync(url + temp.image)))
                        {
                            imageList2.Images.Add(Image.FromStream(imgStream));
                        }
                    }
                }
            }

            btnHotDrink.Image = imageList2.Images[0];
            btnColdDrink.Image = imageList2.Images[1];
            btnFrappe.Image = imageList2.Images[2];
        }

        private async void btnHotDrink_Click(object sender, EventArgs e)
        {
            //List<string> listCoffeeName = new List<string>() { "Espresso", "Green Tea Latte", "Caramel Latte", "Condese Milk Tea",
            //    "Flat White", "Palm Cappuccino", "Americano", "Hot Chocolatte", "Vanilla Latte", "Cappuccino"};

            //for (int index = 0; index < 10; index++)
            //{
            //    UserControl1 userControl1 = new UserControl1();

            //    userControl1.pictureBoxImage.Click += pictureBox_Click;
            //    userControl1.pictureBoxImage.Image = imageList1.Images[index];
            //    userControl1.lblImageName.Text = listCoffeeName[index];
            //    userControl1.pictureBoxImage.Tag = listCoffeeName[index] + "," + "2";

            //    flowLayoutPanel1.Controls.Add(userControl1);
            //}

            //await RunAsync();//.GetAwaiter().GetResult();

            //--------------------------------------------------------------------------------------------------------------------------------

            flowLayoutPanel1.Controls.Clear();
            listproducts.Clear();

            foreach (var temp in listcategory)
            {
                if (temp.name == "Hot drinks")
                {
                    category_id = temp.id;

                    await RunAsync();

                    for (int index = 0; index < listproducts.Count; index++)
                    {
                        userControl1 = new UserControl1();
                        userControl1.pictureBoxImage.Click += pictureBox_Click;
                        userControl1.pictureBoxImage.Image = imageList1.Images[index];
                        userControl1.lblImageName.Text = listproducts[index].name;
                        userControl1.pictureBoxImage.Tag = listproducts[index].name + "," + "2";

                        flowLayoutPanel1.Controls.Add(userControl1);
                    }

                    break;
                }
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            string[] word = pictureBox.Tag.ToString().Split(',');
            string name = word[0];
            string price = word[1];

            EditOrder editOrder = new EditOrder();
            DialogResult dialog = editOrder.ShowDialog();

            if (editOrder.getIsOrder() == true)
            {
                string size = "";

                if (editOrder.getRegularOrLarge() == true)
                {
                    size = "Regular";
                }
                else
                {
                    size = "Large";
                }

                string cream = "";

                if (editOrder.getCream() == true)
                {
                    cream = "Yes";
                }
                else
                {
                    cream = "No";
                }

                string sugar_level = editOrder.getSugar_Level();
                string zone = editOrder.getZone();
                int quantity = editOrder.getQuantity();

                int no = dgvOrder.Rows.Count;
                no++;

                dgvOrder.Rows.Add(no, name, size, sugar_level, cream, quantity.ToString(), price, zone);

                lblTotalAmount.Text = getTotalAmount().ToString();
            }
        }

        private double getTotalAmount()
        {
            double total = 0;

            for (int index = 0; index < dgvOrder.Rows.Count; index++)
            {
                int quantity = int.Parse(dgvOrder.Rows[index].Cells[5].Value.ToString());
                double price = double.Parse(dgvOrder.Rows[index].Cells[6].Value.ToString());

                total += quantity * price;
            }

            return total;
        }

        private async void btnColdDrink_Click(object sender, EventArgs e)
        {
            //await RunAsyncCategory("Cool drinks");

            flowLayoutPanel1.Controls.Clear();
            listproducts.Clear();

            foreach (var temp in listcategory)
            {
                if (temp.name == "Cool drinks")
                {
                    category_id = temp.id;

                    await RunAsync();

                    for (int index = 0; index < listproducts.Count; index++)
                    {
                        UserControl1 userControl1 = new UserControl1();

                        userControl1.pictureBoxImage.Click += pictureBox_Click;
                        userControl1.pictureBoxImage.Image = imageList1.Images[index];
                        userControl1.lblImageName.Text = listproducts[index].name;
                        userControl1.pictureBoxImage.Tag = listproducts[index].name + "," + "2";

                        flowLayoutPanel1.Controls.Add(userControl1);
                    }

                    break;
                }
            }
        }

        private async void btnFrappe_Click(object sender, EventArgs e)
        {
            //RunAsync("Frappe").GetAwaiter().GetResult();

            flowLayoutPanel1.Controls.Clear();
            listproducts.Clear();

            foreach (var temp in listcategory)
            {
                if (temp.name == "Frappe")
                {
                    category_id = temp.id;

                    await RunAsync();

                    for (int index = 0; index < listproducts.Count; index++)
                    {
                        UserControl1 userControl1 = new UserControl1();

                        userControl1.pictureBoxImage.Click += pictureBox_Click;
                        userControl1.pictureBoxImage.Image = imageList1.Images[index];
                        userControl1.lblImageName.Text = listproducts[index].name;
                        userControl1.pictureBoxImage.Tag = listproducts[index].name + "," + "2";

                        flowLayoutPanel1.Controls.Add(userControl1);
                    }

                    break;
                }
            }
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            int edit_IndexColumn = 8;
            int remove_IndexColumn = 9;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == edit_IndexColumn)
                {
                    string size = dgvOrder.Rows[dgvRowIndex].Cells[2].Value.ToString();
                    int quantity = int.Parse(dgvOrder.Rows[dgvRowIndex].Cells[5].Value.ToString());
                    string cream = dgvOrder.Rows[dgvRowIndex].Cells[4].Value.ToString();
                    string sugar_level = dgvOrder.Rows[dgvRowIndex].Cells[3].Value.ToString();
                    string zone = dgvOrder.Rows[dgvRowIndex].Cells[7].Value.ToString();

                    EditOrder editOrder = new EditOrder(size, quantity, cream, sugar_level, zone);
                    editOrder.ShowDialog();

                    if (editOrder.getRegularOrLarge() == true)
                    {
                        size = "Regular";
                    }
                    else
                    {
                        size = "Large";
                    }

                    if (editOrder.getCream() == true)
                    {
                        cream = "Yes";
                    }
                    else
                    {
                        cream = "No";
                    }

                    sugar_level = editOrder.getSugar_Level();
                    zone = editOrder.getZone();
                    quantity = editOrder.getQuantity();

                    dgvOrder.Rows[dgvRowIndex].Cells[2].Value = size;
                    dgvOrder.Rows[dgvRowIndex].Cells[5].Value = quantity.ToString();
                    dgvOrder.Rows[dgvRowIndex].Cells[4].Value = cream;
                    dgvOrder.Rows[dgvRowIndex].Cells[3].Value = sugar_level;
                    dgvOrder.Rows[dgvRowIndex].Cells[7].Value = zone;
                }
                else if (e.ColumnIndex == remove_IndexColumn)
                {
                    DialogResult dialogResult = MessageBox.Show("Are You Sure that You Want To Delete?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        dgvOrder.Rows.RemoveAt(dgvRowIndex);
                    }
                }
            }

            lblTotalAmount.Text = getTotalAmount().ToString();
        }

        int dgvRowIndex;

        private void dgvOrder_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvRowIndex = e.RowIndex;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Calculator calculator = new Calculator(double.Parse(lblTotalAmount.Text));
            calculator.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            MainForm main = new MainForm();
            main.ShowDialog();
        }

        private void ChooseOrder_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
