using System.Reflection;

namespace Launcher
{
    public class HW
    {
        private static List<IHomeWork> homeWorks = new();

        public static String[] GetList()
        {
            List<Type> HomeWorkList = new();
            HomeWorkList.AddRange((Assembly.GetCallingAssembly().GetTypes().
                Where(t => t.GetInterfaces().Any(i => i == typeof(IHomeWork)))));
            List<string> tmp = new();
            for (int i = 0; i < HomeWorkList.Count; i++)
            {
                homeWorks.Add((IHomeWork)Activator.CreateInstance(HomeWorkList[i]));
                tmp.Add($" {homeWorks[i].Lession} {homeWorks[i].Name} {homeWorks[i].Description}");
            }
            return tmp.ToArray();
        }

        public static void Run(int value)
        {
            homeWorks[value].Run();
        }
    }
}

