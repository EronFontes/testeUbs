using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public static class PersonProvider
    {
        public static IEnumerable<Person> ListPerson { get; set; }
        public static int ThreadId { get; set; }
    }
}
