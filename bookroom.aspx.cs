using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bookingoperation;
using BookingDet;

namespace hotelmanagement
{
    public partial class BookRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            int age = Convert.ToInt32(TextBox2.Text);
            long contact_num = long.Parse(TextBox3.Text);
            string email = TextBox4.Text;
            string address = TextBox5.Text;
            string roomcat = DropDownList1.SelectedItem.Text;
            int noday = Convert.ToInt16(TextBox6.Text);
            Booking obj1 = new Booking();
            int bid = obj1.book(name, age, contact_num, email, address, roomcat, noday);
            if (bid != 0)
                Response.Write("<script>alert('Room booked with id"+bid+"')</script>");

        }
    }
}
