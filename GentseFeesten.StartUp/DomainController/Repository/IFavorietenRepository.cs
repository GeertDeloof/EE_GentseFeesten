using DomainController.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainController.Repository
{
    public interface IFavorietenRepository
    {
        public Dictionary<string, Evenement> GetFavorieten();
        public void BewaarFavorieten(Dictionary<string, Evenement> favoDict);
    }
}
