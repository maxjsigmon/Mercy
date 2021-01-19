using Mercy.Models;
using Mercy.Models.Mercy_Post;
using Mercy.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mercy.WebMVC.Controllers
{
    public class MercyPostController : Controller
    {
        // GET: MercyPost
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MercyPostService(userId);
            var model = service.GetPost();

            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePostService();

            if (service.CreatePost(model))
            {
                TempData["SaveResult"] = "Your post was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Post could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostByID(id);

            return View(model);
        }

        // GET
        public ActionResult Edit(int id)
        {
            var service = CreatePostService();
            var detail = service.GetPostByID(id);
            var model =
                new PostEdit
                {
                    PostID = detail.PostID,
                    Title = detail.Title,
                    Description = detail.Description,
                    DateOfNeed = detail.DateOfNeed,
                    TimeOfNeed = detail.TimeOfNeed,
                    WorkOfMercy = detail.WorkOfMercy
                };
            return View(model);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PostID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreatePostService();

            if (service.UpdateNote(model))
            {
                TempData["SaveResult"] = "Your post was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your post could not be updated.");
            return View();
        }

        // GET
        public ActionResult Delete(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostByID(id);

            return View(model);
        }
        
        // POST
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePostService();

            service.DeletePost(id);

            TempData["SaveResult"] = "Your post was deleted";

            return RedirectToAction("Index");
        }

        private MercyPostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MercyPostService(userId);
            return service;
        }
    }
}