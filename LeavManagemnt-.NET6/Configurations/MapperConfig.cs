using AutoMapper;
using LeavManagemnt_.NET6.Models;

namespace LeavManagemnt_.NET6.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
        }
    }
}
