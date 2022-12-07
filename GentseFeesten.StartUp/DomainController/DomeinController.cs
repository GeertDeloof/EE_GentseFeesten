using DomainController.Model;
using DomainController.Repository;
using System.Globalization;

namespace DomainController
{
    public class DomeinController
    {
        IEvenementRepository _repoEvents;
        IFavorietenRepository _repvoFavo;
        public readonly CultureInfo cultureInfo = new CultureInfo("nl-BE");


        public DomeinController(IEvenementRepository repo, IFavorietenRepository repvoFavo)
        {
            _repoEvents = repo;
            _repvoFavo = repvoFavo;
        }

        public Dictionary<string, Evenement>GetMapper2022()
        {
            return _repoEvents.LoadCsv();
        }


        public Evenement GetEvenementByKey(string key)
        {
            Evenement evnt = _repoEvents.GetEvenementByKey(key);
            evnt.SubEvenementenLijst = _repoEvents.MaakSubEvenementen(evnt);
            evnt.SuperEvenement = _repoEvents.GetEvenementByKey(evnt.superEvenementString);
            return evnt;
        }
            


    }
}