using KSFramework.EntityFramework.Maps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Website.Domain.Aggregates.Blog;

namespace Website.Infrastructure.EntityConfigurations.BlogConfigurations;

public sealed class CategoriesConfigurations : EntityWithSoftDeleteMapConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("PostCategories");
        
        // builder.OwnsMany(x => x.Posts, x =>
        // {
        //     x.ToTable("CategoriesPosts");
        // });
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