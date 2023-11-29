using Bags_Accessories.Areas.Identity.Data;
using Bags_Accessories.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bags_Accessories.Data
{
    public class ShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
    : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }


        public DbSet<Bag> Bags { get; set; }

        public DbSet<Accessorie> Accessories { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<CommentBag> CommentBag { get; set; }
        public DbSet<CommentAccessorie> CommentAccessorie { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet<OrderClient> orderClients { get; set; }
    }
}
