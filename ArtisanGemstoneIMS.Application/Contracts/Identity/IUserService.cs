using ArtisanGemstoneIMS.WebUI.Shared.Identity;

namespace ArtisanGemstoneIMS.Application.Contracts.Identity;

public interface IUserService
{
    Task<List<Employee>> GetEmployees();
    Task<Employee> GetEmployee(string employeeId);
}
