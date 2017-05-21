using Spellfire.Model;

namespace Spellfire.Dal
{
    public class LogRepository : MyRepositoryBase<Log>, ILogRepository
    {
        public LogRepository(SpellfireContext context)
            : base(context)
        {
        }
    }
}