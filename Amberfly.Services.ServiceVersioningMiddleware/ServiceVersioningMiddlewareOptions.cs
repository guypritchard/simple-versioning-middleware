namespace ServiceVersioningMiddleware
{
    public sealed class ServiceVersioningMiddlewareOptions
    {
        private const string VersionPath = "/version";

        private const string VersionHeaderName = "X-Service-Version";

        private const string AssemblyDescriptionHeaderName = "X-Service-Description";

        public string Path { get; set; } = 
            ServiceVersioningMiddlewareOptions.VersionPath;

        public string VersionHeader { get; set; } =
            ServiceVersioningMiddlewareOptions.VersionHeaderName;

        public string AssemblyDescriptionHeader { get; set; } =
            ServiceVersioningMiddlewareOptions.AssemblyDescriptionHeaderName;

        public ServiceVersioningType VersioningType { get; set; } = 
            ServiceVersioningType.None;
    }
}
