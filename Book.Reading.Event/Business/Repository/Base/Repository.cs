using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Reading.Event.Base;
using Book.Reading.Event.Core.IRepositories.Base;
using Book.Reading.Event.Business.Data;

namespace Book.Reading.Event.Business.Repository.Base
{
    public class Repository<T> : IRepository<T> where T: Entity
    {
        private readonly EventContext _eventContext;

        public Repository(EventContext eventContext)
        {
            this._eventContext = eventContext ?? throw new ArgumentNullException(nameof(eventContext)); ;
        }
    }
}
