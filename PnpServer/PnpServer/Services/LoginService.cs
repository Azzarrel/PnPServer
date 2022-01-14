using PnpServer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PnpServer.Services
{
    public class LoginService : ILoginService
    {


        private readonly IDatabaseService m_DataBaseService;

        public LoginService(IDatabaseService dataBaseService)
        {
            m_DataBaseService = dataBaseService;
        }

        public User Login(LoginCache login)
        {
           var table = m_DataBaseService.Login(login.UserName, login.Password);
            if (table == null || table.Rows.Count == 0)
                return null;

            DataRow row = table.Rows[0];
            if (row["Password"].ToString() != login.Password)
                return null;

            User user = new User((int)row["ID"], row["Name"].ToString(), row["Password"].ToString(), row["Guid"].ToString());
            return user;


        }

        public User Register(LoginCache login)
        {
            try
            {
                var table = m_DataBaseService.Register(login.UserName, login.Password);
                if (table == null || table.Rows.Count == 0) return null;


                var row = table.Rows[0];
                return new User((int)row["Id"], login.UserName, login.Password, row["Guid"].ToString());
            }
            catch(Exception e)
            {
                throw;
            }
        }
    }
}
