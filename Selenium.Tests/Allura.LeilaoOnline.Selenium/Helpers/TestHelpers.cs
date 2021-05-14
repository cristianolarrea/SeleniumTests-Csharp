using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Allura.LeilaoOnline.Selenium.Helpers
{
    public static class TestHelpers
    {
        public static string PathDOExecutavel => Path.GetDirectoryName
                (Assembly.GetExecutingAssembly().Location);
    }
}
