using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using comp4976_assignment1.Models;

namespace comp4976_assignment1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPasswordHasher<IdentityUser> passwordHasher)
            : base(options)
        {
            _passwordHasher = passwordHasher;
        }

        public DbSet<ContactList> ContactLists { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Donations> Donations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Use seed method here
            Seed(builder);

            builder.Entity<ContactList>().ToTable("ContactList");
            builder.Entity<TransactionType>().ToTable("TransactionType");
            builder.Entity<PaymentMethod>().ToTable("PaymentMethod");
            builder.Entity<Donations>().ToTable("Donations");

            builder.Entity<ContactList>().HasData(
            new ContactList
            {
                AccountNo = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@example.com",
                Street = "123 Main St",
                City = "New York",
                PostalCode = "V5T 2W8",
                Country = "USA",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = "Seed",
                ModifiedBy = "Seed"
            },

            new ContactList
            {
                AccountNo = 2,
                FirstName = "Sam",
                LastName = "Fox",
                Email = "sam@fox.com",
                Street = "457 Fox Avenue",
                City = "Richmond",
                PostalCode = "V4F 1M7",
                Country = "Canada",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = "Seed",
                ModifiedBy = "Seed"
            },
            new ContactList
            {
                AccountNo = 3,
                FirstName = "Ann",
                LastName = "Day",
                Email = "ann@day.com",
                Street = "231 River Road",
                City = "Delta",
                PostalCode = "V6G 1M6",
                Country = "Canada",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = "Seed",
                ModifiedBy = "Seed"
            }
        );

            builder.Entity<PaymentMethod>().HasData(
                new PaymentMethod
                {
                    PaymentMethodId = 1,
                    Name = "Credit Card",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    CreatedBy = "Seed",
                    ModifiedBy = "Seed"
                },
                new PaymentMethod
                {
                    PaymentMethodId = 2,
                    Name = "PayPal",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    CreatedBy = "Seed",
                    ModifiedBy = "Seed"
                },
                new PaymentMethod
                {
                    PaymentMethodId = 3,
                    Name = "Debit Card",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    CreatedBy = "Seed",
                    ModifiedBy = "Seed"
                }
            );

            builder.Entity<TransactionType>().HasData(
                new TransactionType
                {
                    TransactionTypeId = 1,
                    Name = "General Donation",
                    Description = "Donations made without any special purpose",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    CreatedBy = "Seed",
                    ModifiedBy = "Seed"
                },
                new TransactionType
                {
                    TransactionTypeId = 2,
                    Name = "Food for homeless",
                    Description = "Donations made for homeless people",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    CreatedBy = "Seed",
                    ModifiedBy = "Seed"
                },
                new TransactionType
                {
                    TransactionTypeId = 3,
                    Name = "Repair of Gym",
                    Description = "Donations for the purpose of upgrading the gym",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    CreatedBy = "Seed",
                    ModifiedBy = "Seed"
                }
            );

            builder.Entity<Donations>().HasData(
                new Donations
                {
                    TransId = 1,
                    Date = DateTime.Now,
                    AccountNo = 1,  // referencing the contact entry
                    TransactionTypeId = 1,  // referencing the transaction type entry
                    Amount = 100.0f,
                    PaymentMethodId = 1,  // referencing the payment method entry
                    Notes = "This is a first donation",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    CreatedBy = "Seed",
                    ModifiedBy = "Seed"
                },
                new Donations
                {
                    TransId = 2,
                    Date = DateTime.Now,
                    AccountNo = 2,  // referencing the contact entry
                    TransactionTypeId = 2,  // referencing the transaction type entry
                    Amount = 100.0f,
                    PaymentMethodId = 1,  // referencing the payment method entry
                    Notes = "This is a second donation",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    CreatedBy = "Seed",
                    ModifiedBy = "Seed"
                },
                new Donations
                {
                    TransId = 3,
                    Date = DateTime.Now,
                    AccountNo = 3,  // referencing the contact entry
                    TransactionTypeId = 3,  // referencing the transaction type entry
                    Amount = 100.0f,
                    PaymentMethodId = 1,  // referencing the payment method entry
                    Notes = "This is a third donation",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    CreatedBy = "Seed",
                    ModifiedBy = "Seed"
                }
            );
        }

        public void Seed(ModelBuilder builder)
        {
            var pwd = "P@$$w0rd";

            // Seed Roles
            var adminRole = new IdentityRole("Admin");
            adminRole.NormalizedName = adminRole.Name.ToUpper();

            var financeRole = new IdentityRole("Finance");
            financeRole.NormalizedName = financeRole.Name.ToUpper();

            var memberRole = new IdentityRole("Member");
            memberRole.NormalizedName = memberRole.Name.ToUpper();

            List<IdentityRole> roles = new List<IdentityRole>() {
               adminRole,
               financeRole,
               memberRole
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Seed Users
            var adminUser = new IdentityUser
            {
                UserName = "aa@aa.aa",
                Email = "aa@aa.aa",
                EmailConfirmed = true,
            };

            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail = adminUser.Email.ToUpper();
            adminUser.PasswordHash = _passwordHasher.HashPassword(adminUser, pwd);


            var memberUser = new IdentityUser
            {
                UserName = "mm@mm.mm",
                Email = "mm@mm.mm",
                EmailConfirmed = true,
            };

            memberUser.NormalizedUserName = memberUser.UserName.ToUpper();
            memberUser.NormalizedEmail = memberUser.Email.ToUpper();
            memberUser.PasswordHash = _passwordHasher.HashPassword(memberUser, pwd);


            var financeUser = new IdentityUser
            {
                UserName = "ff@ff.ff",
                Email = "ff@ff.ff",
                EmailConfirmed = true,
            };

            financeUser.NormalizedUserName = financeUser.UserName.ToUpper();
            financeUser.NormalizedEmail = financeUser.Email.ToUpper();
            financeUser.PasswordHash = _passwordHasher.HashPassword(financeUser, pwd);

            List<IdentityUser> users = new List<IdentityUser>() {
               adminUser,
               memberUser,
               financeUser
            };

            builder.Entity<IdentityUser>().HasData(users);

            // Seed UserRoles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });


            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == "Member").Id
            });


            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[2].Id,
                RoleId = roles.First(q => q.Name == "Finance").Id
            });

            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}