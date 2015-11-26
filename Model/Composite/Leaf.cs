namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Leaf : Component
    {
        public Leaf(string name)
            : base(name)
        {
        }

        public override void Operation()
        {
            Console.WriteLine(name);
        }

        public override void RecursiveBuild(int[] rules)
        {
            throw new InvalidOperationException();
        }

        public override void Add(int key, Component component)
        {
            throw new InvalidOperationException();
        }
        public override void Add(Component component)
        {
            throw new InvalidOperationException();
        }

        public override void Remove(Component component)
        {
            throw new InvalidOperationException();
        }

        public override Component GetChild(int index)
        {
            throw new InvalidOperationException();
        }
    }
}
