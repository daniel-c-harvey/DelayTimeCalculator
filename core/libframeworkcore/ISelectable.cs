using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public interface ISelectable
    {
        bool IsSelected { get; set; }
        object Item { get; set; }
    }
}
