using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.DTO;
using TMS.Repositories.Interfaces;
using TMS.Services;
using TMS.Services.Interfaces;

namespace TMS.Controllers
{
    public class TenderController : Controller
    {
        private readonly ITenderService tenderService;

        public TenderController(ITenderRepository tendersRepository)
        {
            this.tenderService = new TenderService(tendersRepository);
        }


        [Route("api/[controller]/getalltenderlistasync")]
        [HttpPost]
        public async Task<IActionResult> GetAllTenderListAsync()
        {
            GetAllTenderListAsyncResponse response = await tenderService.GetAllTenderListAsync();
            if (response.IsSuccess)
            {
                //return Ok((IList<Tender>)response.Data);
                //return Ok(JsonConvert.SerializeObject(response.Data));
                return Ok(response);
            }
            return BadRequest(response.Messages[0]);
        }

        [Route("api/[controller]/gettenderbyidasync")]
        [ActionName("GetTenderByIdAsync")]
        [HttpPost]
        public async Task<IActionResult> GetTenderByIdAsync([FromBody] int id)
        {
            GetTenderByIdAsyncResponse response = await tenderService.GetTenderByIdAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Messages[0]);
        }

        [Route("api/[controller]/createtenderasync")]
        [HttpPost]
        public async Task<IActionResult> CreateTenderAsync([FromBody] CreateTenderAsyncRequest request)
        {
            CreateTenderAsyncResponse response = await tenderService.CreateTenderAsync(request);

            if (response.IsSuccess)
            {
                Tender tender = JsonConvert.DeserializeObject<Tender>(request.Data.ToString());
                return Ok(response);
                //return CreatedAtAction(nameof(GetTenderByIdAsync), new { id = tender.Id }, tender);
            }
            return BadRequest(response.Messages[0]);
        }

        [Route("api/[controller]/updatetenderasync")]
        [HttpPost]
        public async Task<IActionResult> UpdateTenderAsync([FromBody] UpdateTenderAsyncRequest request)
        {
            UpdateTenderAsyncResponse response = await tenderService.UpdateTenderAsync(request);

            if (response.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(response.Messages[0]);
        }

        [Route("api/[controller]/deletetenderasync")]
        [HttpPost]
        public async Task<IActionResult> DeleteTenderAsync([FromBody] DeleteTenderAsyncRequest request)
        {
            DeleteTenderAsyncResponse response = await tenderService.DeleteTenderAsync(request);

            if (response.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(response.Messages[0]);
        }

    }
}
