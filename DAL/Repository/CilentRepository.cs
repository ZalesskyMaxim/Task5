using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CilentRepository : AbstractRepository, IModelRepository<DAL.Models.Client, Model.Managers.Client>
    {
        Model.Managers.Client ToEntity(DAL.Models.Client source)
        {
            return new Model.Managers.Client()
            {
                ClientName = source.ClientName
            };
        }

        DAL.Models.Client ToObject(Model.Managers.Client source)
        {
            return new DAL.Models.Client()
            {
                ClientName = source.ClientName
            };
        }

        public Model.Managers.Client GetEntity(DAL.Models.Client source)
        {
            var entity = this.managersContext.Client.FirstOrDefault(x => x.ClientName == source.ClientName);
            return entity;
        }

        public Model.Managers.Client GetEntityNameById(int id)
        {
            var entity = this.managersContext.Client.FirstOrDefault(x => x.ID_Client == id);
            return entity;
        }

        public Model.Managers.Client GetEntityIDByName(string name)
        {
            var entity = this.managersContext.Client.FirstOrDefault(x => x.ClientName == name);
            return entity;
        }

        public void Add(DAL.Models.Client item)
        {
            var entity = this.ToEntity(item);
            managersContext.Client.Add(entity);
        }

        public void Remove(DAL.Models.Client item)
        {
            var entity = this.managersContext.Client.FirstOrDefault(x => x.ID_Client == item.ID_Client);
            if (entity != null)
            {
                managersContext.Client.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(DAL.Models.Client item)
        {
            var entity = this.managersContext.Client.FirstOrDefault(x => x.ID_Client == item.ID_Client);
            if (entity != null)
            {
                entity.ClientName = item.ClientName;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public IEnumerable<DAL.Models.Client> Items
        {
            get
            {
                return this.managersContext.Client.Select(x => this.ToObject(x));
            }
        }

        public void SaveChanges()
        {
            managersContext.SaveChanges();
        }
    }
}
