using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLgs.EdoCta.API.Model;

namespace QLgs.EdoCta.API.Data
{
    public interface IEdoCtaRepository
    {
        Task<List<EstadoCta>> GetExpsCliente(string codCli);

    }
}