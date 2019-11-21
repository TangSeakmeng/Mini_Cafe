using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;

namespace Mini_Cafe__Be_in_One_
{
    public partial class ucDrinks : UserControl
    {
        public ucDrinks(List<Drink> l)
        {
            InitializeComponent();
            listDrink = l;
        }

        public static List<Drink> listDrink = new List<Drink>();

        Image DownloadImage(string fromUrl)
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                using (Stream stream = webClient.OpenRead(fromUrl))
                {
                    return Image.FromStream(stream);
                }
            }
        }

        Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void RowSelection(object sender, EventArgs e)
        {
            if (dgvDrink.SelectedRows.Count != 0)
            {
                string s = dgvDrink.Rows[dgvDrink.CurrentCell.RowIndex].Cells[1].Value.ToString();
                foreach (var a in listDrink)
                {
                    if (s == a.code)
                    {

                        lblNote.Text = a.note;
                        lblLastOrderDate.Text = "Last order date  : " + a.updated_at;
                        lblCode.Text = "Code            : " + a.code;
                        lblName.Text = "Name              : " + a.name;
                        if (a.image == null || a.image == "")
                        {
                            pictureBox1.Image = null;
                        }
                        else
                        {
                            string url = "http://3.13.30.90" + a.image;
                            Image image = resizeImage(DownloadImage(url), new Size(230, 230));
                            pictureBox1.Image = image;
                        }

                    }
                }
            }

        }

        private void UcDrinks_Load(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void BttDelete_Click(object sender, EventArgs e)
        {
            if (dgvDrink.SelectedRows.Count != 0)
            {

                foreach (var a in listDrink)
                {
                    if (a.code == dgvDrink.Rows[dgvDrink.CurrentCell.RowIndex].Cells[1].Value)
                    {
                        using (var client = new HttpClient())
                        {
                            client.BaseAddress = new Uri("http://3.13.30.90/");
                            string s = "api/product/destroy/" + a.id + "?api_token=Oq5CAKdgG1KPwbL0ynX1d938ZCHMe5B7KBVvSe55PKmXK0NpufpWOyNSrWzF";
                            var response = client.DeleteAsync(s).Result;
                            if (response.IsSuccessStatusCode)
                            {
                                dgvDrink.Rows.RemoveAt(dgvDrink.CurrentCell.RowIndex);
                                Console.Write("Success");
                            }
                            else
                                Console.Write("Error");
                        }
                    }
                }
            }
        }

        private void BtEdit_Click(object sender, EventArgs e)
        {
            Drink d = new Drink();
            int index = dgvDrink.CurrentCell.RowIndex;
            int n = -1;
            foreach (var a in listDrink)
            {
                if (a.code == dgvDrink.Rows[index].Cells[1].Value)
                {
                    n++;
                    d = a;
                }
            }
            EditDrink editDrink = new EditDrink(d);
            editDrink.ShowDialog();

            if (editDrink.isCancel == false)
            {
                foreach (var a in listDrink)
                {
                    if (a.id == d.id)
                    {
                        d.name = editDrink.tbtName.Text;
                        d.code = editDrink.tbCode.Text;
                        d.note = editDrink.tbNote.Text;
                        dgvDrink.Rows[index].Cells[1].Value = d.code;
                        dgvDrink.Rows[index].Cells[2].Value = d.name;
                        lblCode.Text = "Code            : " + d.code;
                        lblName.Text = "Name              : " + d.name;
                        lblNote.Text = d.note;

                    }
                }
            }
        }
    }
}
