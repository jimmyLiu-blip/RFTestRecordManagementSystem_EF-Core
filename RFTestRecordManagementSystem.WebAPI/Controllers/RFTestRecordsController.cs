using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RFTestRecordManagementSystem.Service;
using RFTestRecordManagementSystem.Domain;

namespace RFTestRecordManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RFTestRecordsController : ControllerBase
    {
        private readonly IRFTestRecordService _service;

        public RFTestRecordsController(IRFTestRecordService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<RFTestRecord>> GetAll()
        {
            var records = _service.GetAllRecords();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<RFTestRecord>> GetById(int id)
        {
            var record = _service.GetRecordById(id);
            if (record == null)
                return NotFound($"找不到 RecordId = {id}");
            return Ok(record);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RFTestRecord record)
        { 
            if (record == null)
                return BadRequest("請提供有效的資料");

            var id = _service.AddRecord(
                record.Regulation,
                record.RadioTechnology,
                record.Band,
                record.PowerDbm,
                record.Result,
                record.TestDate
                );

            return CreatedAtAction(nameof(GetById), new { id }, record);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RFTestRecord record)
        {
            _service.UpdateRecord(
                id,
                record.Regulation,
                record.RadioTechnology,
                record.Band,
                record.PowerDbm,
                record.Result,
                record.TestDate
                );
            return NoContent();
        }

        [HttpPut("softdelete/{id}")]
        public IActionResult SoftDelete(int id)
        {
            try
            {
                _service.SoftDeleteRecord(id);
                return Ok(new { message = $"RecordId = {id} 已刪除" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = $"刪除失敗：{ex.Message}" });
            }

        }

        [HttpPut("archive/{id}")]
        public IActionResult Archive(int id)
        { 
            _service.ArchiveRecord(id);
            return Ok($"RecordId = {id} 已封存");
        }
    }
}
