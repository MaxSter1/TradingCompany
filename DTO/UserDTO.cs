using System;

namespace DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Login { get; set; }
        public string Phone{ get; set; }

        public int RoleId { get; set; }


        public string GetInfo()
        {
            string info = Id.ToString() + " " + FirstName + " " + LastName + " " + Login + " " + Phone;
            return info;
        }

    }




}
