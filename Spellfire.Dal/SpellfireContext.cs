namespace Spellfire.Dal
{
    using Spellfire.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

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

        public DbSet<Booster> Boosters { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<CardCharacteristic> CardCharacteristics { get; set; }
        public DbSet<CardPhase> CardPhases { get; set; }
        public DbSet<CardKind> CardKinds { get; set; }
        public DbSet<Kind> Kinds { get; set; }
        public DbSet<Rarity> Rarities { get; set; }
        public DbSet<World> Worlds { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but before the model has
        /// been locked down and used to initialize the context. The default implementation of this method does nothing,
        /// but it can be overridden in a derived class such that the model can be further configured before it is
        /// locked down.
        /// </summary>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context is created. The
        /// model for that context is then cached and is for all further instances of the context in the app domain.
        /// This caching can be disabled by setting the ModelCaching property on the given <c>ModelBuilder</c>, but note
        /// that this can seriously degrade performance. More control over caching is provided through use of the
        /// <c>DbModelBuilder</c> and <c>DbContextFactory</c> classes directly.
        /// </remarks>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            // set initializer to null for this class and any potential subclass
            Expression<Action> setInitializerExpression = () => Database.SetInitializer<SpellfireContext>(null);
            var setInitializerCall = (MethodCallExpression)setInitializerExpression.Body;
            var setInitializerMethodInfo =
                setInitializerCall.Method.GetGenericMethodDefinition().MakeGenericMethod(GetType());
            setInitializerMethodInfo.Invoke(null, new object[] { null });
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
