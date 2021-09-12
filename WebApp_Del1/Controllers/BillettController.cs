
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

        public BillettController()
        {
            Lugar lugar = new Lugar("/te","test");
            _lugDb.lugarer.Add(lugar);
            _lugDb.SaveChanges();

        }



        [Route("{id}")]
        public void velgLugar(int id)
        {

            this.billett.lugarId = id;


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