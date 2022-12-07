using DomainController.Model;
using DomainController.Repository;
using System;
using System.Globalization;

namespace Persistence
{
    public class EvenementMapper2022 : IEvenementRepository
    {
        private const string folder = @"C:\Users\Gebruiker\source\repos\2023\EE\EE_GentseFeesten\";
        // Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        // en verder  using (StreamReader reader = new StreamReader(Path.Combine(folder, file)))
        private const string file = "gentse-feesten-evenementen-2022.csv";
        private Dictionary<string, Evenement> evenementDictionary = new();
        CultureInfo cultureInfo = new CultureInfo("nl-BE");

        public Dictionary<string,Evenement> LoadCsv()
        {
                using (StreamReader reader = new StreamReader(Path.Combine(folder, file)))
                {
                   List<string>? subLijst; 
                   while (!reader.EndOfStream)
                    {
                        string lijn = reader.ReadLine();
                        string[] subs = lijn.Split(";");
                        Evenement gfe = MaakEvenement(lijn);
                        evenementDictionary[subs[0]] = gfe;
                        // subs 3 bevat ID van subevenementen: naar lijst - gebeurt nu in evenement
                        //subLijst = !string.IsNullOrEmpty(subs[3]) ? GetSubEenementen(subs[3]) : null;
                    }
                }
                return evenementDictionary;                
            // "70332b26-5636-2e42-54bb-000000005514"  element  circa 3283
        }

        private Evenement MaakEvenement(string rij)
        {
            Evenement gfe = new(rij);

            return gfe;
        }

        public Evenement GetEvenementByKey(string key)
        {
            return evenementDictionary[key];   
        }


    }
}