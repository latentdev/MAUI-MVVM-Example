using ListExample.ViewModels;

namespace ListExample.Views;

public partial class StudentDetail : ContentView
{
	public StudentDetail(StudentViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}