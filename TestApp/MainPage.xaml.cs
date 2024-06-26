using TestApp.ViewModels;

namespace TestApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new TextModifierViewModel();
        }
    }

}
