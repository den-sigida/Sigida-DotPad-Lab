using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotPad.View.Models
{
    public class Notepad
    {
        private int _currentLine = 1;
        public int Characters { get; set; }
        public int Spaces { get; set; }
        public int CurentLine
        {
            get => _currentLine;
            set
            {
                if (value <= 0)
                    _currentLine = 1;
                else
                    _currentLine = value;
            }
        }
        public int CurentColumn { get; set; }
    }
}
