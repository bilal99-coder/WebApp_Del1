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

                // List<Havner> lister = new List<Havner>();
                //lister.Add(new Havner {HavnNavn ="Oslo"} , new Havner { HavnNavn ="Bergen"}) ;
                //return lister; ;
            }
            catch (Exception e)
            {
                var alleHavner1 = new List<Havner>{ new Havner { HavnNavn ="there is an error in the database" },
                                                    new Havner {HavnNavn =  "line 34billettcontext"},
                                                    new Havner {HavnNavn =  e.Message.ToString()},
                                               };
                // return null; 
                return alleHavner1;
            }

            /*
             
             "The source IQueryable doesn't implement IDbAsyncEnumerable<Havner>. Only sources that implement IDbAsyncEnumerable can be used for Entity Framework asynchronous operations. For more details see http://go.microsoft.com/fwlink/?LinkId=287068."
             
             */
        }


        public async Task<List<ankomstHavner>> HentAlleHavnerTil(int id)
        {
            try
            {
                //Henter Havnen som kunden ønsket fra databasen
                Havner ønksetHavn = await _db.Havner.FirstOrDefaultAsync(havn => havn.HavnId == id);
                return ønksetHavn.AnkomstHavner;
                /*
                ankomstHavner muligeAnkomstHavner = await _db.Havner
                Ruter rute = await _db.Ruter.FirstOrDefaultAsync(rute => rute.avgangHavnen == ønksetHavn.HavnNavn);
                List<Havner> alleMulige_AnkomstHavner = rute.ankomstHavner;
                return alleMulige_AnkomstHavner;*/
            }
            catch
            {
                return null;
            }
        }



        public async Task<List<Billett>> HentBillett()
        {
            try
            {
                Billett billett = await 



                List<Billett> alleBilletter = await _db.Kunder.Select(b => new Billett
                {
                    Kid = b.Kid,
                    Fornavn = b.Fornavn,
                    Etternavn = b.Etternavn,
                    Epost = b.Epost,
                    Reisetype = b.Bestillinger.Reisetype,
                    Fra = b.Bestillinger.Fra,
                    Til = b.Bestillinger.Til,
                    Utreise = b.Bestillinger.Utreise,
                    Hjemreise = b.Bestillinger.Hjemreise,
                    AntallVoksne = b.Bestillinger.AntallVoksne,
                    AntallBarn = b.Bestillinger.AntallBarn

                }).ToListAsync();
                return alleBilletter;

            }
            catch
            {
                return null;
            }

        }

        async public Task<bool> LagreBillett(Billett lagetBillett)
        {
            try
            {
                var nyBestillingRad = new Bestilling();
                //nyBestillingRad.BId = lagetBillett.BId;  --> Id blir automatisk generert fra databasen
                nyBestillingRad.Reisetype = lagetBillett.Reisetype;
                nyBestillingRad.Fra = lagetBillett.Fra;
                nyBestillingRad.Til = lagetBillett.Til;
                nyBestillingRad.Utreise = lagetBillett.Utreise;
                nyBestillingRad.Hjemreise = lagetBillett.Hjemreise;
                nyBestillingRad.AntallVoksne = lagetBillett.AntallVoksne;
                nyBestillingRad.AntallBarn = lagetBillett.AntallBarn;

                //Før å opprette en ny Kude, skjekker først om kunden finnes i databasen med bruk av sin unik epost, fordi eposter er uansett alLtid unike 

                // Kan være null hvis kunden med denne eposten ikke finnes i databasen ellers får vi en kunde Objekt. 

                Kunde funnetKunde = await _db.Kunder.FirstOrDefaultAsync(k => k.Epost == lagetBillett.Epost);

                var nyKundeRad = new Kunde();


                /***  Hvis kunden finnes på databasen fra foor  ***/
                if (funnetKunde != null)
                {
                    nyKundeRad.Fornavn = funnetKunde.Fornavn;
                    nyKundeRad.Etternavn = funnetKunde.Etternavn;
                    nyKundeRad.Epost = funnetKunde.Epost;
                    // Legge til denne bestillingen til listen av alle andre bestillinger som kunden har bestilt gjennom vårt system. 
                    nyKundeRad.Bestillinger = nyBestillingRad;
                }


                /***  Hvis kunden ikke finnes på databasen fra foor  ***/
                else if (funnetKunde == null)
                {
                    nyKundeRad.Fornavn = lagetBillett.Fornavn;
                    nyKundeRad.Etternavn = lagetBillett.Etternavn;
                    nyKundeRad.Epost = lagetBillett.Epost;
                    nyKundeRad.Bestillinger = nyBestillingRad;
                    //Adde Kunden til databasen av kunder 
                    _db.Kunder.Add(nyKundeRad);
                }
                //Adde bestilingen til tabellen av bestillinger i databasen 
                await _db.Bestillinger.AddAsync(nyBestillingRad);
                await _db.SaveChangesAsync();
                return true;
            }

            catch
            {
                return false;
            }

        }
    }
}




