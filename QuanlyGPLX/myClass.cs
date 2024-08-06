using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace QuanlyGPLX
{
    public class myClass
    {
        //khai báo 1 biến sqlconnection
        static SqlConnection con = new SqlConnection();
        //Hàm tạo kết nối
        public static void taoketnoi()
        {
            //Cấu trúc chuỗi kết nối đến CSDL SQLServer
            con.ConnectionString = "Data Source =MAYCHULYTHUYET; Initial Catalog = GPLX_CSDT_BM; User ID= sa; Password=123456;";
            try
            {
                con.Open(); //Mở kết nối đến CSDL
            }
            catch(Exception)
            {
                throw;
            }
        }
        //Hàm đóng kết nối
        public static void dongketnoi()
        {
            con.Close();
        }
        //Hàm đổ dữ liệu vào datatable
        public static DataTable getData(string query)
        {
            taoketnoi();
            DataTable tb = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(tb);
            dongketnoi();
            return tb;
        }
        //Hàm lấy dữ liệu bằng Dataset
        public static DataSet getDataSet(string query)
        {
            taoketnoi();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        //Hàm Insert/Update dữ liệu
        public static void execQuery(string qr)
        {
            taoketnoi();
            SqlCommand cmd = new SqlCommand(qr, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            dongketnoi();
        }
        public static DateTime GetFirstDayInMont(int year, int month)
        {
            return new DateTime(year, month, 1);
        }
    }
}
