using Labo2_Banque;

// Creating a new bank.
var bank = new Bank();

// Creating all of the accounts needed and registering the customers.
var jdAccount1 = bank.CreateAccount("John", "Doe");
var jdAccount2 = bank.CreateAccount("John", "Doe");
var spAccount = bank.CreateAccount("Suzette", "Proust");
bank.RegisterCustomer("Gilles", "Surchat");

// Doing all of the transactions necessary.
jdAccount1.Credit(200);
jdAccount2.Credit(100);
jdAccount1.Debit(50);
spAccount.Credit(100);
spAccount.Debit(200);
jdAccount1.Transfer(50, spAccount);
spAccount.Transfer(200, jdAccount1);

// Getting the summary of all of the customers.
foreach (var customer in bank.Customers)
{
    bank.GetCustomerSummary(customer);
}