/*
async public Task<bool> LagreBillett(Billett lagetBillett)
{
    try
    {
        var nyKundeRad = new Kunde();
        nyKundeRad.Fornavn = lagetBillett.Fornavn;
        nyKundeRad.Etternavn = lagetBillett.Etternavn;
        nyKundeRad.Epost = lagetBillett.Epost;
    }
    catch (Exception e)
    {

    }
}*/



/*

    //Alle disse parameterene  får vi fra Javascript  Klienten 
    public async Task<bool> LagreBillett1  (Reiseinformasjon innReiseinformasjon, int[] lugar_Id, Person[] personerIBiletteten)
    {  //Jeg regner med at jeg får et array at av person objekter fra javascript
       //Betaleren får jeg data om fra reiseinformasjon klasse, andre personer får jeg data om fra et array av personer 
       //Instansierer nå en ny billett 
        try
        {
            //Før å opprette en ny Kude, skjekke første om den finnes i databasen med bruk av sin epost, fordi eposter er uansett altid unike 
            var nyBillett = new Billett();
            //Approach NR2
            //Fyller nå billetten med data og info om reisen som vi får fra hoved siden
            nyBillett.fra = innReiseinformasjon.fra;
            nyBillett.til = innReiseinformasjon.til;
            nyBillett.antallBarn = innReiseinformasjon.antallBarn;
            nyBillett.antallVoksne = innReiseinformasjon.antallVoksne;
            nyBillett.antallReisende = innReiseinformasjon.antallReisende;
            nyBillett.tidspunkt = innReiseinformasjon.utreise.ToString();
            nyBillett.type = innReiseinformasjon.reiseType;

            //Henter nå data om betaleren som er stored in ReiseInfromasjon KLasse
            //Lager nå en ny Betalere Objekt 
            Betalere enNyBetaler = new Betalere();
            //Før å fylle attributter til betaleren, skjekker vi foorst om betaleren finnes fra foor i databasen til personer 
            Betalere funnetBetaler = await _db.Betalere.FirstOrDefaultAsync(k => k.personId == innReiseinformasjon.betalerId);
            //Hvis personen ikke finnes fra foor i databasen saa lager vi en ny person "enNyBetaler"
            if (funnetBetaler == null)
            {
                enNyBetaler.kortholdersNavn = innReiseinformasjon.betaler_kortholdersNavn;
                enNyBetaler.cvc = innReiseinformasjon.betaler_cvc;
                enNyBetaler.kortNummer = innReiseinformasjon.betaler_kortNummer;
                enNyBetaler.fornavn = innReiseinformasjon.betalerFornavn;
                enNyBetaler.etternavn = innReiseinformasjon.betalerEtternavn;
                enNyBetaler.addresse = innReiseinformasjon.betalerAdresse;
                enNyBetaler.personId = innReiseinformasjon.betalerId;
                nyBillett.betaleren = enNyBetaler;
                //Adde personen som betalte til listen av personer i billetten 
                //vi trenger ikke å lage betaleren på listen av personer i billetten siden betaleren blir lagret som et eget attributt i billetten 
                //Oppdatere databasen av personer med ny betaleren

                _db.Betalere.Add(enNyBetaler);
                await _db.SaveChangesAsync();
            }
            //Hvis personen finnes fra foor i databasen saa henter vi henne, og adder henne til listen av personer i billetten 

            else
            {
                nyBillett.betaleren = funnetBetaler;
            }
            //Nå etter at jeg hentet data om selve reisen og data om betaleren, nå vil jeg å hente data om andre passasjerer 

            foreach (Person enPerson in innReiseinformasjon.personer)
            {
                //skjekker først om vi har kunden(enPerson) på databasen fra før
                Personer funnetKunde = await _db.personer.FirstOrDefaultAsync(hverPerson => hverPerson.personId == enPerson.personId);
                //Instansierer enNyPerson objekt som vi skal bruke om vi ikke har den passasjereren i databasen 
                Personer enNyPerson = new Personer();
                if (funnetKunde == null)//Hvis kunden finnes ikke i databasen fra foor 
                {
                    enNyPerson.personId = enPerson.personId;
                    enNyPerson.fornavn = enPerson.fornavn;
                    enNyPerson.etternavn = enPerson.etternavn;
                    enNyPerson.addresse = enPerson.adresse;
                    //Må nå adde en enNyPerson til Listen: billettPersoner
                    nyBillett.billettPersoner.Add(enNyPerson);
                    _db.personer.Add(enNyPerson);
                    await _db.SaveChangesAsync();
                }
                else  //Hvis personen finnes i databasen så har vi allerede data om han/henne 
                {
                    //Må nå adde personen i Listen billettPersoner
                    nyBillett.billettPersoner.Add(funnetKunde);
                }

            }

            //Nå har vi lagret data om alle personer som skal være med i reisen, laget en objekt for hver person jeg får fra klienten, added den på billettPersoner listen, og added den til databasen av personer hvis den ikke finnes fra foor 
            //I tillegg til det så ble en betaler objekt laget også, og ble lagret på databasen hvis den ikke finnes fra foor. 
            //Så nå vår billett objekt har data om reisen (f. eks "fra" "til" ..), data om betaleren ("navn",cvc, ..) og data om andre pasasjerer.
            //Jeg trenger nå å hente data om ønsket lugaren 

            //Starter med å lage en ny lugar objekt 

            Lugarer enNyLugar = new Lugarer();
            //Henter oonsket lugar fra databasen av alle lugarer  basert på hva kunden ønkser 
            Lugarer funnetLugar = await _db.lugarer.FirstOrDefaultAsync(k => k.LId == innReiseinformasjon.LugarId);


            //Approach 2 for lugarer 
            int antallLugar1 = 0;
            int antallLugar2 = 0;
            int antallLugar3 = 0;
            int antallLugar4 = 0;
            int antallLugar5 = 0;

        }

        catch (Exception e)
        {

        }
        return true; 

    }
    
        
        
        /* 

                int lugar_Id = {1,1,5,4,1};



                 */
