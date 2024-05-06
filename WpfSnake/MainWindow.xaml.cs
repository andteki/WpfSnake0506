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

namespace WpfSnake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Image[,] Desk = new Image[20, 20];
        public GameGrid GameGrid = new GameGrid(20, 20);
        public Snake Snake;

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }
        
        public void Init() {
            Snake = new Snake(this.GameGrid);
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                {
                    Image img = new Image();
                    img.Width = 30;
                    img.Height = 30;
                    Canvas.SetLeft(img, i * 30);
                    Canvas.SetTop(img, j * 30);                 

                    Desk[i,j]=img;
                    GamePanel.Children.Add(img);
                }
            GameGrid.SetFruit();
            Draw();
        }
        public void Draw() {
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                {
                    if (GameGrid.Grid[i, j] == 0)
                        Desk[i,j].Source = new BitmapImage(new Uri("Assets/TileGreen.png", UriKind.Relative));

                    if (GameGrid.Grid[i, j] == 1)
                        Desk[i, j].Source = new BitmapImage(new Uri("Assets/TileBlue.png", UriKind.Relative));

                    if (GameGrid.Grid[i, j] == 2)
                        Desk[i, j].Source = new BitmapImage(new Uri("Assets/TilePurple.png", UriKind.Relative));
                }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key) {
                case Key.Right:
                    Snake.MoveRight(); break;
                case Key.Up:
                    Snake.MoveUp(); break;
                case Key.Down:
                    Snake.MoveDown(); break;
                case Key.Left:
                    Snake.MoveLeft(); break;
            
            }
            Draw();
        }
    }
}
