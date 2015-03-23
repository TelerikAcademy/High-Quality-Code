namespace LazyInitialization.VirtualProxy
{
    using System.Collections.Generic;

    public class UserProxy : User
    {
        public override List<string> Roles
        {
            get
            {
                if (base.Roles == null)
                {
                    // Get the values from the database
                    // Here is the lazy loading
                    base.Roles = new List<string> { "Admin" };
                }

                return base.Roles;
            }

            set
            {
                base.Roles = value;
            }
        }

        public override bool Equals(object obj)
        {
            var other = obj as User;
            if (other == null)
            {
                return false;
            }

            return other.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
