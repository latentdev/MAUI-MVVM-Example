using ListExample.ViewModels;

namespace ListExample.Views;

public partial class StudentEdit: ContentView
{
	public StudentEdit(StudentViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}