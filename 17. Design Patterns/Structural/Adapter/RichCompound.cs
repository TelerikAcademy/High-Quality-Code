namespace Adapter
{
    using System;

    /// <summary>
    /// The 'ConcreteAdapter' class
    /// </summary>
    internal class RichCompound : ICompound
    {
        private readonly string chemical;

        private readonly float boilingPoint;
        private readonly float meltingPoint;
        private readonly double molecularWeight;
        private readonly string molecularFormula;

        public RichCompound(string chemical)
        {
            this.chemical = chemical;
            var bank = new ChemicalDatabank();

            this.boilingPoint = bank.GetCriticalPoint(this.chemical, "B");
            this.meltingPoint = bank.GetCriticalPoint(chemical, "M");
            this.molecularWeight = bank.GetMolecularWeight(chemical);
            this.molecularFormula = bank.GetMolecularStructure(chemical);
        }

        public void Display()
        {
            Console.WriteLine("Compound: {0} ------ ", this.chemical);
            Console.WriteLine(" Formula: {0}", this.molecularFormula);
            Console.WriteLine(" Weight : {0}", this.molecularWeight);
            Console.WriteLine(" Melting Pt: {0}", this.meltingPoint);
            Console.WriteLine(" Boiling Pt: {0}", this.boilingPoint);
            Console.WriteLine();
        }
    }
}
