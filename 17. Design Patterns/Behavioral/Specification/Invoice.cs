namespace Specification
{
    using System;

    public class Invoice
    {
        public int Id { get; set; }

        public bool SentForCollection { get; set; }

        public bool NoticeSent { get; set; }

        public DateTime PayDeadline { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Invoice №{0}, deadline: {1:yyyy-MM-dd}, noticed? {2}, collecting? {3}",
                this.Id,
                this.PayDeadline,
                this.NoticeSent,
                this.SentForCollection);
        }
    }
}
