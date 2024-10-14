using System.Collections;

namespace TodoList.Application.Extension
{
    public static class EnumerableExtersions
    {
        public static bool HasValueInColletion(this IEnumerable enumerable)
        {
          return enumerable.OfType<object>().Any();
        }
    }
}
