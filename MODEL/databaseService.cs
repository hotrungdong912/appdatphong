using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class databaseService
    { 
       public string chuoiketnoi = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Account;Integrated Security=True";
       public  string sql;
       public SqlConnection ketnoi;
        public SqlCommand thuchien;
       public databaseService()
       {
            ketnoi = new SqlConnection(chuoiketnoi);
       }
        public void Connection()
        {
            if(ketnoi != null && ketnoi.State == System.Data.ConnectionState.Closed) // nếu kết nối đang đóng thì mở ra
            {
                ketnoi.Open();
            }
        }
        public void CloseConnection()
        {
            if (ketnoi != null && ketnoi.State == System.Data.ConnectionState.Open) // nếu đang mở ra thì đóng lại
            {
                ketnoi.Close();
            }
        }
   
        public SqlDataReader ReadDataPars(string sql , SqlParameter[] pars)
        {
            thuchien = new SqlCommand();
            thuchien.CommandType = System.Data.CommandType.Text;
            thuchien.CommandText = sql;
            thuchien.Connection = ketnoi;
            Connection();
            thuchien.Parameters.AddRange(pars);
            SqlDataReader reader = thuchien.ExecuteReader();
          
            


            return reader;
        }
        //ExcuteNonQuery tra ve mot con so.
        //kieu du lieu tra ve la bool vi bool co 0: false, 1:true (chi co hai gia tri <<0,1>>).
   
        public bool WriteDataPars(string sql, SqlParameter[] pars)
        {
            bool write = false;
            thuchien = new SqlCommand();
            thuchien.CommandType = CommandType.Text;
            thuchien.CommandText = sql;
            thuchien.Connection = ketnoi;
            Connection();
            thuchien.Parameters.AddRange(pars);
            if (thuchien.ExecuteNonQuery() != 0)
            {
                write = true;
            }

            return write;
        }
        public bool UpdateDataPars(string sql, SqlParameter[] pars)
        {
            bool update = false;
            thuchien = new SqlCommand();
            thuchien.CommandType = System.Data.CommandType.Text;
            thuchien.CommandText = sql;
            thuchien.Connection = ketnoi;
            Connection();
            thuchien.Parameters.AddRange(pars);
            if (thuchien.ExecuteNonQuery() != 0)
            {
                update = true;
            }
            return update;
        }
       
        public SqlDataReader deleteDataPars(string sql, SqlParameter[] pars)
        {
            thuchien = new SqlCommand();
            thuchien.CommandType = System.Data.CommandType.Text;
            thuchien.CommandText = sql;
            thuchien.Connection = ketnoi;
            Connection();
            thuchien.Parameters.AddRange(pars);
            SqlDataReader reader = thuchien.ExecuteReader();

            return reader;
        }
        public SqlDataAdapter FillData(string sql, SqlParameter[] pars)
        {
            thuchien = new SqlCommand(); // khởi tạo lại giá trị Command
            thuchien.CommandType = CommandType.Text; // kiểu truy vấn
            thuchien.CommandText = sql; // câu truy vấn
            thuchien.Connection = ketnoi;
            Connection();  // gọi hàm mở cổng kết nối
            thuchien.Parameters.AddRange(pars);
            SqlDataAdapter reader = new SqlDataAdapter(thuchien);

            return reader;
        }
        public SqlDataAdapter Data(string sql)
        {
            thuchien = new SqlCommand();
            thuchien.CommandType = CommandType.Text;
            thuchien.CommandText = sql;
            thuchien.Connection = ketnoi;
            Connection();
            SqlDataAdapter da = new SqlDataAdapter(thuchien);
            return da;
        }
        public  int   dataReader(string sql)
        {
            thuchien = new SqlCommand();
            thuchien.CommandType = System.Data.CommandType.Text;
            thuchien.CommandText = sql;
            thuchien.Connection = ketnoi;
            Connection();
            
            SqlDataReader reader = thuchien.ExecuteReader();
            reader.Read();
            int  i = reader.GetInt32(0);
            return i;
        }
        //public string datacolumReader(string sql)
        //{
        //    thuchien = new SqlCommand();
        //    thuchien.CommandType = System.Data.CommandType.Text;
        //    thuchien.CommandText = sql;
        //    thuchien.Connection = ketnoi;
        //    Connection();
        //    SqlDataReader reader = thuchien.ExecuteReader();
        //    reader.Read();
        //    string i = reader.GetString(2);
        //    return i;
        //}
    }   
}
