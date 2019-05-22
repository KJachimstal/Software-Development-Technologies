using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoApplication.Interfaces
{
    public abstract class ViewModelDialog
    {
        public enum Mode { ADD, EDIT }
        public Mode DialogMode { get; set; }
    }
}
