using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.SqlServer.Server;

namespace MODEL
{
    public class accountModel : databaseService
    {
        accountDTO account = new accountDTO();
        
        public bool checkAccount (string user , string pwd)
        {
          
            bool kq = false;
            try
            {
                string sql = " Select * From Account where Username =@user and Pass =@pwd";               

                SqlParameter parUser = new SqlParameter("@user", System.Data.SqlDbType.NVarChar);
                parUser.Value = user;
                SqlParameter parPwd = new SqlParameter("@pwd", System.Data.SqlDbType.NVarChar);
                parPwd.Value = pwd;

                SqlDataReader reader = ReadDataPars(sql, new[] { parUser, parPwd });
                if (reader.Read())
                {
                    kq = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                ketnoi.Close();
            }
            return kq;
        }
        public bool dkAccount(string user, string pwd,string fullname ,string phone , string birth )
        {

            bool kq = false;
            try
            {
                string sql = "INSERT INTO Account (Username,Pass,Fullname,PhoneNumber,Birthday,acctype) VALUES (@user,@pwd,@fullname,@phone,@birth,@acctype)";

                SqlParameter parUser = new SqlParameter("@user", System.Data.SqlDbType.NVarChar);
                parUser.Value = user;
                SqlParameter parPwd = new SqlParameter("@pwd", System.Data.SqlDbType.NVarChar);
                parPwd.Value = pwd;
                SqlParameter parFullname = new SqlParameter("@fullname", System.Data.SqlDbType.NVarChar);
                parFullname.Value = fullname;
                SqlParameter parPhone = new SqlParameter("@phone", System.Data.SqlDbType.Char);
                parPhone.Value = phone;
                SqlParameter parBirth = new SqlParameter("@birth", System.Data.SqlDbType.Date);
                parBirth.Value = birth;
                SqlParameter parAcctype = new SqlParameter("@acctype", System.Data.SqlDbType.Int);
                parAcctype.Value = 2;
                bool write = WriteDataPars(sql, new[] { parUser, parPwd , parFullname,parPhone,parBirth,parAcctype});
                if (write)
                {
                    kq = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                ketnoi.Close();
            }
            return kq;
        }
        public SqlDataAdapter Data()
        {
            SqlDataAdapter kq = null;
            try
            {
                string sql = "SELECT Username , FullName ,Phone, Birthday FROM Account ";

                SqlDataAdapter table = Data(sql);
                if (table != null)
                {
                    kq = table;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        public bool UpdateOwner(string fullname, string card, string email, string room, string phone, string birth)
        {
            bool kq = false;
           
            try
            {
                string sql = "UPDATE Owner SET FullName = @fullname,Phone = @phone,Email = @email,Birthday = @birth,RoomID = @room Where IdentityCard = @card";                
                SqlParameter parName = new SqlParameter("@fullname", SqlDbType.NVarChar);
                parName.Value = fullname;
                SqlParameter parCard = new SqlParameter("@card", SqlDbType.NChar);
                parCard.Value = card;
                SqlParameter parPhone = new SqlParameter("@phone", SqlDbType.NChar);
                parPhone.Value = phone;
                SqlParameter parEmail = new SqlParameter("@email", SqlDbType.NVarChar);
                parEmail.Value = email;
                SqlParameter parBirth = new SqlParameter("@birth", SqlDbType.Date);
                parBirth.Value = birth;
                SqlParameter parRoom = new SqlParameter("@room", SqlDbType.NChar);
                parRoom.Value = room;
                bool write = WriteDataPars(sql, new[] { parName, parCard, parPhone, parEmail, parBirth, parRoom });

                if (write)
                {
                    kq = true;
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }

            finally
            {
                CloseConnection();
            }
            return kq;
        }
        public bool DeleteOwner(string idcard)
        {
            bool kq = false;

            try
            {

                string sql = " Delete From Owner Where IdentityCard = @card ";
                SqlParameter parCard = new SqlParameter("@card", SqlDbType.NChar);
                parCard.Value = idcard;

                bool write = WriteDataPars(sql, new[] { parCard });

                if (write)
                {
                    kq = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            //khi try.. catch ok roi thi finally.
            finally
            {
                CloseConnection();
            }
            return kq;
        }
       
        public bool InsertOwner( string fullname, string card, string email, string room, string phone, string birth)
        { 
            bool kq = false;
            string  x = " Select count(*) From Owner ";//x=7
            int reader = dataReader (x);
            
            try
              
            {
                string sql = " INSERT INTO Owner (OwnerID,FullName,IdentityCard,Phone,Email,Birthday,RoomID) VALUES (@OwnerID,@fullname,@card,@phone,@email,@birth,@room)";
                SqlParameter paronwerID = new SqlParameter("@OwnerID", SqlDbType.NVarChar);
                paronwerID.Value = "OWN"+Convert.ToString(reader+1);
                SqlParameter parName = new SqlParameter("@fullname", SqlDbType.NVarChar);
                parName.Value = fullname;
                SqlParameter parCard = new SqlParameter("@card", SqlDbType.NChar);
                parCard.Value = card;               
                SqlParameter parPhone = new SqlParameter("@phone", SqlDbType.NChar);
                parPhone.Value = phone;
                SqlParameter parEmail = new SqlParameter("@email", SqlDbType.NVarChar);
                parEmail.Value = email;
                SqlParameter parBirth = new SqlParameter("@birth", SqlDbType.Date);
                parBirth.Value = birth;
                SqlParameter parRoom = new SqlParameter("@room", SqlDbType.NChar);
                parRoom.Value = room;
                CloseConnection();
                
                bool write = WriteDataPars(sql, new[] { paronwerID,parName, parCard, parPhone, parEmail, parBirth, parRoom  });

                if (write)
                {
                    kq = true;
                }
            }

            catch (Exception ex)
            {
                ex.ToString();
            }
            //khi try.. catch ok roi thi finally.
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        //=============
        public SqlDataAdapter DataOwner()
        {
            SqlDataAdapter kq = null;
            try
            {
                string sql = "SELECT OwnerID , FullName ,IdentityCard,Phone,Email, Birthday,RoomID FROM Owner ";

                SqlDataAdapter table = Data(sql);
               
                if (table != null)
                {
                    kq = table;
                    
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        public SqlDataAdapter DataRoom()
        {
            SqlDataAdapter kq = null;
            try
            {
                string sql = "SELECT RoomID , Floor ,Accommodated,RoomNumber FROM Room ";

                SqlDataAdapter table = Data(sql);
                if (table != null)
                {
                    kq = table;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        public SqlDataAdapter FindRoom(string room)
        {
            SqlDataAdapter kq = null;
            try
            {
                string sql = "exec FindRoom @roomno";
                SqlParameter parRoomNumber = new SqlParameter("@roomno", SqlDbType.NChar);
                parRoomNumber.Value = room;
                SqlDataAdapter table = FillData(sql, new[] { parRoomNumber });
                if (table != null)
                {
                    kq = table;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        public SqlDataAdapter FindOwner(string IdentityCard)
        {
            SqlDataAdapter kq = null;
            try
            {
                string sql = "select * FROM Owner where IdentityCard = @IdentityCard  ";
                SqlParameter parIdentityCard = new SqlParameter("@IdentityCard", SqlDbType.Char);
                parIdentityCard.Value = IdentityCard;
                SqlDataAdapter table = FillData(sql, new[] { parIdentityCard });
                if (table != null)
                {
                    kq = table;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                CloseConnection();
            }
            return kq;
        }
        public int LoadRoom(string name)
        {
            try
            {
                CloseConnection();
                string sql = "select TinhTrang from TinhTrang where RoomID=@iD";
                SqlParameter parID = new SqlParameter("@iD", SqlDbType.NChar);
                parID.Value = name;
                SqlDataReader reader = ReadDataPars(sql, new[] { parID });
                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                return -1;
            }
            catch
            {
                return -1;
            }
        }


    }

}

