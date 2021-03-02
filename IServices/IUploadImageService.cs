using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory_Web_API.IServices
{
    public interface IUploadImageService
    {
        string SaveImage(IFormFile imageFile, int id, string imageClassification);
        string DeleteImage(string imageName, string imageClassification);
    }
}
