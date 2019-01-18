using Lancet.Models.Domain.Model;
using Lancet.Repository.Abstract;
using Lancet.Repository.Concrete;
using System;

namespace Lancet.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LancetContext _LancetContext;

        public UserRepository UserRepository => userRepository ?? new UserRepository(_LancetContext);
        private UserRepository userRepository;

        public UnitOfWork(LancetContext LancetContext)
        {
            _LancetContext = LancetContext;
        }

        public void Save()
        {
            _LancetContext.SaveChanges();
        }

        #region Disposed
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _LancetContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}