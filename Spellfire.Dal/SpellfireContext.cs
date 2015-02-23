namespace Spellfire.Dal
{
    using Spellfire.Model;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;

    public partial class SpellfireContext : DbContext, IUnitOfWork
    {
        public SpellfireContext()
            : this("name=SpellfireContext")
        {
        }

        public SpellfireContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Spellfire.Model.Attribute> Attributes { get; set; }
        public virtual DbSet<Booster> Boosters { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<CardAttribute> CardAttributes { get; set; }
        public virtual DbSet<CardPhase> CardPhases { get; set; }
        public virtual DbSet<CardType> CardTypes { get; set; }
        public virtual DbSet<Rarity> Rarities { get; set; }
        public virtual DbSet<Spellfire.Model.Type> Types { get; set; }
        public virtual DbSet<World> Worlds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spellfire.Model.Attribute>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Booster>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Booster>()
                .Property(e => e.Abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<Booster>()
                .Property(e => e.ImageName)
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.Power)
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.Blueline)
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<Card>()
                .Property(e => e.ImageName)
                .IsUnicode(false);

            modelBuilder.Entity<Rarity>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Rarity>()
                .Property(e => e.Abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<Spellfire.Model.Type>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Spellfire.Model.Type>()
                .Property(e => e.Icon)
                .IsUnicode(false);

            modelBuilder.Entity<World>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<World>()
                .Property(e => e.Abbreviation)
                .IsUnicode(false);

            modelBuilder.Entity<World>()
                .Property(e => e.ImageName)
                .IsUnicode(false);
        }

        /// <summary>
        /// Attaches an object to a unit of work so that any further changes to it can be tracked. The object is assumed
        /// to already exist.
        /// </summary>
        /// <typeparam name="T">the type of the object to attach</typeparam>
        /// <param name="objectToAttach">the object to attach to the unit of work</param>
        /// <returns>the object that was attached</returns>
        public T Attach<T>(T objectToAttach) where T : class
        {
            return Set<T>().Attach(objectToAttach);
        }

        /// <summary>
        /// Resets settings to their normal values, making large numbers of changes less efficient
        /// </summary>
        public void DisableMassChanges()
        {
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;
        }

        /// <summary>
        /// Temporarily modifies settings to allow large numbers of changes to be made efficiently
        /// </summary>
        public void EnableMassChanges()
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        /// <summary>
        /// Saves all changes
        /// </summary>
        /// <returns>the number of changes saved</returns>
        public int Save()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                                        .SelectMany(x => x.ValidationErrors)
                                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
