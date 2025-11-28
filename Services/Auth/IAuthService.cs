using System.Threading.Tasks;

namespace oculus_sport.Services.Auth
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(string email, string password);
        Task<bool> SignUpAsync(string email, string password);
        void Logout();
    }
}
