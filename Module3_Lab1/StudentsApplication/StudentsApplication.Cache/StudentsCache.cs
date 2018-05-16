using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace StudentsApplication.Cache
{
    public static class StudentsCache
    {
        private static readonly MemoryCache Cache = MemoryCache.Default;

        public static void Add(int id, string fullName)
        {
            if (Cache["Students"] == null)
            {
                Cache["Students"] = new Dictionary<int, string>();
            }
            ((Dictionary<int, string>)Cache["Students"]).Add(id, fullName);
        }

        public static Dictionary<int, string> GetAll()
        {
            return (Cache.Contains("Students")
                ? (Dictionary<int, string>)Cache["Students"]
                : null);
        }

        public static string Get(int id)
        {
            return (Cache.Contains("Students")
                ? ((Dictionary<int, string>)Cache["Students"]).First(student => student.Key == id).Value
                : null);
        }
    }
}