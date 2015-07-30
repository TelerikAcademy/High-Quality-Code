namespace TemplateMethod
{
    using System;
    using System.Threading;

    public class GoogleEmailSender : EmailSenderBase
    {
        public GoogleEmailSender(string senderEmail, string receiverEmail, string message)
            : base(senderEmail, receiverEmail, message)
        {
        }

        protected override bool CheckEmailAddress()
        {
            return this.SenderEmail.EndsWith("gmail.com");
        }

        protected override bool ValidateMessage()
        {
            return !this.Message.Contains("Spam");
        }

        protected override bool SendMail()
        {
            Console.WriteLine("Connecting to gmail.com on port 465 (secure SMTP connection)...");
            Thread.Sleep(2000);
            Console.WriteLine("Sending email...");
            Thread.Sleep(2000);
            Console.WriteLine("Done.");
            return true;
        }
    }
}
