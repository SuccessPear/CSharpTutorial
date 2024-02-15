using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.VoiceCommands;

namespace ConsoleApp1.ViewModels
{
    [ObservableObject]
    public partial class MainWindowViewModel
    {
        public ICommand MyCommand { get; }
        public MainWindowViewModel()
        {
            ButtonContent = "Add";
            StudentList = new();
            StudentList.Add("Cong");
            StudentList.Add("Huyen");
            StudentList.Add("Hoang");
            StudentList.Add("Diep");
            StudentList.Add("Linh");
            StudentList.Add("Chi");

            MyCommand = new CustomCommand(ExecuteMyCommand, CanExecuteMyCommand);
        }

        private void ExecuteMyCommand(object parameter)
        {
            // Logic to execute when the command is invoked
            if (parameter is string newName)
                StudentList.Add(newName);
        }

        private bool CanExecuteMyCommand(object parameter)
        {
            // Logic to determine if the command can be executed
            return true;
        }

        public void AddNewNameToStudentList()
        {
        }

        [ObservableProperty]
        private string buttonContent;

        [ObservableProperty]
        private string textBoxContent;

        [ObservableProperty]
        private ObservableCollection<string> studentList;
    }

    public class CustomCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public CustomCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        // This method is used to raise the CanExecuteChanged event, notifying the UI to update the command's state
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
