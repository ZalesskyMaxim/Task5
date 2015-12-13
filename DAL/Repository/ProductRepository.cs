using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepository : AbstractRepository, IModelRepository<DAL.Models.Product, Model.Managers.Product>
    {
        Model.Managers.Product ToEntity(DAL.Models.Product source)
        {
            return new Model.Managers.Product()
            {
                ProductName = source.ProductName,
                ProductCost = source.ProductCost
            };
        }

        DAL.Models.Product ToObject(Model.Managers.Product source)
        {
            return new DAL.Models.Product()
            {
                ProductName = source.ProductName,
                ProductCost = source.ProductCost
            };
        }

        public Model.Managers.Product GetEntity(DAL.Models.Product source)
        {
            var entity = this.managersContext.Product.FirstOrDefault(x => x.ProductName == source.ProductName && x.ProductCost == source.ProductCost);
            return entity;
        }

        public Model.Managers.Product GetEntityNameById(int id)
        {
            var entity = this.managersContext.Product.FirstOrDefault(x => x.ID_Product == id);
            return entity;
        }

        public Model.Managers.Product GetEntityIDByName(string name)
        {
            var entity = this.managersContext.Product.FirstOrDefault(x => x.ProductName == name);
            return entity;
        }

        public void Add(DAL.Models.Product item)
        {
            var entity = this.ToEntity(item);
            managersContext.Product.Add(entity);
        }

        public void Remove(DAL.Models.Product item)
        {
            var entity = this.managersContext.Product.FirstOrDefault(x => x.ID_Product == item.ID_Product);
            if (entity != null)
            {
                managersContext.Product.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(DAL.Models.Product item)
        {
            var entity = this.managersContext.Product.FirstOrDefault(x => x.ID_Product == item.ID_Product);
            if (entity != null)
            {
                entity.ProductName = item.ProductName;
                entity.ProductCost = item.ProductCost;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public IEnumerable<DAL.Models.Product> Items
        {
            get
            {
                var b = new List<DAL.Models.Product>();
                foreach (var a in managersContext.Product.Select(x => x))
                {
                    b.Add(ToObject(a));
                }

                return b;
            }
        }

        public void SaveChanges()
        {
            managersContext.SaveChanges();
        }
    }
}
