using Microsoft.EntityFrameworkCore;
using EncurtadorUrl.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EncurtadorUrl.EntityTypesConfiguration {
  public class UserConfiguration : IEntityTypeConfiguration<User> {

    public void Configure(EntityTypeBuilder<User> builder){
        builder.ToTable("user").HasKey(u => u.ID);
        
    }
  }
}
