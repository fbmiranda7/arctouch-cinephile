using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcTouch.Cinephile.IoC
{
    /// <summary>
    /// IoC helper for the Ninject container
    /// </summary>
    public static class Resolver
    {
        public static T Get<T>()
        {
            return ApplicationModule.Instance.Kernel.Get<T>();
        }
    }
}
