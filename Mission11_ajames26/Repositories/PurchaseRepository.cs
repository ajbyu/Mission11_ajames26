﻿using Microsoft.EntityFrameworkCore;
using Mission11_ajames26.Models;
using System.Linq;

namespace Mission11_ajames26.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public PurchaseRepository(BookstoreContext context)
        {
            _context = context;
        }

        BookstoreContext _context { get; }

        //Attach specific items and books so they can be saved
        public IQueryable<Purchase> Purchases => _context
            .Purchases
            .Include(p => p.Items)
            .ThenInclude(i => i.Book);

        //Save to database
        public void SavePurchase(Purchase purchase)
        {
            _context.AttachRange(purchase.Items.Select(i => i.Book));

            if (purchase.PurchaseId == 0)
            {
                _context.Add(purchase);
            }

            _context.SaveChanges();
        }
    }
}
