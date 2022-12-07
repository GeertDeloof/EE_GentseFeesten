using DomainController.Repository;
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
        const int KolID = 0;
        const int KolStartDatum = 1;
        const int KolEindDatum = 2;
        const int KolSub = 3;
        const int KolSuper = 4;
        const int KolBeschrijving = 5;
        const int KolNaam = 6;
        const int KolPrijs = 7;

        CultureInfo cultureInfo = new CultureInfo("nl-BE");

        private DateTime _startDatum;
        private DateTime _eindDatum;
        private string[] _subs;

        public Evenement(string rij)
        {
            IngevoerdEvenement = rij;
            _subs = rij.Split(";");
            ID = _subs[KolID];
            if (!string.IsNullOrEmpty(_subs[KolStartDatum])) { _startDatum = DateTime.Parse(_subs[2], cultureInfo); }//_subs[2];
            if (!string.IsNullOrEmpty(_subs[KolEindDatum])) { _eindDatum = DateTime.Parse(_subs[1], cultureInfo); }// _subs[1];
            SubEvenementenString = _subs[KolSub];
            superEvenementString = _subs[KolSuper];
            EvenementNaam = _subs[KolNaam];
            EvenementBeschrijving = _subs[KolBeschrijving];
            Prijs = _subs[KolPrijs];
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

        public List<Evenement> SubEvenementenLijst { get; set; }
        public string SubEvenementenString { get; init; }
        public string superEvenementString {get ; init;}
        public Evenement SuperEvenement  { get; set ; }
        public string EvenementNaam { get; init; }
        public string EvenementBeschrijving { get; init; }
        public string Prijs { get; init; }   // voorlopig -  naar double??
        public string IngevoerdEvenement { get; init; }

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

        public override string ToString()
        {
            string tekst =  $"{EvenementNaam}\nDatum: {StartDatum} om {StartTijd}";
            string prijs = Prijs.Equals("0") || string.IsNullOrWhiteSpace(Prijs) ? "gratis" : Prijs;
            tekst += $"\nPrijs: {prijs}\n\n{EvenementBeschrijving}\n";
          //  tekst += string.Join("\n", SubEvenementen);
            return tekst;
        }


    }
}
