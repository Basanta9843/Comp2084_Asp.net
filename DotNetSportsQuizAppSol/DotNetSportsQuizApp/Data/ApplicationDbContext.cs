using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DotNetSportsQuizApp.Models;

namespace DotNetSportsQuizApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<SportsQuiz> SportsQuiz { get; set; }
        public DbSet<QuizQuestions> QuizQuestions { get; set; }
        public DbSet<PlayerProgress> PlayerProgress { get; set; }
    }
}
