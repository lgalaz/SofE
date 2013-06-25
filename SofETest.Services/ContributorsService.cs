using System;
using System.Collections.Generic;
using System.Linq;
using SofETest.Models;


namespace SofETest.Services
{
    public class ContributorsService : DataService
    {
        public ContributorsService(SofETest.Models.SofETestEntities entities)
        :base(entities)
        {

        }

        public IEnumerable<Contributor> GetAll()
        {
            return Entities.Contributors.ToList();
        }

        public Contributor Get(int id)
        {
            return Entities.Contributors.Where(i=> i.Id == id).SingleOrDefault();
        }
        
        public void Create(Models.Contributor entity)
        {
            Entities.Contributors.Add(entity);
            Entities.SaveChanges();
        }

        public void Update(Contributor entity)
        {
            Entities.SaveChanges();            
        }

        public void Delete(Contributor entity)
        {
            Entities.Contributors.Remove(entity);
            Entities.SaveChanges();
        }
    }
}
