using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplateSelectorSample.Models
{
    public class Colleague: Person
    {
        public Colleague(string name, string position) : base(name)
        {
            this.Position = position;
        }
        public string Position { get; set; }
    }
}
