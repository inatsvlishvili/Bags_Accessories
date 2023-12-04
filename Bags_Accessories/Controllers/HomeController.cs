using Bags_Accessories.Data;
using Bags_Accessories.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Security.Claims;

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
        [HttpPost]
        public IActionResult Contact(ContactUs contact)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            //contact.ID = 0;
            contact.CreatedateTime = DateTime.Now;
            _DbContext.ContactUs.Add(contact);
            _DbContext.SaveChanges();

            ViewBag.send = "წარმატებით გაიგზავნა";
            var call = _DbContext.ContactUs.SingleOrDefault(x => x.ID == contact.ID);
            return View(call);
        }

        public IActionResult ClientOrder(int? BagId, int? AccessorieId)
        {
            ViewBag.BagId = BagId;
            ViewBag.AccessorieId = AccessorieId;
            return View();
        }
        [HttpPost]
        public IActionResult ClientOrder(OrderClient order)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            order.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            order.CreatedateTime = DateTime.Now;
            _DbContext.OrderClients.Add(order);
            _DbContext.SaveChanges();

            ViewBag.send = "წარმატებით დასრულდა ყიდვა";
            var call = _DbContext.OrderClients.SingleOrDefault(x => x.ID == order.ID);
            return View(call);
        }


      
        public IActionResult Index()
        {
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //OrderClient order = new OrderClient();
            //order.UserId = userId;

            //var products = _DbContext.Bags.OrderByDescending(x => x.ID).ToList();
            ViewBag.WomenBags = _DbContext.Bags.Where(x => x.Gender == 1).OrderByDescending(x => x.ID).ToList();
            ViewBag.ManBags = _DbContext.Bags.Where(x => x.Gender == 2).OrderByDescending(x => x.ID).ToList();
            ViewBag.Kidbags = _DbContext.Bags.Where(x => x.Gender == 3).OrderByDescending(x => x.ID).ToList();
            ViewBag.WomenAccessorie = _DbContext.Accessories.Where(x => x.Gender == 1).OrderByDescending(x => x.ID).ToList();
            ViewBag.ManAccessorie = _DbContext.Accessories.Where(x => x.Gender == 2).OrderByDescending(x => x.ID).ToList();
            ViewBag.KidAccessorie = _DbContext.Accessories.Where(x => x.Gender == 3).OrderByDescending(x => x.ID).ToList();

            LoadImages();
            //return View(products);
            return View();

        }

        [HttpPost]
        public IActionResult Index(string search)
        {

            LoadImages();
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.WomenBags = _DbContext.Bags.Where(x => x.Gender == 1 && x.Name.Contains(search)).OrderByDescending(x => x.ID).ToList();
                ViewBag.ManBags = _DbContext.Bags.Where(x => x.Gender == 2 && x.Name.Contains(search)).OrderByDescending(x => x.ID).ToList();
                ViewBag.Kidbags = _DbContext.Bags.Where(x => x.Gender == 3 && x.Name.Contains(search)).OrderByDescending(x => x.ID).ToList();
                ViewBag.WomenAccessorie = _DbContext.Accessories.Where(x => x.Gender == 1 && x.Name.Contains(search)).OrderByDescending(x => x.ID).ToList();
                ViewBag.ManAccessorie = _DbContext.Accessories.Where(x => x.Gender == 2 && x.Name.Contains(search)).OrderByDescending(x => x.ID).ToList();
                ViewBag.KidAccessorie = _DbContext.Accessories.Where(x => x.Gender == 3 && x.Name.Contains(search)).OrderByDescending(x => x.ID).ToList();
            }
            else
            {
                ViewBag.WomenBags = _DbContext.Bags.Where(x => x.Gender == 1).OrderByDescending(x => x.ID).ToList();
                ViewBag.ManBags = _DbContext.Bags.Where(x => x.Gender == 2).OrderByDescending(x => x.ID).ToList();
                ViewBag.Kidbags = _DbContext.Bags.Where(x => x.Gender == 3).OrderByDescending(x => x.ID).ToList();
                ViewBag.WomenAccessorie = _DbContext.Accessories.Where(x => x.Gender == 1).OrderByDescending(x => x.ID).ToList();
                ViewBag.ManAccessorie = _DbContext.Accessories.Where(x => x.Gender == 2).OrderByDescending(x => x.ID).ToList();
                ViewBag.KidAccessorie = _DbContext.Accessories.Where(x => x.Gender == 3).OrderByDescending(x => x.ID).ToList();
            }
            return View();
        }

        private void LoadImages()
        {

            Settings mainImg1 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "MainPageImg1");
            Settings mainImg2 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "MainPageImg2");
            Settings mainImg3 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "MainPageImg3");
            Settings mainImg4 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "MainPageImg4");
            Settings mainImg5 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "MainPageImg5");

            Settings otherImg1 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "OtherPageImg1");
            Settings otherImg2 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "OtherPageImg2");
            Settings otherImg3 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "OtherPageImg3");
            Settings otherImg4 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "OtherPageImg4");
            Settings otherImg5 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "OtherPageImg5");
            Settings otherImg6 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "OtherPageImg6");
            Settings otherImg7 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "OtherPageImg7");
            Settings otherImg8 = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "OtherPageImg8");

            if (mainImg1 != null || mainImg2 != null || mainImg3 != null || mainImg4 != null || mainImg5 != null || otherImg1 != null || otherImg2 != null || otherImg3 != null || otherImg4 != null || otherImg5 != null || otherImg6 != null || otherImg7 != null || otherImg8 != null)
            {
                ViewBag.MainImg1FileName = mainImg1.SettingValue;
                ViewBag.MainImg2FileName = mainImg2.SettingValue;
                ViewBag.MainImg3FileName = mainImg3.SettingValue;
                ViewBag.MainImg4FileName = mainImg4.SettingValue;
                ViewBag.MainImg5FileName = mainImg5.SettingValue;


                ViewBag.WomenBagImg = otherImg1.SettingValue;
                ViewBag.ManBagImg = otherImg2.SettingValue;
                ViewBag.KidBagImg = otherImg3.SettingValue;
                ViewBag.WomenAccessorieImg = otherImg4.SettingValue; 
                ViewBag.ManAccessorieImg = otherImg5.SettingValue;
                ViewBag.KidAccessorieImg = otherImg6.SettingValue;
                ViewBag.ContactImg = otherImg7.SettingValue;
                ViewBag.OrderImg = otherImg8.SettingValue;


            }
        }

        public IActionResult DetailsBag(int ID)
        {

            var bag = _DbContext.Bags.SingleOrDefault(x => x.ID == ID);
            ViewBag.Comments = _DbContext.Comment.Where(x => x.BagID == bag.ID).ToList();
            return View(bag);
        }

        [HttpPost]
        public IActionResult DetailsBag(CommentClient Comment)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            
            //Comment.ID = 0;
            Comment.CreatedateTime = DateTime.Now;
            Comment.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _DbContext.Comment.Add(Comment);
            _DbContext.SaveChanges();

            var bag = _DbContext.Bags.SingleOrDefault(x => x.ID == Comment.BagID);
            ViewBag.Comments = _DbContext.Comment.Where(x => x.BagID == bag.ID).ToList();
            return View(bag);
        }
        public IActionResult DetailsAccessorie(int ID)
        {
            var accessorie = _DbContext.Accessories.SingleOrDefault(x => x.ID == ID);
            ViewBag.Comments = _DbContext.Comment.Where(x => x.AccessorieID == accessorie.ID).ToList();
            return View(accessorie);
        }

        [HttpPost]
        public IActionResult DetailsAccessorie(CommentClient Comment)
        {
            Comment.CreatedateTime = DateTime.Now;
            Comment.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _DbContext.Comment.Add(Comment);
            _DbContext.SaveChanges();

            var accessorie = _DbContext.Accessories.SingleOrDefault(x => x.ID == Comment.AccessorieID);
            ViewBag.Comments = _DbContext.Comment.Where(x => x.AccessorieID == accessorie.ID).ToList();
            return View(accessorie);
        }

        [HttpGet]
        public IActionResult WomensBags(string searchText = null, int? pageIndex = 1, int? pageSize = 21)
        {
            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages = (int)Math.Ceiling((decimal)_DbContext.Bags.Where(x => searchText != null && x.Gender == 1 && x.Name.Contains(searchText)).Count() / (decimal)pageSize);
            }
            else
            {
                totalPages = (int)Math.Ceiling((decimal)_DbContext.Bags.Where(x => x.Gender == 1).Count() / (decimal)pageSize);
            }

            LoadImages();

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Bags.Where(x => searchText != null && x.Gender == 1 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList());
                else
                    return View(_DbContext.Bags.Where(x => x.Gender == 1).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList());
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Bags.Where(x => searchText != null && x.Gender == 1 && x.Name.Contains(searchText)).ToList());
                else
                    return View(_DbContext.Bags.Where(x => x.Gender == 1).ToList());
            }

        }

        [HttpPost]
        public async Task<IActionResult> WomensBags(string searchText = null)
        {
            int? pageSize = 21;
            int? pageIndex = 1;

            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages = (int)Math.Ceiling((decimal)await _DbContext.Bags.Where(x => searchText != null && x.Gender == 1 && x.Name.Contains(searchText)).CountAsync() / (decimal)pageSize);
            }
            else
            {
                totalPages = (int)Math.Ceiling((decimal)await _DbContext.Bags.Where(x => x.Gender == 1).CountAsync() / (decimal)pageSize);
            }
            LoadImages();

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(await _DbContext.Bags.Where(x => searchText != null && x.Gender == 1 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync());
                else
                    return View(await _DbContext.Bags.Where(x => x.Gender == 1).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync());
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(await _DbContext.Bags.Where(x => searchText != null && x.Gender == 1 && x.Name.Contains(searchText)).ToListAsync());
                else
                    return View(await _DbContext.Bags.Where(x => x.Gender == 1).ToListAsync());
            }
        }

        public IActionResult MansBags(string searchText = null, int? pageIndex = 1, int? pageSize = 21)
        {
            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages = (int)Math.Ceiling((decimal)_DbContext.Bags.Where(x => searchText != null && x.Gender == 2 && x.Name.Contains(searchText)).Count() / (decimal)pageSize);
            }
            else
            {
                totalPages = (int)Math.Ceiling((decimal)_DbContext.Bags.Where(x => x.Gender == 2).Count() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Bags.Where(x => searchText != null && x.Gender == 2 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList());
                else
                    return View(_DbContext.Bags.Where(x => x.Gender == 2).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList());
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Bags.Where(x => searchText != null && x.Gender == 2 && x.Name.Contains(searchText)).ToList());
                else
                    return View(_DbContext.Bags.Where(x => x.Gender == 2).ToList());
            }

        }
        [HttpPost]
        public async Task<IActionResult> MansBags(string searchText = null)
        {
            int? pageSize = 21;
            int? pageIndex = 1;

            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages = (int)Math.Ceiling((decimal)await _DbContext.Bags.Where(x => searchText != null && x.Gender == 2 && x.Name.Contains(searchText)).CountAsync() / (decimal)pageSize);
            }
            else
            {
                totalPages = (int)Math.Ceiling((decimal)await _DbContext.Bags.Where(x => x.Gender == 2).CountAsync() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(await _DbContext.Bags.Where(x => searchText != null && x.Gender == 2 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync());
                else
                    return View(await _DbContext.Bags.Where(x => x.Gender == 3).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync());
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(await _DbContext.Bags.Where(x => searchText != null && x.Gender == 2 && x.Name.Contains(searchText)).ToListAsync());
                else
                    return View(await _DbContext.Bags.Where(x => x.Gender == 2).ToListAsync());
            }

        }

        public IActionResult KidsBags(string searchText = null, int? pageIndex = 1, int? pageSize = 21)
        {
            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages = (int)Math.Ceiling((decimal)_DbContext.Bags.Where(x => searchText != null && x.Gender == 3 && x.Name.Contains(searchText)).Count() / (decimal)pageSize);
            }
            else
            {
                totalPages = (int)Math.Ceiling((decimal)_DbContext.Bags.Where(x => x.Gender == 3).Count() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Bags.Where(x => searchText != null && x.Gender == 3 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList());
                else
                    return View(_DbContext.Bags.Where(x => x.Gender == 3).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList());
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Bags.Where(x => searchText != null && x.Gender == 3 && x.Name.Contains(searchText)).ToList());
                else
                    return View(_DbContext.Bags.Where(x => x.Gender == 3).ToList());
            }

        }
        [HttpPost]
        public async Task<IActionResult> KidsBags(string searchText = null)
        {
            int? pageSize = 21;
            int? pageIndex = 1;

            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages = (int)Math.Ceiling((decimal)await _DbContext.Bags.Where(x => searchText != null && x.Gender == 3 && x.Name.Contains(searchText)).CountAsync() / (decimal)pageSize);
            }
            else
            {
                totalPages = (int)Math.Ceiling((decimal)await _DbContext.Bags.Where(x => x.Gender == 3).CountAsync() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(await _DbContext.Bags.Where(x => searchText != null && x.Gender == 3 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync());
                else
                    return View(await _DbContext.Bags.Where(x => x.Gender == 3).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync());
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(await _DbContext.Bags.Where(x => searchText != null && x.Gender == 3 && x.Name.Contains(searchText)).ToListAsync());
                else
                    return View(await _DbContext.Bags.Where(x => x.Gender == 3).ToListAsync());
            }

        }

        public IActionResult WomensAccessories(string searchText = null, int? pageIndex = 1, int? pageSize = 21)
        {
            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages = (int)Math.Ceiling((decimal)_DbContext.Accessories.Where(x => searchText != null && x.Gender == 1 && x.Name.Contains(searchText)).Count() / (decimal)pageSize);
            }
            else
            {
                totalPages = (int)Math.Ceiling((decimal)_DbContext.Accessories.Where(x => x.Gender == 1).Count() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Accessories.Where(x => searchText != null && x.Gender == 1 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList());
                else
                    return View(_DbContext.Accessories.Where(x => x.Gender == 1).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList());
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Accessories.Where(x => searchText != null && x.Gender == 1 && x.Name.Contains(searchText)).ToList());
                else
                    return View(_DbContext.Accessories.Where(x => x.Gender == 1).ToList());
            }

        }

        [HttpPost]
        public async Task<IActionResult> WomensAccessories(string searchText = null)
        {
            int? pageSize = 21;
            int? pageIndex = 1;

            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages = (int)Math.Ceiling((decimal)await _DbContext.Accessories.Where(x => searchText != null && x.Gender == 1 && x.Name.Contains(searchText)).CountAsync() / (decimal)pageSize);
            }
            else
            {
                totalPages = (int)Math.Ceiling((decimal)await _DbContext.Accessories.Where(x => x.Gender == 1).CountAsync() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(await _DbContext.Accessories.Where(x => searchText != null && x.Gender == 1 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync());
                else
                    return View(await _DbContext.Accessories.Where(x => x.Gender == 1).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync());
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(await _DbContext.Accessories.Where(x => searchText != null && x.Gender == 1 && x.Name.Contains(searchText)).ToListAsync());
                else
                    return View(await _DbContext.Accessories.Where(x => x.Gender == 1).ToListAsync());
            }

        }

        public IActionResult MansAccessories(string searchText = null, int? pageIndex = 1, int? pageSize = 21)
        {
            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages = (int)Math.Ceiling((decimal)_DbContext.Accessories.Where(x => searchText != null && x.Gender == 2 && x.Name.Contains(searchText)).Count() / (decimal)pageSize);
            }
            else
            {
                totalPages = (int)Math.Ceiling((decimal)_DbContext.Accessories.Where(x => x.Gender == 2).Count() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Accessories.Where(x => searchText != null && x.Gender == 2 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList());
                else
                    return View(_DbContext.Accessories.Where(x => x.Gender == 2).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList());
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Accessories.Where(x => searchText != null && x.Gender == 2 && x.Name.Contains(searchText)).ToList());
                else
                    return View(_DbContext.Accessories.Where(x => x.Gender == 2).ToList());
            }

        }

        [HttpPost]
        public async Task<IActionResult> MansAccessories(string searchText = null)
        {
            int? pageSize = 21;
            int? pageIndex = 1;

            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages = (int)Math.Ceiling((decimal)await _DbContext.Accessories.Where(x => searchText != null && x.Gender == 2 && x.Name.Contains(searchText)).CountAsync() / (decimal)pageSize);
            }
            else
            {
                totalPages = (int)Math.Ceiling((decimal)await _DbContext.Accessories.Where(x => x.Gender == 2).CountAsync() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(await _DbContext.Accessories.Where(x => searchText != null && x.Gender == 2 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync());
                else
                    return View(await _DbContext.Accessories.Where(x => x.Gender == 2).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync());
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(await _DbContext.Accessories.Where(x => searchText != null && x.Gender == 2 && x.Name.Contains(searchText)).ToListAsync());
                else
                    return View(await _DbContext.Accessories.Where(x => x.Gender == 2).ToListAsync());
            }

        }


        public IActionResult KidsAccessories(string searchText = null, int? pageIndex = 1, int? pageSize = 21)
        {
            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages = (int)Math.Ceiling((decimal)_DbContext.Accessories.Where(x => searchText != null && x.Gender == 3 && x.Name.Contains(searchText)).Count() / (decimal)pageSize);
            }
            else
            {
                totalPages = (int)Math.Ceiling((decimal)_DbContext.Accessories.Where(x => x.Gender == 3).Count() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Accessories.Where(x => searchText != null && x.Gender == 3 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList());
                else
                    return View(_DbContext.Accessories.Where(x => x.Gender == 3).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList());
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Accessories.Where(x => searchText != null && x.Gender == 3 && x.Name.Contains(searchText)).ToList());
                else
                    return View(_DbContext.Accessories.Where(x => x.Gender == 3).ToList());
            }

        }

        [HttpPost]
        public async Task<IActionResult> KidsAccessories(string searchText = null)
        {
            int? pageSize = 21;
            int? pageIndex = 1;

            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages = (int)Math.Ceiling((decimal)await _DbContext.Accessories.Where(x => searchText != null && x.Gender == 3 && x.Name.Contains(searchText)).CountAsync() / (decimal)pageSize);
            }
            else
            {
                totalPages = (int)Math.Ceiling((decimal)await _DbContext.Accessories.Where(x => x.Gender == 3).CountAsync() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(await _DbContext.Accessories.Where(x => searchText != null && x.Gender == 3 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync());
                else
                    return View(await _DbContext.Accessories.Where(x => x.Gender == 3).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToListAsync());
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(await _DbContext.Accessories.Where(x => searchText != null && x.Gender == 3 && x.Name.Contains(searchText)).ToListAsync());
                else
                    return View(await _DbContext.Accessories.Where(x => x.Gender == 3).ToListAsync());
            }

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