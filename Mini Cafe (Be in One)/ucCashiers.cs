using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Cafe__Be_in_One_
{
    public partial class ucCashiers : UserControl
    {
        public ucCashiers(List<Cashier> l)
        {
            InitializeComponent();
            listCashier = l;
        }

        public static List<Cashier> listCashier = new List<Cashier>();

        private void BttDelete_Click(object sender, EventArgs e)
        {
            if (dgvCashier.SelectedRows.Count != 0)
            {
                dgvCashier.Rows.RemoveAt(dgvCashier.CurrentCell.RowIndex);
            }
        }

        private void RowSelection(object sender, EventArgs e)
        {
            if (dgvCashier.SelectedRows.Count != 0)
            {
                string s = dgvCashier.Rows[dgvCashier.CurrentCell.RowIndex].Cells[1].Value.ToString();
                foreach (var a in listCashier)
                {
                    if (s == a.full_name)
                    {
                        lblFname.Text = a.first_name;
                        lblLname.Text = a.last_name;
                        lblLastLoggin.Text = a.last_login_ip;
                        lblEmail.Text = a.email;
                        lblCreateAt.Text = a.created_at;
                        lblHired.Text = a.created_at;
                    }
                }
            }

        }
    }
}
