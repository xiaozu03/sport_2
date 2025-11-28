using System.Threading.Tasks;

namespace oculus_sport.Services.Auth
{
    public class FirebaseAuthService : IAuthService
    {
        // Mock Login: Always returns true for now
        public async Task<bool> LoginAsync(string email, string password)
        {
            // Simulate network delay
            await Task.Delay(1000);

            // In a real app, this is where we'd call Firebase
            // return await CrossFirebase.Auth.SignInWithEmailAndPasswordAsync(email, password);

            return true; // Simulate success
        }

        // Mock Sign Up: Always returns true
        public async Task<bool> SignUpAsync(string email, string password)
        {
            await Task.Delay(1000);
            return true; // Simulate success
        }

        // Mock Logout: Just returns (avoids the crash)
        public void Logout()
        {
            // In a real app:
            // CrossFirebase.Auth.SignOut();

            // For now, we do nothing, just let the UI navigate away
        }
    }
}