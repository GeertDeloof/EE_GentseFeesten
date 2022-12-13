using DomainController.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainController.Repository
{
    public interface IEvenementRepository
    {
        public Dictionary<string, Evenement> LoadCsv();
        public Evenement GetEvenementByKey(string key);
        public List<Evenement> MaakSubEvenementen(Evenement evnt);
        public List<Evenement> GeefEvenementenMetNaam(string naam);
        public List<Evenement> GeefEvenementenVanDeDag(DateTime datum);
    }



}
