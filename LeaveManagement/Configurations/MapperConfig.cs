﻿using AutoMapper;
using LeaveManagement.Data;
using LeaveManagement.Models;

namespace LeaveManagement.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<LeaveType, LeaveTypeViewModel>().ReverseMap();

            CreateMap<Employee,EmployeeListViewModel>().ReverseMap();
            CreateMap<Employee,EmployeeAllocationViewModel>().ReverseMap();

            CreateMap<LeaveAllocation,LeaveAllocationViewModel>().ReverseMap();
            CreateMap<LeaveAllocation,LeaveAllocationEditViewModel>().ReverseMap();
        }
    }
}
