using System.Reflection;

namespace Launcher
{
    public class HW
    {
        private static List<IHomeWork?> homeWorks = new();

        public static String[] GetList()
        {
            List<Type> homeWorkList = new();
            homeWorkList.AddRange((Assembly.GetCallingAssembly().GetTypes().Where(t => t.GetInterfaces()
            .Where(i => i == typeof(IHomeWork)).ToList().Count > 0)));
            List<string> tmp = new();
            for (int i = 0; i < homeWorkList.Count; i++)
            {
                homeWorks.Add((IHomeWork)Activator.CreateInstance(homeWorkList[i])!);
                tmp.Add($" {homeWorks[i]?.Lession} {homeWorks[i]?.Name} {homeWorks[i]?.Description}");
            }
            return tmp.ToArray();
        }

        public static void Run(int value)
        {
            homeWorks[value]?.Run();
        }
    }
}

