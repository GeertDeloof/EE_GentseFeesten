using DomainController.Model;
using DomainController.Repository;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace DomainController
{
    public class DomeinController
    {
        private readonly IEvenementRepository _repoEvents;
        private readonly IFavorietenRepository _repoFavo;
        public readonly CultureInfo cultureInfo = new CultureInfo("nl-BE");
        public const string folder = @"C:\Users\Gebruiker\source\repos\2023\EE\EE_GentseFeesten\";



        public DomeinController(IEvenementRepository repo, IFavorietenRepository repvoFavo)
        {
            _repoEvents = repo;
            _repoFavo = repvoFavo;
        }

        public Dictionary<string, Evenement>GetMapper2022()
        {
            return _repoEvents.LoadCsv();
        }

        public Dictionary<string, Evenement> GetFavorieten()
        {
            return _repoFavo.GetFavorieten();
        }
        
        public void BewaarFavorieten(Dictionary<string, Evenement> favoDict)
        {
            _repoFavo.BewaarFavorieten(favoDict);
        }

        public Evenement GetEvenementByKey(string key)
        {
            return _repoEvents.GetEvenementByKey(key);
        }

        public List<Evenement> GeefLijstVanGerelateerdeEelementen(Evenement e)
        {
            return new List<Evenement>(new BoomStructuurVanEvenementen().AfhankelijkeEvenementen(e, _repoEvents));
        }

        public List<Evenement> GeefEvenementenMetNaam(string naam)
        {
            return _repoEvents.GeefEvenementenMetNaam(naam);
        }

        public List<Evenement> GeefEvenementenVandeDag(DateTime dag)
        {
            return _repoEvents.GeefEvenementenVanDeDag(dag);
        }

    }
}