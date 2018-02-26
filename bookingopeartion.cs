using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BookingDet;

namespace Bookingoperation
{
    public class Booking
    {
        public int book(string name, int age, long no, string em,string address, string cat, int days)
        {

            SqlConnection con = new SqlConnection("server=intvmsql01;user id=PJ09TMS101_1718;password=tcstvm;database=DB09TMS101_1718");

            con.Open();
            SqlCommand cmd = new SqlCommand("booking_ka_proc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@age",age);
            cmd.Parameters.AddWithValue("@con", no);
            cmd.Parameters.AddWithValue("@em", em);
            cmd.Parameters.AddWithValue("@adds", address);
            cmd.Parameters.AddWithValue("@cat", cat);
            cmd.Parameters.AddWithValue("@day", days);
            BookingDetail boj = new BookingDetail(name,age,no,em,address,cat,days);
            cmd.Parameters.AddWithValue("@rent", boj.Rental_amount);
            cmd.Parameters.AddWithValue("@bid", 0);
            cmd.Parameters["@bid"].Direction = ParameterDirection.Output;
            int roef = cmd.ExecuteNonQuery();
            if (roef > 0)
                return Convert.ToInt16(cmd.Parameters["@bid"].Value);
            else
                return 0;

        }
        public List<BookingDetail> view( string room_category)
        {
            SqlConnection con = new SqlConnection("server=intvmsql01;user id=PJ09TMS101_1718;password=tcstvm;database=DB09TMS101_1718");

            con.Open();
            SqlCommand cmd = new SqlCommand("room_ki_cat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@roomcat", room_category);
            List<BookingDetail> lst = new List<BookingDetail>();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                BookingDetail s = new BookingDetail();
                s.Booking_id = Convert.ToInt16(reader["bid"]);
                s.Name = reader["name"].ToString();
                s.Age = Convert.ToInt16( reader["age"]);

                lst.Add(s);

            }

            return lst;
        }
    }
}
