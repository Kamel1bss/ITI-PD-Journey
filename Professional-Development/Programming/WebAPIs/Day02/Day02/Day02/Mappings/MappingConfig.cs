using AutoMapper;
using Day01.Contracts.Requests;

//using Day01.Contracts.Requests;
using Day01.Contracts.Responses;
using Day01.Models;

namespace Day01.Mappings;

public class MappingConfig : Profile
{
    public MappingConfig()
    {
        CreateMap<Student, StudentResponse>()
            .AfterMap((src, dest) =>
            {
                dest.StLname = src.StLname;
                dest.StFname = src.StFname;
                dest.DeptName = src.Dept?.DeptName;
                dest.SupervisorName = src.StSuperNavigation != null
                    ? $"{src.StSuperNavigation.StFname} {src.StSuperNavigation.StLname.Trim()}"
                    : null;
                dest.StAddress = src.StAddress;
                dest.StAge = src.StAge;
                dest.StId = src.StId;
               
            });

            
        CreateMap<StudentRequest, Student>()
            .AfterMap((src, dest) =>
            {
                dest.StLname = src.StLname;
                dest.StFname = src.StFname;
                dest.StAddress = src.StAddress;
                dest.StAge = src.StAge;
                dest.StId = src.StId;
            });

        CreateMap<Department, DepartmentResponse>()
            .AfterMap((src, dest) =>
            {
                dest.DeptName = src.DeptName;
                dest.DeptId = src.DeptId;
                dest.DeptLocation = src.DeptLocation;
                dest.DeptId = src.DeptId;
                dest.StudentsCount = src.Students != null ? src.Students.Count : 0;
            });

        CreateMap<DepartmentRequest, Department>()
            .AfterMap((src, dest) =>
            {
                dest.DeptName = src.DeptName;
                dest.DeptLocation = src.DeptLocation;
                dest.DeptId = src.DeptId;
                dest.DeptDesc = src.DeptDesc;
            });
    }
}
