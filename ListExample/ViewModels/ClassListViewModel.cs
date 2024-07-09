using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExample.ViewModels
{
    public partial class ClassListViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<StudentViewModel> students = new ObservableCollection<StudentViewModel>();


    }
}
