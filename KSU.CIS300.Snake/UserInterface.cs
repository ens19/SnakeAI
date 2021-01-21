/*UserInterface.cs
 * Author: Eve Steinle
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSU.CIS300.Snake
{
    
    public partial class UserInterface : Form
    {
        /// <summary>
        /// The calculated size of a game square(a node on the graph)
        /// </summary>
        private int _squareWidth;
        /// <summary>
        /// The width and height of the game in number of nodes/game squares
        /// </summary>
        private int _size;
        /// <summary>
        /// The game object. This gives the UI access to informing the game when the user
        /// has changed directions, as well as letting the game inform the UI of the score and where
        /// the snake is
        /// </summary>
        private Game _game;
        /// <summary>
        /// Used to give the snake color
        /// </summary>
        private SolidBrush _bodyBrush = new SolidBrush(Color.MediumPurple);
        /// <summary>
        /// Used to give the food color
        /// </summary>
        private SolidBrush _foodBrush = new SolidBrush(Color.SkyBlue);
        /// <summary>
        /// This is what gives each snake square an outline
        /// </summary>
        private Pen _pen = new Pen(Color.White, 2);
        /// <summary>
        /// This field will allow the UserInterface to cancel or stop the async StartMoving method in the Game class
        /// </summary>
        private CancellationTokenSource _cancelSource = new CancellationTokenSource();
        /// <summary>
        /// Default constructor for the user interface
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Creates a new game with the given size and speed
        /// </summary>
        /// <param name="size">the size the gameboard should be</param>
        /// <param name="speed"> the speed of the game</param>
        private void NewGame(int size, int speed)
        {
            _size = size;
            Progress<SnakeStatus> progress = new Progress<SnakeStatus>();
            _cancelSource.Cancel();
            
            uxPictureBox.Width = 600;
            uxPictureBox.Height = 600;
            this.AutoSize = true;
            uxPictureBox.BackColor = Color.Black;
            _squareWidth = uxPictureBox.Width / size;
            if (uxIsAI.Checked)
            {
                _game = new Game(size,(int)uxDelay.Value, true);
            }
            else
            {
                _game = new Game(size, speed, false);
            }
            uxScore.DataBindings.Clear();
            uxScore.DataBindings.Add(new Binding("Text",_game,"Score"));
            progress.ProgressChanged += new EventHandler<SnakeStatus>(CheckProgress);
            _cancelSource = new CancellationTokenSource();
            _game.StartMoving(progress, _cancelSource.Token);
            
        }
        /// <summary>
        /// Checks the progress of the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="status"></param>
        private void CheckProgress(object sender, SnakeStatus status)
        {
            //Note that the Refresh call invalidates the state of the controls, forcing them to be redrawn.
            Refresh();
            if (status == SnakeStatus.Collision)
            {
                MessageBox.Show("Game over!");
            }
            else if (status == SnakeStatus.Win)
            {
                MessageBox.Show("Game Completed!");
            }
        }
        
        /// <summary>
        /// When the user clicks a new game that is easy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEasy_Click(object sender, EventArgs e)
        {
            NewGame(10, 250);
            
        }
        /// <summary>
        /// This is an event handler that will draw all of the game graphics
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (_game != null)
            {
                Graphics g = e.Graphics;
                List<GameNode> path = _game.GetSnakePath();
                foreach (GameNode node in path)
                {
                    Rectangle snake = new Rectangle(node.X * _squareWidth, node.Y * _squareWidth, _squareWidth, _squareWidth);
                    g.FillRectangle(_bodyBrush, snake);
                    g.DrawRectangle(_pen, snake);
                }
                GameNode Food = _game.GetFood();
                
                if ( Food != null)
                {
                    Rectangle food = new Rectangle(Food.X * _squareWidth, Food.Y * _squareWidth, _squareWidth, _squareWidth);
                    g.FillEllipse(_foodBrush, food);
                }
            }
        }
        /// <summary>
        /// This is a KeyDown event handler which is hooked to the Form control and AI checkbox in the UI
        /// designer window. If the game is active, it will call te correct move function through the game
        ///  class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInterface_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                _game.MoveUp();
            }
            if (e.KeyCode == Keys.Down)
            {
                _game.MoveDown();
            }
            if (e.KeyCode == Keys.Right)
            {
                _game.MoveRight();
            }
            if (e.KeyCode == Keys.Left)
            {
                _game.MoveLeft();
            }
            uxPictureBox.Refresh();
        }
        /// <summary>
        /// When the user clicks Normal game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNormal_Click(object sender, EventArgs e)
        {
            NewGame(20, 150);
        }
        /// <summary>
        /// When the user clicks Hard game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxHard_Click(object sender, EventArgs e)
        {
            NewGame(30, 100);
        }
        /// <summary>
        /// A event handler that will enable the use of the arrow keys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInterface_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }
    }
}
