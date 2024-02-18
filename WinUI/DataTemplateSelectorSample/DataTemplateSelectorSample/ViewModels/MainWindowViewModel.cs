using CommunityToolkit.Mvvm.ComponentModel;
using DataTemplateSelectorSample.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplateSelectorSample.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel() 
        {
            PeopleList = new ObservableCollection<Person>()
            {
                new FamilyMember("Cong", "24", "12345"),
                new Colleague("Duy", "Staff Engineer I"),
                new FamilyMember("Diep", "24", "32143"),
                new Colleague("Huyen", "Engineer II"),
            };
        }

        [ObservableProperty]
        private ObservableCollection<Person> peopleList;
    }
}
