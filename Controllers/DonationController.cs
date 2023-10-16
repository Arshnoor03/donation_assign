using comp4976_assignment1.Data;
using comp4976_assignment1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace comp4976_assignment1.Controllers
{
    [Authorize(Roles = "Admin, Finance")]
    public class DonationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public DonationController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: Donation
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.Donations.Include(d => d.ContactList).Include(d => d.PaymentMethod).Include(d => d.TransactionType);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: Donation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Donations == null)
            {
                return NotFound();
            }

            var donations = await _context.Donations
                .Include(d => d.ContactList)
                .Include(d => d.PaymentMethod)
                .Include(d => d.TransactionType)
                .FirstOrDefaultAsync(m => m.TransId == id);
            if (donations == null)
            {
                return NotFound();
            }

            return View(donations);
        }

        // GET: Donation/Create
        public IActionResult Create()
        {
            ViewData["AccountNo"] = new SelectList(_context.ContactLists, "AccountNo", "FullName");
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "PaymentMethodId", "Name");
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name");
            return View();
        }

        // POST: Donation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransId,Date,AccountNo,TransactionTypeId,Amount,PaymentMethodId,Notes")] Donations donations)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                    return View(donations);
                }

                donations.CreatedBy = user.UserName; // Set the CreatedBy field
                donations.ModifiedBy = user.UserName; // Set the ModifiedBy field
                donations.Created = DateTime.Now; // Set the Created field
                donations.Modified = DateTime.Now; // Set the Modified field

                try
                {
                    _context.Add(donations);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            ViewData["AccountNo"] = new SelectList(_context.ContactLists, "AccountNo", "FullName", donations.AccountNo);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "PaymentMethodId", "Name", donations.PaymentMethodId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name", donations.TransactionTypeId);
            return View(donations);
        }

        // GET: Donation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Donations == null)
            {
                return NotFound();
            }

            var donations = await _context.Donations.FindAsync(id);
            if (donations == null)
            {
                return NotFound();
            }
            ViewData["AccountNo"] = new SelectList(_context.ContactLists, "AccountNo", "FullName", donations.AccountNo);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "PaymentMethodId", "Name", donations.PaymentMethodId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name", donations.TransactionTypeId);
            return View(donations);
        }

        // POST: Donation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransId,Date,AccountNo,TransactionTypeId,Amount,PaymentMethodId,Notes")] Donations donations)
        {
            if (id != donations.TransId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Load the existing entity from the database
                    var existingDonation = await _context.Donations.FindAsync(id);

                    // Check if the contact exists
                    if (existingDonation == null)
                    {
                        return NotFound();
                    }

                    existingDonation.Date = donations.Date;
                    existingDonation.AccountNo = donations.AccountNo;
                    existingDonation.TransactionTypeId = donations.TransactionTypeId;
                    existingDonation.Amount = donations.Amount;
                    existingDonation.PaymentMethodId = donations.PaymentMethodId;
                    existingDonation.Notes = donations.Notes;

                    // Get the current user
                    var user = await _userManager.GetUserAsync(User);

                    // Check if user is null
                    if (user == null)
                    {
                        ModelState.AddModelError(string.Empty, "User not found.");
                        return View(donations);
                    }

                    // Update the ModifiedBy field
                    existingDonation.ModifiedBy = user.UserName;
                    existingDonation.Modified = DateTime.Now;

                    // Update the entity in the context and save
                    _context.Update(existingDonation);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonationsExists(donations.TransId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["AccountNo"] = new SelectList(_context.ContactLists, "AccountNo", "AccountNo", donations.AccountNo);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "PaymentMethodId", "Name", donations.PaymentMethodId);
            ViewData["TransactionTypeId"] = new SelectList(_context.TransactionTypes, "TransactionTypeId", "Name", donations.TransactionTypeId);
            return View(donations);
        }

        // GET: Donation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Donations == null)
            {
                return NotFound();
            }

            var donations = await _context.Donations
                .Include(d => d.ContactList)
                .Include(d => d.PaymentMethod)
                .Include(d => d.TransactionType)
                .FirstOrDefaultAsync(m => m.TransId == id);
            if (donations == null)
            {
                return NotFound();
            }

            return View(donations);
        }

        // POST: Donation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Donations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Donations'  is null.");
            }
            var donations = await _context.Donations.FindAsync(id);
            if (donations != null)
            {
                _context.Donations.Remove(donations);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> YTD()
        {
            var currentYear = DateTime.Now.Year;
            var startDate = new DateTime(currentYear, 1, 1);
            var endDate = DateTime.Now;

            var donations = await _context.Donations
                .Include(d => d.ContactList)
                .Include(d => d.TransactionType)
                .Where(d => d.Date >= startDate && d.Date <= endDate)
                .Select(d => new
                {
                    d.Date,
                    d.ContactList!.FullName,
                    d.TransactionType!.Name,
                    d.Amount
                })
                .ToListAsync();

            if (donations == null || !donations.Any())
            {
                return NotFound();
            }

            return View(donations);
        }

        // GET: Donation/YearlyTotals
        public async Task<IActionResult> YearlyTotals()
        {
            var yearlyTotals = await _context.Donations
                .GroupBy(d => d.Date.Year)
                .Select(g => new
                {
                    Year = g.Key,
                    TotalAmount = g.Sum(d => d.Amount)
                })
                .OrderByDescending(y => y.Year)
                .ToListAsync();

            if (yearlyTotals == null || !yearlyTotals.Any())
            {
                return NotFound();
            }

            return View(yearlyTotals);
        }

        private bool DonationsExists(int id)
        {
            return (_context.Donations?.Any(e => e.TransId == id)).GetValueOrDefault();
        }
    }
}
