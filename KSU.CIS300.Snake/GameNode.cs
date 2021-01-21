/*GameNode.cs
 *Author: Eve Steinle
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSU.CIS300.Snake
{
    /// <summary>
    /// A public enum that indicates what the gridData holds
    /// </summary>
    public enum GridData
    {
        Empty, SnakeHead, SnakeBody, SnakeFood
    }
    /// <summary>
    /// An object that serves as a node in the graph that represents the game board
    /// </summary>
    public class GameNode
    {
        /// <summary>
        /// The Y-coordinate for the node
        /// </summary>
        public int Y
        {
            get;
            set;
        }
        /// <summary>
        /// The X-coordinate for the node
        /// </summary>
        public int X
        {
            get;
            set;
        }
        /// <summary>
        /// The information stored at the node
        /// </summary>
        public GridData Data
        {
            get;
            set;
        }
        /// <summary>
        /// This edge represents a connection in the graph to another GameNode
        /// </summary>
        public GameNode SnakeEdge
        {
            get;
            set;
        }
        /// <summary>
        /// This is the default constructor that sets the x-y coordinate properties above.
        /// </summary>
        /// <param name="x"> the x coordinate</param>
        /// <param name="y">the y coordinate</param>
        public GameNode(int x, int y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// An overidden ToString method, the purpose is primarily for debugging
        /// purposes
        /// </summary>
        /// <returns>a string with the GameNode coordinates</returns>
        public override string ToString()
        {
            GameNode g = new GameNode(X, Y);
            string s = g.Data.ToString();
            return s;
        }
    }
}
