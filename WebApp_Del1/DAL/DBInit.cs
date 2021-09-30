﻿using Microsoft.AspNetCore.Builder;
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
                
                var nyHavn1 = new Havner { HavnNavn = "Bergen" };
                var nyHavn2 = new Havner { HavnNavn = "Oslo" };

                /* var havnListe = new List<Havner>
                 {
                     new Havner {HavnNavn = "Bergen"},
                     new Havner { HavnNavn = "Oslo" }
                 }; 
                 context.AlleHavner.Add(havnListe);*/

                //context.AlleHavner.Add(nyHavn1);
               // context.AlleHavner.Add(nyHavn2);
                //context.SaveChanges(); 
            }
        }
    }
}
