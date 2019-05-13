using System;

namespace Kaid.WebAPI.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        KaidDbContext Init();
    }
}