using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Users.UsersModel
{
    public partial class SqlRepository
    {
        public IQueryable<Role> Roles
        {
            get
            {
                return Db.Roles;
            }
        }

        public bool CreateRole(Role instance)
        {
            if (instance.IDRole == 0)
            {
                Db.Roles.InsertOnSubmit(instance);
                Db.Roles.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool UpdateRole(Role instance)
        {
            Role cache = Db.Roles.FirstOrDefault(p => p.IDRole == instance.IDRole);
            if (instance.IDRole == 0)
            {
                cache.Name = instance.Name;
                cache.Code = instance.Code;
                Db.Roles.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool RemoveRole(int idRole)
        {
            Role instance = Db.Roles.FirstOrDefault(p => p.IDRole == idRole);
            if (instance != null)
            {
                Db.Roles.DeleteOnSubmit(instance);
                Db.Roles.Context.SubmitChanges();
                return true;
            }

            return false;
        }
    }
}
