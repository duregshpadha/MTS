using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;
using MTS.BAL.Models;
using System.Threading.Tasks;

namespace MTS.BAL.Repository
{
    public interface IMTSRepo
    {
        /// <summary>
        /// Medicine data table
        /// </summary>
        /// <param name="requestModel">Request model of datatable from front end</param>
        /// <returns></returns>
        Task<DataTablesResponse> Medicines([ModelBinder(BinderType = typeof(ModelBinder))] IDataTablesRequest requestModel);

        /// <summary>
        /// Add medicine
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Added (True/False)</returns>
        Task<bool> AddMedicine(MedicineModel model);

        /// <summary>
        /// Update notes
        /// </summary>
        /// <param name="id">Primery key of Medicine table</param>
        /// <param name="notes">Note for medicine</param>
        /// <returns>Updated (True/False)</returns>
        Task<bool> UpdateMedicine(string id, string notes);

        /// <summary>
        /// Get medecine
        /// </summary>
        /// <param name="id">Primery key of Medicine table</param>
        /// <returns>MedicineModel</returns>
        Task<MedicineModel> Medicine(string id);

        /// <summary>
        /// Delete Medicine
        /// </summary>
        /// <param name="id">Primery key of Medicine table</param>
        /// <returns></returns>
        Task<bool> DeleteMedicine(string id);
    }
}
