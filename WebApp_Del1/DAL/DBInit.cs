using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/**/
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

                var nyHavn1 = new Havner();
                nyHavn1.HavnNavn = "Oslo";
                var nyHavn2 = new Havner();
                nyHavn2.HavnNavn = "Bergen";
                var nyHavn3 = new Havner();
                nyHavn3.HavnNavn = "Kristiansand";
                var nyHavn4 = new Havner();
                nyHavn4.HavnNavn = "Stavanger";
                var nyHavn5 = new Havner();
                nyHavn5.HavnNavn = "Kiel";
                var nyHavn6 = new Havner();
                nyHavn6.HavnNavn = "Arendal";
                var nyHavn7 = new Havner();
                nyHavn7.HavnNavn = "Oslo";
                var nyHavn8 = new Havner();
                nyHavn8.HavnNavn = "Oslo";

                /*var havnListe = new List<Havner>
                 {
                     new Havner {HavnNavn = "Bergen"},
                     new Havner { HavnNavn = "Oslo" }
                 }; */
                

                context.Havner.Add(nyHavn1);
                context.Havner.Add(nyHavn2);
                context.Havner.Add(nyHavn3);
                context.Havner.Add(nyHavn4);
                context.Havner.Add(nyHavn5);
                context.Havner.Add(nyHavn6);
                context.SaveChanges(); 
            }
        }
    }
}

