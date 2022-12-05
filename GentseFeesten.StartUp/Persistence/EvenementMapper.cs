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

        public List<string> LoadCsv()
        {
            using (StreamReader reader = new StreamReader(Path.Combine(folder, file)))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    evenementLijst2022.Add(line);
                }
            }
            return evenementLijst2022;
        }

    }
}