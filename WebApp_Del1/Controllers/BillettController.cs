using billetter.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApp_Del1.Controllers
{
	[Route("[Controller]/[action]")]
	public class BillettController : ControllerBase
    {
        private List<Lugar> lugarer;
        private Billett billett;

        public BillettController()
        {
            this.lugarer = new List<Lugar>();
            Lugar lugar = new Lugar();

        }



        [Route("{id}")]
        public void velgLugar(int id)
        {
            this.billett.lugarId = id;


        }

        public List<Lugar> hentLugarer()
        {
            return this.lugarer;
        }
    }
}