using AutoMapper;
using HR.DAL;
using HR.DTO.Department;
using HR.DTO.Task;
using HR.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Task = HR.DAL.Task;

namespace HR.Helper.Mapping
{
    public class MappingProfile : Profile
    {
        public static void Initialize()
        {
            //Entity to Model

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AspNetUser, UserVM>()
                    .ForMember(d => d.Manager, opt => opt.MapFrom(src => src.AspNetUser1))
                    .ForMember(d => d.Managers, opt => opt.MapFrom(src => src.AspNetUsers1))
                    .ForMember(d => d.ManagerTasks, opt => opt.MapFrom(src => src.Tasks1));

                cfg.CreateMap<Task, TaskVM>()
                    .ForMember(d => d.Employee, opt => opt.MapFrom(src => src.AspNetUser))
                    .ForMember(d => d.Manager, opt => opt.MapFrom(src => src.AspNetUser1));


                cfg.CreateMap<TaskVM, Task>()
                    .ForMember(d => d.AspNetUser, opt => opt.MapFrom(src => src.Employee))
                    .ForMember(d => d.AspNetUser1, opt => opt.MapFrom(src => src.Manager));

                cfg.CreateMap<DepartmentVM, Department>()
                    .ForMember(d => d.AspNetUsers, opt => opt.MapFrom(src => src.Users))
                ;
                cfg.CreateMap<Department, DepartmentVM>()
                    .ForMember(d => d.Users, opt => opt.MapFrom(src => src.AspNetUsers))
                ;

                cfg.CreateMap<UserVM, SelectListItem>()
                    .ForMember(d => d.Value, opt => opt.MapFrom(src => src.Id))
                    .ForMember(d => d.Text, opt => opt.MapFrom(src => src.FullName));

                cfg.CreateMap<DepartmentVM, SelectListItem>()
                    .ForMember(d => d.Value, opt => opt.MapFrom(src => src.Id))
                    .ForMember(d => d.Text, opt => opt.MapFrom(src => src.Name));

            });

        }
    }
}
