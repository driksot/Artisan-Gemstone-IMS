using ArtisanGemstoneIMS.Application.Contracts.Identity;
using ArtisanGemstoneIMS.Infrastructure.Identity.Models;
using ArtisanGemstoneIMS.WebUI.Shared.Identity;
using Microsoft.AspNetCore.Identity;

namespace ArtisanGemstoneIMS.Infrastructure.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Employee> GetEmployee(string employeeId)
    {
        var employee = await _userManager.FindByIdAsync(employeeId);
        return new Employee
        {
            Id = employee!.Id,
            Email = employee.Email!,
            FirstName = employee.FirstName,
            LastName = employee.LastName
        };
    }

    public async Task<List<Employee>> GetEmployees()
    {
        var employees = await _userManager.GetUsersInRoleAsync("Employee");
        return employees.Select(q => new Employee
        {
            Id = q.Id,
            Email = q.Email!,
            FirstName = q.FirstName,
            LastName = q.LastName
        }).ToList();
    }
}
