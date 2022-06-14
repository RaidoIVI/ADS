using System.Reflection;

namespace Launcher
{
    public class Hw
    {
        private static readonly List<IHomeWork?> HomeWorks = new();

        public static String[] GetList()
        {
            List<Type> homeWorkList = new();
            homeWorkList.AddRange((Assembly.GetCallingAssembly().GetTypes().Where(t => t.GetInterfaces()
            .Where(i => i == typeof(IHomeWork)).ToList().Count > 0)));
            List<string> tmp = new();
            for (int i = 0; i < homeWorkList.Count; i++)
            {
                HomeWorks.Add((IHomeWork)Activator.CreateInstance(homeWorkList[i])!);
                tmp.Add($" {HomeWorks[i]?.Lession} {HomeWorks[i]?.Name} {HomeWorks[i]?.Description}");
            }
            return tmp.ToArray();
        }

        public static void Run(int value)
        {
            HomeWorks[value]?.Run();
        }
    }
}

