using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class accountDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string BirthDay { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class OwnerDTO
    {
        public string OwnerID { get; set; }
        public string FullName { get; set; }
        public string IdentityCard { get; set; }
        public string Email { get; set; }
        public string RoomID { get; set; }
        public string Birthday { get; set; }
        public string Phone { get; set; }
    }
    public class RoomDTO
    {
        public string RoomID { get; set; }
        public string Floor { get; set; }
        public string Accommodated { get; set; }
        public string RoomNumber { get; set; }
    }
}
