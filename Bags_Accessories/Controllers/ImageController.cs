using Bags_Accessories.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Bags_Accessories.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Bags_Accessories.Controllers
{
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _iweb;
        readonly ShopDbContext _DbContext;

        public ImageController(IWebHostEnvironment iweb, ShopDbContext DbContext)
        {
            _iweb = iweb;
            _DbContext = DbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile imgfile, int imgIndex)
        {
            if (imgfile == null)
            {
                ViewBag.ErrorText1 = "აირჩიეთ სურათი";
                return View("Index");
            }


            string imgext = Path.GetExtension(imgfile.FileName);
            if (imgext == ".jpg" || imgext == ".png" || imgext == ".gif")
            {
                var imageNewFileName = Guid.NewGuid().ToString();
                imageNewFileName = imageNewFileName + imgext;
                var imgsave = Path.Combine(_iweb.WebRootPath, "PageImg", imageNewFileName);
                var stream = new FileStream(imgsave, FileMode.Create);
                await imgfile.CopyToAsync(stream);
                stream.Close();

                var mainPageImg1Setting = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "MainPageImg" + imgIndex);

                if (mainPageImg1Setting == null)
                {
                    Settings settingNew = new Settings();
                    settingNew.SettingName = "MainPageImg" + imgIndex;
                    settingNew.SettingValue = imageNewFileName;
                    _DbContext.Settings.Add(settingNew);
                    _DbContext.SaveChanges();
                }
                else
                {
                    mainPageImg1Setting.SettingValue = imageNewFileName;
                    _DbContext.SaveChanges();
                }

                ViewBag.Message1 = "სურათი წარმატებით აიტვირთა";
                ViewBag.Message2 = "სურათი წარმატებით აიტვირთა";
                ViewBag.Message3 = "სურათი წარმატებით აიტვირთა";
                ViewBag.Message4 = "სურათი წარმატებით აიტვირთა";
                ViewBag.Message5 = "სურათი წარმატებით აიტვირთა";

            }
            return View("Index");
        }

        //else
        //{
        //    ViewData["Message"] = "Please Upload Only .jgp & .png & .gif Images Only . . . . !";
        //}
        //return View();

        [HttpGet]
        public IActionResult OtherIndex()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> OtherIndex(IFormFile imgfile, int imgIndex)
        {
            if (imgfile == null)
            {
                ViewBag.ErrorText1 = "აირჩიეთ სურათი";
                return View("Index");
            }


            string imgext = Path.GetExtension(imgfile.FileName);
            if (imgext == ".jpg" || imgext == ".png" || imgext == ".gif")
            {
                var imageNewFileName = Guid.NewGuid().ToString();
                imageNewFileName = imageNewFileName + imgext;
                var imgsave = Path.Combine(_iweb.WebRootPath, "OtherPageImg", imageNewFileName);
                var stream = new FileStream(imgsave, FileMode.Create);
                await imgfile.CopyToAsync(stream);
                stream.Close();

                var mainPageImg1Setting = _DbContext.Settings.SingleOrDefault(x => x.SettingName == "OtherPageImg" + imgIndex);

                if (mainPageImg1Setting == null)
                {
                    Settings settingNew = new Settings();
                    settingNew.SettingName = "OtherPageImg" + imgIndex;
                    settingNew.SettingValue = imageNewFileName;
                    _DbContext.Settings.Add(settingNew);
                    _DbContext.SaveChanges();
                }
                else
                {
                    mainPageImg1Setting.SettingValue = imageNewFileName;
                    _DbContext.SaveChanges();
                }

                ViewBag.Message1 = "სურათი წარმატებით აიტვირთა";
                ViewBag.Message2 = "სურათი წარმატებით აიტვირთა";
                ViewBag.Message3 = "სურათი წარმატებით აიტვირთა";
                ViewBag.Message4 = "სურათი წარმატებით აიტვირთა";
                ViewBag.Message5 = "სურათი წარმატებით აიტვირთა";

            }
            return View("OtherIndex");


            //else
            //{
            //    ViewData["Message"] = "Please Upload Only .jgp & .png & .gif Images Only . . . . !";
            //}
            //return View();

        }

    }

}
