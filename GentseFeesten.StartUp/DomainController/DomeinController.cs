using DomainController.Repository;

namespace DomainController
{
    public class DomeinController
    {
        IEvenement2022Repository _repo2022;

        public DomeinController(IEvenement2022Repository repo2022)
        {
            _repo2022 = repo2022;

        }

        public Dictionary<string, string>GetMapper2022()
        {
            return _repo2022.LoadCsv();
        }
        public string GetEvenementByKey(string key)
        {
            return _repo2022.GetEvenementByKey(key);
        }
    }
}