namespace LiskovSubstitutionSquareAfter
{
    public class Square : Shape
    {
        public decimal Side { get; set; }

        public override decimal Area
        {
            get
            {
                return this.Side * this.Side;
            }
        }
    }
}
