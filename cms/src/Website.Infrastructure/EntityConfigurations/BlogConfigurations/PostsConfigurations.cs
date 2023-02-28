using KSFramework.EntityFramework.Maps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Website.Domain.Aggregates.Blog;

namespace Website.Infrastructure.EntityConfigurations.BlogConfigurations;

public sealed class PostsConfigurations : AggregateRootWithSoftDeleteMapConfiguration<Post>
{
    public override void Configure(EntityTypeBuilder<Post> builder)
    {
        base.Configure(builder);
        builder.ToTable("Posts");

        builder.OwnsMany(x => x.Views, c =>
        {
            c.ToTable("PostViews");
            c.OwnsOne(x => x.UserIp).Property(x => x.Value).HasColumnName("UserIp");
        });
        
        builder.HasMany(x => x.Keywords);
        builder.HasMany(x => x.Categories);

        builder.OwnsOne(x => x.Title)
            .Property(x => x.Value).HasColumnName("Title");
        builder.OwnsOne(x => x.SeoTitle)
            .Property(x => x.Value).HasColumnName("SeoTitle");
        builder.OwnsOne(x => x.Description)
            .Property(x => x.Value).HasColumnName("Description");
        builder.OwnsOne(x => x.SeoDescription)
            .Property(x => x.Value).HasColumnName("SeoDescription");
        builder.OwnsOne(x => x.Content)
            .Property(x => x.Value).HasColumnName("Content");
        builder.OwnsOne(x => x.ImageUrl)
            .Property(x => x.Value).HasColumnName("ImageUrl");
        builder.OwnsOne(x => x.Slug)
            .Property(x => x.Value).HasColumnName("Slug");
    }
}