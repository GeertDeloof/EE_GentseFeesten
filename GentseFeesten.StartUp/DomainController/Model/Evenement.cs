using DomainController.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DomainController.Model
{
    public class Evenement
    {
        const int KolID = 0;
        const int KolEindDatum = 1;
        const int KolStartDatum = 2;
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
            IngevoerdeDataString = rij;
            _subs = rij.Split(";");
            ID = _subs[KolID];
            _startDatum = !string.IsNullOrEmpty(_subs[KolStartDatum]) ? DateTime.Parse(_subs[KolStartDatum], cultureInfo) : new DateTime();
            _eindDatum = !string.IsNullOrEmpty(_subs[KolEindDatum]) ? DateTime.Parse(_subs[KolEindDatum], cultureInfo) : new DateTime();
            SubEvenementenString = _subs[KolSub];
            SuperEvenementString = _subs[KolSuper];
            EvenementNaam = _subs[KolNaam];
            EvenementBeschrijving = _subs[KolBeschrijving];
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

        public DateTime StartDatumEnUur { get => _startDatum; set { _startDatum = value; }}  // voorlopi ook sset met oog op testen
        public DateTime EindDatumEnUur
        {
            get => _eindDatum;
            set
            {
                _eindDatum = value;
            }
        }


        public List<Evenement> SubEvenementenLijst { get; set; }
        public string SubEvenementenString { get; init; }
        public string SuperEvenementString { get; init; }
        public Evenement SuperEvenement { get; set; }
        public string EvenementNaam { get; init; }
        public string EvenementBeschrijving { get; init; }
        public string Prijs {
            get {
                if (string.IsNullOrEmpty(_subs[KolPrijs]) || _subs[KolPrijs] == "0")
                    { return "gratis"; }
                else
                { return _subs[KolPrijs]; }
            }
                init => Prijs = _subs[KolPrijs];
            }
         // voorlopig -  naar double??
        public string IngevoerdeDataString { get; init; }

        public override bool Equals(object? obj)
        {
            //Console.WriteLine("Uses override equals method");
            return obj is Evenement evenement && evenement.ID == ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }

        public bool Equals(Evenement evenement)
        {
            return evenement.EvenementNaam == EvenementNaam;
        }

        public bool Equals(string naam)
        {
            return EvenementNaam == naam;
        }

        public bool Equals(DateTime datumStart)
        {
            // Wordt het evenement op dezelfde datum georganiseerd?
            return _startDatum.ToShortDateString() == datumStart.ToShortDateString();
        }

        public bool OverlaptMet(Evenement ander)
        {
            bool beginInPeriode = StartDatumEnUur >= ander.StartDatumEnUur && StartDatumEnUur <= ander.EindDatumEnUur;
            bool eindeInPeriode = EindDatumEnUur >= ander.StartDatumEnUur && EindDatumEnUur <= ander.EindDatumEnUur;
            return beginInPeriode || eindeInPeriode;   
        }

        public override string ToString()
        {
            string tekst =  $"{EvenementNaam}\nDatum: {StartDatum} om {StartTijd}";
          
            tekst += $"\nPrijs: {Prijs}\n\n{EvenementBeschrijving}\n";
          //  tekst += string.Join("\n", SubEvenementen);
            return tekst;
        }

        public string MaakBewaarLijn()
        {
            return $"{ID};{StartDatum};{EindDatum};{SubEvenementenString};{SuperEvenementString};{EvenementBeschrijving};{EvenementNaam};{Prijs}\n";

        }


    }
}
