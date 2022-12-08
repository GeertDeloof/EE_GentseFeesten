using DomainController;
using DomainController.Model;
using DomainController.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;

namespace Persistence
{
    public class FavorietenMapper : IFavorietenRepository
    {

        public List<Evenement> GetFavorieten()
        {
             return new List<Evenement>();
        }
        public void BewaarFavorieten(Dictionary<string,Evenement> favoDict, string folder)
        {


            foreach (KeyValuePair<string,Evenement> lijn in favoDict) 
            {

                Evenement e= lijn.Value;
                using (StreamWriter gff = new StreamWriter(folder + "GebruikerFavorieten.csv")) 
                {
                gff.WriteLine(e.MaakBewaarLijn());
                }
            }

        }


    }
}
