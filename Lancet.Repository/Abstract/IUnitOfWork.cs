using Lancet.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lancet.Repository.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        UserRepository UserRepository { get; }
        void Save();
    }
}
