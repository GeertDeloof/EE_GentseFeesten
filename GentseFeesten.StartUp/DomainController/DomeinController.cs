using DomainController.Model;
using DomainController.Repository;

namespace DomainController
{
    public class DomeinController
    {
        IEvenementRepository _repoEvents;

        public DomeinController(IEvenementRepository repo)
        {
            _repoEvents = repo;

        }

        public Dictionary<string, Evenement>GetMapper2022()
        {
            return _repoEvents.LoadCsv();
        }


        public Evenement GetEvenementByKey(string key)
        {
            return _repoEvents.GetEvenementByKey(key);
        }

    }
}