using DecompNumber.Domain.Models;
using DecompNumber.App.DTO.DTO;

namespace DecompNumber.Domain.Core.Interfaces.Services
{
    public interface IServiceDecomposition
    {
        DecompositionDTO GetDecomposition(Decomposition decomposition);
    }
}