using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    public interface IMatch
    {
        bool Success();
        string RemainingText();
    }
}
