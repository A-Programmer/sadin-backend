using KSFramework.EntityFramework.ExtensionMethods;
using KSFramework.Primitives;
using KSFramework.Utilities;
using Microsoft.EntityFrameworkCore;
using Website.Domain.Aggregates.Blog;
using Website.Domain.Aggregates.Blog.ValueObjects;
using Website.Domain.Aggregates.ContactUsMessages;

namespace Website.Infrastructure.Data;

public class WebsiteDbContext : DbContext
{
    public WebsiteDbContext(DbContextOptions<WebsiteDbContext> options)
        : base(options)
    {
    }

    // public DbSet<ContactUsMessage> ContactUsMessages { get; set; }
    // public DbSet<Post> Posts { get; set; }
    // public DbSet<Category> PostCategories { get; set; }
    // public DbSet<Comment> PostComments { get; set; }
    // public DbSet<Keyword> PostKeywords { get; set; }
    // public DbSet<View> PostViews { get; set; }


    public override async  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ChangeTracker.SetAuditProperties();
        return await base.SaveChangesAsync(cancellationToken);
    }
    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        ChangeTracker.SetAuditProperties();
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    public override int SaveChanges()
    {
        ChangeTracker.SetAuditProperties();
        return base.SaveChanges();
    }
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        ChangeTracker.SetAuditProperties();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        var entitiesAssembly = typeof(Domain.AssemblyReference).Assembly;
        var entityConfigurationsAssembly = typeof(AssemblyReference).Assembly;

        #region Register All Entities
        modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
        #endregion

        #region Apply Entities Configuration
        modelBuilder.RegisterEntityTypeConfiguration(entityConfigurationsAssembly);
        #endregion

        #region Config Delete Behevior for not Cascade Delete
        modelBuilder.AddRestrictDeleteBehaviorConvention();
        #endregion

        #region Add Sequential GUID for Id properties
        modelBuilder.AddSequentialGuidForIdConvention();
        #endregion

        #region Pluralize Table Names
        modelBuilder.AddPluralizingTableNameConvention();
        #endregion
        
        base.OnModelCreating(modelBuilder);
    }
}