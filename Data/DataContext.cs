using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {}

        // public virtual DbSet<LoginData> loginDatas {get; set;}
        public virtual DbSet<SignUpData> signUpDatas {get; set;}

        public virtual DbSet<AngularProduct> Products {get; set;}
    }
}