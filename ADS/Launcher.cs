using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ADS
{
    internal static class Launcher
    {
        internal static void Run()
        {
            List<Type> HomeWorkList = new List<Type>();
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
                        var homeWorkTmp = constructorTmp.Invoke(new object[] { });
                        var lession = type.GetMethod("GetLession");
                        var name = type.GetMethod("GetName");
                        var description = type.GetMethod("GetDescription");
                        var tmp = new object[] { };

                        IO.Send($"{i + 1}. {lession.Invoke(homeWorkTmp, tmp)} {name.Invoke(homeWorkTmp, tmp)} {description.Invoke(homeWorkTmp, tmp)}");

                    }

                    int UserChoice;
                    UserEnter = IO.Get("Введите номер строки для проверки, для выхода наберите -1: ");

                    if (int.TryParse(UserEnter, out UserChoice))
                    {
                        if (UserChoice - 1 < HomeWorkList.Count && UserChoice > 0)
                        {
                            var type = HomeWorkList[UserChoice - 1];
                            var constructor = type.GetConstructor(Type.EmptyTypes);
                            var homeWork = constructor.Invoke(new object[] { });
                            var run = type.GetMethod("Run");
                            var homeWorkRun = run.Invoke(homeWork, new object[] { });
                        }
                    }
                }
                while (UserEnter != "-1");

            }
        }
    }
}
