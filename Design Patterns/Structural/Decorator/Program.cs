namespace Decorator
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            // Create book
            var book = new Book("Microsoft", "CLR via C# 4", 10);
            book.Display();
            Console.WriteLine(new string('-', 60));

            // Create video
            var video = new Video("Stanley Kubrick", "A Clockwork Orange", 23, 92);
            video.Display();
            Console.WriteLine(new string('-', 60));

            // Make book borroable, then borrow and display
            Console.WriteLine("Making book borrowable:");
            var borrowableBook = new Borrowable(book);
            borrowableBook.BorrowItem("Nikolay Kostov");
            borrowableBook.BorrowItem("Ivaylo Kenov");
            borrowableBook.Display();
            Console.WriteLine(new string('-', 60));

            // Make video borrowable, then borrow and display
            Console.WriteLine("Making video borrowable:");
            var borrowableVideo = new Borrowable(video);
            borrowableVideo.BorrowItem("Nikolay Kostov");
            borrowableVideo.BorrowItem("Ivaylo Kenov");
            borrowableVideo.Display();
            Console.WriteLine(new string('-', 60));

            // Make only video buyable
            Console.WriteLine("Making video buyable:");
            var buyableAndBorrowableVideo = new Buyable(borrowableVideo, 15);
            buyableAndBorrowableVideo.Display();
            Console.WriteLine(new string('-', 60));
        }
    }
}
