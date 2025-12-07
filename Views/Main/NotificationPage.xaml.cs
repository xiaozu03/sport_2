using oculus_sport.ViewModels.Main;

namespace oculus_sport.Views.Main;

public partial class NotificationPage : ContentPage
{
    public NotificationPage(NotificationPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}