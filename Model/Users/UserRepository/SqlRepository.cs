using System;
using System.Collections.Generic;
using Ninject;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Users.UsersModel
{
    public partial class SqlRepository : IRepository
    {
        [Inject]
        public UsersModelDataContext Db { get; set; }
    }
}
