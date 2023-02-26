using KSFramework.EntityFramework.Maps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Website.Domain.Aggregates.Blog;

namespace Website.Infrastructure.EntityConfigurations.BlogConfigurations;

internal sealed class CategoriesConfigurations : EntityWithSoftDeleteMapConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("PostCategories");
        
        builder.HasKey(x => x.Id);

        builder.HasMany<Post>(x => x.Posts);

        builder.Ignore(x => x.Title);
        builder.OwnsOne(x => x.Title);
        builder.Ignore(x => x.Slug);
        builder.OwnsOne(x => x.Slug);
        builder.Ignore(x => x.Name);
        builder.OwnsOne(x => x.Name);
        builder.Ignore(x => x.Description);
        builder.OwnsOne(x => x.Description);
        
        base.Configure(builder);
    }
}