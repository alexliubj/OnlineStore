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
        /// <summary>
        /// get user by user name 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static Usermodel getUserInfoByUseranme(string userName,string password)
        {
            Usermodel model = new Usermodel();
            DbCommand comm = GenericDataAccess.CreateNewCommand();
            comm.CommandText = "select user_id,first_name,last_name,address,email,password,role_type from users where email=@email";
            DbParameter param1 = comm.CreateParameter();
            param1.ParameterName = "@email";
            param1.DbType = DbType.String;
            param1.Value = userName;
            comm.Parameters.Add(param1);
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            if (table.Rows.Count > 0)
            {
                // get the first table row
                DataRow dr = table.Rows[0];
                model.user_id = Int32.Parse(dr["user_id"].ToString());
                model.first_name = dr["first_name"].ToString();
                model.last_name = dr["last_name"].ToString();
                model.Address = dr["address"].ToString();
                model.Email = dr["email"].ToString();
                model.Password = dr["password"].ToString();
                model.role_type = Int32.Parse(dr["role_type"].ToString());
            }

            if (password == model.Password)
                return model;
            else
                return null; 
        }
        
        /// <summary>
        /// create new user
        /// </summary>
        /// <param name="usm"></param>
        /// <returns></returns>
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
