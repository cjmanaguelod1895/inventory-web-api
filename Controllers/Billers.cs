using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Inventory_Web_API.IServices;
using Inventory_Web_API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Web_API.Controllers
{
    [ApiExplorerSettings(GroupName = "Billers CRUD Endpoint")]
    [Route("Inventory/[controller]")]
    [ApiController]
    public class Billers : Controller
    {
        private IBillerService _oBillerService;
        private readonly IWebHostEnvironment _hostEnvironment;
        public Billers(IBillerService oBillerService , IWebHostEnvironment hostEnvironment)
        {
            _oBillerService = oBillerService;
            this._hostEnvironment = hostEnvironment;
        }

        /// <summary>
        /// Get list for all Billers.
        /// </summary>
        /// <returns>Get list for all Billers</returns>
        // GET: Inventory/Billers
        [HttpGet]
        [Authorize]
        public IEnumerable<Biller> Get()
        {
            return _oBillerService.GetBillerList();
        }

        /// <summary>
        /// Get list for all Biller per Id.
        /// </summary>
        /// <returns>Get list for all Biller</returns>
        // GET: Inventory/Billers/{billerId}
        [HttpGet("{billerId}")]
        [Authorize]
        public Biller Get(int billerId)
        {
            return _oBillerService.GetBiller(billerId);
        }

        /// <summary>
        /// Add/Save New Billers details.
        /// </summary>
        /// <returns></returns>
        // POST: Inventory/Billers
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Biller>> Post([FromForm] Biller oBiller)
        {



            if (ModelState.IsValid)
            {
                oBiller.Image = await SaveImage(oBiller.ImageFile);
                return _oBillerService.AddBiller(oBiller);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Update user Biller.
        /// </summary>
        /// <returns></returns>
        // PUT: Inventory/Billers/{billerId}
        [HttpPut("{billerId}")]
        [Authorize]
        public Biller Put(int billerId, [FromBody] Biller oBiller)
        {
            if (ModelState.IsValid)
            {
                return _oBillerService.UpdateBiller(billerId, oBiller);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Delete user Biller.
        /// </summary>
        /// <returns></returns>
        // DELETE: Inventory/Biller/{billerId}
        [HttpDelete("{billerId}")]
        [Authorize]
        public string Delete(int billerId)
        {
            return _oBillerService.Delete(billerId);
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string test = "";
            //string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            //imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            //var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Images", imageName);
            //using (var fileStream = new FileStream(imagePath, FileMode.Create))
            //{
            //    await imageFile.CopyToAsync(fileStream);
            //}
            //return imageName;

            try
            {
                if (imageFile.Length > 0)
                {
                    string path = _hostEnvironment.WebRootPath + "\\upload\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + imageFile.FileName))
                    {
                        imageFile.CopyTo(fileStream);
                        fileStream.Flush();
                        test = "Uploaded successfully";
                    }
                }
                else
                {
                    test = "Not Uploaded.";
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return test;
        }
    }
}
