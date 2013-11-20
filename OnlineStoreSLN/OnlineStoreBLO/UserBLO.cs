using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineStoreDAL.Models;
using OnlineStoreDAL;
using System.Data;

namespace OnlineStoreBLO
{
    public static class UserBLO
    {
        public static int CreateUser(Usermodel usm)
        {
            return UserDAO.CreateUser(usm);
        }
    }
}
