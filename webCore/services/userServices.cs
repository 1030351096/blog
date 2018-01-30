using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webCore.repository;

namespace webCore.services
{
    public class userServices : IUserServices
    {
        private IUser_Repostory user_Repostory;
        public userServices(IUser_Repostory IUser_Repostory)
        {
            this.user_Repostory = IUser_Repostory;
        }
        public admin Login(admin admin) => user_Repostory.Login(admin);

        public admin Registered(admin admin) => user_Repostory.Registered(admin);
    }
}
