namespace MindMapping
{
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
    using System.Collections;
    using System.Windows;
    using System.Windows.Markup;
    using Model;
   
    public partial class MainWindow : Window
    {
        private static Point first;

        private static Point second;

        private static bool hasCihld = false;

      
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string Temp { get; set; }

        private void EmptyTextHandler(object sender, MouseEventArgs e)
        {
            tb1.Text = string.Empty;
        }

        private void ReturnTextHandler(object sender, MouseEventArgs e)
        {
            tb1.Text = "Enter mind for search";
        }

       
        private void AddBrunch(double x, double y)
        {         
            TextBox brunchItem = new TextBox(); 
            brunchItem.Text = "Branch";
            brunchItem.Margin = new Thickness(x - 190, y - 80, 0, 0);
            brunchItem.Style = this.FindResource("BrunchMind") as Style;             
            IAddChild container = null;
            brunchItem.MouseLeftButtonUp += GetPositionHandler;
            brunchItem.MouseRightButtonUp += DrawLineHandler;                   
            container = MyGrid;
            container.AddChild(brunchItem);         
            brunchItem.TextChanged += CreateBrunchHandler;
       }

private void CreateBrunchHandler(object sender, TextChangedEventArgs e)
{
  	        ClientC client = new ClientC();
            TextBox tb = sender as TextBox;
            client.CreateBranch(tb.Text);
            if (Temp == null)
            {
                Temp = tb.Text;
            }
            else
            {
                client.CreateChild(Temp, tb.Text);
            }
}

        private void DrawLineHandler(object sender, MouseButtonEventArgs e)
        {
            second.X = (double)e.GetPosition(null).X;
            second.Y = (double)e.GetPosition(null).Y;
            DrawLinef(first, second);            
        }

        private void GetPositionHandler(object sender, MouseEventArgs e)
        {
            first.X = (double)e.GetPosition(null).X;
            first.Y = (double)e.GetPosition(null).Y;
        }

        private void DrawLinef(Point a, Point b)
        {
            Line connectingLine = new Line();
            connectingLine.Stroke = System.Windows.Media.Brushes.Black;
            if (a.X > 190 && b.X > 190)
            {
                connectingLine.X1 = a.X - 190;
                connectingLine.X2 = b.X - 190;
                connectingLine.Y1 = a.Y - 70;
                connectingLine.Y2 = b.Y - 70;
                connectingLine.HorizontalAlignment = HorizontalAlignment.Left;
                connectingLine.VerticalAlignment = VerticalAlignment.Center;
                connectingLine.StrokeThickness = 2;
                IAddChild container = null;
                container = MyGrid;
                MyGrid.Children.Add(connectingLine);
            }
        }
        
        private void AddLeaf(double x, double y)
        {
            TextBox leafItem = new TextBox();
            leafItem.Text = "Leaf";
            leafItem.Margin  = new Thickness(x - 190, y - 80, 0, 0);
            leafItem.Style = this.FindResource("LeafMind") as Style;
            leafItem.MouseLeftButtonUp += GetPositionHandler;
            leafItem.MouseRightButtonUp += DrawLineHandler;
            IAddChild container = null;
            container = MyGrid;
            container.AddChild(leafItem);
            leafItem.TextChanged += CompositeCreateHandler;
        }

        private void CompositeCreateHandler(object sender, TextChangedEventArgs e)
        {
            ClientC client = new ClientC();
            TextBox tb = sender as TextBox;
            client.CreateLeaf(tb.Text);
            client.CreateChild(Temp, tb.Text);
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
            client.CreateBranch("Root " + tb.Text);
            Temp = tb.Text;
        }

        private void RootFirstHandler(object sender, MouseButtonEventArgs e)
        {
            first.X = (double)e.GetPosition(null).X;
            first.Y = (double)e.GetPosition(null).Y;          
        }

        private void RootSecondHandler(object sender, MouseButtonEventArgs e)
        {
            second.X = (double)e.GetPosition(null).X;
            second.Y = (double)e.GetPosition(null).Y;
            DrawLinef(first, second);
        }
    }
}