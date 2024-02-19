using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Services
{
    public static class CodePersonne
    {
        public static string CreationCode(string prefixe) => $"{prefixe!}-{Guid.NewGuid().ToString().ToUpper().Substring(0, 6)}";
    }
}
