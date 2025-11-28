using CommunityToolkit.Mvvm.ComponentModel;

namespace oculus_sport.ViewModels.Base
{
    // ObservableObject comes from CommunityToolkit.Mvvm
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _title = string.Empty;
    }
}