
using IrishJobs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IrishJobs.Data.Mappings
{
    public class CompanyModelMap : IEntityTypeConfiguration<CompanyModel>
    {
        public void Configure(EntityTypeBuilder<CompanyModel> builder)
        {
            // Tabela
            builder.ToTable("Company");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Address);//.IsRequired().HasColumnType("NVARCHAR").HasMaxLength(38);
            builder.Property(x => x.Permanent);
            builder.Property(x => x.Contract);
            builder.Property(x => x.Country);
            builder.Property(x => x.CreationDate);
            builder.Property(x => x.Email);
            builder.Property(x => x.Phone);
            builder.Property(x => x.Description);//.IsRequired().HasColumnType("NVARCHAR").HasMaxLength(38);

            // Índices
            builder
                .HasIndex(x => x.Name, "IX_Company_Name");
                //.IsUnique(); 

            // Relacionamentos
             //builder
                 //.HasMany(c=>c.Ads).WithOne(a=>a.Company).HasForeignKey(c=>c.Id);
        }
    }
}