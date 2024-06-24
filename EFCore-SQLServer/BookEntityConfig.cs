using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_SQLServer
{
    public class BookEntityConfig:IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder) {
            builder.ToTable("T_Books");
            builder.Property(b => b.Title).HasMaxLength(500).IsRequired();
        
        }
    }
}
