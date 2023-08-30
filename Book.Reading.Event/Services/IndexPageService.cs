using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Reading.Event.Interfaces;

namespace Book.Reading.Event.Services
{
    public class IndexPageService : IIndexPageService
    {
        private readonly IMapper _mapper;
        public IndexPageService(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
