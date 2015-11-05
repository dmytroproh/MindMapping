using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    
        class Context
        {
          StrategyA strategy;
            ClientC clientC = new ClientC();
            int goal;
           //Dictionary<int, Component> DictTree = CompositeC.nodes;
            public Context(StrategyA strategy, int goal)
            {
                this.strategy = strategy;
                this.goal = goal;
            }

           public void Search()
            {
             //  strategy.Search(DictTree, goal);
           }

        
        }
    
}
