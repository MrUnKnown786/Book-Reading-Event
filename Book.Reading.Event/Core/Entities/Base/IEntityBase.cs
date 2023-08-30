using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Reading.Event.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
