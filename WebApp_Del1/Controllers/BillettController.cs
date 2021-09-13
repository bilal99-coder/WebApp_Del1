
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
        private static Person person = new Person();
        private static Lugar lugar;


        private readonly BillettContext _lugDb;

        public BillettController(BillettContext db)
        {
 
            _lugDb = db;
          //  nyBillett();



        }

        public void nyBillett()
        {
            billett = new Billett();
            person = new Person();
            lugar = new Lugar();

        }

        [Route("{id}")]
        public void velgLugar(int id)
        {
            Lugar lugaren = _lugDb.lugarer.Find(id);
            if (lugar != null)
            {
                lugar = lugaren;
            
            }



        }


        [Route("{id}")]
        public void fjernLugar(int id)
        {
            Lugar lugaren = _lugDb.lugarer.Find(id);
            if (lugar != null)
            {
                lugar = null;

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
            person.personId = billett.billettId;
            _lugDb.personer.Add(person);

            _lugDb.billetter.Add(billett);
  
            _lugDb.SaveChanges();
   
           
        }
    }
}