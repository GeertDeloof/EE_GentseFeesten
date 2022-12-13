using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainController.Repository;

namespace DomainController.Model
{
    public class BoomStructuurVanEvenementen
    {
        private List<Evenement> _boom = new();
        private Queue<Evenement> _boomOpbouw = new();
        private Evenement _evnt;
        private Evenement _topEvenement;
        IEvenementRepository _repo;

        public BoomStructuurVanEvenementen()
        {
   
        }

        private Evenement GeefTopVanBoom()
        {
            bool IsTopBereikt = false;
             _topEvenement = _evnt;          
            do
            {
 
                if (string.IsNullOrEmpty(_topEvenement.SuperEvenementString) || string.IsNullOrWhiteSpace(_topEvenement.SuperEvenementString))
                {

                    IsTopBereikt = true;
                }
                else
                {
                    _topEvenement = _repo.GetEvenementByKey(_topEvenement.SuperEvenementString);
                }

            } while (!IsTopBereikt);
            return _topEvenement;
        }

        public List<Evenement> AfhankelijkeEvenementen(Evenement evnt, IEvenementRepository repo)
        {
            _evnt = evnt;
            _repo = repo;
            bool vanTopTotBeneden = false;
            _boomOpbouw.Enqueue(GeefTopVanBoom());
            List<Evenement> perNiveau;
            Evenement eersteVanQueue;
            while (_boomOpbouw.Count > 0)
            {
                _evnt = _boomOpbouw.Dequeue();
                foreach (Evenement e in _evnt.SubEvenementenLijst)
                {
                    _boomOpbouw.Enqueue(e);   // voorlopig - uitwerken: toevoegen aan boom als het nogniet besta
                    if (! _boom.Contains(e))
                    {
                        _boom.Add(e);
                    }
                }
            } 
            return _boom;  //.OrderBy(e => e);  // voorlopig
        }
    }
}
