
using IrishJobs.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IrishJobs.Data.Mappings
{
    public class AdModelMap : IEntityTypeConfiguration<AdModel>
    {
        public void Configure(EntityTypeBuilder<AdModel> builder)
        {
            // Tabela
            builder.ToTable("Ads");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propriedades
            builder.Property(x => x.Category);
            builder.Property(x => x.Title);
            builder.Property(x => x.Salary);
            builder.Property(x => x.Location);
            builder.Property(x => x.Remote);
            builder.Property(x => x.Permanent);
            builder.Property(x => x.LastUpdate);
            builder.Property(x => x.CreationDate).HasDefaultValue(System.DateTime.Now);
            builder.Property(x => x.Description);

            // Índices
            builder
                .HasIndex(x => x.Category, "IX_User_Category");
                //.IsUnique();

            //builder.HasOne<CompanyModel>(a => a.Company).WithMany(c=>c.Ads).HasForeignKey(a =>a.CompanyId);

        }
    }
}


















//Jorgge-E-Lariss