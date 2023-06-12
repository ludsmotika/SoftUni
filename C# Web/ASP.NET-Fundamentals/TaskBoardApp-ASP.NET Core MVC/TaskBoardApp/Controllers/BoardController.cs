using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Board;
using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Controllers
{
    public class BoardController : Controller
    {

        private readonly TaskBoardAppDbContext data;
        private readonly UserManager<IdentityUser> _userManager;


        public BoardController(TaskBoardAppDbContext context, UserManager<IdentityUser> userManager)
        {
            data = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> All()
        {
            var boards = await data.Boards.Select(x => new BoardViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Tasks = x.Tasks.Select(t => new TaskViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Owner = t.OwnerId
                })
            }

            ).ToListAsync();


            return View(boards);
        }

    }
}