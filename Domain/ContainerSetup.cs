using System.Reflection;

using Basics.Containers;
using Basics.Domain;

namespace FullStackTraining.CallMeBack.Domain
{
    public static class ContainerSetup
    {
        public static void Setup(IContainerBuilder builder)
        {
            builder.RegisterDomains(Assembly.GetExecutingAssembly());
            Repository.ContainerSetup.Register(builder);
        }
    }
}