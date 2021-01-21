/* GameBoard.cs
 * Author: Eve Steinle
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSU.CIS300.Snake
{
    /// <summary>
    /// A public enum that holds the Directions
    /// </summary>
    public enum Direction
    {
        Up, Down, Left, Right, None
    }
    /// <summary>
    /// A enum that holds all the different snake status's
    /// </summary>
    public enum SnakeStatus
    {
        Moving,
        InvalidDirection,
        Eating,
        Collision,
        Win
    }
    /// <summary>
    /// Contains the majority of the game's logic. Keeps info about the game board and is responsible for making the snake grow
    /// or move into a new place on the board
    /// </summary>
    public class GameBoard
    {
        /// <summary>
        /// The gamenode that contains the food
        /// </summary>
        public GameNode Food
        {
            get;
            set;
        }
        /// <summary>
        /// This is the array for storing the nodes of the game board.
        /// </summary>
        public GameNode[,] Grid
        {
            get;
            private set;
        }
        /// <summary>
        /// Maintains a reference to where the head of the snake is currently located
        /// </summary>
        public GameNode Head
        {
            get;
            set;
        }
        /// <summary>
        /// Mantains a reference to where the tail of the snake is currently located
        /// </summary>
        public GameNode Tail
        {
            get;
            set;
        }
        /// <summary>
        /// Keeps track of how big the snake is at any given time
        /// </summary>
        public int SnakeSize
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Keeps track of the dimension of the board
        /// </summary>
        private int _size;
        /// <summary>
        /// An Direction array that contains  all 4 possible directions 
        /// </summary>
        private Direction[] _aiDirection = new Direction[4] 
                    {Direction.Up,Direction.Left,Direction.Right,Direction.Down};
        /// <summary>
        /// A Direction array that contains the left/right
        /// </summary>
        private Direction[] _leftRight= new Direction[2] { Direction.Left, Direction.Right };
        /// <summary>
        /// A Direction array that contains the up/down
        /// </summary>
        private Direction[] _upDown= new Direction[2] { Direction.Up, Direction.Down };
        /// <summary>
        /// A new random object, this is primarily used to add the food
        /// </summary>
        private static Random _random = new Random();
        /// <summary>
        /// The default constructor
        /// </summary>
        /// <param name="size">the size of the board </param>
        public GameBoard(int size)
        {
            Grid = new GameNode[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Grid[i, j] = new GameNode(i,j);
                }
            }
            Grid[size / 2, size / 2].Data = GridData.SnakeHead;
            Head = Grid[size / 2, size / 2 ];
            Tail = Grid[size / 2, size / 2] ;
            _size = size;
            SnakeSize = 1;
            AddFood();
        }
        /// <summary>
        /// This method randomly places the snake food on the board
        /// </summary>
        public void AddFood()
        {
            int xCoordinate = _random.Next(_size);
            int yCoordinate = _random.Next(_size);
            while (Grid[xCoordinate, yCoordinate].Data != GridData.Empty)
            {
                xCoordinate = _random.Next(_size);
                 yCoordinate = _random.Next(_size);  
            }
            Grid[xCoordinate, yCoordinate].Data = GridData.SnakeFood;
            Food = Grid[xCoordinate, yCoordinate];
        }
        /// <summary>
        /// Gets the next node from the current node based n the direction
        /// </summary>
        /// <param name="dir">the direction the node is going to</param>
        /// <param name="current">the current node/ one we are trying to look ahead of</param>
        /// <returns></returns>
        public GameNode GetNextNode(Direction dir,GameNode current)
        {
            if (dir == Direction.Up)
            {
                
                if(current.Y -1 < 0)
                {
                    return null;
                }
                else
                {
                    return Grid[current.X,current.Y-1];
                }
            }
            if (dir == Direction.Down)
            {
                
                if (current.Y + 1 >= _size)
                {
                    return null;
                }
                else
                {
                    return Grid[current.X, current.Y + 1];
                }
            }
            if (dir == Direction.Right)
            {
                
                if (current.X + 1 >= _size )
                {
                    return null;
                }
                else
                {
                    return Grid[current.X + 1, current.Y];
                }
            }
            else
            {
                
                if ( current.X -1 < 0)
                {
                    return null;
                }
                else
                {
                    return Grid[current.X-1, current.Y];
                }
            }
        }
        /// <summary>
        /// Moves the snake in a specific direction and returns the status of the snake
        /// </summary>
        /// <param name="dir">the direction it's headed</param>
        /// <returns> the status of the snake</returns>
        public SnakeStatus MoveSnake(Direction dir)
        {
            GameNode next = GetNextNode(dir, Head);
            if (next == null)
            {
                return SnakeStatus.Collision;
            }
            else if (next.SnakeEdge == Head)
            {
                return SnakeStatus.InvalidDirection;
            }
            else if(next.Data == GridData.SnakeBody)
            {
                return SnakeStatus.Collision;
            }
            GameNode temp = next;
            next.Data = GridData.SnakeHead;
            Head.SnakeEdge = next;
            Head.Data = GridData.SnakeBody;
            if (temp == Food)
            {
                Head = next;
                SnakeSize++;
                if (SnakeSize == Grid.Length)
                {
                    return SnakeStatus.Win;
                }
                AddFood();
                return SnakeStatus.Eating;

            }
            else {
                if(Head != Tail)
                {
                    Tail.Data = GridData.Empty;
                    GameNode tail = Tail.SnakeEdge;
                    Tail.SnakeEdge = null;
                    Tail = tail;
                }
                else
                {
                    SnakeSize++;

                }
                Head = next;
                return SnakeStatus.Moving;
            }  
        }
        /// <summary>
        ///  a list of game nodes that contain the snake starting from the tail.
        /// </summary>
        /// <returns> a list of gamenodes that contains the snake</returns>
        public List<GameNode> GetSnakePath()
        {
            List<GameNode> path = new List<GameNode>();
            GameNode temp = Tail;
            while(temp != null)
            {
                path.Add(temp);
                temp = temp.SnakeEdge;
            }
            return path;
        }
        /// <summary>
        /// Reverses the given path from the destination to the head of the snake resulting
        /// in a list of series of directions
        /// </summary>
        /// <param name="path">A dictionary containing the paths from each node </param>
        /// <param name="dest"> the desitation </param>
        /// <returns> a list of directions from dest to head </returns>
        private List<Direction> BuildPath(Dictionary<GameNode, (GameNode, Direction)> path, GameNode dest)
        {
            Stack<Direction> s = new Stack<Direction>();
            List<Direction> directions = new List<Direction>();
            while(dest != Head)
            {
                s.Push(path[dest].Item2);
                dest = path[dest].Item1; 
            }
            while(s.Count > 0)
            {
                directions.Add(s.Pop());
            }
            return directions;
            
        }
        /// <summary>
        /// Calculates the shortest path from the head of the snake to the destination
        /// </summary>
        /// <param name="dest">the gamenode that is the destination</param>
        /// <returns>a list of directions based on the path</returns>
        public List<Direction> FindShortestAiPath(GameNode dest)
        {
            //source,dest,direction
            Queue<(GameNode, GameNode, Direction)> q = new Queue<(GameNode, GameNode, Direction)>();
            Dictionary<GameNode, (GameNode, Direction)> path = new Dictionary<GameNode, (GameNode, Direction)>();
            List<(GameNode, GameNode, Direction)> adjEdges = AdjancentEdges(Head);
            path[Head] = (Head, Direction.None);
            foreach ((GameNode, GameNode, Direction) item in adjEdges)
            {
                q.Enqueue(item);
            }
            while(q.Count > 0)
            {
                (GameNode, GameNode, Direction) edge = q.Dequeue();
                GameNode x = edge.Item2;
                if (!path.ContainsKey(x))
                {
                    
                    path.Add(edge.Item2, (edge.Item1, edge.Item3));
                    if (edge.Item2 == dest)
                    {
                        return BuildPath(path, dest);
                    }
                    adjEdges = AdjancentEdges(x);
                    foreach ((GameNode, GameNode, Direction) item in adjEdges)
                    {
                        q.Enqueue(item);
                    }
                }
            }
            return new List<Direction>();    
       }
        /// <summary>
        /// Helper method that finds the adjancent edges
        /// </summary>
        /// <param name="cur"> the current gamenode</param>
        /// <returns>a list of (gamenode,gamenode,Direction) that contains the adjancent edges </returns>
       private List<(GameNode, GameNode, Direction)> AdjancentEdges(GameNode cur)
       {
           List<(GameNode, GameNode, Direction)> li = new List<(GameNode, GameNode, Direction)>();
           for (int i = 0; i < _aiDirection.Length; i++)
           {
               GameNode dest = GetNextNode(_aiDirection[i], cur);
               
               if(dest != null)
                {
                    if(dest.Data == GridData.Empty || dest.Data == GridData.SnakeFood || dest == Tail)
                    {
                        if(!(dest == Tail && cur == Head))
                        {
                            li.Add((cur, dest, _aiDirection[i]));
                        }
                    }
                }
           }
           return li;
       }
        /// <summary>
        /// Finds the Hamiltonian Path
        /// </summary>
        /// <returns> A queue of directions </returns>
        public Queue<Direction> FindLongestAiPath()
        {
            Queue<Direction> longPath = new Queue<Direction>();
            List<Direction> shortPath = FindShortestAiPath(Tail);
            bool[,] aiPath = new bool[Grid.Length,Grid.Length];
            if(shortPath.Count <= 0)
            {
                return null;
            }
            Direction[] dir = null;
            GameNode curNode = Head;
            VisitedNodes(aiPath, curNode, shortPath);
            int index = 0;
            while(index < shortPath.Count)
            {
                Direction pathDirection = shortPath[index];
                GameNode nextNode = GetNextNode(pathDirection, curNode);
                bool flag = false;
                if(pathDirection == Direction.Left || pathDirection == Direction.Right)
                {
                    dir = _upDown;
                }
                else
                {
                    dir = _leftRight;
                }
                foreach (Direction d in dir)
                {
                    GameNode secondNode = GetNextNode(d, curNode);
                    GameNode finalNode = GetNextNode(d, nextNode);

                    if(secondNode != null && finalNode != null && !aiPath[secondNode.X,secondNode.Y] && !aiPath[finalNode.X, finalNode.Y])
                    {
                        aiPath[secondNode.X, secondNode.Y] = true;
                        aiPath[finalNode.X, finalNode.Y] = true;
                        shortPath.Insert(index, d);
                        shortPath.Insert(index + 2,FlipDirections(d));
                        flag = true;
                        break;
                    }  
                }
                if (!flag)
                {
                    curNode = nextNode;
                    index++;
                }
            }
            shortPath.Add(Direction.Up);
            for (int i = 0; i < shortPath.Count; i++)
            {
                longPath.Enqueue(shortPath[i]);
            }
            return longPath;
        }
        /// <summary>
        /// Helper method to flip the directions 
        /// </summary>
        /// <param name="dir">the current direction</param>
        /// <returns>the opposite direction of dir</returns>
        private Direction FlipDirections(Direction dir)
        {
            if(dir == Direction.Left)
            {
                return Direction.Right;
            }
            if(dir == Direction.Right)
            {
                return Direction.Left;
            }
            if(dir == Direction.Up)
            {
                return Direction.Down;
            }
            else
            {
                return Direction.Up;
            }
            
        }
        /// <summary>
        /// Helper method that sets the visted notes from the shortest path
        /// </summary>
        /// <param name="nodes"> the bool array that says if we visited it or not</param>
        /// <param name="cur">the current gamenode</param>
        /// <param name="path">the path of directions</param>
        private void VisitedNodes(bool[,] nodes, GameNode cur, List<Direction> path)
        {
            nodes[cur.X, cur.Y] = true;
            foreach (Direction dir in path)
            {
                cur = GetNextNode(dir, cur);
                nodes[cur.X, cur.Y] = true;
            }
        }
    }
}
