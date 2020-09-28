using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MCSTOGO.Data;
using MCSTOGO.Data.Entities;
using MCSTOGO.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;


namespace MCSTOGO.Services
{
    public interface IImageService
    {
        public Task<Dictionary<string, dynamic>> saveImage(IFormFile file);
    }

    public class ImageService : IImageService
    {
        private readonly MCSDbContext _db;
        private readonly IStrGenerator _generator;
        private readonly IWebHostEnvironment _env;

        public ImageService(IWebHostEnvironment env, IStrGenerator generator, MCSDbContext db)
        {
            _db = db;
            _env = env;
            _generator = generator;
        }

        public async Task<Dictionary<string, dynamic>> saveImage(IFormFile file)
        {var result =new Dictionary<string, dynamic>();
            // if (p.Length > 0)
            // {
                if (!Directory.Exists(_env.WebRootPath + "\\img"))
                {
                    Directory.CreateDirectory(_env.WebRootPath + "\\img");
                }

                using (FileStream fl = System.IO.File.Create(_env.WebRootPath + "\\img\\" + file.FileName))
                {
                    var fileName = file.FileName;
                    // var fileName = ContentDispositionHeaderValue.Parse(p.ContentDisposition).FileName.Trim('"');
                    file.CopyTo(fl);
                    fl.Flush();
//                     Photo photo = new Photo()
//                     {
// //                            ArticleId = postId,
//                         Url = "img\\" + fileName,
//                         Id = _generator.PolyIdGenerator(16)
//                     };

                    // _db.Photos.Add(photo);
                    // _db.SaveChanges();
                    
                    result.Add("status","succes");
                    result.Add("url","/img/"+fileName);
                    return result;
                }
            // }
            // result.Clear();
            // result.Add("status","error");
            // return result;
        }
    }
}