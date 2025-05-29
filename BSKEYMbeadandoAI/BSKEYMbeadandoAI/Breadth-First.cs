using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSKEYMbeadandoAI
{
    internal class Breadth_First
    {
        private State state;
        private Queue<Node> queuenodes;
        HashSet<(int, int)> visitedPositions;
        private int stepCount = 0;

        public Breadth_First(Form1 form1)
        {
            queuenodes = new Queue<Node>();
            queuenodes.Enqueue(new Node(null, 0, 0));
            state = new State(form1);
            visitedPositions = new HashSet<(int, int)>();

        }

        public bool Solve(Node parent)
        {

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(parent);

            while (queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();

                int row = currentNode.CurrentPositionRow;
                int col = currentNode.CurrentPositionCol;
                if (visitedPositions.Contains((row, col)))
                    continue;
                visitedPositions.Add((row, col));
                state.CurrentPositionRow = row;
                state.CurrentPositionCol = col;

                Direction[] directions = { Direction.Bottom, Direction.Right, Direction.Top, Direction.Left };
                foreach (Direction dir in directions)
                {
                    if (state.IsMovementPossible(dir, row, col))
                    {
                        if (state.NoStopMakeAMove(dir))
                        {
                                Node newNode = new Node(currentNode, state.CurrentPositionRow, state.CurrentPositionCol);
                                if (state.CurrentPositionRow == 7 && state.CurrentPositionCol == 7)
                                {
                                    Console.WriteLine($"Megoldva! Mélység: {newNode.Depth} X: {state.CurrentPositionCol} Y: {state.CurrentPositionRow}");
                                    return true;
                                }
                                queue.Enqueue(newNode);
                                state.NoStopUndoMove(dir);
                        }
                    }
                }
            }

            return false;

        }
    }
}
