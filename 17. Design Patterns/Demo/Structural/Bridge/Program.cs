namespace Bridge
{
    using System;
    using System.Collections.Generic;

    using Bridge.Formatters;
    using Bridge.Manuscripts;

    public static class Program
    {
        public static void Main()
        {
            var documents = new List<Manuscript>();
            var formatter = new FancyFormatter(); // new BackwardsFormatter();

            var faq = new Faq(formatter) { Title = "The Bridge Pattern FAQ" };
            faq.Questions.Add("What is it?", "A design pattern");
            faq.Questions.Add("When do we use it?", "When you need to separate an abstraction from an implementation.");
            documents.Add(faq);

            var book = new Book(formatter)
            {
                Title = "Lots of Patterns",
                Author = "John Sonmez",
                Text = "Blah blah blah..."
            };
            documents.Add(book);

            var paper = new TermPaper(formatter)
            {
                Class = "Design Patterns",
                Student = "Joe N00b",
                Text = "Blah blah blah...",
                References = "GOF"
            };
            documents.Add(paper);

            foreach (var doc in documents)
            {
                doc.Print();
            }

            // Wait for user
            Console.ReadKey();
        }
    }
}
