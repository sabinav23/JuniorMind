using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    interface IPattern
    {
        bool Match(string text);
    }
}