/*
        foreach (int id in lugar_Id)
        {
            if (id == 1)
            {
                antallLugar1++; //0+1+1+1   = 3 
            }
            else if (id == 2)
            {
                antallLugar2++;
            }
            else if (id == 3)
            {
                antallLugar3++;
            }
            else if (id == 4)
            {
                antallLugar4++;// 0+1
            }
            else antallLugar5++; // 0+1 = 1

        }
        antallLugar1 = 3;
        antallLugar5 = 1;

        //billetten skal ha en liste av lugarer 


        */
/* 
 public void Bestill(Reiseinformasjon innReiseinformasjon, int [] lugarId , Person [] personerIBiletteten)

    Javascript : 
       int [] idLugar = {1,1,1}; ,
       Etter at kunden har trykket "Gå Videre"
       Så henter du ønsket id-ene til ænsket lugarene. 
       fyyle idLugar med de id-ene.
       Sende dem til meg 



//Adder Lugaren til listen av lugarer i billetten 
if (funnetLugar != null)
{
   nyBillett.billettLugarer.Add(funnetLugar);
}


//Bergner nå endelig prisen 
//Må lage denne metoden som regner prisen 
//nyBillett.pris = beregnPris(innReiseinformasjon, innLugar);

//Nå som har billetten fått alle nødvendig data og er komplett så kan jeg adde den til databasen 
_db.billetter.Add(nyBillett);
await _db.SaveChangesAsync();
return true;
}

catch
{
return false;
}
}

/* public double beregnPris(Reiseinformasjon info, Lugarer thisLugar)
{ // Barn betaler ikke kun voksne 
try
{
double startPris = 00; // dette er start prisen
                       //disse to funskjonene skal utvikles etterhvert 
double lugarerPris = beregnLugarerPris();
double andreTjenesterPris = beregntjenesterPris();
double Total = startPris + lugarerPris + andreTjenesterPris;
return Total;
}
catch
{
return -1;
}
}

public double beregnLugarerPris()
{
return -1;
}

public double beregntjenesterPris()
{
return -2;
}

[Route("{id}")]
public async Task velgLugar(int id)
{
Lugarer lugar = await _db.lugarer.FirstOrDefaultAsync(k => k.LId == id);
if (lugar != null)
{
_db.lugarer.Add(lugar);
await _db.SaveChangesAsync();
}
}


[Route("{id}")]
public async Task<bool> fjernLugar(int id)
{

try
{
Lugarer lugar = await _db.lugarer.FirstOrDefaultAsync(k => k.LId == id);
if (lugar != null)
{
    _db.lugarer.Remove(lugar);
    await _db.SaveChangesAsync();
}
return true;
}
catch
{
return false;
}
}
}*/

