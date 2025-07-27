using BoardTroveAPI.Models;
using System.Reflection;

namespace BoardTroveAPI.Data
{
    public static class UtilMisc
    {
        public static readonly Dictionary<string, Type> TypesToModelNames = new()
        {
            ["FEN"] = typeof(FENPost),
            ["PGN"] = typeof(PGNPost)
        };

        //currently unused methods
        public static void CopyDerivedProperties<T>(T source, T target)
        {
            var baseProps = typeof(BasePost).GetProperties().Select(p => p.Name).ToHashSet();
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                 .Where(p =>
                                     p.CanRead &&
                                     p.CanWrite &&
                                     !baseProps.Contains(p.Name)
                                 );

            foreach (var prop in props)
            {
                var value = prop.GetValue(source);
                prop.SetValue(target, value);
            }
        }
        public static Type? MatchTypeFromBaseClass(string type)
        {
            var baseType = typeof(BasePost);
            var matchingType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .FirstOrDefault(t =>
                    t.Name == type &&
                    t.IsClass &&
                    !t.IsAbstract &&
                    baseType.IsAssignableFrom(t)
                );
            return matchingType;
        }
    }
}
