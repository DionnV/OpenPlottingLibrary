using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPL_GUI
{
    struct MouseInfo
    {
        public bool isLeftDown { get; set; }
        public bool isRightDown { get; set; }
        public int xPosWhenPressed { get; set; }
        public int yPosWhenPressed { get; set; }
    }
}
