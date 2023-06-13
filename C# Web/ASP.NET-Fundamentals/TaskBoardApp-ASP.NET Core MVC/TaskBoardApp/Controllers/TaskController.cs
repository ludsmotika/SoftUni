using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Board;
using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Controllers
{

    using Task = Data.Models.Task;

    [Authorize]
    public class TaskController : Controller
    {

        private readonly TaskBoardAppDbContext data;
        private readonly UserManager<IdentityUser> _userManager;


        public TaskController(TaskBoardAppDbContext context, UserManager<IdentityUser> userManager)
        {
            data = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = GetBoards()
            };
            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskModel)
        {

            if (!GetBoards().Any(x => x.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            string currentUserId = GetUserId();

            if (!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();
                return View(taskModel);
            }

            Task task = new Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId
            };

            await data.Tasks.AddAsync(task);
            await data.SaveChangesAsync();


            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Details(int id)
        {

            var task = await data.Tasks.Where(x => x.Id == id).Select(x => new TaskDetailsViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CreatedOn = x.CreatedOn.ToString("f"),
                Board = x.Board.Name,
                Owner = _userManager.FindByIdAsync(x.OwnerId).GetAwaiter().GetResult().UserName
            }).FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel taskModel = new TaskFormModel()
            {
                Title=task.Title,
                Description=task.Description,
                BoardId=task.BoardId,
                Boards= GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
        {
            var task = await data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetBoards().Any(x=>x.Id==taskModel.BoardId)) 
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            if (!ModelState.IsValid) 
            {
                taskModel.Boards = GetBoards();
                return View(taskModel);
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            await data.SaveChangesAsync();
            return RedirectToAction("All", "Board");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await data.Tasks.FindAsync(id);

            if (task == null) 
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskViewModel taskModel = new TaskViewModel()
            {
                Id= task.Id,
                Title= task.Title,
                Description= task.Description
            };


            return View(taskModel);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskModel) 
        {
            //get the task
            var task = await data.Tasks.FindAsync(taskModel.Id);

            //validation
            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }
            //remove the task and save changes

            data.Tasks.Remove(task);
            await data.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }

        private IEnumerable<TaskBoardModel> GetBoards()
        {
            var boards = data.Boards.Select(x => new TaskBoardModel() { Id = x.Id, Name = x.Name });
            return boards;
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

    }
}
