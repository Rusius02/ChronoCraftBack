using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SqlServer.Repository.Chrono
{
    public interface IChronoRepository
    {
        Domain.Chrono Create(Domain.Chrono chrono);

        List<Domain.Chrono> GetAll();

        Domain.Chrono GetUser(Domain.Chrono chronos);

        bool Delete(Domain.Chrono chronos);

        bool Update(Domain.Chrono chronos);
    }
}
