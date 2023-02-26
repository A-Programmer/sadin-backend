using KSFramework.EntityFramework.Maps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Website.Domain.Aggregates.Blog;

namespace Website.Infrastructure.EntityConfigurations.BlogConfigurations;

internal sealed class KeywordsConfigurations : EntityWithSoftDeleteMapConfiguration<Keyword>
{
    public override void Configure(EntityTypeBuilder<Keyword> builder)
    {
        builder.ToTable("PostsKeywords");
        
        builder.HasKey(x => x.Id);

        builder.HasMany<Post>(x => x.Posts);

        builder.Ignore(x => x.Title);
        builder.OwnsOne(x => x.Title);
        builder.Ignore(x => x.Slug);
        builder.OwnsOne(x => x.Slug);
        builder.Ignore(x => x.Name);
        builder.OwnsOne(x => x.Name);
        
        base.Configure(builder);
    }
}