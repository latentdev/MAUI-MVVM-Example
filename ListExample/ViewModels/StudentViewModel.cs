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
        DateTime dateOfBirth;

        public int Age => CalculateAge(DateOfBirth);

        [ObservableProperty]
        List<StudentViewModel> notAllowed = new List<StudentViewModel>();

        public event EventHandler<StudentViewModel> StudentAdded;
        public event EventHandler<StudentViewModel> StudentUpdated;
        public event EventHandler<StudentViewModel> Cancelled;
        public event EventHandler<StudentViewModel> StudentDeleted;

        public StudentViewModel(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        [RelayCommand]
        public async Task SaveStudentAsync()
        {
            StudentAdded?.Invoke(this, this);
        }

        [RelayCommand]
        public async Task UpdateStudentAsync()
        {
            StudentUpdated?.Invoke(this, this);
        }

        [RelayCommand]
        public async Task CancelStudentAsync()
        {
            Cancelled?.Invoke(this, this);
        }

        [RelayCommand]
        public async Task DeleteStudentAsync()
        {
            StudentDeleted?.Invoke(this, this);
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--; // Adjust if birthday hasn't occurred this year
            return age;
        }
    }
}
