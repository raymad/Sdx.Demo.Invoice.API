using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sdx.Demo.Invoice.Application.Interfaces
{
    public interface IIntegrationEventService
    {
        Task SaveContextChangesAsync();
    }
}
