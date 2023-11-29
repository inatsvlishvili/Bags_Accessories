using Bags_Accessories.Data;
using Bags_Accessories.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;




namespace Bags_Accessories.Controllers
{
    //[Authorize]
    public class AdminController : Controller
    {
        ShopDbContext _DbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(IWebHostEnvironment webHostEnvironment, ShopDbContext DbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _DbContext = DbContext;
        }

        public IActionResult index()
        {
            return View();
        }
      

        [HttpGet]
        public IActionResult BagAdd()
        {
            return View();
        }


        [HttpPost]
        public IActionResult BagAdd(Bag prod)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (prod.ImageFile==null)
            {
                ViewBag.Error = "აირჩიეთ სურათი";
                return View();
            }
            var FileDic = "";
            if (prod.Gender==1)
            {
                FileDic = "productImages/WomenBagImg";
            }
            else if (prod.Gender==2)
            {
                FileDic = "productImages/ManBagImg";
            }
            else if (prod.Gender==3)
            {
                FileDic = "productImages/KidBagImg";
            }
            else
            {

            }
            string imgPath = Path.Combine(_webHostEnvironment.WebRootPath, FileDic);
            if (!Directory.Exists(imgPath))
                Directory.CreateDirectory(imgPath);


            string imgext = Path.GetExtension(prod.ImageFile.FileName);
            var imageNewFileName = Guid.NewGuid().ToString();
            imageNewFileName = imageNewFileName + imgext;
            var filePath = Path.Combine(imgPath, imageNewFileName);

            using (FileStream fs = System.IO.File.Create(filePath))
            {
                prod.ImageFile.CopyTo(fs);
            }

            prod.ImageName = imageNewFileName;
            _DbContext.Bags.Add(prod);
            _DbContext.SaveChanges();

            return View();
            //. viewbagi gavaketo, warmatebit aitvirta

        }

        //string imgPath = Path.Combine(_webHostEnvironment.WebRootPath, FileDic);
        //string FilePath =_webHostEnvironment.WebRootPath+"\\"+ FileDic;

        //if (!Directory.Exists(imgPath))
        //    Directory.CreateDirectory(imgPath);


        //var filePath = Path.Combine(imgPath, prod.ImageFile.FileName);

        //using (FileStream fs = System.IO.File.Create(filePath))
        //{
        //    prod.ImageFile.CopyTo(fs);
        //}

        //prod.ImageName = prod.ImageFile.FileName;
        //_DbContext.Bags.Add(prod);
        //_DbContext.SaveChanges();

        //return RedirectToAction("Display");

        public IActionResult AllBag(string searchText = null, int? pageIndex = 1, int? pageSize = 10)

