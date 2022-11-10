namespace Labo2_Banque
{
    public class Bank
    {
        public List<BankAccount> BankAccounts;
        public List<Customer> Customers;

        public Bank()
        {
            // Creation of the list containing all of the customers.
            Customers = new List<Customer>();
            // Creation of the list containing all of the bank accounts.
            BankAccounts = new List<BankAccount>();
        }
        
        /// <summary>
        /// This method checks if the customer is on the registry list of the bank and add it to said list if it's not already on said list.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>Customer</returns>
        public Customer RegisterCustomer(string firstName, string lastName)
        {
            var customer = new Customer(firstName, lastName);
            if (!Customers.Contains(customer))
            {
                Customers.Add(customer);
            }

            return customer;
        }
        
        /// <summary>
        /// This method creates an account and add it to the list of all the accounts for the bank.
        /// It also uses the RegisterCutomer method to add the customer on the registry list of the bank.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>BankAccount</returns>
        public BankAccount CreateAccount(string firstName, string lastName)
        {
            var bankAccount = new BankAccount(RegisterCustomer(firstName, lastName), 0);
            BankAccounts.Add(bankAccount);
            return bankAccount;
        }
        
        /// <summary>
        /// This method allows to check the summary of a customer.
        /// It displays the full name of the customer and all of their accounts. 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>BankAccount[]</returns>
        public BankAccount[] GetCustomerSummary(Customer customer)
        {
            var bankAccountsOfCustomer = new List<BankAccount>();
            var index = 0;
            float totalFortune = 0;

            Console.WriteLine("-----------------------");
            Console.WriteLine($"{customer.FullName()} : ");
            foreach (var bankAccount in BankAccounts)
            {
                if (bankAccount.Owner.Equals(customer))
                {
                    ++index;
                    bankAccountsOfCustomer.Add(bankAccount);
                    Console.WriteLine($"- Account #{index} : {bankAccountsOfCustomer[index - 1].Balance}");
                    totalFortune += bankAccountsOfCustomer[index - 1].Balance;
                }
            }
            Console.WriteLine($"Total fortune : {totalFortune}");
            Console.WriteLine("-----------------------");
            return bankAccountsOfCustomer.ToArray();
        }
    }
}