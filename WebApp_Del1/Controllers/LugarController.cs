using billetter.Model;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace billetter.Controllers

{
    [Route("[controller]/[action]")]
    public class LugarController : Controller
    {
        private List<Lugar> lugarer;
        private Billett billett;

        public LugarController()
        {
            this.lugarer = new List<Lugar>();

        }



        [Route("{id}")]
        public ActionResult velgLugar(int id)
        {
            Billett billett = new Billett();

            billett.lugarId = id;
            TempData["billett"] = JsonConvert.SerializeObject(billett);


            return RedirectToAction("hentBillett", "neste");


        }

        public List<Lugar> hentLugarer()
        {
            return this.lugarer;
        }

        public void hentBillett()
        {

            if (TempData.ContainsKey("billett"))
                this.billett = ((Billett)JsonConvert.DeserializeObject<Billett>(TempData["billett"].ToString()));

        }


    }
}