

namespace Spellfire.Dal
{
    public abstract class MyRepositoryBase<TEntity> : RepositoryBase<TEntity, SpellfireContext>
        where TEntity : class
    {
        protected MyRepositoryBase(SpellfireContext context)
            : base(context)
        {
        }
    }
}