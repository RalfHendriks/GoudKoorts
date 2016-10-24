using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Goudkoorts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameController _game;
        private Dictionary<String, BitmapImage> _switches = new Dictionary<string, BitmapImage>();

        public MainWindow()
        {
            InitializeComponent();
            initSwitches();
            initGrid(12,8);
            _game = new GameController(this);
        }

        public void addVisualObject(BaseTile tile)
        {
            Image img = new Image();
            img.Visibility = Visibility.Visible;
            string type = tile.GetType().ToString().Split('.').Last();
            img.Source = new BitmapImage(new Uri(@"Assets/Images/" + type + tile.Direction + ".png", UriKind.Relative));
            if(type == "SwitchTile")
            {
                img.MouseEnter += Img_MouseEnter;
                img.MouseDown += Img_MouseDown;
            }
            img.Width = 50;
            img.Height = 50;
            tPart.Children.Add(img);
            Grid.SetColumn(img, (int)tile.Pos.X);
            Grid.SetRow(img, 7 - (int)tile.Pos.Y);
        }

        private BitmapImage TurnSwitch(string name)
        {
            return name.Contains("Left") == true ? (name.Contains("Up") == true ? _switches["SwitchTileLeftDown"] : _switches["SwitchTileLeftUp"]) : (name.Contains("Up") == true ? _switches["SwitchTileDownRight"] : _switches["SwitchTileUpRight"]);
        }

        private void Img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image img = (Image)sender;
            img.Source = TurnSwitch(img.Source.ToString().Split('/').Last().Split('.').First());
            img.UpdateLayout();
        }

        private void Img_MouseEnter(object sender, MouseEventArgs e)
        {
            Image img = (Image)sender;
            img.Cursor = Cursors.Hand;
        }

        public void PlaceCart(int start)
        {
            Image img = new Image();
            img.Visibility = Visibility.Visible;
            img.Source = new BitmapImage(new Uri(@"Assets/Images/CartFull.png", UriKind.Relative));
            img.Width = 50;
            img.Height = 50;
            tPart.Children.Add(img);
            Grid.SetColumn(img, 0);
            Grid.SetRow(img, 7 - start);
        }

        public void MoveCart(Point Old, Point New)
        {
            Image rowItem = (Image)tPart.Children.Cast<UIElement>().Where(i => Grid.GetRow(i) == (7 - Old.Y) && Grid.GetColumn(i) == Old.X).Last();
            tPart.Children.Remove(rowItem);
            tPart.Children.Add(rowItem);
            Grid.SetColumn(rowItem, (int)New.X);
            Grid.SetRow(rowItem, 7 - (int)New.Y);

            //tPart.Children.Remove(c);

        }

        private void initSwitches()
        {
            var f = Directory.GetFiles("../../Assets/Images","SwitchTile*");
            for (int i = 0; i < f.Count(); i++)
            {
                string name = f[i].Split(new[] { "\\" }, StringSplitOptions.None).Last().Split('.').First();
                _switches.Add(name, new BitmapImage(new Uri(f[i],UriKind.Relative)));
            }
        }

        private void initGrid(int xSize, int ySize)
        {
            for (int i = 0; i < xSize; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                gridCol.Name = "x" + i;
                tPart.ColumnDefinitions.Add(gridCol);
            }

            for (int i = 0; i < ySize; i++)
            {
                RowDefinition rowCol = new RowDefinition();
                rowCol.Name = "y" + i;
                tPart.RowDefinitions.Add(rowCol);
            }
        }
    }
}
