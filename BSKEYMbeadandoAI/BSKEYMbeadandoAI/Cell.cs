using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSKEYMbeadandoAI
{
    internal class Cell
    {

        private bool leftWall = true;
        private bool topWall = true;
        private bool bottomWall = true;
        private bool rightWall = true;

        private bool visited = false;

        public Cell(bool leftWall, bool topWall, bool bottomWall, bool rightWall)
        {
            this.LeftWall = leftWall;
            this.TopWall = topWall;
            this.BottomWall = bottomWall;
            this.RightWall = rightWall;
        }

        public bool Visited { get => visited; set => visited = value; }
        public bool LeftWall { get => leftWall; set => leftWall = value; }
        public bool TopWall { get => topWall; set => topWall = value; }
        public bool BottomWall { get => bottomWall; set => bottomWall = value; }
        public bool RightWall { get => rightWall; set => rightWall = value; }
    }
}
