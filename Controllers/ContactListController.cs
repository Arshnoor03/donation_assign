using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using comp4976_assignment1.Data;
using comp4976_assignment1.Models;
using Microsoft.AspNetCore.Authorization;

namespace comp4976_assignment1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactListController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ContactListController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: ContactList
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactLists.ToListAsync());
        }

        public async Task<IActionResult> Error()
        {
            return View(await _context.ContactLists.ToListAsync());
        }

        // GET: ContactList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.ContactLists
                .FirstOrDefaultAsync(m => m.AccountNo == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: ContactList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountNo,FirstName,LastName,Email,Street,City,PostalCode,Country")] ContactList contactList)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                contactList.CreatedBy = user!.UserName; // Set the CreatedBy field
                contactList.ModifiedBy = user!.UserName; // Set the ModifiedBy field
                contactList.Created = DateTime.Now; // Set the Created field
                contactList.Modified = DateTime.Now; // Set the Modified field

                try
                {
                    _context.Add(contactList);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return View(contactList);
        }

        // GET: ContactList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.ContactLists.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: ContactList/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountNo,FirstName,LastName,Email,Street,City,PostalCode,Country")] ContactList contact)
        {
            if (id != contact.AccountNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Load the existing entity from the database
                    var existingContact = await _context.ContactLists.FindAsync(id);

                    // Check if the contact exists
                    if (existingContact == null)
                    {
                        return NotFound();
                    }

                    // Update the properties of the existing entity
                    existingContact.FirstName = contact.FirstName;
                    existingContact.LastName = contact.LastName;
                    existingContact.Email = contact.Email;
                    existingContact.Street = contact.Street;
                    existingContact.City = contact.City;
                    existingContact.PostalCode = contact.PostalCode;
                    existingContact.Country = contact.Country;

                    // Get the current user
                    var user = await _userManager.GetUserAsync(User);

                    // Update the ModifiedBy field
                    existingContact.ModifiedBy = user!.UserName;
                    existingContact.Modified = DateTime.Now;

                    // Update the entity in the context and save
                    _context.Update(existingContact);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.AccountNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return View(contact);
        }

        // GET: ContactList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.ContactLists
                .FirstOrDefaultAsync(m => m.AccountNo == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: ContactList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await _context.ContactLists.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            _context.ContactLists.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> TaxReceipt(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentYear = DateTime.Now.Year;
            var startDate = new DateTime(currentYear, 1, 1);
            var endDate = new DateTime(currentYear, 12, 31);

            var donor = await _context.ContactLists.FirstOrDefaultAsync(c => c.AccountNo == id);
            if (donor == null)
            {
                return NotFound("The account does not exist.");
            }

            var donorDonations = await _context.Donations
                .Where(d => d.ContactList!.AccountNo == id && d.Date >= startDate && d.Date <= endDate)
                .ToListAsync();

            if (!donorDonations.Any())
            {
                return RedirectToAction(nameof(Error));
            }

            var donorName = donor.FirstName + " " + donor.LastName;

            ViewBag.DonorName = donorName;
            ViewBag.TotalDonations = donorDonations.Sum(d => d.Amount);
            ViewBag.EndOfYear = endDate.ToString("MMMM dd, yyyy");
            ViewBag.CurrentYear = currentYear;

            return View(donorDonations);
        }

        private bool ContactExists(int id)
        {
            return _context.ContactLists.Any(e => e.AccountNo == id);
        }
    }
}
