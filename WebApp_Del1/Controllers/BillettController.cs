using Microsoft.AspNetCore.Mvc;

namespace WebApp_Del1.Controllers
{
	[Route("[Controller]/[action]")]
	public class BillettController : ControllerBase
    {
        private Billett billett;

        private readonly BillettContext _lugDb;

        public BillettController()
        {
            Lugar lugar = new Lugar();

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