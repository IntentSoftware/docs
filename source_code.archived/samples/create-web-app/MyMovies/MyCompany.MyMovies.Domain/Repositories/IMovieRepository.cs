using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityInterface", Version = "1.0")]

namespace MyCompany.MyMovies.Domain
{
    public interface IMovieRepository : IRepository<IMovie, Movie>
    {
        Task<IMovie> FindByIdAsync(Guid id);
    }
}