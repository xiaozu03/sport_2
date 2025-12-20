# OCULUS_Sport - Campus Sports Booking App

![.NET 9](https://img.shields.io/badge/.NET-9.0-blueviolet)
![.NET MAUI](https://img.shields.io/badge/.NET%20MAUI-Multiplatform-green.svg)
![MVVM](httpshttps://img.shields.io/badge/Architecture-MVVM-orange)

## 1. Project Overview

This is the official repository for the **Campus Sports Facilities Booking App**, a cross-platform mobile application developed with **.NET MAUI** (for .NET 9). This project is designed to meet the requirements of the (Your Course/Module Name) assignment.

The application allows students and staff of the university (UTS) to browse, book, and manage reservations for on-campus sports facilities, including 3 badminton courts, 4 ping-pong courts, and 1 basketball court.

The project is built following a strict **MVVM (Model-View-ViewModel)** pattern and integrates with **Firebase** for real-time data and authentication, and **SQLite** for offline data storage (e.g., booking history and user profiles).

## 2. Technology Stack

* **Framework:** .NET MAUI (.NET 9)
* **Architecture:** Model-View-ViewModel (MVVM)
* **Remote Database:** Firebase (Firestore or Realtime Database)
* **Authentication:** Firebase Authentication
* **Local Database:** SQLite (for offline capabilities)
* **UI:** XAML

## 3. Core Features

* **User Authentication:** Secure Login and Sign Up for students.
* **Facility Browsing:** View a list of all available sports (Pickleball, Badminton, Football, etc.) and courts.
* **Real-time Booking:** Select a facility, date, and time slot. The app checks for availability in real-time.
* **Payment Flow:** A complete booking flow, from selection to confirmation.
* **Booking History:** Users can view their past and upcoming bookings. This data is available offline.
* **Offline Profile:** User profile information is stored locally on the device.
* **Event & Schedule Viewing:** The main tab bar includes navigation for Home, Schedule, Events, History, and Profile.

---

## 4. Architectural Pattern: MVVM

This project strictly adheres to the **MVVM (Model-View-ViewModel)** pattern to ensure a clean separation of concerns, testability, and maintainability.



* **Model:** Represents the data objects of our app. (e.g., `User.cs`, `Booking.cs`, `Facility.cs`). These are "dumb" classes that just hold data.
* **View:** The UI (User Interface) layer. This is defined in `.xaml` files (e.g., `LoginPage.xaml`). The View is responsible *only* for displaying data and forwarding user actions (like button clicks) to the ViewModel.
* **ViewModel:** The "brain" of the View. It contains all the UI logic, data properties, and commands. (e.g., `LoginPageViewModel.cs`). It knows nothing about the View. Data Binding connects the View and ViewModel.

## 5. Project File Structure
```
/CampusSports.App
├── Helpers/                      # Helper classes and constants
│   └── MessagingCenterKeys.cs    # Keys for pub/sub messaging
│
├── Models/                       # Data models
│   ├── Booking.cs                # Reservation entity
│   ├── Facility.cs               # Facility details (includes Geo-coordinates)
│   ├── NotificationItem.cs       # Notification model
│   ├── SportCategory.cs          # Categories (Badminton, Basketball, etc.)
│   ├── SportEvent.cs             # Campus event updates
│   ├── TimeSlot.cs               # Booking time slots
│   └── User.cs                   # User profile model
│
│
├── Services/                     # Business logic and data access
│   ├── Auth/                     # Authentication services
│   │   ├── FirebaseAuthService.cs
│   │   └── IAuthService.cs
│   ├── Other/                    # General services
│   │   ├── BookingService.cs
│   │   ├── ConnectivityService.cs
│   │   ├── IBookingService.cs
│   │   └── NotificationService.cs
│   └── Storage/                  # Data persistence
│       ├── FirebaseDataService.cs
│       ├── IDatabaseService.cs
│       └── LocalDatabaseService.cs
│
├── ViewModels/                   # MVVM ViewModels
│   ├── Auth/                     # Authentication logic
│   │   ├── LoginPageViewModel.cs
│   │   └── SignUpPageViewModel.cs
│   ├── Base/
│   │   └── BaseViewModel.cs      # Shared ViewModel functionality
│   └── Main/                     # Core feature logic
│       ├── BookingConfirmationViewModel.cs
│       ├── BookingDetailsViewModel.cs
│       ├── BookingSuccessViewModel.cs
│       ├── BookingViewModel.cs
│       ├── EventDetailsViewModel.cs
│       ├── EventPageViewModel.cs
│       ├── HistoryPageViewModel.cs
│       ├── HomePageViewModel.cs
│       ├── NotificationPageViewModel.cs
│       ├── ProfilePageViewModel.cs
│       └── SchedulePageViewModel.cs
│
├── Views/                        # UI Pages (XAML + Code-behind)
│   ├── Auth/                     # Login & Signup screens
│   │   ├── LoginPage.xaml
│   │   └── SignUpPage.xaml
│   └── Main/                     # Main app screens
│       ├── BookingConfirmationPage.xaml
│       ├── BookingDetailsPage.xaml
│       ├── BookingPage.xaml      # Includes Map View
│       ├── BookingSuccessPage.xaml
│       ├── EventDetailsPage.xaml
│       ├── EventPage.xaml
│       ├── HistoryPage.xaml
│       ├── HomePage.xaml
│       ├── NotificationPage.xaml
│       ├── ProfilePage.xaml
│       └── SchedulePage.xaml
│
├── App.xaml                      # App entry point & global resources
├── AppShell.xaml                 # App navigation shell
├── GlobalXmlns.cs                # Global XML namespace definitions
├── MauiProgram.cs                # Dependency injection & app configuration
└── oculus_sport.csproj           # Project file
```
## 6. Getting Started

### Prerequisites

* .NET 9 SDK
* Visual Studio 2022 (with .NET MAUI workload) or Visual Studio Code
* A Firebase project (for authentication and database)
* Android Emulator or a physical device

### Configuration

1.  **Clone the repository:**
    ```bash
    git clone https://(your-repo-url).git
    cd CampusSports.App
    ```
2.  **Restore dependencies:**
    ```bash
    dotnet restore
    ```
3.  **Add Firebase Configuration:**
    * **For Android:** Download your `google-services.json` file from the Firebase console and place it in `/Platforms/Android/`.
    * **For iOS:** Download your `GoogleService-Info.plist` file from Firebase and place it in `/Platforms/iOS/`.
    * *Note: Ensure the build action for these files is set correctly (`GoogleServicesJson` for Android, `BundleResource` for iOS).*

4.  **Build and Run:**
    * Open the solution in Visual Studio.
    * Select your target (e.g., "Android Emulator").
    * Press the "Run" button.

## 7. Key Concepts Demonstrated

This project is designed to demonstrate a wide range of core .NET MAUI and mobile development concepts as required:

* **App Class & Life-cycle:** `App.xaml.cs` manages the `OnStart`, `OnSleep`, and `OnResume` app life-cycle events.
* **MVVM:** The entire project architecture (see section 4).
* **In-app Navigation:** Handled by `AppShell.xaml` for the main tab bar and `Shell.Current.GoToAsync(...)` for all other navigation.
* **Data Binding:** Used in all `Views/` to connect UI elements to `ViewModel/` properties (e.g., `{Binding Username}`).
* **Localization:** The `Resources/Strings/` directory is set up to hold translated strings.
* **Messaging Center:** Used for decoupled, message-based communication between ViewModels (e.g., notifying one VM from another).
* **Notification:** The `NotificationService.cs` will be used to implement local push notifications.
* **Data Storage:** The `Services/Storage/` directory demonstrates using two data services (SQLite for local, Firebase for remote) behind a common interface.
* **Multimedia:** The `Resources/Images/` folder is used to store and display images.
* **Connectivity:** The `ConnectivityService.cs` is used to check for an active internet connection before making Firebase calls.
