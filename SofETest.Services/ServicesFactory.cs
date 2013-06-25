using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofETest.Services
{
    public class ServicesFactory
    {
        private SofETest.Models.SofETestEntities _entities;

        public ServicesFactory()
        {
            _entities = new SofETest.Models.SofETestEntities();
        }

        #region Contributors Service
        private ContributorsService _contributors;

        public ContributorsService Contributors
        {
            get
            {
                if (_contributors == null)
                {
                    _contributors = new ContributorsService(_entities);
                }

                return _contributors;
            }
        }
        #endregion
    }
}
