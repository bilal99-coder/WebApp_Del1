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



                /************* ************** Oslo og distinasjoner fra Oslo sin havn ************** **************/
                var nyHavn1 = new Havner();
                nyHavn1.HavnNavn = "Oslo";



                var ankomstHavn1 = new ankomstHavner { HavnNavn = "Portofino, Italia", pris = 3190 };
                var ankomstHavn2 = new ankomstHavner { HavnNavn = "Livorno, Italia", pris = 4190 };
                var ankomstHavn3 = new ankomstHavner { HavnNavn = "Bergen, Norge", pris = 490 };
                var ankomstHavn4 = new ankomstHavner { HavnNavn = "Corfu, Hellas", pris = 6599 };
                var ankomstHavn5 = new ankomstHavner { HavnNavn = "Kiel, Tyskland", pris = 899 };



                //En liste over mulige distinasjoner hvis du reiser fra Olso
                var oslo_ankomsthavner = new List<ankomstHavner>();
                oslo_ankomsthavner.Add(ankomstHavn1);
                oslo_ankomsthavner.Add(ankomstHavn2);
                oslo_ankomsthavner.Add(ankomstHavn3);
                oslo_ankomsthavner.Add(ankomstHavn4);
                oslo_ankomsthavner.Add(ankomstHavn5);



                nyHavn1.AnkomstHavner = oslo_ankomsthavner;
                context.Havner.Add(nyHavn1);



                /************* ************** Bergen og distinasjoner fra Oslo sin havn ************** **************/
                var nyHavn2 = new Havner();
                nyHavn2.HavnNavn = "Bergen";



                var ankomstHavn6 = new ankomstHavner { HavnNavn = "Marseille, Frankrike", pris = 2450 };
                var ankomstHavn7 = new ankomstHavner { HavnNavn = "Venice, Italia", pris = 3190 };
                var ankomstHavn8 = new ankomstHavner { HavnNavn = "San Juan, Puerto Rico", pris = 8900 };
                var ankomstHavn9 = new ankomstHavner { HavnNavn = "Piraeus, Hellas", pris = 6790 };
                var ankomstHavn10 = new ankomstHavner { HavnNavn = "Barcelona, Spania", pris = 2190 };



                //En liste over mulige distinasjoner hvis du reiser fra Bergen
                var bergen_ankomsthavner = new List<ankomstHavner>();
                bergen_ankomsthavner.Add(ankomstHavn6);
                bergen_ankomsthavner.Add(ankomstHavn7);
                bergen_ankomsthavner.Add(ankomstHavn8);
                bergen_ankomsthavner.Add(ankomstHavn9);
                bergen_ankomsthavner.Add(ankomstHavn10);






                nyHavn2.AnkomstHavner = bergen_ankomsthavner;
                context.Havner.Add(nyHavn2);



                /************* ************** Oslo og distinasjoner fra Oslo sin havn ************** **************/
                var nyHavn3 = new Havner();
                nyHavn3.HavnNavn = "Kristiansand";



                var ankomstHavn11 = new ankomstHavner { HavnNavn = "PortMiami, USA", pris = 10090 };
                var ankomstHavn12 = new ankomstHavner { HavnNavn = "Port Canaveral, USA", pris = 9990 };
                var ankomstHavn13 = new ankomstHavner { HavnNavn = "Cozumel, Mexico", pris = 6750 };
                var ankomstHavn14 = new ankomstHavner { HavnNavn = "Port Everglades, USA", pris = 2190 };
                var ankomstHavn15 = new ankomstHavner { HavnNavn = "Prince George Wharf, Bahamas", pris = 4790 };



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

            }
        }
    }
}