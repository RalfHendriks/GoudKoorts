using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace Goudkoorts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameController _game;

        public MainWindow()
        {
            InitializeComponent();
            initGrid(12,8);
            _game = new GameController(this);
        }

        public void addVisualObject(BaseTile tile)
        {
            Image img = new Image();
            img.Visibility = Visibility.Visible;
            img.Source = new BitmapImage(new Uri(@"Images/" + "cart_full" + ".PNG", UriKind.Relative));
            img.Width = 50;
            img.Height = 50;
            tPart.Children.Add(img);
            Grid.SetColumn(img, (int)tile.Pos.X);
            Grid.SetRow(img, (int)tile.Pos.Y);
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
