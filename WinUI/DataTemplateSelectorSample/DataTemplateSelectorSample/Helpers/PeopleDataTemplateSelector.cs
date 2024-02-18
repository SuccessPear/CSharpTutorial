using DataTemplateSelectorSample.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplateSelectorSample.Helpers
{
    public class PeopleDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultDataTemplate { get; set; } = new();
        public DataTemplate? FamilyMemberTemplate { get; set; }
        public DataTemplate? ColleagueTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            DataTemplate? dataTemplate = (item as Person) switch
            {
                FamilyMember => FamilyMemberTemplate,
                Colleague => ColleagueTemplate,
                _ => null,
            };
            return dataTemplate;
        }
    }
}
