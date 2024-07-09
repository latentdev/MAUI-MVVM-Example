using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExample.ViewModels
{
    public partial class StudentViewModel : ObservableObject
    {
        [ObservableProperty]
        Guid id = Guid.NewGuid();

        [ObservableProperty]
        string firstName = "";

        [ObservableProperty]
        string lastName = "";

        [ObservableProperty]
        int age = 0;

        [ObservableProperty]
        List<StudentViewModel> notAllowed = new List<StudentViewModel>();

        public event EventHandler<StudentViewModel> StudentAdded;
        public event EventHandler<StudentViewModel> StudentUpdated;

        public StudentViewModel(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        [RelayCommand]
        public async Task SaveStudentAsync()
        {
            StudentAdded?.Invoke(this, this);
            await Shell.Current.Navigation.PopModalAsync();
        }

        [RelayCommand]
        public async Task UpdateStudentAsync()
        {
            StudentUpdated?.Invoke(this, this);
            await Shell.Current.Navigation.PopModalAsync();
        }

        [RelayCommand]
        public async Task CancelNewStudentAsync()
        {
            await Shell.Current.Navigation.PopModalAsync();
        }
    }
}
