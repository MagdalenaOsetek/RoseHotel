using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoseHotel.Application.Abstractions
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
