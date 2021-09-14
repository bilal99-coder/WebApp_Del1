using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp_Del1.Contexts;

namespace WebApp_Del1.Controllers
{
    [Route("[Controller]/[action]")]
    public class BillettController : ControllerBase
    {
        //Vil ikke bli problemer med flere brukere - sjekket.
        //Ulike brukere delere ikke statiske variabler i kontrollere.
        private static Billett billett = new Billett();
        private static List<Person> personer = new List<Person>();
        private static List<Lugar> lugarer = new List<Lugar>();


        private readonly BillettContext _lugDb;

        public BillettController(BillettContext db)
        {
 
            _lugDb = db;
          //  nyBillett();
          // kommentar



        }

        public void nyBillett()
        {
            billett = new Billett();
            personer = new List<Person>();
            lugarer = new List<Lugar>();

        }

        [Route("{id}")]
        public void velgLugar(int id)
        {
            Lugar lugar = _lugDb.lugarer.Find(id);
            if (lugar != null)
            {
                lugarer.Add(lugar);
            
            }



        }


        [Route("{id}")]
        public void fjernLugar(int id)
        {
            Lugar lugar = _lugDb.lugarer.Find(id);
            if (lugar != null)
            {
                lugarer.Remove(lugar);

            }



        }

        [HttpPost]
        public void lagrePerson(Person person)
        {
            if (person != null)
            {
                personer.Add(person);

            }

        }

        [Route("{id}")]
        public void fjernPerson(int id)
        {
            Person person = _lugDb.personer.Find(id);
            if (person != null)
            {
                personer.Remove(person);

            }



        }


        public List<Lugar> hentLugarer()
        {
            return _lugDb.lugarer.ToList();
        }

        //Funksjon for debuging
        public List<Billett> hentBilletter()
        {
            return _lugDb.billetter.ToList();
        }
        public void registrerBillett()
        {


            _lugDb.billetter.Add(billett);

            _lugDb.SaveChanges();

            personer.ForEach((x) =>
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

          
   
   
            _lugDb.SaveChanges();
            nyBillett(); 
        }
    }
}