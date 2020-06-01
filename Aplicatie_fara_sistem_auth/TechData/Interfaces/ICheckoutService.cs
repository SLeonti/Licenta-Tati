using System.Collections.Generic;
using TechData.Models;

namespace TechData.Interfaces
{
    public interface ICheckoutService
    {
        IEnumerable<Checkout> GetAll();
        Checkout Get(int id);
        void Add(Checkout newCheckout);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);
        void PlaceHold(int assetId, string userMail);
        void CheckoutItem(int id, string userMail);
        void CheckInItem(int id);
        Checkout GetLatestCheckout(int id);
        int GetNumberOfCopies(int id);
        bool IsCheckedOut(int id);
        bool IsCheckedOutByMe(int id, string myMail);

        string GetCurrentHoldPatron(int id);
        string GetCurrentHoldPlaced(int id);
        string GetCurrentPatron(int id);

        IEnumerable<Hold> GetCurrentHolds(int id);

        void MarkLost(int id);
        void MarkFound(int id);
    }
}
