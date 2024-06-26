using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.ViewModels
{
    public partial class TextModifierViewModel : ObservableObject
    {
        [ObservableProperty]
        string inputText = "";

        [ObservableProperty]
        string outputText = "";

        [RelayCommand]
        public void ModifyText()
        {
            OutputText = InputText.ToUpper();
        }
    }
}
