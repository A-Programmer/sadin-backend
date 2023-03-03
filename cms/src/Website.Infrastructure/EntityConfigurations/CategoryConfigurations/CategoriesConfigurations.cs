using KSFramework.EntityFramework.Maps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Website.Domain.Aggregates.Categories;

namespace Website.Infrastructure.EntityConfigurations.CategoryConfigurations;

public sealed class CategoriesConfigurations : AggregateRootWithSoftDeleteMapConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("Catecories");
        
        builder.HasMany(x => x.Posts);

        builder.OwnsOne(x => x.Title)
            .Property(x => x.Value).HasColumnName("Title");
        builder.OwnsOne(x => x.Slug)
            .Property(x => x.Value).HasColumnName("Slug");
        builder.OwnsOne(x => x.Name)
            .Property(x => x.Value).HasColumnName("Name");
        builder.OwnsOne(x => x.Description)
            .Property(x => x.Value).HasColumnName("Description");
    }
}