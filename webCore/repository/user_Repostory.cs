using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webCore.repository
{
    public class user_Repostory : IUser_Repostory
    {
        private DbcontextDB db = new DbcontextDB();
        public admin Login(admin admin)
        {
            admin.password = common.common.MD5(admin.password);
            return db.FirstOrDefault<admin>("select * from [admin] where email=@0 and password=@1", admin.email, admin.password);
        }

        public admin Registered(admin admin)
        {
            var user = db.FirstOrDefault<admin>("select * from [admin] where email=@0", admin.email);
            if (user == null)
            {
                admin.password = common.common.MD5(admin.password);
                admin.id = (int)db.Insert(admin);
                return admin;
            }
            return null;
        }
    }
}
