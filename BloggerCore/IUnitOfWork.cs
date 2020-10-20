using BloggerDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BloggerCore
{
    public interface IUnitOfWork
    {
        DbSet<User> Users { get; set; }
        DbSet<Person> Persons { get; set; }
        DbSet<Friend> Friends { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Like> Likes { get; set; }
        DbSet<Comment> Comments { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
