using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BSKEYMbeadandoAI
{
    internal class State : ICloneable
    {

        

        private int[] table = new int[]
            {
                1101, 1100, 0110, 0101, 1100, 0110, 0101, 1101,
                1000, 0011, 1101, 1000, 0011, 1100, 0001, 1001,
                1010, 0101, 1001, 1001, 1100, 0011, 1000, 0011,
                1101, 1010, 0001, 1001, 1010, 0101, 1010, 0101,
                1000, 0111, 1001, 1000, 0111, 1010, 0110, 0001,
                1001, 1100, 0011, 1010, 0110, 0100, 0101, 1001,
                1001, 1010, 0101, 1100, 0101, 1001, 1011, 1001,
                1010, 0110, 0010, 0011, 1011, 1010, 0110, 0011,

            };

        private int tryLimit = 0;
        private List<Node> nodes = new List<Node>();
        private static bool goalStateReached = false;

        public int[] Table
        {
            get 
            {
                return ((State)this.Clone()).table;
            }
        }

        public int CurrentPositionRow { get => currentPositionRow; set => currentPositionRow = value; }
        public int CurrentPositionCol { get => currentPositionCol; set => currentPositionCol = value; }
        public int TryLimit { get => tryLimit; set => tryLimit = value; }
        internal List<Node> Nodes { get => nodes; set => nodes = value; }

        private Form1 form1;

        public State(Form1 form)
        {
            form1 = form;
        }

        private int currentPositionRow = 0;
        private int currentPositionCol = 0;

        public List<Direction> MovementOptions()
        {

            List<Direction> directions = new List<Direction>();
            if (IsMovementPossible(Direction.Left))
                directions.Add(Direction.Left);
            if (IsMovementPossible(Direction.Top))
                directions.Add(Direction.Top);
            if (IsMovementPossible(Direction.Bottom))
                directions.Add(Direction.Bottom);
            if (IsMovementPossible(Direction.Right))
                directions.Add(Direction.Right);
            return directions;

        }

        public bool IsMovementPossible(Direction direction)
        {
            int rowFrom = CurrentPositionRow;
            int colFrom = CurrentPositionCol;
            int fullcode = table[rowFrom *8 + colFrom];

            int[] code = new int[4];
            code[0] = fullcode / 1000; 
            fullcode = fullcode % 1000;
            code[1] = fullcode / 100;
            fullcode = fullcode % 100;
            code[2] = fullcode / 10; 
            fullcode = fullcode % 10;
            code[3] = fullcode; 



            switch (direction)
            {
                case Direction.Left:
                    return (code[0]) == 0;
                case Direction.Top:
                    return (code[1]) == 0;
                case Direction.Bottom:
                    return (code[2]) == 0;
                case Direction.Right:
                    return (code[3]) == 0;
                default:
                    Console.WriteLine("Érvénytelen irány!");
                    form1.CurrentPositionUpdater(CurrentPositionCol, CurrentPositionRow);
                    form1.ReDrawField();
                    return false;
            }
            
            
            
        }

        public bool IsMovementPossible(Direction direction, int posrow, int poscol)
        {
            int rowFrom = posrow;
            int colFrom = poscol;
            int fullcode = table[rowFrom * 8 + colFrom];

            int[] code = new int[4];
            code[0] = fullcode / 1000;
            fullcode = fullcode % 1000;
            code[1] = fullcode / 100;
            fullcode = fullcode % 100;
            code[2] = fullcode / 10;
            fullcode = fullcode % 10;
            code[3] = fullcode;



            switch (direction)
            {
                case Direction.Left:
                    return (code[0]) == 0;
                case Direction.Top:
                    return (code[1]) == 0;
                case Direction.Bottom:
                    return (code[2]) == 0;
                case Direction.Right:
                    return (code[3]) == 0;
                default:
                    Console.WriteLine("Érvénytelen irány!");
                    form1.CurrentPositionUpdater(CurrentPositionCol, CurrentPositionRow);
                    form1.ReDrawField();
                    return false;
            }



        }

        public bool MakeAMove(Direction direction)
        {

            if (goalStateReached)
                return false;

            if (!IsMovementPossible(direction))
            {
                return false;
            }

            Cell cell = form1.Maze[CurrentPositionRow, CurrentPositionCol];


            switch (direction)
            {
                case Direction.Left:
                    cell.Visited = true;
                    CurrentPositionCol--;
                    break;
                case Direction.Top:
                    cell.Visited = true;
                    CurrentPositionRow--;
                    break;
                case Direction.Bottom:
                    cell.Visited = true;
                    CurrentPositionRow++;
                    break;
                case Direction.Right:
                    cell.Visited = true;
                    CurrentPositionCol++;
                    break;
            }

            
            Console.WriteLine("---REALCurrent x pos: " + CurrentPositionCol+ " y pos: " + CurrentPositionRow);
            
            
            form1.CurrentPositionUpdater(CurrentPositionCol, CurrentPositionRow);
            form1.ReDrawField();
            return true;

        }

        public bool NoStopMakeAMove(Direction direction)
        {


            if (!IsMovementPossible(direction))
            {
                return false;
            }

            Cell cell = form1.Maze[CurrentPositionRow, CurrentPositionCol];


            switch (direction)
            {
                case Direction.Left:
                    cell.Visited = true;
                    CurrentPositionCol--;
                    break;
                case Direction.Top:
                    cell.Visited = true;
                    CurrentPositionRow--;
                    break;
                case Direction.Bottom:
                    cell.Visited = true;
                    CurrentPositionRow++;
                    break;
                case Direction.Right:
                    cell.Visited = true;
                    CurrentPositionCol++;
                    break;
            }


            Console.WriteLine("---REALCurrent x pos: " + CurrentPositionCol + " y pos: " + CurrentPositionRow);


            form1.CurrentPositionUpdater(CurrentPositionCol, CurrentPositionRow);
            form1.ReDrawField();
            return true;

        }

        public bool UndoMove(Direction direction)
        {
            if (goalStateReached)
                return false;

            Cell cell = form1.Maze[CurrentPositionRow, CurrentPositionCol];

            Direction opposite;
            switch (direction)
            {
                case Direction.Left:
                    opposite = Direction.Right;
                    break;
                case Direction.Right:
                    opposite = Direction.Left;
                    break;
                case Direction.Top:
                    opposite = Direction.Bottom;
                    break;
                case Direction.Bottom:
                    opposite = Direction.Top;
                    break;
                default:
                    return false;
            }

            
            switch (opposite)
            {
                case Direction.Left:
                    CurrentPositionCol--;
                    break;
                case Direction.Right:
                    CurrentPositionCol++;
                    break;
                case Direction.Top:
                    CurrentPositionRow--;
                    break;
                case Direction.Bottom:
                    CurrentPositionRow++;
                    break;
                default:
                    return false;
            }

            form1.CurrentPositionUpdater(CurrentPositionCol, CurrentPositionRow);
            form1.ReDrawField();
            return false;
        }

        public bool NoStopUndoMove(Direction direction)
        {

            Cell cell = form1.Maze[CurrentPositionRow, CurrentPositionCol];

            Direction opposite;
            switch (direction)
            {
                case Direction.Left:
                    opposite = Direction.Right;
                    break;
                case Direction.Right:
                    opposite = Direction.Left;
                    break;
                case Direction.Top:
                    opposite = Direction.Bottom;
                    break;
                case Direction.Bottom:
                    opposite = Direction.Top;
                    break;
                default:
                    return false;
            }


            switch (opposite)
            {
                case Direction.Left:
                    CurrentPositionCol--;
                    break;
                case Direction.Right:
                    CurrentPositionCol++;
                    break;
                case Direction.Top:
                    CurrentPositionRow--;
                    break;
                case Direction.Bottom:
                    CurrentPositionRow++;
                    break;
                default:
                    return false;
            }

            form1.CurrentPositionUpdater(CurrentPositionCol, CurrentPositionRow);
            form1.ReDrawField();
            return false;
        }

        public bool IsGoalState()
        {
            if (CurrentPositionRow == 7 && CurrentPositionCol == 7)
            {
                goalStateReached = true;
                foreach (Node n in Nodes)
                {
                    Console.WriteLine("Node: " + n.CurrentPositionCol + " " + n.CurrentPositionRow);
                }
            }
            return CurrentPositionRow == 7 && CurrentPositionCol == 7;
        }

        public bool IsVisited(Direction direction)
        {

            switch (direction)
                {
                case Direction.Left:
                    return form1.Maze[CurrentPositionRow, CurrentPositionCol - 1].Visited;
                case Direction.Top:
                    return form1.Maze[CurrentPositionRow - 1, CurrentPositionCol].Visited;
                case Direction.Bottom:
                    return form1.Maze[CurrentPositionRow + 1, CurrentPositionCol].Visited;
                case Direction.Right:
                    return form1.Maze[CurrentPositionRow, CurrentPositionCol + 1].Visited;
                default:
                    return false;
            }

        }

        public void ResetState()
        {
            CurrentPositionRow = 0;
            CurrentPositionCol = 0;
            tryLimit = 0;
            goalStateReached = false;
            Nodes.Clear();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    form1.Maze[i, j].Visited = false;
                }
            }
            form1.CurrentPositionUpdater(CurrentPositionCol, CurrentPositionRow);
            form1.ReDrawField();
        }

        public void SolverPasser(Solvers solver)
        {
            form1.ResetSolver(solver);
        }

        public void MakeANode() 
        {
            Node node = null;

            if (Nodes.Count == 0)
            {
                node = new Node(null, CurrentPositionRow, CurrentPositionCol);
            }
            else
            {
                node = new Node(Nodes.Last(), CurrentPositionRow, CurrentPositionCol);
            }
            Nodes.Add(node);
            Console.WriteLine("Depth counter: " + node.Depth);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
            
        }
    }
}
