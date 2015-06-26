using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteenProject
{
    class Tile : IComparable
    {
        private string label;
        private int position;

        public string Label
        {
            get { return label; }
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        public Tile(string label, int position)
        {
            this.label = label;
            this.position = position;
        }

        public Tile()
        {
        }

        public int CompareTo(object tile)
        {
            Tile currentTile = (Tile)tile;
            int result = this.position.CompareTo(currentTile.Position);

            return result;
        }
    }
}
