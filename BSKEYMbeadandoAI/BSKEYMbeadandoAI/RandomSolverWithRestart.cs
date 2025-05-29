using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSKEYMbeadandoAI
{
    internal class RandomSolverWithRestart
    {
        private static Random random = new Random();
        private State state;

        private int trylimit = 30;
        private int stuckCounter = 10;

        public RandomSolverWithRestart(Form1 form)
        {
            state = new State(form);
            state.TryLimit = trylimit;
        }

        public void Solve()
        {
            state.MakeANode();
            while (!state.IsGoalState())
            {
                Direction direction = PickADirection();
                if(direction == Direction.reset) 
                { 
                    Console.WriteLine("No valid direction found, resetting state...");
                    state.ResetState();
                    state.SolverPasser(Solvers.TrialAndErrorWithRestart);
                    return;
                }

                if (state.MakeAMove(direction))
                {
                    state.MakeANode(); 
                }

                if (state.TryLimit <= state.Nodes.Last().Depth)
                {
                    return;
                }
            }
        }

        public Direction PickADirection()
        {
            List<Direction> directions = new List<Direction>();
            directions.Add(Direction.Left);
            directions.Add(Direction.Top);
            directions.Add(Direction.Bottom);
            directions.Add(Direction.Right);

            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(directions.Count);
                Direction direction = directions[index];
                if (state.IsMovementPossible(direction) && !state.IsVisited(direction))
                {
                    stuckCounter = 10;
                    return direction;
                }
                else
                {
                    directions.Remove(direction);
                }
            }

            stuckCounter--;
            if (stuckCounter <= 0)
            {
                Console.WriteLine("Stuck! Resetting state...");
                stuckCounter = 10;
                return Direction.reset;
            }
            return Direction.None;

        }

        
    }
}
