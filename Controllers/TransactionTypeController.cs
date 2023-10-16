using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using comp4976_assignment1.Data;
using comp4976_assignment1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace comp4976_assignment1.Controllers
{
    [Authorize (Roles = "Admin")]
    public class TransactionTypeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TransactionTypeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TransactionType
        public async Task<IActionResult> Index()
        {
            return View(await _context.TransactionTypes.ToListAsync());
        }

        // GET: TransactionType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.TransactionTypes
                .FirstOrDefaultAsync(m => m.TransactionTypeId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: TransactionType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransactionType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionTypeId,Name,Description")] TransactionType transaction)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                transaction.CreatedBy = user!.UserName; // Set the CreatedBy field
                transaction.ModifiedBy = user!.UserName; // Set the ModifieddBy field
                transaction.Created = DateTime.Now;
                transaction.Modified = DateTime.Now;

                try
                {
                    _context.Add(transaction);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View(transaction);
        }

        // GET: TransactionType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.TransactionTypes.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        // POST: TransactionType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionTypeId,Name,Description")] TransactionType transaction)
        {
            if (id != transaction.TransactionTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                     // Load the existing entity from the database
                    var existingTransaction = await _context.TransactionTypes.FindAsync(id);
                    if (existingTransaction == null)
                    {
                        return NotFound();
                    }

                    existingTransaction.Name = transaction.Name;
                    existingTransaction.Description = transaction.Description;

                    var user = await _userManager.GetUserAsync(User);
                    existingTransaction.ModifiedBy = user!.UserName; // Set the ModifiedBy field
                    existingTransaction.Modified = DateTime.Now; // Set the Modified field
                 
                    _context.Update(existingTransaction);
                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!transactionExists(transaction.TransactionTypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
            return View(transaction);
        }

        // GET: TransactionType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.TransactionTypes
                .FirstOrDefaultAsync(m => m.TransactionTypeId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: TransactionType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.TransactionTypes.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            _context.TransactionTypes.Remove(transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool transactionExists(int id)
        {
            return _context.TransactionTypes.Any(e => e.TransactionTypeId == id);
        }
    }
}
