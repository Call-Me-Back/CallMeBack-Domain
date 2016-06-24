using System.Reflection;

using Basics.Containers;

namespace FullStackTraining.CallMeBack.Repository
{
    public static class ContainerSetup
    {
        public static void Register(IContainerBuilder builder)
        {
            builder.RegisterByConvention(new[] { Assembly.GetExecutingAssembly() },
                type => type.Name.EndsWith("Repository"));
        }
    }
}