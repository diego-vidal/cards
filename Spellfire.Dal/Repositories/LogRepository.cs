using Spellfire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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