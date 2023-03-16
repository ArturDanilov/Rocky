using Microsoft.EntityFrameworkCore;
using Rocky.Models;

namespace Rocky.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //передаем параметры в базовый класс DbContext 
        {
        }

        public DbSet<Category> Category { get; set; } //тут мы создаем таблицу Category в базе данных
        public DbSet<ApplicationType> ApplicationType { get; set; } //тут мы создаем таблицу ApplicationType в базе данных
    }
}
