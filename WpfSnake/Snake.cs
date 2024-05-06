using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSnake
{
    public class Snake
    {
        public List<Position> Body;
        public GameGrid GameGrid;
        public int Grow;
        
        public Snake(GameGrid gameGrid)
        {
            GameGrid = gameGrid;
            Body = new List<Position>();
            for (int i = 0; i < 10; i++) { 
                Body.Add(new Position(i,9));
                GameGrid.Grid[i, 9] = 1;
            }            
        }

        public Position GetHead() { 
            return Body[Body.Count-1];
        }

        //public Position GetTail() { }
        public void Step(Position newHead) {
            if (GameGrid.IsInside(newHead) && (
                    GameGrid.IsEmpty(newHead) || GameGrid.IsFruit(newHead)
                )) {
                Body.Add(newHead);
                GameGrid.Place(newHead);
                GameGrid.Clear(Body[0]);
                
                if (GameGrid.IsFruit(newHead)) {
                    GameGrid.SetFruit();
                    Grow += 5;
                }
                if (Grow > 0) Grow--;
                if (Grow==0) Body.Remove(Body[0]); 

                // Gyümi
                // Game Over
            }        
        }

        public void MoveLeft() {
            Position head = GetHead();
            Position newHead = new Position (head.X-1, head.Y);
            Step(newHead);
        } 

        public void MoveRight() {
            Position head = GetHead();
            Position newHead = new Position (head.X+1, head.Y);
            Step(newHead);
        } 
        
        public void MoveUp() {
            Position head = GetHead();
            Position newHead = new Position (head.X, head.Y-1);
            Step(newHead);
        } 
        
        public void MoveDown() {
            Position head = GetHead();
            Position newHead = new Position (head.X, head.Y+1);
            Step(newHead);
        }
    }
}
