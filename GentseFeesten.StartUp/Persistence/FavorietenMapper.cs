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

        public const string folder = @"C:\Users\Gebruiker\source\repos\2023\EE\EE_GentseFeesten\";
        private string favoBestand = "GebruikerFavorieten.csv";
        private Dictionary<string, Evenement> favorietenDictionary = new();


        public Dictionary<string, Evenement> GetFavorieten()
            {
                using (StreamReader reader = new StreamReader(Path.Combine(folder, favoBestand)))
                {
                    while (!reader.EndOfStream)
                    {
                        string lijn = reader.ReadLine();
                        string[] subs = lijn.Split(";");

                    if (!string.IsNullOrEmpty(subs[0])) {
                         Evenement gfe = new(lijn);
                        favorietenDictionary[subs[0]] = gfe;
                    }
                    else
                    {
                        Console.WriteLine("Wacht");
                    }
                    }
                 }
                return favorietenDictionary;
                // "70332b26-5636-2e42-54bb-000000005514"  element  circa 3283
            }

        public void BewaarFavorieten(Dictionary<string,Evenement> favoDict)
        {

            string tekst = "";
            foreach (KeyValuePair<string,Evenement> lijn in favoDict) 
            {

               Evenement e= lijn.Value;
                tekst += e.MaakBewaarLijn();
            }
            //tekst += "einde";
                using (StreamWriter gff = new StreamWriter(folder + favoBestand)) 
                {
                gff.WriteLine(tekst);
                }            
        }


    }
}
