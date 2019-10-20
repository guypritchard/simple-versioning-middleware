
namespace ServiceVersioningMiddleware
{
    using System;
    using System.Reflection;

    internal static class AssemblyVersion
    {
        private static AssemblyName assemblyName = AssemblyVersion.GetVersion();
        private static string assemblyDescription = AssemblyVersion.GetAssemblyDescription();

        public static Version Version
        {
            get
            {
                return AssemblyVersion.assemblyName.Version;
            }
        }

        public static string Name
        {
            get
            {
                return AssemblyVersion.assemblyName.Name;
            }
        }

        public static string Description
        {
            get
            {
                return AssemblyVersion.assemblyDescription;
            }
        }

        private static AssemblyName GetVersion()
        {
            return Assembly
                .GetEntryAssembly()
                .GetName();
        }

        private static string GetAssemblyDescription()
        {
            string assemblyDescription = string.Empty;

            var attribute = (AssemblyDescriptionAttribute)Attribute.GetCustomAttribute(
                                Assembly.GetEntryAssembly(),
                                typeof(AssemblyDescriptionAttribute));

            if (attribute != null)
            {
                assemblyDescription = attribute.Description;
            }

            return assemblyDescription;
        }
    }
}
