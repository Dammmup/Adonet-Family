using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class FamilyDbContext : DbContext
    {
        public DbSet<Family> Families { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Здесь укажите строку подключения к вашей базе данных
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-D8S3V2D;Initial Catalog=family;Integrated Security=True;");
        }

        // Хранимая процедура для выборки семей
        public List<Family> GetFamilies()
        {
            return Families.FromSqlRaw("EXEC GetFamilies").ToList();
        }
    }
}
