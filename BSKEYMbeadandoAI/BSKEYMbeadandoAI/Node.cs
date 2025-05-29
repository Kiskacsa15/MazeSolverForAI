using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSKEYMbeadandoAI
{
    internal class Node
    {
        public Node(Node parent, int currentPositionRow, int currentPositionCol)
        {
            Parent = parent;
            CurrentPositionRow = currentPositionRow;
            CurrentPositionCol = currentPositionCol;
            if (parent != null)
            {
                Depth = parent.Depth + 1;
            }
            else
            {
                Depth = 0;
            }
        }
        private State state;

        public Node(State state, Node parent)
        {
            Parent = parent;
            this.state = state;
            CurrentPositionRow = state.CurrentPositionRow;
            CurrentPositionCol = state.CurrentPositionCol;
            if (parent != null)
            {
                Depth = parent.Depth + 1;
            }
            else
            {
                Depth = 0;
            }
        }

        public Node Parent { get; set; }
        public int CurrentPositionRow { get; set; }
        public int CurrentPositionCol { get; set; }
        public int Depth { get; set; }


        public bool IsTerminalNode()
        {
            return (CurrentPositionRow == 7 && CurrentPositionCol == 7);
        }


        public bool HasLoop() 
        {
            Node temp = this.Parent;
            while (temp != null)
            {
                if (temp.CurrentPositionRow == this.CurrentPositionRow && temp.CurrentPositionCol == this.CurrentPositionCol)
                    return true;
                temp = temp.Parent;
            }

            return false;
        }


        





    }
}
