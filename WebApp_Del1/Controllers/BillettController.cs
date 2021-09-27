using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Del1.Contexts;
using WebApp_Del1.Models;

namespace WebApp_Del1.Controllers
{
    [Route("[Controller]/[action]")]
    public class BillettController : ControllerBase
    {
      


        private readonly BillettContext _db;

        public BillettController(BillettContext db)
        {
            _db = db;
        }

        //Alle disse parameterene  får vi fra Javascript  Klienten 
        public void Bestill(Reiseinformasjon innReiseinformasjon, int [] lugar_Id, Person [] personerIBiletteten)
        {  //Jeg regner med at jeg får et array at av person objekter fra javascript
            //Betaleren får jeg data om fra reiseinformasjon klasse, andre personer får jeg data om fra et array av personer 
            //Instansierer nå en ny billett 
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
            Betalere funnetBetaler = _db.Betalere.FirstOrDefault(k=>k.personId == innReiseinformasjon.personId );
            //Hvis personen ikke finnes fra foor i databasen saa lager vi en ny person "enNyBetaler"
            if(funnetBetaler == null)
            {
                enNyBetaler.kortholdersNavn = innReiseinformasjon.kortholdersNavn;
                enNyBetaler.cvc = innReiseinformasjon.cvc;
                enNyBetaler.kortNummer = innReiseinformasjon.kortNummer; 
                enNyBetaler.fornavn = innReiseinformasjon.fornavn; 
                enNyBetaler.etternavn = innReiseinformasjon.etternavn; 
                enNyBetaler.addresse = innReiseinformasjon.addresse; 
                enNyBetaler.personId = innReiseinformasjon.personId;
                nyBillett.betaleren = enNyBetaler;
                //Adde personen som betalte til listen av personer i billetten 
                //vi trenger ikke å lage betaleren på listen av personer i billetten siden betaleren blir lagret som et eget attributt i billetten 
                //Oppdatere databasen av personer med ny betaleren
                _db.Betalere.Add(enNyBetaler); 
                _db.SaveChanges(); 
            }
            //Hvis personen finnes fra foor i databasen saa henter vi henne, og adder henne til listen av personer i billetten 
           
            else
            {
                nyBillett.betaleren = funnetBetaler; 
            }

            //Nå etter at jeg hentet data om selve reisen og data om betaleren, nå vil jeg å hente data om andre passasjerer 

            foreach( Person enPerson in personerIBiletteten)
                {
                    //skjekker først om vi har kunden(Person =? enPerson) på databasen fra før
                     Personer funnetKunde = _db.personer.FirstOrDefault(hverPerson =>hverPerson.personId == enPerson.personId);
                    //Instansierer enNyPerson objekt som vi skal bruke om vi ikke har den passasjereren i databasen 
                    Personer enNyPerson = new Personer();
                    if(funnetKunde == null)//Hvis kunden finnes ikke i databasen fra foor 
                    {
                        enNyPerson.personId = enPerson.personId; 
                        enNyPerson.fornavn = enPerson.fornavn; 
                        enNyPerson.etternavn = enPerson.etternavn; 
                        enNyPerson.addresse = enPerson.addresse; 
                        //Må nå adde en enNyPerson til Listen: billettPersoner
                        nyBillett.billettPersoner.Add(enNyPerson);
                        _db.personer.Add(enNyPerson);
                        _db.SaveChanges(); 
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
            //Henter oonsket lugar fra databasen av alle lugarer 
            Lugarer funnetLugar = _db.lugarer.FirstOrDefault(k => k.LId == innReiseinformasjon.LugarId);


            //Approach 2 for lugarer 
            int antallLugar1 = 0;
            int antallLugar2 = 0;
            int antallLugar3 = 0;
            int antallLugar4 = 0; 
            int antallLugar5 = 0;

            /* 
             
            int lugar_Id = {1,1,5,4,1};


             
             */ 

            foreach(int id in lugar_Id)
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
                else  antallLugar5++; // 0+1 = 1
                
            }
            antallLugar1 = 3;
            antallLugar5 = 1;
           
            //billetten skal ha en liste av lugarer 


            /*
             * 
             * public void Bestill(Reiseinformasjon innReiseinformasjon, int [] lugarId , Person [] personerIBiletteten)
             
                 Javascript : 
                    int [] idLugar = {1,1,1}; ,
                    Etter at kunden har trykket "Gå Videre"
                    Så henter du ønsket id-ene til ænsket lugarene. 
                    fyyle idLugar med de id-ene.
                    Sende dem til meg 
             
             */

            //Adder Lugaren til listen av lugarer i billetten 
            if (funnetLugar!= null)
            {
                nyBillett.billettLugarer.Add(funnetLugar); 
            }
            

            //Bergner nå endelig prisen 
            //Må lage denne metoden som regner prisen 
            nyBillett.pris = beregnPris(innReiseinformasjon, innLugar);

            //Nå som har billetten fått alle nødvendig data og er komplett så kan jeg adde den til databasen 
            _db.billetter.Add(nyBillett);
            _db.SaveChanges(); 
            /*

            //Approach NR1
            Betalere enBetaler = new Betalere (); 
            foreach(Betaler aPerson in personerIBiletteten)
            {
                if (aPerson.GetType().IsInstanceOfType(Betaler))
                {
                   enBetaler.kortholdersNavn = aPerson.kortholdersNavn;
                   enBetaler.cvc = aPerson.cvc;
                   enBetaler.kortNummer = aPerson.kortNummer; 
                   enBetaler.fornavn = aPerson.fornavn; 
                   enBetaler.etternavn = aPerson.etternavn; 
                   enBetaler.addresse = aPerson.addresse; 
                   enBetaler.personId = aPerson.personId; 
                }
            }
            //Adder nå betaleren til listen av personer i Billetten 
            nyBillett.billettPersoner.Add(enBetaler); 
            
            //Tar ut nå alle personer fra Person arrayet (personerIBiletteten)
            foreach(Person aPassanger in personerIBiletteten)
            {
                if (!(aPassanger.GetType().IsInstanceOfType(Betaler)))
                {
                    //skjekker først om vi har kunden på databasen fra før 
                    //Hvis ikke så må vi adde personen til databasen 
                    Personer funnetKunde = _db.personer.FirstOrDefault(k => k.personId == innReiseinformasjon.personId);
                }
            }

            //Fyller nå billetten med data og info om reisen som vi får fra hoved siden
            nyBillett.fra = innReiseinformasjon.fra;
            nyBillett.til = innReiseinformasjon.til;
            nyBillett.antallBarn = innReiseinformasjon.antallBarn;
            nyBillett.antallVoksne = innReiseinformasjon.antallVoksne;
            nyBillett.antallReisende = innReiseinformasjon.antallReisende; 
            nyBillett.tidspunkt = innReiseinformasjon.utreise.ToString();
            nyBillett.type = innReiseinformasjon.reiseType;
            //Må lage denne metoden 
            nyBillett.pris = beregnPris(innReiseinformasjon, innLugar);
            // fyller nå Listen over personer i billetten
            //skjekker først om vi har kunden på databasen fra før 
            Personer funnetKunde = _db.personer.FirstOrDefault(k => k.personId == innReiseinformasjon.personId);
            // et eksempel:   for (if = 0; i< antallPesoner, ++i){
            //Lage en nyperson 

            //Adde personen i PersonListen  I  selve billetten 

            //Oppdatere databasen men nye personer og den nye billetten 
            // }
            // Jeg tenker på å ha public void Bestill(Reiseinformasjon [] innReiseinformasjon, Lugarer innLugar)
            //Jeg vil ha (et array med flere reiseInformasjon objekter) som input 

            if (funnetKunde == null)
            {
                //opprett kunden 
                var nyPerson = new Personer();
                //nyPerson.personId = innReiseinformasjon.personId;
                nyPerson.fornavn = innReiseinformasjon.fornavn;
                nyPerson.etternavn = innReiseinformasjon.etternavn;
                nyPerson.addresse = innReiseinformasjon.addresse;

                //Oprette betaler 
                var nyBetaler = new Betaler();
                nyBetaler.kortholdersNavn = innReiseinformasjon.kortholdersNavn;
                nyBetaler.cvc = innReiseinformasjon.cvc;
                nyBetaler.kortNummer = innReiseinformasjon.kortNummer;
                //legg personen i billetten
                nyBillett.billettPersoner.Add(nyPerson);
                //oppdatere personer databasen 
                _db.personer.Add(nyPerson);
                _db.SaveChanges();
            }
            else
            {
                nyBillett.billettPersoner.Add(funnetKunde);
                //her trenger vi ikke å oppdatere databasen fordi personen finens allerede i databasen 
            }

            //Lage en lugar objekt 


            //Adde lugaren (eller lugarer) til billetten 

            //Adde den nye billetten til databasen 
            _db.billetter.Add(nyBillett);
            _db.SaveChanges();
            */
        }

        public double beregnPris (Reiseinformasjon info, Lugarer thisLugar)
        { // Barn betaler ikke kun voksne 
            double startPris = 00; // dette er start prisen
            //disse to funskjonene skal utvikles etterhvert 
            double lugarerPris = beregnLugarerPris();
            double andreTjenesterPris = beregntjenesterPris();
            double Total = startPris + lugarerPris + andreTjenesterPris;
            return Total; 
        }

        public static double beregnLugarerPris()
        {
            return -1; 
        }

        public static double beregntjenesterPris()
        {
            return -2; 
        }

        [Route("{id}")]
        public void velgLugar(int id)
        {
            Lugarer lugar = _db.lugarer.Find(id);
            if (lugar != null)
            {
                    _db.lugarer.Add(lugar);
            
            }
        }


        [Route("{id}")]
        public void fjernLugar(int id)
        {
            Lugarer lugar = _db.lugarer.Find(id);
            if (lugar != null)
            {
                _db.lugarer.Remove(lugar);

            }



        }

        /*

        [HttpPost]
        public async Task<bool> lagrePerson(Person innPerson)
        {
            try
            {
                var nyPersonRad = new Personer();
                nyPersonRad.personId = innPerson.personId; 
                nyPersonRad.fornavn = innPerson.fornavn;
                nyPersonRad.etternavn = innPerson.etternavn;
                nyPersonRad.addresse = innPerson.addresse;
                


            }
            catch
            {
                return false; 
            }



















            if (person != null)
            {
                personer.Add(person);

            }

        }

        [Route("{id}")]
        public void fjernPerson(int id)
        {
            Personer person = _db.personer.Find(id);
            if (person != null)
            {
                _db.personer.Remove(person);

            }



        }


        public List<Lugarer> hentLugarer()
        {
            return _db.lugarer.ToList();
        }

        //Funksjon for debuging
        public List<Billett> hentBilletter()
        {
            return _db.billetter.ToList();
        }
        public void registrerBillett()
        {

            
            _db.billetter.Add(billett);

            _db.SaveChanges();

            _db.personer.ForEach((x) =>
            {
                _lugDb.Add(x);

                _lugDb.SaveChanges();
                BillettPerson billettPerson = new BillettPerson();

                billettPerson.billettId = billett.billettId;


                billettPerson.personId = x.personId;
  
                _lugDb.billettPerson.Add(billettPerson);
     

            });


            lugarer.ForEach((x) =>
            {
                BillettLugar billettLugar = new BillettLugar();

                billettLugar.billettId = billett.billettId;
       

                billettLugar.lugarId = x.lugarId;
         
 

                _lugDb.billettLugar.Add(billettLugar);
   

            });

          
   
   
            _db.SaveChanges();
            nyBillett(); 
        }*/

        public static void Main (string [] args)
        {
            System.Console.WriteLine("beaølkrnbeak");
        }
    }
}