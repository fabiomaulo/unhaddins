using System;
using NUnit.Framework;

namespace uNhAddIns.WPF.Tests
{
    public static class TestHelper
    {
        public static void ShouldImplement<T>(this Type type)
        {
            typeof (T).IsAssignableFrom(type).Should(
                string.Format("{0} should implement {1}", type.Name, typeof (T).Name)
                );
        }
    }
}