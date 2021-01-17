using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KataApplication
{
    public static class Infra
    {
        public static string GetFileObject()
        {
            
            string resourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames()
                                  .Single(str => str.EndsWith("KataInput.txt"));
            return resourceName;
        }

    }
}
