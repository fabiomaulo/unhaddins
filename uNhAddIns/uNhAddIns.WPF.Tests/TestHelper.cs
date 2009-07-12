using System;
using NUnit.Framework;

namespace uNhAddIns.WPF.Tests
{
    //Todo: update to nunitex 1.0.2
    //http://fabiomaulo.blogspot.com/2009/07/nunitex-102.html

    public static class TestHelper
    {
        public static void ShouldImplement<T>(this Type type)
        {
            typeof (T).IsAssignableFrom(type).Should(
                string.Format("{0} should implement {1}", type.Name, typeof (T).Name)
                ).Be.True();
        }
    }
}