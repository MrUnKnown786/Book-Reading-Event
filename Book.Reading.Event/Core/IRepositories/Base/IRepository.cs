using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Reading.Event.Base;

namespace Book.Reading.Event.Core.IRepositories.Base
{
    public interface IRepository<T> where T : Entity
    {
    }
}
