using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Models;

namespace Project1.Services
{
    public interface ICustomerService
    {
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<Customer?> GetCustomerByEmailAsync(string email);
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly BankingContext _context;

        public CustomerService(BankingContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            return await _context.Customers
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer?> GetCustomerByEmailAsync(string email)
        {
            return await _context.Customers
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers
                .Include(c => c.Accounts)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            customer.CreatedDate = DateTime.UtcNow;
            customer.Status = CustomerStatus.Active;

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            var existing = await _context.Customers.FindAsync(customer.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(customer);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return false;

            customer.Status = CustomerStatus.Closed;
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
