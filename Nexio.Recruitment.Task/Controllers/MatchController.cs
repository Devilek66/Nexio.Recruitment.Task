using Nexio.Recruitment.Task.Models.ViewModels;
using Nexio.Recruitment.Task.Services.ServicesInterfaces;
using System.Web.Mvc;

namespace Nexio.Recruitment.Task.Controllers
{
    public class MatchController : Controller
    {
        private readonly IPairingService _pairingService;

        public MatchController(IPairingService pairingService)
        {
            _pairingService = pairingService;
        }

        public ActionResult Woman()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Woman(PersonViewModel person)
        {
            Session["Woman"] = person;
            return RedirectToAction("Man");
        }

        public ActionResult Man()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Man(PersonViewModel person)
        {
            Session["Man"] = person;
            return RedirectToAction("Result");
        }

        public ActionResult Result()
        {
            PersonViewModel woman = (PersonViewModel)Session["Woman"];
            PersonViewModel man = (PersonViewModel)Session["Man"];

            ResultViewModel result = new ResultViewModel
            {
                Match = _pairingService.DoTheyMatch(woman, man),
                WomanName = woman.Name,
                ManName = man.Name
            };

            return View(result);
        }
    }
}