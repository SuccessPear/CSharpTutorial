using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplateSelectorSample.Models
{
    public class FamilyMember: Person
    {
        public FamilyMember(string name, string age, string phoneNumber) : base(name)
        {
            this.Age = age;
            this.PhoneNumber = phoneNumber;
        }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
    }
}
