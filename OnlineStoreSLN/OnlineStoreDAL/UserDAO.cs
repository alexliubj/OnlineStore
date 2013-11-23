using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineStoreDAL.Models;
using System.Data;
using System.Data.Common;


namespace OnlineStoreDAL
{
    public class UserDAO
    {
        // Retrieve the recent orders
        public static int CreateUser(Usermodel usm)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateNewCommand();
            // set the stored procedure name
            //comm.CommandText = "insert into users values(2,'firstname','lastnmae','address','eee@gg.com','sjflsj',GETDATE(),0)";
            comm.CommandText = "insert into users values('firstname','lastnmae','address','eee@gg.com','sjflsj'," + DateTime.Now + ",0)";

            // create a new parameter
           // DbParameter param = comm.CreateParameter();
           // param.ParameterName = "@CartID";
           // param.Value = shoppingCartId;
           // param.DbType = DbType.String;
          //  param.Size = 36;
          //  comm.Parameters.Add(param);
            // return the result table
            return Int32.Parse( GenericDataAccess.ExecuteScalar(comm));

        }
    }
}
