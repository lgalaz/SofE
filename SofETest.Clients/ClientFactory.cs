using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofETest.Clients
{
    public class ClientFactory
    {
        #region Contributors Client
        private ContributorClient _contributors;

        public ContributorClient Contributors
        {
            get
            {
                if (_contributors == null)
                {
                    _contributors = new ContributorClient();
                }

                return _contributors;
            }
        }
        #endregion
    }
}
