//using Bags_Accessories.Areas.Identity.Data;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Bags_Accessories.Data;

//public class AuthDbContext : IdentityDbContext<ApplicationUser>
//{
//    public AuthDbContext(DbContextOptions<AuthDbContext> options)
//        : base(options)
//    {
//    }

//    public object Password { get; internal set; }
//    public object Email { get; internal set; }

//    protected override void OnModelCreating(ModelBuilder builder)
//    {
//        base.OnModelCreating(builder);
//        // Customize the ASP.NET Identity model and override the defaults if needed.
//        // For example, you can rename the ASP.NET Identity table names and more.
//        // Add your customizations after calling base.OnModelCreating(builder);
//        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
//    }
//}

//public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<AuthDbContext>
//{
//    public void Configure(EntityTypeBuilder<AuthDbContext> builder)
//    {

//        builder.Property(x => x.Users).HasMaxLength(100);
//        builder.Property(x => x.Password).HasMaxLength(100);
//        builder.Property(x => x.Email).HasMaxLength(100);
//    }
//}