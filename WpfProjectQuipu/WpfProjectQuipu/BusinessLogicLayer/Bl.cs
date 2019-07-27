using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProjectQuipu.DataLayer.Concrete;
using WpfProjectQuipu.Models;

namespace WpfProjectQuipu.BusinessLogicLayer
{
    class Bl
    {
        //Insert Client
        public bool Insert_User(Clients edititems)
        {
            return new UserDa().Insert_User(edititems);
        }
        //Update Client
        public bool Update_User(Clients editItem)
        {
            return new UserDa().Update_User(editItem);
        }
        //Delete User
        public bool Delete_User(Clients editItem)
        {
            return new UserDa().Delete_User(editItem);
        }
    }
}
