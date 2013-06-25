using SofETest.Models;

namespace SofETest.Services
{
    public class DataService
    {
        private SofETestEntities _entities;

        internal SofETestEntities Entities
        {
            get
            {
                return _entities;
            }
        }

        public DataService(SofETestEntities entities)
        {
            _entities = entities;
        }
    }
}
