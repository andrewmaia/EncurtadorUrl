using Microsoft.EntityFrameworkCore;
using EncurtadorUrl.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EncurtadorUrl.EntityTypesConfiguration {
  public class UrlConfiguration : IEntityTypeConfiguration<Url> {

    public void Configure(EntityTypeBuilder<Url> builder){
        builder.ToTable("url").HasKey(u => u.ID);                
    }
  }
}
