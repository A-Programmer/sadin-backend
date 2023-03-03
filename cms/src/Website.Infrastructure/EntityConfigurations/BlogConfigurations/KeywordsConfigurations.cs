using KSFramework.EntityFramework.Maps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Website.Domain.Aggregates.Blog;

namespace Website.Infrastructure.EntityConfigurations.BlogConfigurations;

public sealed class KeywordsConfigurations : EntityWithSoftDeleteMapConfiguration<Keyword>
{
    public override void Configure(EntityTypeBuilder<Keyword> builder)
    {
        base.Configure(builder);
        
        builder.ToTable("PostsKeywords");
        
        builder.HasKey(x => x.Id);

        builder.HasMany<Post>(x => x.Posts);
        
        builder.OwnsOne(x => x.Title)
            .Property(x => x.Value).HasColumnName("Title");
        builder.OwnsOne(x => x.Slug)
            .Property(x => x.Value).HasColumnName("Slug");
        builder.OwnsOne(x => x.Name)
            .Property(x => x.Value).HasColumnName("Name");
    }
}