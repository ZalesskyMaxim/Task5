﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL.Repository
{
    public class ManagerRepository : AbstractRepository, IModelRepository<DAL.Models.Manager, Model.Managers.Manager>
    {
        Model.Managers.Manager ToEntity(DAL.Models.Manager source)
        {
            return new Model.Managers.Manager() 
            { 
                ManagerName = source.ManagerName
            };
        }

        DAL.Models.Manager ToObject(Model.Managers.Manager source)
        {
            return new DAL.Models.Manager() 
            {
                ManagerName = source.ManagerName
            };
        }

        public Model.Managers.Manager GetEntity(DAL.Models.Manager source)
        {
            var entity = this.managersContext.Manager.FirstOrDefault(x => x.ManagerName == source.ManagerName);
            //return new Model.Manager()
            //{
            //    ManagerName = source.ManagerName
            //};
            return entity;
        }

        public Model.Managers.Manager GetEntityNameById(int id)
        {
            var entity = this.managersContext.Manager.FirstOrDefault(x => x.ID_Manager == id);
            return entity;
        }

        public Model.Managers.Manager GetEntityIDByName(string name)
        {
            var entity = this.managersContext.Manager.FirstOrDefault(x => x.ManagerName == name);
            return entity;
        }

        public void Add(DAL.Models.Manager item)
        {
            var entity = this.ToEntity(item);
            managersContext.Manager.Add(entity);
        }

        public void Remove(DAL.Models.Manager item)
        {
            var entity = this.managersContext.Manager.FirstOrDefault(x => x.ID_Manager == item.ID_Manager);
            if (entity != null)
            {
                managersContext.Manager.Remove(entity);
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public void Update(DAL.Models.Manager item)
        {
            var entity = this.managersContext.Manager.FirstOrDefault(x => x.ManagerName == item.ManagerName);
            if (entity != null)
            {
                entity.ManagerName = item.ManagerName;
            }
            else
            {
                throw new ArgumentException("Incorrect argument!!!");
            }
        }

        public IEnumerable<DAL.Models.Manager> Items
        {
            get
            {
                var b = new List<DAL.Models.Manager>();
                foreach (var a in managersContext.Manager.Select(x => x))
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
