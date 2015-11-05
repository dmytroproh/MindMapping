using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }
        public abstract void Operation();
        public abstract void RecursiveBuild(int[] rules);
        public abstract void Add(int key, Component component);
 



        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract Component GetChild(int index);
    }
}
