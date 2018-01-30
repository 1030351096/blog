using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace webCore.services
{
    public interface IUserServices
    {   
        admin Login(admin admin);
        admin Registered(admin admin);
    }
}
