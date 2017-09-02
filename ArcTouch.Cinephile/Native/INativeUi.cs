using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcTouch.Cinephile.Native
{
    /// <summary>
    /// Defines any native method that cannot be accessed directly from portable classes
    /// </summary>
    public interface INativeUi
    {
        /// <summary>
        /// Displays a tooltip text
        /// </summary>
        /// <param name="text"></param>
        void DisplayTooltip(string text);
    }
}
