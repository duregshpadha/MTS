using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTS.BAL.Models;
using MTS.BAL.Repository;
using MTS.API.Base;
using MTS.Constants.WebsiteMessagesConstants;
using MTS.API.Models;
using MTS.Utilities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace MTS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public HomeController(IBaseRepo baseRepo, IMTSRepo repo, IGenerateID generateID)
        {
            _baseRepo = baseRepo;
            _repo = repo;
            _generateID = generateID;
        }
        private readonly IBaseRepo _baseRepo;
        private readonly IMTSRepo _repo;
        private readonly IGenerateID _generateID;

        /// <summary>
        /// Get data table of medicines
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        /// <response code="200">Returns success: true</response>
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(DataTablesResponse))]
        [HttpPost("Medicines")]
        public async Task<IActionResult> Medicines([ModelBinder(BinderType = typeof(ModelBinder))] IDataTablesRequest requestModel)
        {
            var medicines = await _repo.Medicines(requestModel: requestModel);
            var record = new
            {
                draw = medicines.Draw,
                recordsTotal = medicines.TotalRecords,
                recordsFiltered = medicines.TotalRecordsFiltered,
                data = medicines.Data,
                error = medicines.Error,
                additionalParameters = medicines.AdditionalParameters
            };
            return Ok(record);
        }

        /// <summary>
        /// Get medecine
        /// </summary>
        /// <param name="id">Id of medecine</param>
        /// <returns></returns>
        /// <response code="200">Returns success: true</response>
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ApiResponceT<MedicineModel>))]
        [HttpGet("Medicine")]
        public async Task<IActionResult> Medicine([Required] string id)
        {
            var medecine = await _repo.Medicine(id: id);
            return _baseRepo.CustomResponce(statusCode: StatusCodes.Status200OK, success: true, message: "", data: medecine);
        }

        /// <summary>
        /// Add Medicine
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">Returns success: true</response>
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ApiResponceString))]
        [HttpPost("AddMedicine")]
        public async Task<IActionResult> AddMedicine(MedicineViewModel model)
        {
            if (model.ExpiryDate.Date <= DateTime.Now.Date)
            {
                return _baseRepo.CustomResponce(statusCode: StatusCodes.Status400BadRequest, success: false, message: "ExpiryDate should be greater than today's date", data: "");
            }

            MedicineModel medicine = new MedicineModel()
            {
                Id = _generateID.GeneratID(),
                Brand = model.Brand,
                ExpiryDate = model.ExpiryDate,
                Notes = model.Notes,
                Price = model.Price,
                Quantity = model.Quantity
            };

            bool isAdded = await _repo.AddMedicine(model: medicine);
            if (isAdded)
            {
                return _baseRepo.CustomResponce(statusCode: StatusCodes.Status200OK, success: true, message: SuccessContants.RecordAddedSuccessfully, data: "");
            }
            else
            {
                return _baseRepo.CustomResponce(statusCode: StatusCodes.Status200OK, success: false, message: ErrorContants.Techincalproblempleasetryagain, data: "");
            }
        }

        /// <summary>
        /// Update notes in medicine
        /// </summary>
        /// <param name="id">Id of medicine</param>
        /// <param name="notes">Notes of medicine</param>
        /// <returns></returns>
        /// <response code="200">Returns success: true</response>
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ApiResponceString))]
        [HttpGet("UpdateMedicine")]
        public async Task<IActionResult> UpdateMedicine([Required] string id, [Required] string notes)
        {
            bool isUpdated = await _repo.UpdateMedicine(id: id, notes: notes);
            if (isUpdated)
            {
                return _baseRepo.CustomResponce(statusCode: StatusCodes.Status200OK, success: true, message: SuccessContants.RecordUpdatedSuccessfully, data: "");
            }
            else
            {
                return _baseRepo.CustomResponce(statusCode: StatusCodes.Status400BadRequest, success: false, message: ErrorContants.Techincalproblempleasetryagain, data: "");
            }
        }

        /// <summary>
        /// Delete Medicine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Returns success: true</response>
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(ApiResponceString))]
        [HttpGet("DeleteMedicine")]
        public async Task<IActionResult> DeleteMedicine([Required] string id)
        {
            bool isDeleted = await _repo.DeleteMedicine(id: id);
            if (isDeleted)
            {
                return _baseRepo.CustomResponce(statusCode: StatusCodes.Status200OK, success: true, message: SuccessContants.RecordDeletedSuccessfully, data: "");
            }
            else
            {
                return _baseRepo.CustomResponce(statusCode: StatusCodes.Status200OK, success: false, message: ErrorContants.Techincalproblempleasetryagain, data: "");
            }
        }
    }
}
