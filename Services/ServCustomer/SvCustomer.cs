using Microsoft.EntityFrameworkCore;
using Entidades;
using Services.MyDbContext;

namespace Services.Customer
{
    public class SvCustomer : ISvCustumer
    {
        private MyContext _myDbContext = default!;
        public SvCustomer()
        {
            _myDbContext = new MyContext();
        }

        #region Writes
        public Entidades.Customer Addcustomer(Entidades.Customer customer)
        {
            _myDbContext.Customers.Add(customer);
            _myDbContext.SaveChanges();
            return customer;
        }

        public void DeleteCustomer(int id)
        {
            Entidades.Customer deleteCustomer = _myDbContext.Customers.Find(id);
            if (deleteCustomer != null)
            {
                //_myDbContext.Customers.Remove(deleteCustomer);
                deleteCustomer.ChangeIsActive();
                _myDbContext.Customers.Update(deleteCustomer);
                _myDbContext.SaveChanges();
            }

        }
        public Entidades.Customer UpdateCustomer(int id, Entidades.Customer customer)
        {
            Entidades.Customer customerUpdate = _myDbContext.Customers.Find(id);
            if (customerUpdate == null)
            {
                return null;
            }
            else
            {
                customerUpdate.Name = customer.Name;
                customerUpdate.Email = customer.Email;

                _myDbContext.Update(customerUpdate);
                _myDbContext.SaveChanges();

                return customerUpdate;
            }
        }
        #endregion

        #region Reads
        public List<Entidades.Customer> GetAllcustomer()
        {
            return _myDbContext.Customers.Where(Customer => Customer.IsActive).Include(x => x.Invoices).ToList();
        }

        public Entidades.Customer GetCostumerById(int id)
        {
            return _myDbContext.Customers.Where(Customer => Customer.IsActive).Include(x => x.Invoices).SingleOrDefault(x => x.Id == id);

        }
        public Entidades.Customer SearchByEmail(string _mail)
        {
            return _myDbContext.Customers.Where(Customer => Customer.IsActive).Include(x => x.Invoices).SingleOrDefault(x => x.Email == _mail);
        }
        #endregion
    }
}