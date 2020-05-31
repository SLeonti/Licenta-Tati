using System.Collections.Generic;
using TechData.Models;

namespace TechData.Interfaces
{
    public interface ICheckoutHistory
    {
        IEnumerable<CheckoutHistory> GetAll();
        IEnumerable<CheckoutHistory> GetForAsset(LibraryAsset asset);
        IEnumerable<CheckoutHistory> GetForCard(LibraryCard card);
        CheckoutHistory Get(int id);
        void Add(CheckoutHistory newCheckoutHistory);
    }
}
