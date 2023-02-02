using AutoMapper;
using LeavManagemnt_.NET6.Data;
using LeavManagemnt_.NET6.Models;

namespace LeavManagemnt_.NET6.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
            CreateMap<Employee,EmployeeListVM>().ReverseMap();
            CreateMap<EmployeeAllocationVM, Employee>().ReverseMap();    
            CreateMap<LeaveAllocationVM, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveAllocationEditVM, LeaveAllocation>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestCreateVM>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestVM>().ReverseMap();
        }
    }
}
