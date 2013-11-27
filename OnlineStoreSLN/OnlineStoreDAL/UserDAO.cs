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
            comm.CommandText = "insert into users values(@firstname,@lastname,@address,@email,@password,@datetime,0)";

            DbParameter param1 = comm.CreateParameter();
            param1.ParameterName = "@firstname";
            param1.DbType = DbType.String;
            param1.Value = usm.first_name;
            
            DbParameter param2 = comm.CreateParameter();
            param2.ParameterName = "@lastname";
            param2.DbType = DbType.String;
            param2.Value = usm.last_name;

            DbParameter param3 = comm.CreateParameter();
            param3.ParameterName = "@address";
            param3.DbType = DbType.String;
            param3.Value = usm.Address;

            DbParameter param4 = comm.CreateParameter();
            param4.ParameterName = "@email";
            param4.DbType = DbType.String;
            param4.Value = usm.Email;

            DbParameter param5 = comm.CreateParameter();
            param5.ParameterName = "@password";
            param5.DbType = DbType.String;
            param5.Value = usm.Password;

            DbParameter param6 = comm.CreateParameter();
            param6.ParameterName = "@datetime";
            param6.DbType = DbType.DateTime;
            param6.Value = DateTime.Now;

            comm.Parameters.Add(param1);
            comm.Parameters.Add(param2);
            comm.Parameters.Add(param3);
            comm.Parameters.Add(param4);
            comm.Parameters.Add(param5);
            comm.Parameters.Add(param6);
            return GenericDataAccess.ExecuteNonQuery(comm);

        }
    }
}
