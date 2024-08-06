using System.Threading.Tasks;
using System.Web.Mvc;
using apiconsume2.Models;
using apiconsume2.Repositories;

namespace YourNamespace.Controllers
{
    public class SBrewController : Controller
    {
        private readonly SBrewRepository _sbrewRepository;

        public SBrewController()
        {
            _sbrewRepository = new SBrewRepository();
        }

        // GET: /SBrew/
        [HttpGet]
        public async Task<ActionResult> Index(int pageno = 1, int pagesize = 10)
        {
            var sbrews = await _sbrewRepository.GetSBrewsAsync(pageno, pagesize);
            return View(sbrews);
        }

        
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, "Invalid ID provided.");
            }

            var sbrew = await _sbrewRepository.GetSBrewByIdAsync(id);
            if (sbrew == null)
            {
                return HttpNotFound();
            }
            return View(sbrew);
        }
    }
}
