using Microsoft.EntityFrameworkCore;
using EncurtadorUrl.Models;
using EncurtadorUrl.EntityTypesConfiguration;

namespace EncurtadorUrl
{
    public class EncurtadorUrlContext : DbContext
    {
        public EncurtadorUrlContext(DbContextOptions<EncurtadorUrlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UrlConfiguration());
                 
        }        

        public DbSet<Url> Urls { get; set; }        
       
    }        
}