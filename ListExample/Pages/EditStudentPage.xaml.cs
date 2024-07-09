using ListExample.ViewModels;

namespace ListExample.Pages;

public partial class EditStudentPage : ContentPage
{
	public EditStudentPage(StudentViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}