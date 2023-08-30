using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Reading.Event.Application.Models;
using Book.Reading.Event.Models;

namespace Book.Reading.Event.Mapper
{
    public class EventProfiles : Profile
    {
        public EventProfiles()
        {
            CreateMap<EventModel, EventViewModel>().ReverseMap();
            CreateMap<SignUpModel, SignUpViewModel>().ReverseMap();
            CreateMap<LoginModel, LoginViewModel>().ReverseMap();
            CreateMap<CommentModel, CommentViewModel>().ReverseMap();
        }
    }
}
