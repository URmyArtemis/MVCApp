using MVCEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLogic
{
    public class LogicUser
    {
        //CRUD
        public User CheckLogin(string userName, string password)
        {
            JooleEntity jooleEntity = new JooleEntity();
            var data = jooleEntity.User.Where(p => p.UserName == userName && p.Password == password).FirstOrDefault();
            return data;
        }

        public List<User> GetUsersList(string keyWord)
        {
            JooleEntity jooleEntity = new JooleEntity();
            var data = jooleEntity.User.ToList();
            if (!string.IsNullOrEmpty(keyWord))
            {
                data = data.Where(p => p.UserName.Contains(keyWord)).ToList();
            }
            return data;
        }
    }
}
