using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ListExample.Views;
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
        object currentView;

        [ObservableProperty]
        public StudentViewModel selectedStudent;

        public ObservableCollection<StudentViewModel> Students { get; }

        public ClassViewModel(string className)
        {
            ClassName = className;
            Students = new ObservableCollection<StudentViewModel>
            {
                new StudentViewModel("Nick", "Olson", new DateTime(1987, 9, 6)),
                new StudentViewModel("John", "Doe", new DateTime(1992, 3, 21)),
                new StudentViewModel("Jane", "Doe", new DateTime(1964, 3, 30))
            };
            SelectedStudent = Students[0];
            CurrentView = new StudentEdit(SelectedStudent);
        }

        [RelayCommand]
        public async Task AddStudent()
        {
            var student = new StudentViewModel("", "", new DateTime(1987,9,6));
            student.StudentAdded += (sender, student) =>
            {
                var index = Students.IndexOf(student);
                if (index == -1)
                    Students.Add(student);
                else
                    Students[index] = student;
                student.StudentAdded -= (sender, student) => { };
                SelectedStudent = student;
                CurrentView = new StudentDetail(student);
            };
            CurrentView = new StudentEdit(student);
        }


        partial void OnSelectedStudentChanged(StudentViewModel value)
        {
            // Handle the logic when the selected student changes
            // For example, you can update another ViewModel or trigger a navigation

            if (value != null)
            {
                value.StudentAdded += (sender, student) =>
                {
                    var index = Students.IndexOf(student);
                    if (index == -1)
                        Students.Add(student);
                    else
                        Students[index] = student;
                    student.StudentAdded -= (sender, student) => { };
                    SelectedStudent = student;
                    CurrentView = new StudentDetail(student);
                };
                value.StudentUpdated += (sender, student) =>
                {
                    //should probably do some checks to see if the student is already in the list
                    //var index = Students.IndexOf(student);
                    //Students[index] = student;
                    CurrentView = new StudentEdit(student);
                    student.StudentUpdated -= (sender, student) => { };
                };
                value.StudentDeleted += (sender, student) =>
                {
                    //should probably do some checks to see if the student is already in the list
                    Students.Remove(student);
                    if (Students.Count > 0)
                    {
                        SelectedStudent = Students[0];
                        CurrentView = new StudentDetail(SelectedStudent);
                    }
                    else
                        SelectedStudent = null;
                    student.StudentDeleted -= (sender, student) => { };
                };
                CurrentView = new StudentDetail(value);
            }
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
