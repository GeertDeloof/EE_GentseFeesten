using DomainController;
using DomainController.Model;
using DomainController.Repository;
using System.Globalization;

namespace Presentation
{
    public class GfApplicatie
    {
        public readonly DomeinController  dc;   // public voor testing


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

            //  Boom
            string lijn1 = "000cee29-43a2-4425-8321-07b7c7f7b51f;17-07-2022 13:45;17-07-2022 13:00;" +
                "29514079-b3db-d844-2019-000000002874;;" +
                "Pastoor Guy Claus zal samen met enkele confraters de mis van zondag 17 juli opdragen in het Gents. Vrie welgekomen !;" +
                "Mis in 't Gentsch gesproken;5;";
            Evenement ev1 = new Evenement(lijn1);  // 		Key	"00695927-ef9a-a1ca-4813-000000002385"	string
                                                   //ev1.EindDatumEnUur = ev1.StartDatumEnUur.AddMinutes(45);
            string lijn2 = "000cee29-43a2-4425-8321-07b7c7f7b51f;17-07-2022 13:45;17-07-2022 13:00;" +
                "29514079-b3db-d844-2019-000000002874;;" +
                "Pastoor Guy Claus zal samen met enkele confraters de mis van zondag 17 juli opdragen in het Gents. Vrie welgekomen !;" +
                "Mis in 't Gentsch gesproken;5;";
            Evenement teZoeken = dc.GetEvenementByKey("00678269-c438-4a43-114e-000000003429");
            Evenement ev2 = new Evenement(lijn2);  /// dict.First().Value;

         //   List<Evenement> lijst = dc.GeefLijstVanGerelateerdeEelementen(teZoeken);

            //foreach(Evenement e in lijst)
            //{
            //    Console.WriteLine($"{e.EvenementNaam} \n {e}");
            //}

            string folder = @"C:\Users\Gebruiker\source\repos\2023\EE\EE_GentseFeesten\";

            dc.BewaarFavorieten(favo);
            Console.WriteLine("Favorieten bewaard.");
            int teller = 0;
            foreach (KeyValuePair<string, Evenement> el in dict)
            {
                if (teller < dict.Count)
                {
                    Evenement ev3 = dc.GetEvenementByKey(el.Key);

                    List<Evenement> namenLijst = dc.GeefEvenementenMetNaam("Rondleiding met gids in Plantentuin Universiteit Gent. Bedreigde planten.");
                    Console.WriteLine(namenLijst.Count);

                    DateTime dag = new DateTime(2022, 07,19);
                    List<Evenement> evenemenetenOp = dc.GeefEvenementenVandeDag(dag);
                    foreach(Evenement ev in evenemenetenOp)
                    {
                        Console.WriteLine(ev);
                    }
                    Console.WriteLine(evenemenetenOp.Count);


                    /* List<Evenement> lijst = dc.GeefLijstVanGerelateerdeEelementen(ev3);



                    *************** Voorlopig even weg

                            Console.WriteLine($"{ev3.EvenementNaam.ToUpper()}");
                            Console.WriteLine(new string('=', ev3.EvenementNaam.Length));
                            Console.WriteLine($"{ev3.StartDatum} om {ev3.StartTijd}");
                            if (ev3.SubEvenementenLijst.Count > 0)
                            {
                                Console.WriteLine("        Met de volgende gerelateerde evenementen:");
                                Console.WriteLine("        -----------------------------------------");
                                foreach (Evenement s in ev3.SubEvenementenLijst)
                                {
                                    Console.WriteLine($"          {s.EvenementNaam} - Datum: {s.StartDatum} om {s.StartTijd}  Prijs {s.Prijs}");
                                }


                            }
                            Console.WriteLine();
                            if (lijst.Count > 5)
                            {
                                Console.WriteLine("        Met de volgende boom:");
                                Console.WriteLine("        ---------------------");
                                foreach (Evenement l in lijst)
                                {

                                    //Console.WriteLine(s.ID != evnt.ID ? $"        {s.EvenementNaam} - {evnt.StartDatum} om {evnt.StartTijd}" : "          Geen");
                                    Console.WriteLine($"          {l.EvenementNaam} - Datum: {l.StartDatum} om {l.StartTijd}  Prijs {l.Prijs}");
                                }


                            }
                            */
                    Console.WriteLine();

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

    }