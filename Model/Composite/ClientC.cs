namespace Model
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
   public class ClientC
    {   
      public ArrayList Result = CompositeC.Values;
      public Dictionary<string, Component> Tree = new Dictionary<string, Component>();
        public static void RecursiveInit()
        {        
            int[] array = null;

            array = new int[16] 
            {                      
                                   1, 2, 3, 4,
                                   5, 6, 7, 8, 9,
                                   10, 11, 12, 13,
                                   14, 15, 16
            };

            Component tree = new CompositeC("root");
            tree.RecursiveBuild(array);
            CompositeC tree2 = tree as CompositeC;      
            tree.Operation();
        }
        public void CreateBranch(string text) 
        {
            Component branch1 = new CompositeC(text);
            Tree.Add(text, branch1);
        }
       
        public void CreateLeaf(string text)
        {           
            Component leaf = new CompositeC(text);
            Tree.Add(text, leaf);
        }
        public void CreateChild(string textBranch, string textLeaf)
       {
            CompositeC composite = (CompositeC)Tree[textBranch];
            Leaf leaf = (Leaf)Tree[textLeaf];
            composite.Add(leaf);
        }
    }
}
