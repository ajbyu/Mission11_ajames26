using Mission11_ajames26.Models;
using System.Linq;

namespace Mission11_ajames26.Repositories
{
    public interface IPurchaseRepository
    {
        IQueryable<Purchase> Purchases { get; }

        void SavePurchase (Purchase purchase);
    }
}
