
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp_Del1.Contexts;

namespace WebApp_Del1.Controllers
{
    [Route("[Controller]/[action]")]
    public class BillettController : ControllerBase
    {

        private static Billett billett;
        private static List<Person> personer;
        private static List<Lugar> lugarer;


        private readonly BillettContext _lugDb;

        public BillettController(BillettContext db)
        {
 
            _lugDb = db;
          //  nyBillett();



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
           billett.billettPerson = new List<BillettPerson>();
           billett.billettLugar = new List<BillettLugar>();

            _lugDb.billetter.Add(billett);

            personer.ForEach((x) =>
            {
                BillettPerson billettPerson = new BillettPerson();

                billettPerson.billettId = billett.billettId;
                billettPerson.billett   = billett;

                billettPerson.personId = x.personId;
                billettPerson.person    = x;
                billett.billettPerson.Add(billettPerson);
                _lugDb.billettPerson.Add(billettPerson);
     

            });


            lugarer.ForEach((x) =>
            {
                BillettLugar billettLugar = new BillettLugar();

                billettLugar.billettId = billett.billettId;
                billettLugar.billett = billett;

                billettLugar.lugarId = x.lugarId;
                billettLugar.lugar = x;
                billett.billettLugar.Add(billettLugar);

                _lugDb.billettLugar.Add(billettLugar);
   

            });

          
   
   
            _lugDb.SaveChanges();
        }
    }
}