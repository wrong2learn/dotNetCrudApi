using dotNetCrudApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotNetCrudApi.DatabaseContext
{
    //install dotnet-ef tool (from nuget console):
    //cd in the project folder ( not where .sln file
    //dotnet tool install --global dotnet-ef
    //publish db: dotnet-ef migrations add InitialMigration
    //dotnet-ef database update
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Post> Posts { get; set; }
    }
}
