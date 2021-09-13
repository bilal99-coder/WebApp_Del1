
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp_Del1.Contexts;

namespace WebApp_Del1.Controllers
{
    [Route("[Controller]/[action]")]
    public class BillettController : ControllerBase
    {

        private Billett billett;
        private List<Person> personer;
        private List<Lugar> lugarer;


        private readonly BillettContext _lugDb;

        public BillettController(BillettContext db)
        {
 
            _lugDb = db;
            nyBillett();



        }

        public void nyBillett()
        {
            this.billett = new Billett();
            this.personer = new List<Person>();
            this.lugarer = new List<Lugar>();

        }

        [Route("{id}")]
        public void velgLugar(int id)
        {
            Lugar lugar = _lugDb.lugarer.Find(id);
            if (lugar != null)
            {
                this.lugarer.Add(lugar);
            
            }



        }


        [Route("{id}")]
        public void fjernLugar(int id)
        {
            Lugar lugar = _lugDb.lugarer.Find(id);
            if (lugar != null)
            {
                this.lugarer.Remove(lugar);

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

            personer.ForEach((x) =>
            {
                BillettPerson billettPerson = new BillettPerson();

                billettPerson.billettId = this.billett.billettId;
                billettPerson.billett   = this.billett;

                billettPerson.personId = x.personId;
                billettPerson.person    = x;

                _lugDb.billettPerson.Add(billettPerson);
                
               
            });


            lugarer.ForEach((x) =>
            {
                BillettLugar billettLugar = new BillettLugar();

                billettLugar.billettId = this.billett.billettId;
                billettLugar.billett = this.billett;

                billettLugar.lugarId = x.lugarId;
                billettLugar.lugar = x;

                _lugDb.billettLugar.Add(billettLugar);


            });

          
   
   
            _lugDb.SaveChanges();
        }
    }
}