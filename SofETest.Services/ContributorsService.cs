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
            #region Validation

            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("id must be an integer greater than 0");
            }

            #endregion

            return Entities.Contributors.Where(i=> i.Id == id).SingleOrDefault();
        }
        
        public void Create(Models.Contributor entity)
        {
            #region Validation

            if (entity == null)
            {
                throw new ArgumentNullException("Contributor instance is invalid.");
            }

            if (entity.Email == string.Empty)
            {
                throw new ArgumentException("Invalid email.");
            }

            if (entity.Name == string.Empty)
            {
                throw new ArgumentException("Invalid name.");
            }

            if (entity.Phone < 1000000000)
            {
                throw new ArgumentException("Phone should a 10 digit number. Phone is lower than expected.");
            }

            if (entity.Phone > 9999999999)
            {
                throw new ArgumentException("Phone should be a 10 digit number. Phone is grater than expected.");
            }

            #endregion

            Entities.Contributors.Add(entity);
            Entities.SaveChanges();
        }

        public void Update(Contributor entity)
        {
            #region Validation

            if (entity == null)
            {
                throw new ArgumentNullException("Contributor instance is invalid.");
            }

            if (entity.Id <= 0)
            { 
                throw new ArgumentException("Id must be grater than 0");
            }

            if (entity.Email == string.Empty)
            {
                throw new ArgumentException("Invalid email.");
            }

            if (entity.Name == string.Empty)
            {
                throw new ArgumentException("Invalid name.");
            }

            if (entity.Phone < 1000000000)
            {
                throw new ArgumentException("Phone should a 10 digit number. Phone is lower than expected.");
            }

            if (entity.Phone > 9999999999)
            {
                throw new ArgumentException("Phone should be a 10 digit number. Phone is grater than expected.");
            }

            #endregion

            Entities.SaveChanges();            
        }

        public void Delete(Contributor entity)
        {
            #region validation

            if (entity.Id <= 0)
            {
                throw new ArgumentOutOfRangeException("id must be an integer greater than 0");
            }

            var contributor = Get(entity.Id);

            if (contributor == null)
            {
                throw new InvalidOperationException("Cannot delete entity because it does not exist.");
            }

            #endregion  

            Entities.Contributors.Remove(entity);
            Entities.SaveChanges();
        }
    }
}
