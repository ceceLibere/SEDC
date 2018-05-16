using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace StudentAuthApplication.Cache
{
    public static class StudentsCache
    {
        private static MemoryCache _cache = MemoryCache.Default;

        public static void Add(int id, string fullName)
        {
            if (_cache["Students"] == null)
            {
                _cache["Students"] = new Dictionary<int, string>();
            }
            ((Dictionary<int, string>)_cache["Students"]).Add(id, fullName);
        }

        public static Dictionary<int, string> GetAll()
        {
            return (_cache.Contains("Students")
                ? (Dictionary<int, string>)_cache["Students"]
                : null);
        }

        public static string Get(int id)
        {
            return (_cache.Contains("Students")
                ? ((Dictionary<int, string>)_cache["Students"]).First(student => student.Key == id).Value
                : null);
        }
    }
}