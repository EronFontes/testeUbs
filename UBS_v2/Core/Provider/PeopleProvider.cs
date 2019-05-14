using Core.Entities;
using System.Collections.Generic;

namespace Core.Provider
{
    public static class PeopleProvider
    {
        public static IEnumerable<People> ListPeople { get; set; }
        public static int ThreadId { get; set; }
    }
}
