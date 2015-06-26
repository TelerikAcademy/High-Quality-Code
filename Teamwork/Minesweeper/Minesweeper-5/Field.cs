using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Field
    {
        public Field()
        {
            this.value = 0;
            this.status = FieldStatus.Closed;
        }

        private int value;
        private FieldStatus status;

        public enum FieldStatus { Closed, Opened, IsAMine }

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public FieldStatus Status
        {
            get { return this.status; }
            set { this.status = value; }
        }
    }
}
