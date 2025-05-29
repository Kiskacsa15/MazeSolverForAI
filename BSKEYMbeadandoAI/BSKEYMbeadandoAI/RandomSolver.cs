using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace BSKEYMbeadandoAI
{
    internal class RandomSolver
    {
        private static Random random = new Random();
        private State state;


        private int trylimit = 30;

        public RandomSolver(Form1 form)
        {
            state = new State(form);
            state.TryLimit = trylimit;
        }


        public void Solve()
        {
            state.MakeANode();

            while (state.MakeAMove(PickADirection()) && !state.IsGoalState())
            {
                    state.MakeANode();

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
                    return direction;
                }
                else
                {
                    directions.Remove(direction);
                }
            }

            Console.WriteLine("Megakadtam!");
            return Direction.None;

        }


    }
}
