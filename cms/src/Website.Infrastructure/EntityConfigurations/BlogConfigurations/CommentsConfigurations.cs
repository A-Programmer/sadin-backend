using KSFramework.EntityFramework.Maps.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Website.Domain.Aggregates.Blog;
using Website.Domain.Aggregates.Blog.ValueObjects;

namespace Website.Infrastructure.EntityConfigurations.BlogConfigurations;

public sealed class CommentsConfigurations : EntityWithSoftDeleteMapConfiguration<Comment>
{
    public override void Configure(EntityTypeBuilder<Comment> builder)
    {
        base.Configure(builder); 
        
        builder.ToTable("PostComments");

        builder.Ignore(x => x.Content);
        builder.OwnsOne<PostCommentContent>(x => x.Content)
            .Property(x => x.Value).HasColumnName("Content");
        
        builder.HasKey(x => x.Id);

        builder.HasOne<Post>(x => x.Post)
            .WithMany(x => x.Comments)
            .OnDelete(DeleteBehavior.Cascade);
    }
}