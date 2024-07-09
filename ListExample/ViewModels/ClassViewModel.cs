using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ListExample.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExample.ViewModels
{
    public partial class ClassViewModel : ObservableObject
    {
        [ObservableProperty]
        Guid id = Guid.NewGuid();

        [ObservableProperty]
        string className = "CST 401";

        [ObservableProperty]
        ObservableCollection<StudentViewModel> students = new() { new StudentViewModel("Nick", "Olson", 37)};

        public ClassViewModel(string className)
        {
            ClassName = className;
        }

        [RelayCommand]
        public async Task AddStudent()
        {
            var student = new StudentViewModel("", "", 0);
            student.StudentAdded += (sender, student) =>
            {
                //should probably do some checks to see if the student is already in the list
                Students.Add(student);
            };
            await Shell.Current.Navigation.PushModalAsync(new EditStudentPage(student));
        }

        //[RelayCommand]
        //public void RemoveStudent(StudentViewModel student)
        //{
        //    Students.Remove(student);
        //}

        //[RelayCommand]
        //public void EditStudent(StudentViewModel student, string firstName, string lastName, int age)
        //{
        //    student.FirstName = firstName;
        //    student.LastName = lastName;
        //    student.Age = age;
        //}
    }
}
