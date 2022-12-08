using DomainController.Model;
using DomainController.Repository;
using System.Globalization;

namespace DomainController
{
    public class DomeinController
    {
        private IEvenementRepository _repoEvents;
        private IFavorietenRepository _repoFavo;
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

        public void BewaarFavorieten(Dictionary<string, Evenement> favoDict)
        {
            _repoFavo.BewaarFavorieten(favoDict);
        }

        public Evenement GetEvenementByKey(string key)
        {
            Evenement evnt = _repoEvents.GetEvenementByKey(key);
            evnt.SubEvenementenLijst = _repoEvents.MaakSubEvenementen(evnt);
            evnt.SuperEvenement = _repoEvents.GetEvenementByKey(evnt.superEvenementString);
            return evnt;
        }

        public Dictionary<string, Evenement> GetFavorieten()
        {
            return _repoFavo.GetFavorieten();
        }




    }
}