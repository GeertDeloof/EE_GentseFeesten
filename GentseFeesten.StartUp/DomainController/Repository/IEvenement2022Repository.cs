using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainController.Repository
{
    public interface IEvenement2022Repository
    {
        public Dictionary<string, string> LoadCsv();
        public string GetEvenementByKey(string key);
    }
}
