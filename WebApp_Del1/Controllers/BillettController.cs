
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApp_Del1.Contexts;

namespace WebApp_Del1.Controllers
{
    [Route("[Controller]/[action]")]
    public class BillettController : ControllerBase
    {
        //Personer plasseres ikke inn her
        private Billett billett;
        
        //lugarer plasseres inn her
        private List<BillettLugar> lugarer;

        //personer plasseres inn her
        private List<BillettPerson> personer;

        private readonly BillettContext _lugDb;

        public BillettController(BillettContext db)
        {
 
            _lugDb = db;
            nyBillett();



        }

        public void nyBillett()
        {
            this.billett = new Billett();
            this.lugarer = new List<BillettLugar>();
            this.personer = new List<BillettPerson>();
        }

        [Route("{id}")]
        public void velgLugar(int id)
        {
            Lugar lugar = _lugDb.lugarer.Find(id);
            if (lugar != null)
            {
                BillettLugar billettLugar = new BillettLugar();
                billettLugar.billettId    = this.billett.billettId;
                billettLugar.lugar = lugar;
                billettLugar.lugarId = lugar.lugarId;
                lugarer.Add(billettLugar);

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
            lugarer.ForEach((x) => _lugDb.billettlugar.Add(x));
            personer.ForEach((x) => _lugDb.billettperson.Add(x));
          
            _lugDb.SaveChanges();
        }
    }
}