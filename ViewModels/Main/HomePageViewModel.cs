using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using oculus_sport.Models;
using oculus_sport.Services.Auth;
using oculus_sport.Services.Storage;
using oculus_sport.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace oculus_sport.ViewModels.Main
{
<<<<<<< HEAD
=======
    // This allows the Login Page to pass the "User" object directly to Home
>>>>>>> master
    [QueryProperty(nameof(CurrentUser), "User")]
    public partial class HomePageViewModel : BaseViewModel
    {
        // ----------------- Services -----------------
        private readonly FirebaseDataService _dataService;
        private readonly IAuthService _authService;

        // ----------------- Fields -----------------
        private string? _idToken;
        private List<Facility> _allFacilities = new();

        // ----------------- Observable Properties -----------------
        [ObservableProperty]
        private ObservableCollection<SportCategory> _categories = new();

        [ObservableProperty]
        private ObservableCollection<Facility> _facilities = new();

        [ObservableProperty]
        private string _userName = "Guest";

        [ObservableProperty]
        private User _currentUser;

        [ObservableProperty]
        private string _statusMessage = string.Empty;

        // ----------------- Constructor -----------------
        public HomePageViewModel(FirebaseDataService dataService, IAuthService authService)
        {
            _dataService = dataService;
            _authService = authService;
            Title = "Home";

<<<<<<< HEAD
            // 1. Initial User Load (From AuthService state)
=======
            // 1. Initial User Load (Try to get from AuthService memory first)
            // This handles the case where the app is just opening and user is already logged in
>>>>>>> master
            var cachedUser = _authService.GetCurrentUser();
            if (cachedUser != null)
            {
                CurrentUser = cachedUser;
                UserName = cachedUser.Name;
            }

            LoadCategories();

<<<<<<< HEAD
            // Start data load immediately
            Task.Run(LoadDataAsync);
        }

        // ----------------- User Sync -----------------

=======
            // Kick off data loading immediately
            Task.Run(LoadDataAsync);
        }

        // ----------------- User Sync (Critical for Login) -----------------

        // This method is called automatically when the [QueryProperty] "User" is set
        // (i.e., when navigating from Login Page -> Home Page)
>>>>>>> master
        partial void OnCurrentUserChanged(User value)
        {
            if (value != null)
            {
<<<<<<< HEAD
                UserName = value.Name;
                // If the user object has an ID Token, store it (optional, as we usually get it from SecureStorage)
                // _idToken = value.IdToken; 

                // Reload data if user changes
=======
                Debug.WriteLine($"[HomeViewModel] User Changed: {value.Name}");
                UserName = value.Name;

                // If the user object passed in has a fresh token, use it
                if (!string.IsNullOrEmpty(value.IdToken))
                {
                    _idToken = value.IdToken;
                }

                // Reload data for this specific user
>>>>>>> master
                _ = LoadDataAsync();
            }
        }

<<<<<<< HEAD
        // Helper to sync user state if needed manually
        public async Task UserHomepageSync(string uid, string idToken)
        {
            _idToken = idToken;
            // Note: We are reusing the existing method from FirebaseDataService if available, 
            // or just updating the local user object.
            var user = await _dataService.GetUserProfileAsync(uid);
            if (user != null)
            {
                CurrentUser = user;
            }
=======
        // Helper to sync user state manually if needed (e.g. from App.xaml.cs startup)
        public async Task UserHomepageSync(string uid, string idToken)
        {
            _idToken = idToken;
            var user = await _dataService.GetUserFromFirestore(uid, idToken);
            if (user != null)
            {
                user.IdToken = idToken;
                CurrentUser = user; // Triggers OnCurrentUserChanged
            }
        }

        // ----------------- Page Lifecycle (Called by HomePage.xaml.cs) -----------------

        public async Task LoadAsync()
        {
            // 1. Get Token from Storage
            var idToken = await SecureStorage.GetAsync("idToken");

            // 2. Validate Token
            if (string.IsNullOrEmpty(idToken) || IsTokenExpired(idToken))
            {
                StatusMessage = "Session expired. Please log in again.";
                await Shell.Current.GoToAsync("//LoginPage");
                return;
            }

            _idToken = idToken;

            // 3. Get/Refresh User
            // If we navigated here normally, CurrentUser might already be set. 
            // If not (cold start), we fetch it.
            var user = _authService.GetCurrentUser();
            if (user != null)
            {
                UserName = user.Name;
                user.IdToken = idToken;
                CurrentUser = user;
            }
            else
            {
                // Fallback: fetch user from DB using stored ID
                var uid = Preferences.Get("LastUserId", "");
                if (!string.IsNullOrEmpty(uid))
                {
                    await UserHomepageSync(uid, idToken);
                }
            }

            // 4. Ensure Data is Loaded
            if (_allFacilities.Count == 0)
            {
                await LoadDataAsync();
            }
>>>>>>> master
        }

        // ----------------- Data Loading (Merged with Map Logic) -----------------

        private void LoadCategories()
        {
<<<<<<< HEAD
            Categories.Add(new SportCategory { Name = "Badminton", IsSelected = true });
            Categories.Add(new SportCategory { Name = "Ping-Pong" }); // Ensure naming matches your DB/Filter
=======
            Categories.Clear();
            Categories.Add(new SportCategory { Name = "Badminton", IsSelected = true });
            Categories.Add(new SportCategory { Name = "Ping-Pong" });
>>>>>>> master
            Categories.Add(new SportCategory { Name = "Basketball" });
        }

        private async Task LoadDataAsync()
        {
            if (IsBusy) return;
<<<<<<< HEAD
=======

            // Double check token availability
            if (string.IsNullOrEmpty(_idToken)) _idToken = await SecureStorage.GetAsync("idToken");
            if (string.IsNullOrEmpty(_idToken)) return;

>>>>>>> master
            IsBusy = true;

            try
            {
<<<<<<< HEAD
                // 1. Fetch from Firestore (Using our REST Service)
                var fetchedFacilities = await _dataService.GetFacilitiesFromFirestoreAsync();

                _allFacilities.Clear();

                // 2. Process and Assign Local Maps (Our Map Logic)
                foreach (var facility in fetchedFacilities)
                {
                    // Logic to assign the correct local map image
                    if (facility.Name.Contains("Badminton", StringComparison.OrdinalIgnoreCase))
                        facility.LocationMapUrl = "recreation_center.png";
                    else if (facility.Name.Contains("Ping", StringComparison.OrdinalIgnoreCase)) // Catch Ping-Pong/PingPong
                        facility.LocationMapUrl = "recreational_center.png";
                    else if (facility.Name.Contains("Basketball", StringComparison.OrdinalIgnoreCase))
=======
                // Fetch from Firestore using the ID Token
                var fetchedFacilities = await _dataService.GetFacilitiesAsync(_idToken);

                _allFacilities.Clear();

                // Process and Assign Local Maps (Your Map Logic)
                foreach (var facility in fetchedFacilities)
                {
                    // Logic to assign the correct local map image based on name
                    if (facility.FacilityName.Contains("Badminton", StringComparison.OrdinalIgnoreCase))
                        facility.LocationMapUrl = "recreation_center.png";
                    else if (facility.FacilityName.Contains("Ping", StringComparison.OrdinalIgnoreCase))
                        facility.LocationMapUrl = "recreation_center.png";
                    else if (facility.FacilityName.Contains("Basketball", StringComparison.OrdinalIgnoreCase))
>>>>>>> master
                        facility.LocationMapUrl = "outdoor_court.png";
                    else
                        facility.LocationMapUrl = "recreation_center.png"; // Fallback

                    _allFacilities.Add(facility);
                }

<<<<<<< HEAD
                // 3. Update UI on Main Thread
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    // Default filter
=======
                // Update UI on Main Thread
                MainThread.BeginInvokeOnMainThread(() =>
                {
>>>>>>> master
                    FilterFacilities("Badminton");
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Error] LoadDataAsync: {ex.Message}");
<<<<<<< HEAD
                await Shell.Current.DisplayAlert("Error", $"Could not load facilities: {ex.Message}", "OK");
=======
>>>>>>> master
            }
            finally
            {
                IsBusy = false;
            }
        }

<<<<<<< HEAD
        // ----------------- Interaction Logic -----------------
=======
        // ----------------- Filtering & Interaction -----------------
>>>>>>> master

        [RelayCommand]
        void SelectCategory(SportCategory category)
        {
            if (Categories == null) return;
            foreach (var c in Categories) c.IsSelected = false;
            category.IsSelected = true;

            FilterFacilities(category.Name);
        }

        private void FilterFacilities(string categoryName)
        {
            Facilities.Clear();

            // Handle naming mismatch (Ping-Pong vs Ping)
            string searchTerm = categoryName;
            if (categoryName.Contains("Ping")) searchTerm = "Ping";

            var filtered = _allFacilities
<<<<<<< HEAD
                .Where(f => f.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
=======
                .Where(f => f.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)
                         || f.FacilityName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
>>>>>>> master

            foreach (var facility in filtered)
            {
                Facilities.Add(facility);
            }
        }

        [RelayCommand]
        async Task BookFacility(Facility facility)
        {
<<<<<<< HEAD
            Debug.WriteLine($"[DEBUG] Selected Facility: {facility.Name}");
=======
            Debug.WriteLine($"[DEBUG] Selected Facility: {facility.FacilityName}");
>>>>>>> master
            var navigationParameter = new Dictionary<string, object> { { "Facility", facility } };
            await Shell.Current.GoToAsync("BookingPage", navigationParameter);
        }

        [RelayCommand]
        async Task GoToNotifications()
        {
            await Shell.Current.GoToAsync("NotificationPage");
        }

<<<<<<< HEAD
        // ----------------- Token Validation -----------------

        public async Task LoadAsync()
        {
            var user = _authService.GetCurrentUser();
            if (user == null)
            {
                StatusMessage = "No logged in user detected.";
                // Optional: Force login
                // await Shell.Current.GoToAsync("//LoginPage"); 
                return;
            }

            // Check token validity
            var idToken = await SecureStorage.GetAsync("idToken");
            if (string.IsNullOrEmpty(idToken) || IsTokenExpired(idToken))
            {
                StatusMessage = "Session expired. Please log in again.";
                await Shell.Current.GoToAsync("//LoginPage");
                return;
            }

            // If valid, ensure UI is up to date
            StatusMessage = $"Welcome back, {user.Name}";

            // Optionally refresh token if API supports it
            await _authService.RefreshIdTokenAsync();
        }
=======
        // ----------------- Token Helper -----------------
>>>>>>> master

        private bool IsTokenExpired(string idToken)
        {
            try
            {
                var parts = idToken.Split('.');
                if (parts.Length != 3) return true;

                var payload = parts[1];
                var payloadPad = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=');
                var jsonBytes = Convert.FromBase64String(payloadPad);
                var json = System.Text.Encoding.UTF8.GetString(jsonBytes);

<<<<<<< HEAD
                // Simple regex to find exp claim
=======
>>>>>>> master
                var expMatch = System.Text.RegularExpressions.Regex.Match(json, "\"exp\":(\\d+)");
                if (!expMatch.Success) return true;

                var expUnix = long.Parse(expMatch.Groups[1].Value);
                var expDate = DateTimeOffset.FromUnixTimeSeconds(expUnix);

                return expDate < DateTimeOffset.UtcNow;
            }
            catch
            {
<<<<<<< HEAD
                return true; // Assume expired if parse fails
            }
        }
    }
}
=======
                return true;
            }
        }
    }
}
>>>>>>> master
