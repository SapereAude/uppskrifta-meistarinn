using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    // Manipulatar texta
    class TextConsistency
    {
        public static string SetTextToLowerAndTrim(string _txtToAlter)
        {
            string txtFinal = _txtToAlter.ToLower().Trim();
            return txtFinal;
        }

    }
}
