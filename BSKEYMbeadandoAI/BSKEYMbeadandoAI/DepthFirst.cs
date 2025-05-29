using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BSKEYMbeadandoAI
{
    internal class DepthFirst
    {
        private State state;
        HashSet<(int, int)> visitedPositions;

        public DepthFirst(Form1 form1)
        {
            state = new State(form1);
            visitedPositions = new HashSet<(int, int)>();

        }

        public bool Solve(Node parent)
        {
            int row = state.CurrentPositionRow;
            int col = state.CurrentPositionCol;
            if (visitedPositions.Contains((row, col)))
                return false;

            visitedPositions.Add((row, col));

            Node currentNode = new Node(parent, row, col);

            if (row == 7 && col == 7)
            {
                Console.WriteLine($"Megoldva! Mélység: {currentNode.Depth} X: {col} Y: {row}");
                return true;
            }

            state.CurrentPositionRow = row;
            state.CurrentPositionCol = col;

            Direction[] directions = { Direction.Bottom, Direction.Right, Direction.Top, Direction.Left };

            foreach (Direction dir in directions)
            {
                if (state.IsMovementPossible(dir, row, col))
                {
                    if (state.MakeAMove(dir))
                    {
                        if (Solve(currentNode))
                        {
                            return true;
                        }

                        state.UndoMove(dir);
                    }
                }
            }

            return false;
        }
    }
}