        {

            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages=(int)Math.Ceiling((decimal)_DbContext.Bags.Where(x => searchText!=null && x.Name.Contains(searchText)).Count() / (decimal)pageSize);
            }
            else
            {
                totalPages=(int)Math.Ceiling((decimal)_DbContext.Bags.Count() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Bags.Where(x => searchText!=null && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
                else
                    return View(_DbContext.Bags.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Bags.Where(x => searchText!=null && x.Name.Contains(searchText)));
                else
                    return View(_DbContext.Bags);
            }
        }

        [HttpGet]
        public IActionResult BagEdit(int id)
        {
            var obj = _DbContext.Bags.Find(id);

            return View(obj);
        }
        [HttpPost]
        public IActionResult BagEdit(Bag prod)
        {
            //_DbContext.Entry(prod).State = (Microsoft.EntityFrameworkCore.EntityState)System.Data.Entity.EntityState.Modified;
            _DbContext.Bags.Update(prod);
            _DbContext.SaveChanges();
            return RedirectToAction("Display");
        }
        [HttpGet]
        public IActionResult BagDelete(int id)
        {
            var obj = _DbContext.Bags.Find(id);

            return View(obj);
        }
        [HttpPost]
        public IActionResult BagDelete(Bag prod)
        {
            /////var prodToDelete = _DbContext.Products.Find(prod.ID);
            /////_DbContext.Products.Remove(prodToDelete);
            _DbContext.Bags.Remove(prod);
            _DbContext.SaveChanges();
            return RedirectToAction("Display");
        }
        public IActionResult Details(int id)
        {
            var obj = _DbContext.Bags.Find(id);

            return View(obj);
        }
        [HttpGet]
        public IActionResult AccessorieAdd()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AccessorieAdd(Accessorie prod)
        {
            var FileDic = "productImages";

            string imgPath = Path.Combine(_webHostEnvironment.WebRootPath, FileDic);
            //string FilePath =_webHostEnvironment.WebRootPath+"\\"+ FileDic;

            if (!Directory.Exists(imgPath))
                Directory.CreateDirectory(imgPath);


            var filePath = Path.Combine(imgPath, prod.ImageFile.FileName);

            using (FileStream fs = System.IO.File.Create(filePath))
            {
                prod.ImageFile.CopyTo(fs);
            }

            prod.ImageName = prod.ImageFile.FileName;
            _DbContext.Accessories.Add(prod);
            _DbContext.SaveChanges();

            return RedirectToAction("Display");
        }

        [HttpGet]
        public IActionResult AccessorieEdit(int id)
        {
            var obj = _DbContext.Accessories.Find(id);

            return View(obj);
        }
        [HttpGet]
        public IActionResult AccessorieDelete(int id)
        {
            var obj = _DbContext.Accessories.Find(id);

            return View(obj);
        }
        [HttpPost]
        public IActionResult AccessorieDelete(Accessorie prod)
        {
            /////var prodToDelete = _DbContext.Products.Find(prod.ID);
            /////_DbContext.Products.Remove(prodToDelete);
            _DbContext.Accessories.Remove(prod);
            _DbContext.SaveChanges();
            return RedirectToAction("Display");
        }
        public IActionResult AllAccessorie(int? pageIndex = 1, int? pageSize = 10)
        {
            //var search =_DbContext.Products.Where(x => x.Name.Equals("serch"));
            //return View(search);
            var totalPages = (int)Math.Ceiling((decimal)_DbContext.Accessories.Count() / (decimal)pageSize);

            ViewBag.ProductsTotalCount = totalPages;

            if (pageIndex != null && pageSize != null)
                return View(_DbContext.Accessories.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
            else
                return View(_DbContext.Accessories);
        }

        public IActionResult WomensBag(string searchText = null, int? pageIndex = 1, int? pageSize = 10)
        {

            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages=(int)Math.Ceiling((decimal)_DbContext.Bags.Where(x => searchText!=null && x.Gender == 1 && x.Name.Contains(searchText)).Count() / (decimal)pageSize);
            }
            else
            {
                totalPages=(int)Math.Ceiling((decimal)_DbContext.Bags.Where(x => x.Gender == 1).Count() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Bags.Where(x => searchText!=null &&  x.Gender == 1 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
                else
                    return View(_DbContext.Bags.Where(x => x.Gender == 1).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Bags.Where(x => searchText!=null && x.Gender == 1 && x.Name.Contains(searchText)));
                else
                    return View(_DbContext.Bags.Where(x => x.Gender == 1));
            }
        }


        public IActionResult MansBag(string searchText = null, int? pageIndex = 1, int? pageSize = 10)
        {

            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages=(int)Math.Ceiling((decimal)_DbContext.Bags.Where(x => searchText!=null && x.Gender == 2 && x.Name.Contains(searchText)).Count() / (decimal)pageSize);
            }
            else
            {
                totalPages=(int)Math.Ceiling((decimal)_DbContext.Bags.Where(x => x.Gender == 2).Count() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Bags.Where(x => searchText!=null &&  x.Gender == 2 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
                else
                    return View(_DbContext.Bags.Where(x => x.Gender == 2).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Bags.Where(x => searchText!=null && x.Gender == 2 && x.Name.Contains(searchText)));
                else
                    return View(_DbContext.Bags.Where(x => x.Gender == 2));
            }
        }
        public IActionResult KidsBag(string searchText = null, int? pageIndex = 1, int? pageSize = 10)
        {

            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages=(int)Math.Ceiling((decimal)_DbContext.Bags.Where(x => searchText!=null && x.Gender == 3 && x.Name.Contains(searchText)).Count() / (decimal)pageSize);
            }
            else
            {
                totalPages=(int)Math.Ceiling((decimal)_DbContext.Bags.Where(x => x.Gender == 3).Count() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Bags.Where(x => searchText!=null &&  x.Gender == 3 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
                else
                    return View(_DbContext.Bags.Where(x => x.Gender == 3).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Bags.Where(x => searchText!=null && x.Gender == 3 && x.Name.Contains(searchText)));
                else
                    return View(_DbContext.Bags.Where(x => x.Gender == 3));
            }
        }
        public IActionResult WomensAccessorie(string searchText = null, int? pageIndex = 1, int? pageSize = 10)
        {

            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages=(int)Math.Ceiling((decimal)_DbContext.Accessories.Where(x => searchText!=null && x.Gender == 1 && x.Name.Contains(searchText)).Count() / (decimal)pageSize);
            }
            else
            {
                totalPages=(int)Math.Ceiling((decimal)_DbContext.Accessories.Where(x => x.Gender == 1).Count() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Accessories.Where(x => searchText!=null &&  x.Gender == 1 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
                else
                    return View(_DbContext.Accessories.Where(x => x.Gender == 1).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Accessories.Where(x => searchText!=null && x.Gender == 1 && x.Name.Contains(searchText)));
                else
                    return View(_DbContext.Accessories.Where(x => x.Gender == 1));
            }
        }
        public IActionResult MansAccessorie(string searchText = null, int? pageIndex = 1, int? pageSize = 10)
        {

            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages=(int)Math.Ceiling((decimal)_DbContext.Accessories.Where(x => searchText!=null && x.Gender == 2 && x.Name.Contains(searchText)).Count() / (decimal)pageSize);
            }
            else
            {
                totalPages=(int)Math.Ceiling((decimal)_DbContext.Accessories.Where(x => x.Gender == 2).Count() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Accessories.Where(x => searchText!=null &&  x.Gender == 2 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
                else
                    return View(_DbContext.Accessories.Where(x => x.Gender == 2).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Accessories.Where(x => searchText!=null && x.Gender == 2 && x.Name.Contains(searchText)));
                else
                    return View(_DbContext.Accessories.Where(x => x.Gender == 2));
            }
        }
        public IActionResult KidsAccessorie(string searchText = null, int? pageIndex = 1, int? pageSize = 10)
        {

            var totalPages = 0;
            if (!string.IsNullOrEmpty(searchText))
            {
                totalPages=(int)Math.Ceiling((decimal)_DbContext.Accessories.Where(x => searchText!=null && x.Gender == 3 && x.Name.Contains(searchText)).Count() / (decimal)pageSize);
            }
            else
            {
                totalPages=(int)Math.Ceiling((decimal)_DbContext.Accessories.Where(x => x.Gender == 3).Count() / (decimal)pageSize);
            }

            ViewBag.ProductsTotalCount = totalPages;
            ViewBag.PageIndex = pageIndex;
            ViewBag.SearchText = searchText;
            if (pageIndex != null && pageSize != null)
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Accessories.Where(x => searchText!=null &&  x.Gender == 3 && x.Name.Contains(searchText)).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
                else
                    return View(_DbContext.Accessories.Where(x => x.Gender == 3).Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value));
            }
            else
            {
                if (!string.IsNullOrEmpty(searchText))
                    return View(_DbContext.Accessories.Where(x => searchText!=null && x.Gender == 3 && x.Name.Contains(searchText)));
                else
                    return View(_DbContext.Accessories.Where(x => x.Gender == 3));
            }
        }

    }
}
