using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        public void nyBillett()
        {
            
        }

        public void Bestill(Reiseinformasjon innReiseinformasjon, Lugarer innLugar)
        {
            // returnerer ikke noe her, ingen feilhåndtering mot databasen her
            //Instansierer nå en ny billett 
            var nyBillett = new Billett();
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
            }

            //Lage en lugar objekt 


            //Adde lugaren (eller lugarer) til billetten 

            //Adde den nye billetten til databasen 
            _db.billetter.Add(nyBillett);
            _db.SaveChanges();

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
            Lugarer lugar = _lugDb.lugarer.Find(id);
            if (lugar != null)
            {
                lugarer.Remove(lugar);

            }



        }

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
        }
    }
}