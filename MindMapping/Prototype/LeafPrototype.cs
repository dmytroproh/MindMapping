using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMapping.Prototype
{
    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(int id)
            : base(id)
        {
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype1(Id);
        }
    }
}
