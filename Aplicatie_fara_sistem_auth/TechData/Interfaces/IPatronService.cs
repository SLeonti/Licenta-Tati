using System.Collections.Generic;
using TechData.Models;

namespace TechData.Interfaces
{
    public interface IPatronService
    {
        IEnumerable<Patron> GetAll();
        Patron Get(int id);
        void Add(Patron newBook, int branchId);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int patronId);
        IEnumerable<Hold> GetHolds(int patronId);
        IEnumerable<Checkout> GetCheckouts(int id);
    }
}
