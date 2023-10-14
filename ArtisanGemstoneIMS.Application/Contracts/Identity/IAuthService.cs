using ArtisanGemstoneIMS.WebUI.Shared.Identity;

namespace ArtisanGemstoneIMS.Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}
