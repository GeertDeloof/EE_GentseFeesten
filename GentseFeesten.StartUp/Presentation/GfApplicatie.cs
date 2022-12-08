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
            Dictionary<string, Evenement> favo;
            Console.WriteLine("Welkom bij de Gentse Feesten.");
            try
            {
                dict = new Dictionary<string, Evenement>(dc.GetMapper2022());
                favo = new Dictionary<string, Evenement>(dc.GetFavorieten()); //TijelijkeFavorietenRepo();
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
            string folder = @"C:\Users\Gebruiker\source\repos\2023\EE\EE_GentseFeesten\";

            dc.BewaarFavorieten(favo);
            Console.WriteLine("Fvorieten bewaard.");

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

            Console.WriteLine("De favorieten");

            favo.ToList().ForEach(f => { Console.WriteLine(f); });


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

        //public Dictionary<string, Evenement> TijelijkeFavorietenRepo()
        //{
        //    Dictionary<string, Evenement> favoDict = new();
        //    favoDict["fe7d82b7-2215-4d96-af61-533d9670e968"] = dc.GetEvenementByKey("fe7d82b7-2215-4d96-af61-533d9670e968");
        //    favoDict["fe8cced0-3a85-4eaa-b27a-967cd5e75547"] = dc.GetEvenementByKey("fe8cced0-3a85-4eaa-b27a-967cd5e75547");
        //    favoDict["fe8dc7c0-d4e0-4f88-9fed-6bbf501064eb"] = dc.GetEvenementByKey("fe8dc7c0-d4e0-4f88-9fed-6bbf501064eb");
        //    favoDict["fea6c7a9-b1c9-b9cf-3f57-000000001248"]= dc.GetEvenementByKey("fea6c7a9-b1c9-b9cf-3f57-000000001248");
        //    favoDict["feacd328-c0ee-2f1d-2dce-000000004488"] = dc.GetEvenementByKey("feacd328-c0ee-2f1d-2dce-000000004488");
        //    return favoDict;
        //}

        //public void BewaarFavorieten(Dictionary<string, Evenement> favoDict, string folder)
        //{

        //    string tekst = "";
        //    foreach (KeyValuePair<string, Evenement> lijn in favoDict)
        //    {

        //        Evenement e = lijn.Value;
        //        tekst += e.MaakBewaarLijn();
        //    } 
        //    using (StreamWriter gff = new StreamWriter(folder + "GebruikerFavorieten.csv"))
        //        {
        //            gff.WriteLine(tekst);
        //        }

        //}
    }
}