using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClassLibrary.DataAccess
{

    public static class LanguageHelper
    {
       


        public static void SetCulture(string culture)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
        }

        

    }
}
