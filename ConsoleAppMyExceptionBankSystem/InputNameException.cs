using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMyExceptionBankSystem
{
    public class InputNameException : Exception
    {
        public override string Message => "Слишком короткое имя, проверьте его.";

    }
}
