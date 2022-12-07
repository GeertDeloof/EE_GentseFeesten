using DomainController;
using DomainController.Model;
using System.Globalization;

namespace Presentation
{
    public class GfApplicatie
    {
        private readonly DomeinController  dc;


        public GfApplicatie(DomeinController domainController)
        {
            dc = domainController;
            Dictionary<string, Evenement> dict; 
            List<Evenement> favo;
            Console.WriteLine("Welkom bij de Gentse Feesten.");
            try
            {
                dict = new Dictionary<string, Evenement>(dc.GetMapper2022());
                favo = TijelijkeFavorietenRepo();
            }
            catch (FileNotFoundException)
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

            favo.ForEach(f => { Console.WriteLine(f); });

            int teller = 0;
            foreach (KeyValuePair<string, Evenement> el in dict)
            {
                if (teller < dict.Count)
                {
                    Evenement evnt = dc.GetEvenementByKey(el.Key);

                    if (evnt.SubEvenementenLijst.Count > 0) 
                    { 
                            Console.WriteLine($"{evnt.EvenementNaam.ToUpper()}");
                            Console.WriteLine(new string( '=', evnt.EvenementNaam.Length));
                            Console.WriteLine($"{evnt.StartDatum} om {evnt.StartTijd}");
                            if (evnt.SubEvenementenLijst.Count > 0)
                            {
                                Console.WriteLine("        Met de volgende gerelateerde evenementen:");
                                Console.WriteLine("        -----------------------------------------");
                                foreach(  Evenement s in evnt.SubEvenementenLijst)
                                {

                                    //Console.WriteLine(s.ID != evnt.ID ? $"        {s.EvenementNaam} - {evnt.StartDatum} om {evnt.StartTijd}" : "          Geen");
                                    Console.WriteLine($"          {s.EvenementNaam} - Datum: {s.StartDatum} om {s.StartTijd}");
                                }

                       
                            }
                            Console.WriteLine();                    
                    
                    }

                }

                teller++;
            }
            Console.WriteLine($"\n\n Gentse feesten kent dit jaar {dict.Count} evenementen. Joepie!!!");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Onder andere:");
            Evenement e1 = dc.GetEvenementByKey("000d12fa-2492-0eba-98e0-000000000831");  //"70332b26-5636-2e42-54bb-000000005514");

            Console.WriteLine(e1);
              Console.WriteLine();
            Console.WriteLine("Met de volgende gerelateerde evenementen:");
            Console.WriteLine("-----------------------------------------");
            e1.SubEvenementenLijst.ForEach(e => Console.WriteLine("      " + e.EvenementNaam));
        }

        public List<Evenement> TijelijkeFavorietenRepo()
        {
            return new List<Evenement>()
            {
                dc.GetEvenementByKey("fe7d82b7-2215-4d96-af61-533d9670e968"),
                dc.GetEvenementByKey("fe8cced0-3a85-4eaa-b27a-967cd5e75547"),
                dc.GetEvenementByKey("fe8dc7c0-d4e0-4f88-9fed-6bbf501064eb"),
                dc.GetEvenementByKey("fea6c7a9-b1c9-b9cf-3f57-000000001248"),
                dc.GetEvenementByKey("feacd328-c0ee-2f1d-2dce-000000004488")
            };
        }
    }
}