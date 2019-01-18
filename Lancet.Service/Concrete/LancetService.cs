using AutoMapper;
using Lancet.Repository.Abstract;
using Lancet.Service.Abstract;
using Lancet.Service.Helpers;
using Microsoft.Extensions.Configuration;
using System;

namespace Lancet.Service.Concrete
{
    public partial class LancetService : ILancetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private readonly IConfiguration _configuration;
        //private User currentUser;

        public LancetService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        #region IDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _unitOfWork.Dispose();
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
