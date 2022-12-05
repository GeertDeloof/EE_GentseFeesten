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
            List<string> list = new List<string>(dc.GetMapper2022());
          
            for(int i=250; i<=1000; i++)
            {
                Console.WriteLine(i.ToString());
                Console.WriteLine(string.Join("\n ", list[i]));
                Console.WriteLine();
            }
        }
    }
}