using System;

namespace WebServer.ServerService.Common
{
    public static class Guard
    {
        public static void AgainstNull(object obj, string name = null)
        {
            if (obj == null)
            {
                throw new ArgumentException($"{nameof(name)} cannot be null");
            }
        }
    }
}