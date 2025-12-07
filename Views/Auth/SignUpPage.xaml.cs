using Microsoft.Maui.Controls;
using oculus_sport.ViewModels.Auth;

namespace oculus_sport.Views.Auth
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage(SignUpPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
