using Microsoft.AspNetCore.Mvc;
using DecompNumber.Domain.Core.Interfaces.Services;
using DecompNumber.Domain.Models;
using System.Collections.Generic;

namespace DecompNumberAPI.Controllers
{
    [Route("DecompNumberAPI/[controller]")]
    [ApiController]
    public class DecompositionController : ControllerBase
    {
        private readonly IServiceDecomposition _serviceDecomp;

        public DecompositionController(IServiceDecomposition serviceDecomp)
        {
            _serviceDecomp = serviceDecomp;
        }

        [HttpGet("{entryNumber}", Name = "Get")]
        public ActionResult<IList<long>> GetDecomposition(int entryNumber)
        {
            Decomposition decomp = new Decomposition { EntryNumber = entryNumber };

            var result = _serviceDecomp.GetDecomposition(decomp);

            if (result.DividingNumbers.Count > 0)
                return Ok(result);

            return Problem(result.Error);
        }
    }
}