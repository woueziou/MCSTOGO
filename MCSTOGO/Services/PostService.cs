using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using MCSTOGO.Data;
using MCSTOGO.Data.Entities;
using MCSTOGO.Helpers;
using MCSTOGO.Models;
using Microsoft.EntityFrameworkCore;

namespace MCSTOGO.Services
{
    public interface IPostService
    {
        public Task<Dictionary<string, dynamic>> savePost(PostInputModel post);
        public Task<Dictionary<string, dynamic>> ListPost();
        public Task<Dictionary<string, dynamic>> GetPost(string Id);
    }

    public class PostService : IPostService
    {
        private readonly IStrGenerator _generator;
        private readonly MCSDbContext _contextDb;
        private readonly IImageService _imageService;

        public PostService(IStrGenerator generator, MCSDbContext contextDb, IImageService imageService)
        {
            _generator = generator;
            _contextDb = contextDb;
            _imageService = imageService;
        }

        public async Task<Dictionary<string, dynamic>> savePost(PostInputModel post)
        {
            var resultTask = new Dictionary<string, dynamic>();
            string postId = _generator.PolyIdGenerator(12);
            // Add Post
            var p = new Post()
            {
                Id = postId,
                Lieu = post.Lieu,
                Prix = post.Prix,
                TypeContrat = post.TypeContrat,
                DateAjout = DateTime.Now.ToString(),
                Description = post.Description,
                EtatVente = "actif",
                NomPost = post.NomPost
            };
            await _contextDb.Posts.AddAsync(p);
            if (post.Photo1 != null)
            {
                var result = await _imageService.saveImage(post.Photo1);
                var photo = new Photo()
                {
                    Etat = "actif",
                    Id = _generator.PolyIdGenerator(12),
                    Url = result["url"],
                    DateAjout = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    PostId = postId
                };
#pragma warning disable 4014
                _contextDb.Photos.AddAsync(photo);
#pragma warning restore 4014
            }

            if (post.Photo2 != null)
            {
                var result = await _imageService.saveImage(post.Photo2);
                var photo = new Photo()
                {
                    Etat = "actif",
                    Id = _generator.PolyIdGenerator(12),
                    Url = result["url"],
                    DateAjout = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    PostId = postId
                };
#pragma warning disable 4014
                _contextDb.Photos.AddAsync(photo);
#pragma warning restore 4014
            }

            if (post.Photo3 != null)
            {
                var result = await _imageService.saveImage(post.Photo3);
                var photo = new Photo()
                {
                    Etat = "actif",
                    Id = _generator.PolyIdGenerator(12),
                    Url = result["url"],
                    DateAjout = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    PostId = postId
                };
#pragma warning disable 4014
                _contextDb.Photos.AddAsync(photo);
#pragma warning restore 4014
            }

            try
            {
                await _contextDb.SaveChangesAsync();
                resultTask.Add("status", "success");
                resultTask.Add("postId", postId);
                return resultTask;
            }
            catch (Exception e)
            {
                resultTask.Clear();
                resultTask.Add("status", "error");
                resultTask.Add("message", e.Message);
                return resultTask;
            }
        }

        public async Task<Dictionary<string, dynamic>> ListPost()
        {
            var result = new Dictionary<string, dynamic>();
            try
            {
                var listPost = await _contextDb.Posts.Include(p => p.Photos).Where(p => p.EtatVente == "actif")
                    .ToListAsync();
                var returnList = new List<PostViewModel>();
                if (listPost.Count > 0)
                {
                    foreach (var post in listPost)
                    {
                        var p = new PostViewModel()
                        {
                            Id = post.Id,
                            Lieu = post.Lieu,
                            Prix = post.Prix,
                            NomPost = post.NomPost,
                            Description = post.Description,
                            PhotoUrls = post.Photos.Select(photo => photo.Url).ToList(),
                            TypeContrat = post.TypeContrat
                        };
                        returnList.Add(p);
                    }

                    result.Add("status", "success");
                    result.Add("data", returnList);
                    return result;
                }

                result.Add("status", "error");
                result.Add("message", "Empty List");
                return result;
            }
            catch (Exception e)
            {
                result.Add("status", "error");
                result.Add("message", e.Message);
                return result;
            }
        }

        public async Task<Dictionary<string, dynamic>> GetPost(string Id)
        {
            var result = new Dictionary<string, dynamic>();
            var p = await _contextDb.Posts.Include(p => p.Photos).SingleAsync(post => post.Id == Id);
            if (p != null)
            {
                var pw = new PostViewModel()
                {
                    Description = p.Description,
                    Id = p.Id,
                    Lieu = p.Lieu,
                    Prix = p.Prix,
                    NomPost = p.NomPost,
                    PhotoUrls = p.Photos.Select(photo => photo.Url).ToList(),
                    TypeContrat = p.TypeContrat
                };
                result.Add("status", "success");
                result.Add("data", pw);
                return result;
            }

            result.Clear();
            result.Add("status", "error");
            result.Add("message", "Pas de post");
            return result;
        }
    }
}