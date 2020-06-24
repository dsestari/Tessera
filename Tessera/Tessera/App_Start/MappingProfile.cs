using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tessera.Dtos;
using Tessera.Models;

namespace Tessera.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to DTO
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<UserStatus, UserStatusDto>();
            Mapper.CreateMap<Group, GroupDto>();
            Mapper.CreateMap<GroupStatus, GroupStatusDto>();
            Mapper.CreateMap<Ticket, TicketDto>();
            Mapper.CreateMap<TicketStatus, TicketStatusDto>();
            Mapper.CreateMap<Priority, PriorityDto>();
            Mapper.CreateMap<TicketAction, TicketActionDto>();
            
            // DTO to Domain
            Mapper.CreateMap<UserDto, User>()
                .ForMember(u => u.Id, opt => opt.Ignore());

            Mapper.CreateMap<TicketDto, Ticket>()
                .ForMember(t => t.Id, opt => opt.Ignore());
        }
    }
}