using BasicData.Domain.Entries;
using BasicData.Infrastructure.Persistence;

namespace BasicData.Infrastructure.Seeds
{

    internal class SeedCustomerDataAsync
    {
        internal static void SeedCustomerData(ApplicationDbContext context)
        {
            if (context.Customers.Any())
                return;
            try
            {

                var customers = new List<Customer>();
                customers.AddRange(new  List<Customer>
                {
                    new Customer
                    {
                        Comment = "No Comment",
                        FirstCustomerName = "Ahmed",
                        LastCustomerName = "Mohamed Mahmoud",
                        Email = "Ahmed1995@gmail.com",
                        PhoneNumber = "01006097896",
                        Class = Domain.Enum.Classes.A
                    },
                    new Customer
                    {
                        Comment = "No Comment",
                        FirstCustomerName = "Omar",
                        LastCustomerName = "Ibrahim Mohamed",
                        Email = "Omar2001@gmail.com",
                        PhoneNumber = "01066897896",
                        Class = Domain.Enum.Classes.B
                    },
                    new Customer
                    {
                        Comment = "No Comment",
                        FirstCustomerName = "Aml",
                        LastCustomerName = "Ali Mahmoud",
                        Email = "Aml1998@gmail.com",
                        PhoneNumber = "01089096896",
                        Class = Domain.Enum.Classes.C
                    }
                });
                using (var transaction = new System.Transactions.TransactionScope())
                {
                    context.Customers.AddRange(customers);
                    context.SaveChanges();
                    transaction.Complete();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
