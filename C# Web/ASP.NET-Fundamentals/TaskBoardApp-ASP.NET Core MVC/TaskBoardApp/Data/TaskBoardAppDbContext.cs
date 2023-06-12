using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Data
{

    using Task = Models.Task;

    public class TaskBoardAppDbContext : IdentityDbContext
    {
        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {
        }

        private IdentityUser TestUser { get; set; } = null!;
        private Board OpenBoard { get; set; } = null!;
        private Board InProgressBoard { get; set; } = null!;
        private Board DoneBoard { get; set; } = null!;


        public DbSet<Board> Boards { get; set; } = null!;
        public DbSet<Task> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .Entity<Task>()
                    .HasOne(b => b.Board)
                    .WithMany(t => t.Tasks)
                    .HasForeignKey(b => b.BoardId)
                    .OnDelete(DeleteBehavior.Restrict);

            SeedUsers();
            modelBuilder.Entity<IdentityUser>().HasData(TestUser);

            SeedBoards();
            modelBuilder.Entity<Board>().HasData(OpenBoard, InProgressBoard, DoneBoard);

            modelBuilder.Entity<Task>()
                        .HasData(new Task()
                        {
                            Id = 1,
                            Title = "Improve CSS styles",
                            Description = "Implement better styling for all public pages",
                            CreatedOn = DateTime.Now.AddDays(-200),
                            OwnerId = TestUser.Id,
                            BoardId = OpenBoard.Id
                        },
                        new Task()
                        {
                            Id = 2,
                            Title = "Android client app",
                            Description = "Create android client app for the Taskboard RESTful API",
                            CreatedOn = DateTime.Now.AddMonths(-5),
                            OwnerId = TestUser.Id,
                            BoardId = OpenBoard.Id
                        },
                        new Task()
                        {
                            Id = 3,
                            Title = "Desktop Client App",
                            Description = "Create windows forms desktop client app for the Taskboard RESTful API",
                            CreatedOn = DateTime.Now.AddMonths(-1),
                            OwnerId = TestUser.Id,
                            BoardId = InProgressBoard.Id
                        },
                        new Task()
                        {
                            Id = 4,
                            Title = "Create Tasks",
                            Description = "Implement [Create Task] page for adding new tasks",
                            CreatedOn = DateTime.Now.AddYears(-1),
                            OwnerId = TestUser.Id,
                            BoardId = DoneBoard.Id
                        });

            base.OnModelCreating(modelBuilder);
        }


        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            TestUser = new IdentityUser()
            {
                Email = "test@softuni.bg",
                NormalizedEmail = "TEST@SOFTUNI.BG",
                UserName = "Nikolai Kostov",
                NormalizedUserName = "NIKOLAI KOSTOV"
            };

            TestUser.PasswordHash = hasher.HashPassword(TestUser, "softuni");

        }

        private void SeedBoards()
        {
            OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };

            InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };

            DoneBoard = new Board() 
            {
            Id= 3,
            Name="Done"
            };
        }
    }
}