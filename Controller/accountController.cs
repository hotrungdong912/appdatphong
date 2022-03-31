using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using DTO;
namespace Controller
{
    public class accountController
    {
        OwnerDTO ownerDTO = new OwnerDTO();
        RoomDTO RoomDTO = new RoomDTO();
        accountModel model = new accountModel();
        public bool checkAccount (accountDTO account)
        {
          
            bool kq = false;
            if (model.checkAccount(account.UserName,account.Password))
            {
                kq = true;
            }
            return kq;
        }
        public bool dkkAccount(accountDTO account)
        {

            bool kq = false;
            if (model.dkAccount(account.UserName, account.Password,account.FullName,account.PhoneNumber,account.BirthDay))
            {
                kq = true;
            }
            return kq;
        }

        public SqlDataAdapter data()
        {
            SqlDataAdapter table = null;
            table = model.Data();
            return table;
        }
       
        public SqlDataAdapter Data()
        {
            SqlDataAdapter table = null;
            table = model.Data();
            return table;
        }
        public SqlDataAdapter DataOwner()
        {
            SqlDataAdapter table = null;
            table = model.DataOwner();
            return table;
        }
        public SqlDataAdapter DataRoom()
        {
            SqlDataAdapter table = null;
            table = model.DataRoom();
            return table;
        }
        public int LoadRoom(string name)
        {
            return model.LoadRoom(name);
        }
        public bool InsertOwner(OwnerDTO owner)
        {
            bool kq = false;
            if (model.InsertOwner(owner.FullName, owner.IdentityCard, owner.Email, owner.RoomID, owner.Phone, owner.Birthday))
            {
                kq = true;
            }
            return kq;
        }
        public bool UpdateOwner(OwnerDTO owner)
        {
            bool kq = false;
            if (model.UpdateOwner(owner.FullName, owner.IdentityCard, owner.Email, owner.RoomID, owner.Phone, owner.Birthday))
            {
                kq = true;
            }
            return kq;
        }       
        public bool DeleteOwner(string idcard)
        {
            return model.DeleteOwner(idcard);
        }
        public SqlDataAdapter FindRoom(string room)
        {
            RoomDTO.RoomNumber = room;
            SqlDataAdapter table = null;
            table = model.FindRoom(RoomDTO.RoomNumber);
            return table;
        }
        public SqlDataAdapter FindOwner(string IdentityCard)
        {
            ownerDTO.IdentityCard = IdentityCard;
            SqlDataAdapter table = null;
            table = model.FindOwner(ownerDTO.IdentityCard);
            return table;
        }
    }
}
