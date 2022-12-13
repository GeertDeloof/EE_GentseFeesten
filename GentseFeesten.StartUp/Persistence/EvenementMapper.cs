using DomainController.Model;
using DomainController.Repository;
using System;
using System.Globalization;

namespace Persistence
{
    public class EvenementMapper2022 : IEvenementRepository
    {
        public const string folder = @"C:\Users\Gebruiker\source\repos\2023\EE\EE_GentseFeesten\";
        // Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        // en verder  using (StreamReader reader = new StreamReader(Path.Combine(folder, file)))
        private const string file = "gentse-feesten-evenementen-2022.csv";
        private Dictionary<string, Evenement> evenementDictionary = new();

        public Dictionary<string,Evenement> LoadCsv()
        {
                using (StreamReader reader = new StreamReader(Path.Combine(folder, file)))
                {
                   while (!reader.EndOfStream)
                    {
                        string lijn = reader.ReadLine();
                        string[] subs = lijn.Split(";");
                    Evenement gfe = new(lijn);
                    evenementDictionary[subs[0]] = gfe;    
                    }
                }
                return evenementDictionary;                
            // "70332b26-5636-2e42-54bb-000000005514"  element  circa 3283
        }

        public Evenement GetEvenementByKey(string key)
        {
            if (evenementDictionary.ContainsKey(key))
            {
                //return evenementDictionary[key];
                Evenement evnt = evenementDictionary[key];
                evnt.SubEvenementenLijst = MaakSubEvenementen(evnt);
                evnt.SuperEvenement = evnt.SuperEvenement != null ? evenementDictionary[evnt.SuperEvenementString] : null;
                return evnt;
            }
            else
            {
                return null;
            }

        }

 

        public List<Evenement> MaakSubEvenementen(Evenement evnt)
        {
            List<Evenement> subLijst = new();
            // Maak lijst met subevenementen
            char[] separators = { ',' };
            string [] subEvent = evnt.SubEvenementenString.Split(separators);
            foreach (string s in subEvent)
            {
                if (s != "")
                {
                    subLijst.Add(GetEvenementByKey(s));
                }
            }
            return subLijst;
        }

        public List<Evenement> GeefEvenementenVanDeDag(DateTime datum)
        {
            List<Evenement> evenementLijst = new();
            foreach(Evenement evnt in evenementDictionary.Values)
            {
                if (evnt.StartDatumEnUur.Equals(datum))
                {
                    evenementLijst.Add(evnt);
                 };
            }
            return evenementLijst;
        }

        public List<Evenement> GeefEvenementenMetNaam(string naam)
        {
            List<Evenement> evenementLijst = new();
            foreach (Evenement evnt in evenementDictionary.Values)
            {
                if (evnt.EvenementNaam.Equals(naam))
                {
                    evenementLijst.Add(evnt);
                }
            }
            return evenementLijst;
        }


    }
}