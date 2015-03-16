namespace Bridge.Manuscripts
{
    using System;

    using Bridge.Formatters;

    internal class TermPaper : Manuscript
    {
        public TermPaper(IFormatter formatter)
            : base(formatter)
        {
        }

        public string Class { get; set; }

        public string Student { get; set; }

        public string Text { get; set; }

        public string References { get; set; }

        public override void Print()
        {
            Console.WriteLine(this.Formatter.Format("Class", this.Class));
            Console.WriteLine(this.Formatter.Format("Student", this.Student));
            Console.WriteLine(this.Formatter.Format("Text", this.Text));
            Console.WriteLine(this.Formatter.Format("References", this.References));
            Console.WriteLine();
        }
    }
}
