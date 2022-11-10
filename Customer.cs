namespace Labo2_Banque
{
    public class Customer
    {
        public string FirstName;
        public string LastName;

        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        
        // This method returns the concatenation of two elements.
        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }

        // Define how equality between object is asserted.
        public override bool Equals(object? obj)
        {
            // Check for null and compare run-time types.
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var c = (Customer)obj;
            return FirstName == c.FirstName && LastName == c.LastName;
        }

        // This is a conventional overwrite to allow proper function of the object in the hash table.
        public override int GetHashCode()
        {
            // The lack of safety of the implementation of this method cannot be addressed without changing the visibility to attributes to private.
            return HashCode.Combine(FirstName, LastName);
        }
    }
}