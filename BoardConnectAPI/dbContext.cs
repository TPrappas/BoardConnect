using Microsoft.EntityFrameworkCore;

namespace BoardConnectAPI
{
    public class dbContext : DbContext
    {
        #region Public Properties

        /// <summary>
        /// The projects
        /// </summary>
        public DbSet<ProjectEntity> Projects { get; set; }

        /// <summary>
        /// The tasks
        /// </summary>
        public DbSet<TaskEntity> Tasks { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options">The options</param>
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// This method will automatically call Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges
        /// to discover any changes to entity instances before saving to the underlying database.
        /// This can be disabled via Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled.
        /// Multiple active operations on the same context instance are not supported. Use
        /// 'await' to ensure that any asynchronous operations have completed before calling
        /// another method on this context.
        /// </summary>
        /// <param name="cancellationToken">
        /// A System.Threading.CancellationToken to observe while waiting for the task to
        /// complete.
        /// </param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return SaveChangesAsync(true, true, cancellationToken);
        }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// This method will automatically call Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges
        /// to discover any changes to entity instances before saving to the underlying database.
        /// This can be disabled via Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled.
        /// Multiple active operations on the same context instance are not supported. Use
        /// 'await' to ensure that any asynchronous operations have completed before calling
        /// another method on this context.
        /// </summary>
        /// <param name="shouldUpdateCreationDates">
        /// A flag indicating whether the creation dates should be updated for the models that implement the <see cref="IDateCreatable"/>
        /// interfaces
        /// </param>
        /// <param name="shouldUpdateModificationDates">
        /// A flag indicating whether the modification dates should be updated for the models that implement the <see cref="IDateModifiable"/>
        /// interfaces
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to observe while waiting for the task to
        /// complete.
        /// </param>
        /// <returns></returns>
        public Task<int> SaveChangesAsync(bool shouldUpdateCreationDates, bool shouldUpdateModificationDates, CancellationToken cancellationToken = default)
        {
            if (shouldUpdateCreationDates)
            {
                foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                    if (entry.State == EntityState.Added)
                        entry.Entity.DateCreated = DateTimeOffset.Now;
            }

            if (shouldUpdateModificationDates)
            {
                foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                        entry.Entity.DateUpdated = DateTimeOffset.Now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention
        /// from the entity types exposed in <see cref="DbSet{TEntity}"/> properties
        /// on your derived context. The resulting model may be cached and re-used for subsequent
        /// instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEntity>()
                .HasMany(x => x.Tasks)
                .WithOne(x => x.Project)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        #endregion
    }
}
