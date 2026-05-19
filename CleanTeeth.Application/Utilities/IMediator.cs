using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Application.Utilities
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}
