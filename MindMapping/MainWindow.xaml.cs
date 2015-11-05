using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;

using System.Collections;
using System.Windows;

using System.Windows.Markup;


namespace MindMapping
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        static Point First;
        static Point Second;
        static String temp;
        static bool hasCihld = false;
        private void EmptyTextHandler(object sender, MouseEventArgs e)
        {
            tb1.Text = "";
        }

        private void ReturnTextHandler(object sender, MouseEventArgs e)
        {
            tb1.Text = "Enter mind for search";
        }

        
        
        
        
        private void AddBrunch(double X, double Y)
        {         
           TextBox BrunchItem = new TextBox(); 
            BrunchItem.Text = "Branch";
            BrunchItem.Margin = new Thickness(X-190, Y-80, 0, 0);
            BrunchItem.Style = this.FindResource("BrunchMind") as Style;             
            IAddChild container = null;
            BrunchItem.MouseLeftButtonUp+=GetPositionHandler;
            BrunchItem.MouseRightButtonUp += DrawLineHandler;                       
            container = MyGrid;
            container.AddChild(BrunchItem);             
            BrunchItem.TextChanged +=CreateBrunchHandler;
       }

private void CreateBrunchHandler(object sender, TextChangedEventArgs e)
{
 	       ClientC client = new ClientC();
            TextBox tb = sender as TextBox;
            client.CreateBranch(tb.Text);
            if (temp == null)
                temp = tb.Text;
            else
                client.CreateChild(temp, tb.Text);
}

        private void DrawLineHandler(object sender, MouseButtonEventArgs e)
        {
            Second.X = (double)e.GetPosition(null).X;
            Second.Y = (double)e.GetPosition(null).Y;
            DrawLinef(First, Second);
            
        }

        private void GetPositionHandler(object sender, MouseEventArgs e)
        {
            First.X = (double)e.GetPosition(null).X;
            First.Y = (double)e.GetPosition(null).Y;
        }
        private void DrawLinef(Point a, Point b)
        {

            Line myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.Black;
            if (a.X >190&& b.X > 190)
            {
                myLine.X1 = a.X - 190;
                myLine.X2 = b.X - 190;
                myLine.Y1 = a.Y - 70;
                myLine.Y2 = b.Y - 70;
                myLine.HorizontalAlignment = HorizontalAlignment.Left;
                myLine.VerticalAlignment = VerticalAlignment.Center;
                myLine.StrokeThickness = 2;
                IAddChild container = null;
                container = MyGrid;
                MyGrid.Children.Add(myLine);
            }


        }

          
        
        private void AddLeaf(double X, double Y)
        {
            TextBox LeafItem = new TextBox();
            LeafItem.Text = "Leaf";
            LeafItem.Margin  = new Thickness(X-190, Y-80, 0, 0);
            LeafItem.Style = this.FindResource("LeafMind") as Style;
            LeafItem.MouseLeftButtonUp += GetPositionHandler;
            LeafItem.MouseRightButtonUp += DrawLineHandler;
            IAddChild container = null;
            container = MyGrid;
            container.AddChild(LeafItem);
            LeafItem.TextChanged += CompositeCreateHandler;
        }

        private void CompositeCreateHandler(object sender, TextChangedEventArgs e)
        {
            ClientC client = new ClientC();
            TextBox tb = sender as TextBox;
            client.CreateLeaf(tb.Text);
            client.CreateChild(temp,tb.Text);
        }

            

        

    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            hasCihld = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            hasCihld = false;
        }

     
        private void DrawMindHandler(object sender, MouseButtonEventArgs e)
        {
            if (hasCihld)
            {
                AddBrunch((double)e.GetPosition(null).X, (double)e.GetPosition(null).Y);
            }
            else
            {
                AddLeaf((double)e.GetPosition(null).X, (double)e.GetPosition(null).Y);
            }
            
        }

        private void TextChangedHandler(object sender, TextChangedEventArgs e)
        {
            ClientC client = new ClientC();
            TextBox tb = sender as TextBox;
            client.CreateBranch("Root "+tb.Text);
            temp = tb.Text;
        }

      

     

        private void RootFirstHandler(object sender, MouseButtonEventArgs e)
        {
            First.X = (double)e.GetPosition(null).X;
            First.Y = (double)e.GetPosition(null).Y;
            
        }
        private void RootSecondHandler(object sender, MouseButtonEventArgs e)
        {
            Second.X = (double)e.GetPosition(null).X;
            Second.Y = (double)e.GetPosition(null).Y;
            DrawLinef(First, Second);
        }

       

    }
}