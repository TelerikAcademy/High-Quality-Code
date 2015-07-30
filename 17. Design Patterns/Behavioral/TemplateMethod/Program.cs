namespace TemplateMethod
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            EmailSenderBase emailSender =
                new YahooEmailSender("admin@yahoo.com", "admin@telerik.com", "Sup, guys?");
            //// new GoogleEmailSender(...)
            var sendEmailResult = emailSender.SendEmail();
            Console.WriteLine("Result: {0}", sendEmailResult ? "Success" : "Fail");
        }
    }
}
