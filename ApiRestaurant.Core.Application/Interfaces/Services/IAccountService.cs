using ApiRestaurant.Core.Application.DTO_S.Account;

namespace ApiRestaurant.Core.Application.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegisterResponse> RegisterAdminAsync(RegisterRequest request);
        Task<RegisterResponse> RegisterWaiterAsync(RegisterRequest request);
    }
}