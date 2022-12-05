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

        public List<string> GetMapper2022()
        {
            return _repo2022.LoadCsv();
        }
    }
}