using Fido.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fido.Web.Data
{
public class ApplicationDataContext: IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
        : base(options)
    { }

    public DbSet<Attachment> Attachments { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<Pet> Pets { get; set; }

    public DbSet<Walk> Walks { get; set; }
}
}
