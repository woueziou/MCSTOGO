using System.Collections.Generic;
using System.Threading.Tasks;
using MCSTOGO.Models;
using MCSTOGO.Services;
using Microsoft.AspNetCore.Components;
using ActionParameterAlias;
using Microsoft.AspNetCore.Mvc;

namespace MCSTOGO.Controllers
{
    public class ImmoController : Controller
    {
        private readonly IPostService _postService;

        public ImmoController(IPostService postService)
        {
            _postService = postService;
        }


        // GET
        public async Task<IActionResult> Index()
        {
            var task = await _postService.ListPost();
            if (task["status"] == "success")
            {
                List<PostViewModel> list = task["data"];
                return View(list);
            }

            if (task["message"] == "Empty List")
            {
                return View(new List<PostViewModel>());
            }

            return View("Error");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> NewPost(PostInputModel post)
        {
            if (ModelState.IsValid)
            {
                var task = await _postService.savePost(post);
                if (task["status"] == "success")
                {
                    return RedirectToAction(nameof(Index));
                }

                return View("Error");
            }

            return View();
        }

        public IActionResult NewPost()
        {
            List<string> contrats = new List<string>() {"Location", "Vente", "Bail"};
            return View();
        }

// [ActionParameterAlias.Alias("postId")]
        public async Task<IActionResult> Info(string postId)
        {
            var post = await _postService.GetPost(postId);
            if (post["status"] == "success")
            {
                PostViewModel p = post["data"];
                return View(p);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}