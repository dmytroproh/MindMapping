using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    abstract class StrategyA
    {
        public abstract void Search(Dictionary<int,Component> array, int goal);
    }
}
