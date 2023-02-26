using KSFramework.EntityFramework.Maps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Website.Domain.Aggregates.Blog;

namespace Website.Infrastructure.EntityConfigurations.BlogConfigurations;

public sealed class PostsConfigurations : AggregateRootWithSoftDeleteMapConfiguration<Post>
{
    public override void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");

        builder.OwnsMany(x => x.Views, c =>
        {
            c.ToTable("PostViews");
        });

        builder.OwnsMany(x => x.Categories, x =>
        {
            x.ToTable("PostCategories");
        });

        builder.OwnsMany(x => x.Keywords, x =>
        {
            x.ToTable("PostKeywords");
        });

        builder.OwnsOne(x => x.Title);
        builder.OwnsOne(x => x.SeoTitle);
        builder.OwnsOne(x => x.Description);
        builder.OwnsOne(x => x.SeoDescription);
        builder.OwnsOne(x => x.Content);
        builder.OwnsOne(x => x.ImageUrl);
        builder.OwnsOne(x => x.Slug);
        
        base.Configure(builder);
    }
}