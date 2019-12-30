using System;
using System.Collections.Generic;
using System.Text;

namespace Lexov.Utilities
{
    public interface IOrientationHandler
    {
        void ForcePortrait();
        void ForceLandscape();
    }
}
