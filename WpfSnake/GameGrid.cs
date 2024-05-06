using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSnake
{
    public class GameGrid
    {
        public int[,] Grid;
        public int Rows;
        public int Columns;
        public Position Fruit;

        public GameGrid(int rows, int columns) {
            Rows = rows;
            Columns=columns;
            Grid = new int[rows, columns];            
        }

        public bool IsInside(Position p) { 
            return p.X>=0 && p.X<Rows && p.Y>=0 && p.Y<Columns;
        } 
        public bool IsEmpty(Position p) {
            return IsInside(p) && Grid[p.X, p.Y] == 0;
        }
        
        public bool IsFruit(Position p) {
            return IsInside(p) && Grid[p.X, p.Y] == 2;
        } 
        public void Clear(Position p) {
            Grid[p.X, p.Y] = 0;
        } 
        public void Place(Position p) { 
            if (IsEmpty(p)) Grid[p.X, p.Y] = 1;
        }


        public void SetFruit()
        {
            if (Fruit != null)
            {
                Grid[Fruit.X, Fruit.Y] = 1;
            }
            Position p;
            do
            {
                p = new Position();
            } while (!IsEmpty(p));
            Grid[p.X, p.Y] = 2;
            Fruit = p;
        }

    }
}
