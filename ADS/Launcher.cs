using System.Reflection;

namespace ADS
{
    internal static class Launcher
    {
        internal static void Run()
        {
            List<Type> HomeWorkList = new();
            HomeWorkList.AddRange(Assembly.GetExecutingAssembly().GetTypes().Where(t => t.BaseType == typeof(HomeWork)));
            if (HomeWorkList.Count > 0)
            {
                string UserEnter;
                do
                {
                    for (int i = 0; i < HomeWorkList.Count; i++) // (Type type in HomeWorkList)
                    {
                        var type = HomeWorkList[i];
                        var constructorTmp = type.GetConstructor(Type.EmptyTypes);
                        var homeWorkTmp = constructorTmp.Invoke(Array.Empty<object>());
                        var lession = type.GetMethod("GetLession");
                        var name = type.GetMethod("GetName");
                        var description = type.GetMethod("GetDescription");
                        var tmp = Array.Empty<object>();

                        IO.SendLine($"{i + 1}. {lession.Invoke(homeWorkTmp, tmp)} {name.Invoke(homeWorkTmp, tmp)} {description.Invoke(homeWorkTmp, tmp)}");

                    }

                    UserEnter = IO.Get("Введите номер строки для проверки, для выхода наберите -1: ");

                    if (int.TryParse(UserEnter, out int UserChoice))
                    {
                        if (UserChoice - 1 < HomeWorkList.Count && UserChoice > 0)
                        {
                            var type = HomeWorkList[UserChoice - 1];
                            var constructor = type.GetConstructor(Type.EmptyTypes);
                            var homeWork = constructor.Invoke(Array.Empty<object>());
                            var run = type.GetMethod("Run");
                            var homeWorkRun = run.Invoke(homeWork, Array.Empty<object>());
                        }
                    }
                }
                while (UserEnter != "-1");

            }
        }
    }
}
