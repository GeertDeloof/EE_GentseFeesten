using DomainController.Repository;

namespace Persistence
{
    public class EvenementMapper2022 : IEvenement2022Repository
    {
        private string folder = @"C:\Users\Gebruiker\source\repos\2023\EE\EE_GentseFeesten\";
        // Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        // en verder  using (StreamReader reader = new StreamReader(Path.Combine(folder, file)))
        private const string file = "gentse-feesten-evenementen-2022.csv";
        private List<string> evenementLijst2022= new List<string>();
        private Dictionary<string, string> evenemetDictionary = new();

        public Dictionary<string,string> LoadCsv()
        {
            using (StreamReader reader = new StreamReader(Path.Combine(folder, file)))
            {
                while (!reader.EndOfStream)
                {
                    string lijn = reader.ReadLine();
                    string[] parts = lijn.Split(";");
                    evenemetDictionary[parts[0]] = lijn;
                    //evenementLijst2022.Add(line);
                }
            }
            return evenemetDictionary;
            // "70332b26-5636-2e42-54bb-000000005514"  element 28xx
        }

        public string GetEvenementByKey(string key)
        {
            return evenemetDictionary[key];   
        }
    }
}