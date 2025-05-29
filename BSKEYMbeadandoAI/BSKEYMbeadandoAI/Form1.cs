using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSKEYMbeadandoAI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StateInitializer();
        }


        private Cell[,] maze = new Cell[8, 8];
        private int CellRow = 0;
        private int CellCol = 0;
        private int currentPosX = 0;
        private int currentPosY = 0;
        private State state;
        

        internal Cell[,] Maze { get => maze; }

        private void StateInitializer()
        {
            state = new State(this);
            currentPosX = state.CurrentPositionCol;
            currentPosY = state.CurrentPositionRow;
            CellFiller(state.Table);

        }

        public void CurrentPositionUpdater(int x, int y)
        {
            currentPosX = x;
            currentPosY = y;
        }

        private void Cellmaker(int code)
        {
            #region CodeDarabolás
            int left = code / 1000;
            code = code % 1000;
            int top = code / 100;
            code = code % 100;
            int bottom = code / 10;
            code = code % 10;
            int right = code;
            #endregion

            bool LeftWall = true;
            bool TopWall = true;
            bool BottomWall = true;
            bool RightWall = true;

            #region Ifek
            if (left == 0)
            {
                LeftWall = false;
            }
            if (top == 0)
            {
                TopWall = false;
            }
            if (bottom == 0)
            {
                BottomWall = false;
            }
            if (right == 0)
            {
                RightWall = false;
            }
            #endregion

            Maze[CellRow, CellCol] = new Cell(LeftWall,TopWall,BottomWall,RightWall);

            CellCol++;
            if (CellCol >= 8)
            {
                CellCol = 0;
                CellRow++;
            }

        }

        private void CellFiller(int[] table)
        {
            int[] codes = table;


            foreach (int code in codes)
            {
                Cellmaker(code);
            }
            
        }


        private void mazefield_Paint(object sender, PaintEventArgs e)
        {
            int cellSize = 40;
            Pen wallPen = new Pen(Color.Black, 2);

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    
                    int x = col * cellSize;
                    int y = row * cellSize;
                    Cell cell = Maze[row, col];

                    if (cell.Visited)
                    {
                        BgColorSetter(col, row, "lightgray");
                    }

                    if (row == currentPosY && col == currentPosX)
                    {
                        BgColorSetter(col, row, "red");
                        Maze[row, col].Visited = true;
                    }

                    if(row == 7 && col == 7)
                    {
                        BgColorSetter(col, row, "green");
                    }

                    if (cell.TopWall)
                    {
                        e.Graphics.DrawLine(wallPen, x, y, x + cellSize, y);
                    }

                    if (cell.RightWall)
                    {
                        e.Graphics.DrawLine(wallPen, x + cellSize, y, x + cellSize, y + cellSize);
                    }

                    if (cell.BottomWall)
                    {
                        e.Graphics.DrawLine(wallPen, x, y + cellSize, x + cellSize, y + cellSize);
                    }

                    if (cell.LeftWall)
                    {
                        e.Graphics.DrawLine(wallPen, x, y, x, y + cellSize);
                    }

                    
                   
                }
            }

        }

        private void BgColorSetter(int positionx, int positiony, string color)
        {
            int cellSize = 40;
            int startX = positionx * cellSize;
            int startY = positiony * cellSize;
            using (Graphics g = mazefield.CreateGraphics())
            {
                Color bgColor = Color.White;

                switch (color.ToLower())
                {
                    case "gray":
                        bgColor = Color.Gray;
                        break;
                    case "lightgray":
                        bgColor = Color.LightGray;
                        break;
                    case "red":
                        bgColor = Color.Red;
                        break;
                    case "green":
                        bgColor = Color.Green;
                        break;
                    case "blue":
                        bgColor = Color.Blue;
                        break;
                    case "orange":
                        bgColor = Color.Orange;
                        break;
                    default:
                        bgColor = Color.White;
                        break;
                }

                using (Brush brush = new SolidBrush(bgColor))
                {
                    g.FillRectangle(brush, startX, startY, cellSize, cellSize);
                }
            }
            
        }

        public void ReDrawField()
        {
            mazefield.Invalidate();
        }

        private async void trialanderrorwithrestart_Click(object sender, EventArgs e)
        {
            state.ResetState();
            RandomSolverWithRestart solver = new RandomSolverWithRestart(this);
            //await solver.Solve();
            solver.Solve();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            state.ResetState();
        }
        
            
        //ha nézném async
        public void ResetSolver(Solvers solvers)
        {
            switch (solvers)
            {
                case Solvers.TrialAndErrorWithRestart:
                    RandomSolverWithRestart solver = new RandomSolverWithRestart(this);
                    //await solver.Solve();
                    solver.Solve();
                    break;
                case Solvers.BackTrack:
                    BackTrack backtrack = new BackTrack(this, 10);
                    backtrack.Solve(0, new Node(null, state.CurrentPositionRow, state.CurrentPositionCol));
                    break;
                case Solvers.DepthFirst:
                    //DepthFirst depthFirstSolver = new DepthFirst(this);
                    //depthFirstSolver.Solve(new Note);
                    break;

                default:
                    throw new NotImplementedException("Solver not implemented: " + solvers);

            }
        }

        private void trialanderror_Click(object sender, EventArgs e)
        {
            state.ResetState();
            RandomSolver solver = new RandomSolver(this);
            //await solver.Solve();
            solver.Solve();
        }

        private void backtrack_Click(object sender, EventArgs e)
        {
            state.ResetState();

            if (depth.Text == "")
            {
                depth.Text = "16";
            }
                BackTrack backtrack = new BackTrack(this, int.Parse(depth.Text));
            backtrack.Solve(0, new Node(null, state.CurrentPositionRow, state.CurrentPositionCol));
        }

        private void depthfirst_Click(object sender, EventArgs e)
        {
            state.ResetState();
            DepthFirst depthFirstSolver = new DepthFirst(this);
            Node node = new Node(null, state.CurrentPositionRow, state.CurrentPositionCol);
            depthFirstSolver.Solve(node);
        }

        private void breadthfirst_Click(object sender, EventArgs e)
        {
            state.ResetState();
            Breadth_First breadthFirstSolver = new Breadth_First(this);
            Node node = new Node(null, state.CurrentPositionRow, state.CurrentPositionCol);
            breadthFirstSolver.Solve(node);
        }
    }
}
