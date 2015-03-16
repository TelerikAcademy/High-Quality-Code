namespace Bridge.Manuscripts
{
    using System;

    using Bridge.Formatters;

    internal class Book : Manuscript
    {
        public Book(IFormatter formatter)
            : base(formatter)
        {
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Text { get; set; }

        public override void Print()
        {
            Console.WriteLine(this.Formatter.Format("Title", this.Title));
            Console.WriteLine(this.Formatter.Format("Author", this.Author));
            Console.WriteLine(this.Formatter.Format("Text", this.Text));
            Console.WriteLine();
        }
    }
}
