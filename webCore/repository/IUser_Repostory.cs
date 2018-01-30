using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webCore.repository
{
    public interface IUser_Repostory
    {
        admin Login(admin admin);
        admin Registered(admin admin);

    }
}
