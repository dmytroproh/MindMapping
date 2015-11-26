namespace Model
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
   public class CompositeC : Component
    {
        public static ArrayList Values = new ArrayList();
        public Dictionary<int, Component> Nodes = new Dictionary<int, Component>();
        private ArrayList des = new ArrayList(); 
        
        private int position = -1;
        public CompositeC(string name)
            : base(name)
        {
        }
 
        public override void RecursiveBuild(int[] rules)
        {
            if (position < rules.Length - 1)
            {
                int result = rules[++position] % 4;

                if (!Nodes.ContainsKey(result))
                {
                    Nodes.Add(result, new CompositeC("branch " + result.ToString()));
                }

                  Nodes[result].Add(position, new Leaf(rules[position].ToString() + " Лол"));

                RecursiveBuild(rules);
            }   
        }
     
        public override void Operation()
        {      
            foreach (var component in Nodes)
            { 
                component.Value.Operation();
                Values.Add(component.Key);
            }
        }

        public override void Add(int key, Component component)    
        {
            Nodes.Add(key, component);
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
            return Nodes[index] as Component;
        }
    }
}
