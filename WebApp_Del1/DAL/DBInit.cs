using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace WebApp_Del1.DAL
{
    public class DBInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BillettContext>();



                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //Havner som skal være i fra select på frontend

                var nyHavn4 = new Havner();
                nyHavn4.HavnNavn = "Stavanger";
                var nyHavn5 = new Havner();
                nyHavn5.HavnNavn = "Kiel";
                var nyHavn6 = new Havner();
                nyHavn6.HavnNavn = "Arendal"; 
                var nyHavn7 = new Havner();
                nyHavn7.HavnNavn = "Barcelone "; 
                var nyHavn8 = new Havner();
                nyHavn8.HavnNavn = "Monaco";

                /************* **************  Oslo og  distinasjoner fra Oslo sin havn  ************** **************/
                var nyHavn1 = new Havner();
                nyHavn1.HavnNavn = "Oslo";

                var ankomstHavn1 = new ankomstHavner { HavnNavn = "Portofino, Italia"};
                var ankomstHavn2 = new ankomstHavner { HavnNavn = "Livorno, Italia"};
                var ankomstHavn3 = new ankomstHavner { HavnNavn = "Bergen, Norge"};
                var ankomstHavn4 = new ankomstHavner { HavnNavn = "Corfu, Hellas"};
                var ankomstHavn5 = new ankomstHavner { HavnNavn = "Kiel, Tyskland"};

                //En liste over mulige distinasjoner hvis du reiser fra Olso
                var oslo_ankomsthavner = new List<ankomstHavner>();
                oslo_ankomsthavner.Add(ankomstHavn1);
                oslo_ankomsthavner.Add(ankomstHavn2);
                oslo_ankomsthavner.Add(ankomstHavn3);
                oslo_ankomsthavner.Add(ankomstHavn4);
                oslo_ankomsthavner.Add(ankomstHavn5);

                nyHavn1.AnkomstHavner = oslo_ankomsthavner;
                context.Havner.Add(nyHavn1);

                /************* **************  Bergen og  distinasjoner fra Oslo sin havn  ************** **************/
                var nyHavn2 = new Havner();
                nyHavn2.HavnNavn = "Bergen";

                var ankomstHavn6 = new ankomstHavner { HavnNavn = "Marseille, Frankrike" };
                var ankomstHavn7 = new ankomstHavner { HavnNavn = "Venice, Italia" };
                var ankomstHavn8 = new ankomstHavner { HavnNavn = "San Juan, Puerto Rico" };
                var ankomstHavn9 = new ankomstHavner { HavnNavn = "Piraeus, Hellas" };
                var ankomstHavn10 = new ankomstHavner { HavnNavn = "Barcelona, Spania" };

                //En liste over mulige distinasjoner hvis du reiser fra Bergen
                var bergen_ankomsthavner = new List<ankomstHavner>();
                bergen_ankomsthavner.Add(ankomstHavn6);
                bergen_ankomsthavner.Add(ankomstHavn7);
                bergen_ankomsthavner.Add(ankomstHavn8);
                bergen_ankomsthavner.Add(ankomstHavn9);
                bergen_ankomsthavner.Add(ankomstHavn10);

                nyHavn2.AnkomstHavner = bergen_ankomsthavner;
                context.Havner.Add(nyHavn2);

                /************* **************  Oslo og  distinasjoner fra Oslo sin havn  ************** **************/
                var nyHavn3 = new Havner();
                nyHavn3.HavnNavn = "Kristiansand";

                var ankomstHavn11= new ankomstHavner { HavnNavn = "PortMiami, USA" };
                var ankomstHavn12 = new ankomstHavner { HavnNavn = "Port Canaveral, USA" };
                var ankomstHavn13 = new ankomstHavner { HavnNavn = "Cozumel, Mexico" };
                var ankomstHavn14 = new ankomstHavner { HavnNavn = "Port Everglades, USA" };
                var ankomstHavn15 = new ankomstHavner { HavnNavn = "Prince George Wharf, Bahamas" };

                //En liste over mulige distinasjoner hvis du reiser fra Kristiansand
                var kristiansand_ankomsthavner = new List<ankomstHavner>();
                kristiansand_ankomsthavner.Add(ankomstHavn11);
                kristiansand_ankomsthavner.Add(ankomstHavn12);
                kristiansand_ankomsthavner.Add(ankomstHavn13);
                kristiansand_ankomsthavner.Add(ankomstHavn14);
                kristiansand_ankomsthavner.Add(ankomstHavn15);

                nyHavn3.AnkomstHavner = kristiansand_ankomsthavner; 
                context.Havner.Add(nyHavn3);

                // Lagre endringer på databasen 
                context.SaveChanges();















                /* var havnListe = new List<Havner>
                {
                new Havner {HavnNavn = "Bergen"},
                new Havner { HavnNavn = "Oslo" }
                };
                context.AlleHavner.Add(havnListe);*/


                /* context.Havner.Add(nyHavn2);
                 context.Havner.Add(nyHavn3);
                 context.Havner.Add(nyHavn4);
                 context.Havner.Add(nyHavn5);
                 context.Havner.Add(nyHavn6);*/





                /*{
                                new Havner {HavnNavn = "Kristiansand"},
                                new Havner {HavnNavn = "Kiel"},
                                new Havner {HavnNavn = "Malmo"},
                                new Havner {HavnNavn = "Kopenhagen"},

                            };*/


                /*
                                var nyHavn8 = new Havner();
                                nyHavn8.HavnNavn = "Kopenhagen";
                                HavnerFor_Rute1.Add(nyHavn8); 

                                Ruter rute1 = new Ruter();
                                rute1.avgangHavnen = "Oslo";
                                rute1.ankomstHavner = HavnerFor_Rute1;
                                context.Ruter.Add(rute1);*/

            }
        }
    }
}