using AutoMapper;
using CompanyEmployee.Controllers;
using CompanyEmployee.Mappings;
using Contracts;
using Entities;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.Protocol;
using Repository;

namespace CompanyEmployeeTest;

public class CompanyEmployeeTest
{
    private List<Company> GetTestCompanies()
    {
        var companies = new List<Company>();
        
        companies.Add(new Company()
        {
            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            Name = "IT_Solutions Ltd",
            Address = "583 Wall Dr. Gwynn Oak, MD 21207",
            Country = "USA Test"
        });
        
        companies.Add(new Company()
        {
            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
            Name = "Admin_Solutions Ltd",
            Address = "312 Forest Avenue, BF 923",
            Country = "USA Test"
        });
 
        return companies;
    }
    
    private List<CompanyDto> GetTestCompanyDtos()
    {
        var companyDtos = new List<CompanyDto>();
        
        companyDtos.Add(new CompanyDto()
        {
            Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
            Name = "IT_Solutions Ltd",
            FullAddress  = "583 Wall Dr. Gwynn Oak, MD 21207",
        });
        
        companyDtos.Add(new CompanyDto()
        {
            Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
            Name = "Admin_Solutions Ltd",
            FullAddress = "312 Forest Avenue, BF 923",
          
        });
 
        return companyDtos;
    }

    [Fact]
    public void GetAllCompanies_returns_all_companies()
    {
        // Arrange
        var mockRepo = new Mock<IRepositoryManager>();
        var mockLogger = new Mock<ILoggerManager>();
        var response = new List<CompanyDto>();
        
        mockRepo.Setup(repo => repo.Company.GetAllCompanies(false)).Returns(GetTestCompanies());
        
        var myProfile = new MappingProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        
        IMapper mapper = new Mapper(configuration);
        var controller = new CompaniesController(mockRepo.Object, mockLogger.Object,mapper);

        // Act
        var result = controller.GetCompanies();

        ObjectResult objectResult = (OkObjectResult)result;
        if (objectResult.Value != null)
        {
            response =  (List<CompanyDto>) objectResult.Value; 
        }
        
        
        // Assert
        Assert.Equal(2, response.Count);
        Assert.IsType<CompanyDto>(response.First());

    }
}