using bpkp_be.Database;
using bpkp_be.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bpkp_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BpkpController : ControllerBase
    {
        private readonly DataContext _context;

        public BpkpController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllBpkp")]
        public async Task<ActionResult<List<TrBpkb>>> GetAllBpkp()
        {
            var allBpkp = await _context.tr_bpkp.ToListAsync();

            return Ok(allBpkp);
        }

        [HttpGet("GetAllLocation")]
        public async Task<ActionResult<List<MsStorageLocation>>> GetAllLocation()
        {
            var allLocation = await _context.ms_storage_location.ToListAsync();

            return Ok(allLocation);
        }

        [HttpGet("GetAllUser")]
        public async Task<ActionResult<List<MsUser>>> GetAllUser()
        {
            var allUser = await _context.ms_user.ToListAsync();

            return Ok(allUser);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<TrBpkb>>> GetBpkpById(string id)
        {
            var bpkp = await _context.tr_bpkp.FindAsync(id);
            if (bpkp is null)
            {
                return BadRequest("Bpkp Not Found!");
            }

            return Ok(bpkp);
        }

        [HttpPost("AddBpkp")]
        public async Task<ActionResult<List<TrBpkb>>> AddBpkp(TrBpkb bpkp)
        {
            _context.tr_bpkp.Add(bpkp);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //[HttpPut]
        //public async Task<ActionResult<List<TrBpkb>>> UpdateBpkp(TrBpkb bpkp)
        //{
        //    var bpkpData = await _context.tr_bpkp.FindAsync(bpkp.AgreementNumber);
        //    if (bpkpData is null)
        //    {
        //        return BadRequest("Bpkp Not Found!");
        //    }

        //    bpkpData.AgreementNumber = bpkp.AgreementNumber;

        //    await _context.SaveChangesAsync();

        //    return Ok();
        //}
    }
}
