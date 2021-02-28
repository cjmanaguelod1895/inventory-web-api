using Inventory_Web_API.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.Services
{
    public class UploadImageService : IUploadImageService
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public UploadImageService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }


        public  string SaveImage(IFormFile imageFile, int id)
        {
            string response = "";

            try
            {
                if (imageFile.Length > 0)
                {

                    string imageName = Path.GetFileNameWithoutExtension(imageFile.FileName);
                    string extension = Path.GetExtension(imageFile.FileName);
                    string fileName = "BillerImage_" + id + "_"+ DateTime.Now.ToString("yyyyMMdd") + extension;
                    string path = _hostEnvironment.WebRootPath + "\\images\\\\uploads\\\\billers\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + fileName))
                    {
                        imageFile.CopyTo(fileStream);
                        fileStream.Flush();
                        response = fileName;
                    }
                }
                else
                {
                    response = "Not Uploaded.";
                }
            }
            catch (Exception ex)
            {

                response = ex.Message.ToString();
            }

            return response;
        }


        public string DeleteImage(string imageName)
        {
            string response = "";
            string path = _hostEnvironment.WebRootPath + "\\images\\\\uploads\\\\billers\\";

            string filePath = Path.Combine(path, imageName);
            System.IO.File.Delete(filePath);


            return response;
        }
    }
}
