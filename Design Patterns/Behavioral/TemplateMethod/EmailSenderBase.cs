namespace TemplateMethod
{
    /// <summary>
    /// The 'AbstractClass'
    /// </summary>
    public abstract class EmailSenderBase
    {
        protected EmailSenderBase(string senderEmail, string receiverEmail, string message)
        {
            this.SenderEmail = senderEmail;
            this.ReceiverEmail = receiverEmail;
            this.Message = message;
        }

        protected string SenderEmail { get; private set; }

        protected string ReceiverEmail { get; private set; }

        protected string Message { get; private set; }

        public bool SendEmail()
        {
            if (!this.CheckEmailAddress())
            {
                return false;
            }

            if (!this.ValidateMessage())
            {
                return false;
            }

            if (!this.SendMail())
            {
                return false;
            }
            
            return true;
        }

        protected abstract bool CheckEmailAddress();

        protected abstract bool ValidateMessage();

        protected abstract bool SendMail();
    }
}
