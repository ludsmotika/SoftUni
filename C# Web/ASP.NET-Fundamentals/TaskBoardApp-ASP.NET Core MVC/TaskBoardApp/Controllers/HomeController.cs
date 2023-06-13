using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;
using TaskBoardApp.Data;
using TaskBoardApp.Models;
using TaskBoardApp.Models.Home;

namespace TaskBoardApp.Controllers
{
    public class HomeController : Controller 
    {

        private readonly TaskBoardAppDbContext data;

        public HomeController(TaskBoardAppDbContext context)
        {
            data = context;
        }


        public async Task<IActionResult> Index()
        {
            var tasksBoard = data.Boards.Select(x => x.Name).Distinct();

            var tasksCount = new List<HomeBoardModel>();

            foreach (var boardName in tasksBoard) 
            {
                var tasksInBoard = data.Tasks.Where(x => x.Board.Name == boardName).Count();

                tasksCount.Add(new HomeBoardModel()
                {
                    BoardName = boardName,
                    TasksCount = tasksInBoard
                });
            }

            var userTasksCount = -1;

            if (User.Identity.IsAuthenticated) 
            {
                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                userTasksCount = data.Tasks.Where(x=>x.OwnerId==currentUserId).Count();
            }

            var homeModel = new HomeViewModel()
            {
                AllTasksCount= data.Tasks.Count(),
                BoardsWithTasksCount= tasksCount,
                UserTasksCount= userTasksCount
            };

            return View(homeModel);
        }
    }
}