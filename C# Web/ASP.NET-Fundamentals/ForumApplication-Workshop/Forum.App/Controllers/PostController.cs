using Forum.App.Data;
using Forum.App.Data.Models;
using Forum.App.Models.Post;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Forum.App.Controllers
{
    public class PostController : Controller
    {

        private readonly ForumAppDbContext _data;
        public PostController(ForumAppDbContext data)
        {
            _data = data;
        }

        public async Task<IActionResult> All()
        {
            var posts = await _data.Posts.Select(x => new PostViewModel()
            {
                Id = x.Id.ToString(),
                Title = x.Title,
                Content = x.Content
            }).ToListAsync();

            return View(posts);
        }


        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel modelToAdd)
        {

            var post = new Post()
            {
                Title = modelToAdd.Title,
                Content = modelToAdd.Content
            };


            await _data.AddAsync(post);
            await _data.SaveChangesAsync();

            return RedirectToAction("All", "Post");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var post = await _data.Posts.FirstAsync(x => x.Id.ToString() == id);


            return View(new PostFormModel()
            {
                Title = post.Title,
                Content = post.Content
            });
        }

        [HttpPost]

        public async Task<IActionResult> Edit(string id, PostFormModel model)
        {

            //get the model with the passed id from the url 

            Post postToChange = await _data.Posts.FirstAsync(x => x.Id.ToString() == id);
            //change its values from the model passed from the form in the view 

            postToChange.Title = model.Title;
            postToChange.Content = model.Content;

            //and save the changes in the dbContext
            await _data.SaveChangesAsync();

            return RedirectToAction("All", "Post");
        }


        public async Task<IActionResult> Delete(string id)
        {
            var postToDelete = await _data.Posts.FirstAsync(x=>x.Id.ToString()==id);

            _data.Remove(postToDelete);
            await _data.SaveChangesAsync();

            return RedirectToAction("All", "Post");
        }
    }
}

