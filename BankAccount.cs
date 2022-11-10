namespace Labo2_Banque
{
    public class BankAccount
    {
        public Customer Owner;
        public float Balance;
        
        public BankAccount(Customer owner, float balance)
        {
            Owner = owner;
            Balance = balance;
        }
        
        /// <summary>
        /// This method allows us to credit an amount to a bank account.
        /// </summary>
        /// <param name="amount"></param>
        public void Credit(float amount)
        {
            Balance += amount;
            Console.WriteLine($"Account of {Owner.FullName()} : +{amount}");
        }

        
        /// <summary>
        /// This method allows us to debit an amount of a bank account.
        /// It also does not allow us to to the transaction if the amount exceed the total of the balance.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>bool</returns>
        public bool Debit(float amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($"Account of {Owner.FullName()} : -{amount}");
                return true;
            }

            Console.WriteLine($"Account of {Owner.FullName()} : Insufficient balance (-{amount})");
            return false;
        }
        
        /// <summary>
        /// This method allows us to transfer some money from one bank account to an other.
        /// It also does not allow us to to the transaction if the balance of the first bank account would be less than 0.
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="bankAccount"></param>
        /// <returns>bool</returns>
        public bool Transfer(float amount, BankAccount bankAccount)
        {
            if (Debit(amount))
            {
                bankAccount.Credit(amount);
                Console.WriteLine($"Transfer from the account of {Owner.FullName()} to the account of {bankAccount.Owner.FullName()} was successful : {amount}");
                return true;
            }

            Console.WriteLine($"Transfer from the account of {Owner.FullName()} to the account of {bankAccount.Owner.FullName()} was denied : Insufficient balance ({amount})");
            return false;
        }
    }
}