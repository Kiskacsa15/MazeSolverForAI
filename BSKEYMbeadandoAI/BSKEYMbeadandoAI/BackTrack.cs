using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSKEYMbeadandoAI
{
    internal class BackTrack
    {
        private State state;
        private int maxDepth = 0;
        private List<Node> nodes = new List<Node>();

        public BackTrack(Form1 form, int maxDepth)
        {
            this.maxDepth = maxDepth;
            nodes.Add(new Node(null, 0, 0));
            state = new State(form);
        }
        
        public void Solve(int currentDepth, Node node)
        {
            Console.WriteLine("Max depth: " + maxDepth);
            Console.WriteLine("Current depth: " + currentDepth);
           


            if (currentDepth > maxDepth)
            {
                Console.WriteLine("Max depth reached, returning to previous node.");
                nodes.RemoveAt(nodes.Count - 1);
                return;
            }
            if (state.IsGoalState())
            {
                Console.WriteLine("Goal state reached at depth: " + currentDepth);
                state.SolverPasser(Solvers.BackTrack);
                return;
            }



            Direction[] directions = { Direction.Bottom, Direction.Right, Direction.Top, Direction.Left };
            foreach (Direction dir in directions)
            {
                if (state.IsMovementPossible(dir, node.CurrentPositionRow, node.CurrentPositionCol))
                {

                    
                    if (state.MakeAMove(dir))
                    {

                        Node newNode = new Node(node, state.CurrentPositionRow, state.CurrentPositionCol);
                        if(!newNode.HasLoop())
                        {

                        nodes.Add(newNode);
                        Solve(currentDepth + 1, newNode);

                        }

                        state.UndoMove(dir);


                    }
                }
            }
        }
    }
}
