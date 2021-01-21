/*Game.cs
 * Author: Eve Steinle

 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KSU.CIS300.Snake
{
    /// <summary>
    /// The communication between the UI and game logic. It mantains the status of the game
    /// and manage moving the snake based off the key presses given by the UI
    /// </summary>
    public class Game : INotifyPropertyChanged
    {
        /// <summary>
        /// Keeps track of how many points the player has
        /// </summary>
        private int _score;
        /// <summary>
        /// Indicates how many milliseconds the game should wait before ticks
        /// </summary>
        private int _delay;
        /// <summary>
        /// Indicates if the game should be controlled by AI
        /// </summary>
        private bool _isAI;
        /// <summary>
        /// If AI is enabled, this queue will store the AI path
        /// </summary>
        private Queue<Direction> _aiPath;
        /// <summary>
        /// Stores whether of not the game is currently being played
        /// </summary>
        public bool Play;
        /// <summary>
        /// Gets the score while implementing data binding
        /// </summary>
        public int Score
        {
            get { return _score; }
            set
            {
                if (_score != value)
                {
                    _score = value;
                    OnPropertyChanged("Score");
                }
            }
        }
        /// <summary>
        /// The reference to the game board object that contains the 
        /// logic for moving the snake on the graph
        /// </summary>
        public GameBoard Board { get; private set; }
        /// <summary>
        /// The size of the game to create
        /// </summary>
        public int Size { get; private set; }
        /// <summary>
        /// The last direction that the snake successfully moved
        /// </summary>
        public Direction LastDirection { get; set; }
        /// <summary>
        /// The most recent direction reported by the UI
        /// </summary>
        public Direction KeyPress { get; private set; }
        /// <summary>
        /// The current status of the snake
        /// </summary>
        public SnakeStatus Status { get; private set; }
        /// <summary>
        /// This event is needed to implement the INotify Interface 
        /// and identify that a property has changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The interface that indicates if a property value has changed.
        /// </summary>
        public interface INotifyPropertyChanged
        {
        }
        /// <summary>
        /// This is what will call the property changed event with the appropriate property,
        /// needed for the Score Data Binding
        /// </summary>
        /// <param name="propertyName"> a string that holds the name of the property</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// The constructor for the Game class
        /// </summary>
        /// <param name="size">the size the gameboard should be</param>
        /// <param name="speed">an integer that indicates how fast the delay should be between moves</param>
        /// <param name="isAI">indicates if we are playing with AI or not</param>
        public Game(int size, int speed, bool isAI)
        {
            Size = size;
            Board = new GameBoard(size);
            _score = 2;
            
            Play = true;
            Board.MoveSnake(Direction.Up);
            _delay = speed;
            _isAI = isAI;
            
             if(isAI)
            {
                _aiPath = Board.FindLongestAiPath();
                
             }
            
        }
        /// <summary>
        /// This is an asynchronous method that acts as a game clock. The snake in the game is always moving unnless
        /// Play gets set to false or there is a cancelcation token requested
        /// </summary>
        /// <param name="progress">An IProgress that will report the progress of the snake</param>
        /// <param name="cancelToken">a cancellation token source that will indicate if the UI has made a cancelation request</param>
        /// <returns> Returns a task which is an asyncronous operation which in my understanding will display the move</returns>
        public async Task StartMoving(IProgress<SnakeStatus> progress,CancellationToken cancelToken)
        {

            while(Play == true && !cancelToken.IsCancellationRequested )
            {
                if (_isAI == true)
                {
                    Direction aiMove = _aiPath.Dequeue();
                    KeyPress = aiMove;
                    Status = Board.MoveSnake(KeyPress);
                    
                    _aiPath.Enqueue(aiMove);
                }
                else
                {
                    Status = Board.MoveSnake(KeyPress);
                }
                if (Status.Equals(SnakeStatus.Collision))
                {
                    Play = false;
                }

                if (Status.Equals(SnakeStatus.Eating))
                {
                    Score++;

                }
                if (Status.Equals(SnakeStatus.InvalidDirection))
                {
                    Status = Board.MoveSnake(LastDirection);
                    KeyPress = LastDirection;
                    if (Status.Equals(SnakeStatus.Collision))
                    {
                        Play = false;
                    }
                    if (Status.Equals(SnakeStatus.Eating))
                    {
                        Score++;
                    }
                }
                if (Status.Equals(SnakeStatus.Win))
                {
                    Score++;
                    Play = false;
                }

                LastDirection = KeyPress;


                progress.Report(Status);
                await Task.Delay(_delay);
            }
        }
        /// <summary>
        /// Gets the snakes path
        /// </summary>
        /// <returns>Returns the result of the GetSnakePath method </returns>
        public List<GameNode> GetSnakePath()
        {
            return Board.GetSnakePath();
        }
        /// <summary>
        /// Returns the Food Property of the game board
        /// </summary>
        /// <returns> The food property of the game board</returns>
        public GameNode GetFood()
        {
            if(Board.Food.Data != GridData.SnakeFood)
            {
                return null;
            }
            else
            {
                return Board.Food;
            }
        }
        /// <summary>
        /// Sets the key presss field to be up
        /// </summary>
        public void MoveUp()
        {
            KeyPress = Direction.Up;
        }
        /// <summary>
        /// Sets the key presss field to be down
        /// </summary>
        public void MoveDown()
        {
            KeyPress = Direction.Down;
        }
        /// <summary>
        /// Sets the key presss field to be left
        /// </summary>
        public void MoveLeft()
        {
            KeyPress = Direction.Left;
        }
        /// <summary>
        /// Sets the key presss field to be right
        /// </summary>
        public void MoveRight()
        {
            KeyPress = Direction.Right;
        }


    }
}
