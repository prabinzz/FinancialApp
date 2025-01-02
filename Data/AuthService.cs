using FinancialApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Data
{
    internal class AuthService
    {
        public bool Authorized;
        public User User;

        public void Login(User user)
        {
            this.Authorized = true;
            this.User = user;
        }
    }
    
}
