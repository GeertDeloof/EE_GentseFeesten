using DomainController;
using DomainController.Model;

namespace Presentation
{
    public class GfApplicatie
    {
        private readonly DomeinController  dc;

        public GfApplicatie(DomeinController domainController)
        {
            dc = domainController;
            Dictionary<string, Evenement> dict; 
            Console.WriteLine("Welkom bij de Gentse Feesten.");
            try
            {
                dict = new Dictionary<string, Evenement>(dc.GetMapper2022());
            }
            catch (FileNotFoundException ex)
            {
                string message = "Het bestand met de evenementen werd niet gevonden.\n\nRaadpleeg de systeembeheerder.";
                Console.WriteLine(message);
                Thread.Sleep(3000);
                return ;
            }
            //catch (Exception ex)
            //{
            //    string message = "Er trad een onverwachte fout op. Raadpleeg de systeembeheerder. Dit is de foutboodschap \n \n";

            //    Console.WriteLine(message + ex.Message);
            //    return;
            //}

            Evenement e1 = dc.GetEvenementByKey("70332b26-5636-2e42-54bb-000000005514");
            Console.WriteLine(e1);

            int teller = 1;
            foreach (KeyValuePair<string, Evenement> keyValue in dict)
            {
                if (teller > dict.Count-100 && teller < dict.Count)
                {
                    Console.WriteLine(keyValue.Value);
                    Console.WriteLine();
                }

                teller++;
            }
            Console.WriteLine($"\n\n Gentse feesten kent dit jaar {dict.Count} evenementen. Joepie!!!");
        }
    }
}