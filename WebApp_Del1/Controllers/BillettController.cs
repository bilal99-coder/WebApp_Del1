
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

        private readonly BillettContext _lugDb;
        
        public BillettController(BillettContext db)
        {
            _lugDb = db;


        }



        [Route("{id}")]
        public void velgLugar(int id)
        {

            //this.billett. = id;


        }

        public List<Lugar> hentLugarer()
        {
            return _lugDb.lugarer.ToList();
        }

        public void registrerBillett()
        {
            _lugDb.billetter.Add(billett);
            _lugDb.SaveChanges();
        }
    }
}