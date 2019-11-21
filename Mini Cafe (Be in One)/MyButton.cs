using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Cafe__Be_in_One_
{
    class MyButton
    {
        public Button BtnTable { get; set; }
        public string stringSataus { get; set; }
        public int status { get; set; }
        public int pay { get; set; }

        public MyButton()
        {

        }
        public MyButton(ref Button BtnTable)
        {
            this.BtnTable = BtnTable;
        }
        public void SetPayStatus(int status, int pay)
        {
            this.status = status;
            this.pay = pay;
            if (this.status == (int)Status.Unavailble && this.pay == (int)(Pay.UnPaid))
            {
                this.BtnTable.BackColor = Color.DarkSlateGray;
                this.stringSataus = "Unavailble/UnPaid";
            }
            else if (this.status == (int)Status.Unavailble && this.pay == (int)(Pay.Paid))
            {
                this.BtnTable.BackColor = Color.Gold;
                this.stringSataus = "Unavailble/Paid";
            }
            else if (this.status == (int)Status.TakeAway && this.pay == (int)(Pay.Paid))
            {
                this.BtnTable.BackColor = Color.Red;
                this.stringSataus = "TakeAway/Paid";
            }
            else
            {
                this.BtnTable.BackColor = Color.ForestGreen;
                this.stringSataus = "Availble";
            }

        }
        public string GetStatus()
        {

            if (this.status == (int)Status.Unavailble && this.pay == (int)Pay.Paid)
            {
                return "Unavailble/Paid";
            }
            else if (this.status == (int)Status.Unavailble && this.pay == (int)Pay.UnPaid)
            {
                return "Unavailble/UnPaid";
            }
            else if (this.status == (int)Status.TakeAway && this.pay == (int)(Pay.Paid))
            {
                return "Take Away/Paid";
            }

            return "Availble";
        }
    }
}
