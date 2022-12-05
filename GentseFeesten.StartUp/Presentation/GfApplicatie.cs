using DomainController;

namespace Presentation
{
    public class GfApplicatie
    {
        private readonly DomeinController  dc;

        public GfApplicatie(DomeinController domainController)
        {
            dc = domainController;

            Console.WriteLine("Welkom bij de Gentse Feesten.");
            Dictionary<string,string> dict = new Dictionary<string,string>(dc.GetMapper2022());

            Console.WriteLine("Element \"70332b26-5636-2e42-54bb-000000005514\"");
            Console.WriteLine(dc.GetEvenementByKey("70332b26-5636-2e42-54bb-000000005514"));
            Console.WriteLine();
            Thread.Sleep(10000);
              
            int teller = 1;
            foreach(KeyValuePair<string,string> keyValue in dict)
            {
                Console.WriteLine(teller.ToString());
                Console.WriteLine(keyValue.Key.ToString());
                Console.WriteLine();
                Console.WriteLine(keyValue.Value);
//                Console.WriteLine(string.Join("\n ", key.);
                Console.WriteLine();

                teller++;
            }

        }
    }
}