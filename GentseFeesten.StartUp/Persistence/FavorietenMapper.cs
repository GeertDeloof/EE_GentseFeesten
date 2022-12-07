using DomainController;
using DomainController.Model;
using DomainController.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class FavorietenMapper : IFavorietenRepository
    {

        public List<Evenement> GetFavorieten()
        {
            return new List<Evenement>();
        }
        public void BewaarFavorieten()
        {
            
        }


    }
}
