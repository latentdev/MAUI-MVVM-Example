using ListExample.ViewModels;

namespace ListExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ClassViewModel("CST 401");
        }
    }
}
