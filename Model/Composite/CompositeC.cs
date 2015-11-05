using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class CompositeC : Component
    {
        public Dictionary<int, Component> nodes = new Dictionary<int, Component>();
        ArrayList des = new ArrayList();

    
         public static ArrayList values = new ArrayList();
        public CompositeC(string name)
            : base(name)
        {
            
        }

        int position = -1;

 
        public override void RecursiveBuild(int[] rules)
        {

            if (position < rules.Length - 1)
            {
                int result = rules[++position] % 4;

                if (!nodes.ContainsKey(result))
                    nodes.Add(result, new CompositeC("branch " + result.ToString()));

                  nodes[result].Add(position, new Leaf(rules[position].ToString() + " Лол"));

                RecursiveBuild(rules);
            }   

        }

     
        public override void Operation()
        {
           
          
            foreach (var component in nodes)
            { 
                component.Value.Operation();
                values.Add(component.Key);
            }

        }

        public override void Add(int key, Component component)
        
        {
           
            nodes.Add(key, component);
        }
        public override void Add(Component component)
        {
            des.Add(component);
        }

        public override void Remove(Component component)
        {
            des.Remove(component);
        }

        public override Component GetChild(int index)
        {
            return nodes[index] as Component;
        }
    }
}
