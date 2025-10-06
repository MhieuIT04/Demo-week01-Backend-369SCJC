using MyAPI_DotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MyAPI_DotNet.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Menu> Menus { get; set; }
        DbSet<News> News { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}