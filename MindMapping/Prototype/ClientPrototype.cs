﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindMapping.Prototype
{
    class ClientPrototype
    {

        static void Do() 
        {
            Prototype prototype = null;
            Prototype original = null;


            prototype = new ConcretePrototype1(1);
            original = prototype.Clone();

            prototype = new ConcretePrototype2(2);
            original = prototype.Clone();
        
        
        }
  
        
                 
           
           
    }
}
