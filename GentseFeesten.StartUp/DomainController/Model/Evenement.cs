using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainController.Model
{
    public class Evenement
    {

        CultureInfo cultureInfo = new CultureInfo("nl-BE");

        private string _rij;
        private string _datum;
        private DateTime _startDatum;
        private DateTime _eindDatum;
        private DateTime _eindTijd;
        private DateTime _startTijd;
        private string[] _subs;

        public Evenement(string rij)
        {
            _subs = rij.Split(";");

            ID = _subs[0];
            _rij = rij;
            if (!string.IsNullOrEmpty(_subs[2])) { _startDatum = DateTime.Parse(_subs[2], cultureInfo); }//_subs[2];
            if (!string.IsNullOrEmpty(_subs[1])) { _eindDatum = DateTime.Parse(_subs[1], cultureInfo); }// _subs[1];
            EvenementNaam= _subs[6];
            EvenementBeschrijving = _subs[5];
            SubEvenementen = GetSubEenementen(_subs[3]);
            SuperEvenement = _subs[4];
            Prijs = _subs[7];
        }

        public string ID { get; init; }
        public string EindDatum
        {
            get => _eindDatum.ToString("d", cultureInfo);
        }

        public string EindTijd
        {
            get => _eindDatum.ToString("t", cultureInfo);
        }

        public string StartDatum
        {
            get => _startDatum.ToString("d", cultureInfo);
        }


        public string StartTijd
        {
            get => _startDatum.ToString("t", cultureInfo);
        }

        public List<string> SubEvenementen { get; init; }
        //public string SubEvenementen { get; init; }

        //        public Evenement SuperEvenement { get; init; }
        public string SuperEvenement { get; init; }
        public string EvenementNaam { get; init; }
        public string EvenementBeschrijving { get; init; }
        public string Prijs { get; init; }   // voorlopig -  naar double??

        public override bool Equals(object? obj)
        {
            Console.WriteLine("Uses override equals method");
            return obj is Evenement evenement && evenement.EvenementNaam == EvenementNaam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EvenementNaam);
        }

        public bool Equals(Evenement evenement)
        {
            return evenement.ID == ID;
        }

        private List<string> GetSubEenementen(string subEevenementen)   // voorlopig later terug naar de mapper  brengen
        {
            List<Evenement> subLijst = new();
            char[] separators = { ',' };
            string[] subEvent = subEevenementen.Split(separators);

            //foreach (string s in subEvent)
            //{

            //    subLijst.Add(new Evenement(GetEvenementByKey(s)));
            //}
            return new List<string>(subEvent);
        }

        public override string ToString()
        {
            string tekst =  $"{EvenementNaam}\nDatum: {StartDatum} om {StartTijd}";
            string prijs = Prijs.Equals("0") || string.IsNullOrWhiteSpace(Prijs) ? "gratis" : Prijs;
            tekst += $"\nPrijs: {prijs}\n\n{EvenementBeschrijving}\n";
            tekst += string.Join("\n", SubEvenementen);
            return tekst;
        }
    }
}
