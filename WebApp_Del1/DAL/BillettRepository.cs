using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data.Entity;
//using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApp_Del1.Controllers;
using WebApp_Del1.Models;



namespace WebApp_Del1.DAL
{
    public class BillettRepository : IBillettRepository
    {
        private readonly BillettContext _db;
        private readonly ILogger<BillettController> _log;
        public BillettRepository(BillettContext db, ILogger<BillettController> log)
        {
            _db = db;
            _log = log;
        }



        //Henter ut alle Havner inn i første select (Reise fra)



        public async Task<List<Havner>> HentAlleHavner_Fra()
        {
            try
            {
                List<Havner> alleHavner = await _db.Havner.ToListAsync();
                return alleHavner;
            }
            catch
            {
                return null;
            }
        }




        public async Task<List<ankomstHavner>> HentAlleHavnerTil(int id)
        {
            try
            {
                //Henter Havnen som kunden ønsket fra databasen
                Havner ønksetHavn = await _db.Havner.FirstOrDefaultAsync(havn => havn.HavnId == id);
                return ønksetHavn.AnkomstHavner;
            }
            catch
            {
                return null;
            }
        }





        public async Task<Billett> HentBillett(int id)
        {
            try
            {



                Billetter funnet_bestilling = await _db.Bestillinger.FirstOrDefaultAsync(k => k.BId == id);
                Kunde funnet_Kunde = await _db.Kunder.FirstOrDefaultAsync(k => k.Kid == funnet_bestilling.Kid + 1);


                if (funnet_bestilling != null)
                {
                    Billett billett = new Billett
                    {
                        // Kid = funnet_bestilling.Kid,
                        Fornavn = funnet_Kunde.Fornavn,
                        Etternavn = funnet_Kunde.Etternavn,
                        Epost = funnet_Kunde.Epost,
                        Reisetype = funnet_bestilling.Reisetype,
                        Fra = funnet_bestilling.Fra,
                        Til = funnet_bestilling.Til,
                        Utreise = funnet_bestilling.Utreise,
                        Hjemreise = funnet_bestilling.Hjemreise,
                        AntallVoksne = funnet_bestilling.AntallVoksne,
                        AntallBarn = funnet_bestilling.AntallBarn
                    };



                    return billett;



                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }



        }



        async public Task<int> LagreBillett(Billett lagetBillett)
        {
            try
            {
                var nyBestillingRad = new Billetter();
                //nyBestillingRad.BId = lagetBillett.BId;// --> Id blir automatisk generert fra databasen
                nyBestillingRad.Reisetype = lagetBillett.Reisetype;
                nyBestillingRad.Fra = lagetBillett.Fra;
                nyBestillingRad.Til = lagetBillett.Til;
                nyBestillingRad.Utreise = lagetBillett.Utreise;
                nyBestillingRad.Hjemreise = lagetBillett.Hjemreise;
                nyBestillingRad.AntallVoksne = lagetBillett.AntallVoksne;
                nyBestillingRad.AntallBarn = lagetBillett.AntallBarn;

                Kunde nyKundeRad = new Kunde(); // brukes i tilfellet vi skal lage en ny kunde
                Kunde funnetKunde = await _db.Kunder.FirstOrDefaultAsync(k => k.Epost == lagetBillett.Epost);




                Kunde nyKundeRad = new Kunde(); // brukes i tilfellet vi skal lage en ny kunde 



                if (funnetKunde == null)
                {
                    nyKundeRad.Fornavn = lagetBillett.Fornavn;
                    nyKundeRad.Etternavn = lagetBillett.Etternavn;
                    nyKundeRad.Epost = lagetBillett.Epost;
                    // *** Legge til denne bestillingen til listen av alle andre bestillinger som kunden har bestilt fra før gjennom vårt system. ***//
                    var nyKunde__bestillinger = new List<Billetter>();
                    nyKunde__bestillinger.Add(nyBestillingRad);
                    nyKundeRad.bestillinger = nyKunde__bestillinger;
                    //Adde Kunden til databasen av kunder
                    _db.Kunder.Add(nyKundeRad);
                    // await _db.SaveChangesAsync();
                    //Access the database to get the kunde id of the new Kunde
                    // Kunde registrertKunde = (await _db.Kunder.FirstOrDefaultAsync(k => k.Epost == lagetBillett.Epost));
                    nyBestillingRad.Kid = nyKundeRad.Kid;
                }




                else
                {
                    nyBestillingRad.Kid = funnetKunde.Kid;
                    var funnetKunde__bestillinger = funnetKunde.bestillinger;
                    funnetKunde__bestillinger.Add(nyBestillingRad);
                    funnetKunde.bestillinger = funnetKunde__bestillinger;
                    // await _db.SaveChangesAsync();
                }

                _db.Bestillinger.Add(nyBestillingRad);
                //Oppdatere databasen
                await _db.SaveChangesAsync();




                return nyBestillingRad.BId;
             

            }

            catch (Exception e)
            {
                return -1;
            }



        }




        public async Task<int> ReturnPris(int id)
        {
            try
            {
                ankomstHavner ankomstHavnen = await _db.ankomstHavner.FirstOrDefaultAsync(h => h.HavnId == id);
                return ankomstHavnen.pris;
            }
            catch
            {
                return -1;
            }

        }
    }
}









