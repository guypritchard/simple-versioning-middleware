namespace ServiceVersioningMiddleware
{
    using System;
    
    [Flags]
    public enum ServiceVersioningType
    {
        None = 0,
        Endpoint = 1,
        Header = 2,
    }
}
