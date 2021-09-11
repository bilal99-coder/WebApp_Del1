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
    public class NesteController : Controller
    {
        private Billett billett;

        public NesteController()
        {


        }


        public void hentBillett()
        {

            if (TempData.ContainsKey("billett"))
                this.billett = ((Billett)JsonConvert.DeserializeObject<Billett>(TempData["billett"].ToString()));

        }
    }
}