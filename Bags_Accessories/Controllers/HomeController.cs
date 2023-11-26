using Bags_Accessories.Data;
using Bags_Accessories.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing.Printing;

namespace Bags_Accessories.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly ShopDbContext _DbContext;

        public HomeController(ILogger<HomeController> logger, ShopDbContext DbContext)
        {
            _logger = logger;
            _DbContext = DbContext;
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Index()
        {
            //    CommentBag commentBag = new CommentBag();
            //    commentBag.BagID=4;
            //    commentBag.CommentTXT="hi good product";
            //    commentBag.Email="sdd@sdsd.com";
            //    commentBag.Name="george";
            //    _DbContext.CommentBag.Add(commentBag);
            //    _DbContext.SaveChanges();

            //var bag4 = _DbContext.Bags.Include(x=>x.BagComments).SingleOrDefault(x=>x.ID==4);
            //var ccc = bag4.BagComments.ToList();


            var products = _DbContext.Bags.OrderByDescending(x => x.ID).ToList();
            ViewBag.WomenBags = _DbContext.Bags.Where(x => x.Gender==1).OrderByDescending(x => x.ID).ToList();
            ViewBag.ManBags = _DbContext.Bags.Where(x => x.Gender == 2).OrderByDescending(x => x.ID).ToList();
            ViewBag.Kidbags = _DbContext.Bags.Where(x => x.Gender == 3).OrderByDescending(x => x.ID).ToList();

            LoadImages();
            return View(products);

        }

        [HttpPost]
        public async Task<IActionResult> Index(string search)
        {

            LoadImages();

            if (!string.IsNullOrEmpty(search))
            {
                var products = await _DbContext.Bags.Where(x => x.Name.Contains(search)).ToListAsync();
                return View(products);
            }
            else
            {
                return View(await _DbContext.Bags.ToListAsync());
            }
        }

        private void LoadImages()
        {
            Settings mainImg1 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "MainPageImg1");
            Settings mainImg2 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "MainPageImg2");
            Settings mainImg3 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "MainPageImg3");
            Settings mainImg4 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "MainPageImg4");
            Settings mainImg5 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "MainPageImg5");

            if (mainImg1 != null || mainImg2 != null || mainImg3 != null || mainImg4 != null || mainImg5 != null)
            {
                ViewBag.MainImg1FileName = mainImg1.SettingValue;
                ViewBag.MainImg2FileName = mainImg2.SettingValue;
                ViewBag.MainImg3FileName = mainImg3.SettingValue;
                ViewBag.MainImg4FileName = mainImg4.SettingValue;
                ViewBag.MainImg5FileName = mainImg5.SettingValue;
            }
        }

        public IActionResult DetailsBag(int ID)
        {
            var bag = _DbContext.Bags.SingleOrDefault(x => x.ID==ID);
            return View(bag);
        }

        [HttpPost]
        public IActionResult DetailsBag(CommentBag Comment)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Comment.ID = 0;
            //Comment.CreateDate = DateTime.Now;
            _DbContext.CommentBag.Add(Comment);
            _DbContext.SaveChanges();


            var bag = _DbContext.Bags.SingleOrDefault(x => x.ID==Comment.BagID);
            return View(bag);
        }
        public IActionResult DetailsAccessorie(int ID)
        {
            var acce = _DbContext.Accessories.SingleOrDefault(x => x.ID==ID);
            return View(acce);
        }

        [HttpGet]
        public IActionResult WomensBags()
        {
            var products = _DbContext.Bags.Where(x => x.Gender==1).OrderByDescending(x => x.ID).ToList();

            LoadImages();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> WomensBags(string search)
        {
            LoadImages();
            if (!string.IsNullOrEmpty(search))
            {
                var products = await _DbContext.Bags.Where(x => search!=null && x.Gender == 1 && x.Name.Contains(search)).ToListAsync();
                return View(products);
            }
            else
            {
                return View(await _DbContext.Bags.Where(x => x.Gender == 1).ToListAsync());
            }
        }
        public IActionResult WomansAccessories()
        {
            return View();
        }
        public IActionResult MansBags()
        {
            return View();
        }

        public IActionResult MansAccessories()
        {
            return View();
        }
        public IActionResult KidsBags()
        {
            return View();
        }
        public IActionResult KidsAccessories()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        //public IActionResult Login(User model)
        //{
        //    //_DbContext.adminPanels.Where(x = > == )
        //    //shemocemba model.username model.password tu scoria.

        //    if (true)//aq piroba tu scoria
        //    {
        //        return RedirectToAction("Index", "Admin");
        //    }
        //    else
        //        return View();
        //}
        
       
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}