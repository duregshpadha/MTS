using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Mvc;
using MTS.BAL.Models;
using MTS.DAL;
using MTS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MTS.BAL.Repository
{
    class MTSRepo : IMTSRepo
    {
        public MTSRepo(MTSDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        private readonly MTSDBContext _dbContext;

        /// <summary>
        /// Medicine data table
        /// </summary>
        /// <param name="requestModel">Request model of datatable from front end</param>
        /// <returns></returns>
        public async Task<DataTablesResponse> Medicines([ModelBinder(BinderType = typeof(ModelBinder))] IDataTablesRequest requestModel)
        {
            var query = _dbContext.Medicines.Select(x => new
            {
                x.Id,
                x.Brand,
                ExpiryDate = x.ExpiryDate.ToString("yyyy-MMM-dd"),
                x.Notes,
                x.Price,
                x.Quantity,
            });

            int totalCount = await query.CountAsync();

            #region Filtering
            // Apply filters for searching
            if (!string.IsNullOrEmpty(requestModel.Search.Value))
            {
                var value = requestModel.Search.Value.Trim();
                value = (string.IsNullOrEmpty(value)) ? value : value.ToLower();

                query = query.Where(x => x.Brand.Contains(value));
            }
            int filteredCount = await query.CountAsync();
            #endregion Filtering

            #region Sorting  
            // Sorting  
            IEnumerable<IColumn> sortedColumns = requestModel.Columns.Where(x => x.Sort != null);
            string orderByString = String.Empty;

            foreach (var column in sortedColumns)
            {
                orderByString += orderByString != String.Empty ? "," : "";
                orderByString += (column.Field) + (column.Sort.Direction == SortDirection.Ascending ? " asc" : " desc");
            }

            query = query.OrderBy(orderByString == string.Empty ? "id asc" : orderByString);
            #endregion Sorting 

            // Paging
            query = query.Skip(requestModel.Start).Take(requestModel.Length);

            var data = await query.ToListAsync();

            return DataTablesResponse.Create(requestModel, totalCount, filteredCount, data);
        }

        /// <summary>
        /// Get medecine
        /// </summary>
        /// <param name="id">Primery key of Medicine table</param>
        /// <returns>MedicineModel</returns>
        public async Task<MedicineModel> Medicine(string id)
        {
            return await _dbContext.Medicines.Where(m => m.Id == id).Select(x => new MedicineModel()
            {
                Id = x.Id,
                Brand = x.Brand,
                ExpiryDate = x.ExpiryDate,
                Notes = x.Notes,
                Price = x.Price,
                Quantity = x.Quantity
            }).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Add medicine
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Added (True/False)</returns>
        public async Task<bool> AddMedicine(MedicineModel model)
        {
            Medicine medicine = new Medicine()
            {
                Id = model.Id,
                Brand = model.Brand,
                ExpiryDate = model.ExpiryDate,
                Notes = model.Notes,
                Price = model.Price,
                Quantity = model.Quantity
            };

            await _dbContext.Medicines.AddAsync(medicine);
            int affectedRows = await _dbContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        /// <summary>
        /// Update notes
        /// </summary>
        /// <param name="id">Primery key of Medicine table</param>
        /// <param name="notes">Note for medicine</param>
        /// <returns>Updated (True/False)</returns>
        public async Task<bool> UpdateMedicine(string id, string notes)
        {
            var medicine = await _dbContext.Medicines.FindAsync(id);
            if (medicine == null)
                return false;

            medicine.Notes = notes;
            int affectedRows = await _dbContext.SaveChangesAsync();
            return affectedRows > 0;
        }

        /// <summary>
        /// Delete Medicine
        /// </summary>
        /// <param name="id">Primery key of Medicine table</param>
        /// <returns></returns>
        public async Task<bool> DeleteMedicine(string id)
        {
            var medicine = await _dbContext.Medicines.FindAsync(id);
            if (medicine == null)
                return false;

            _dbContext.Medicines.Remove(medicine);
            int affectedRows = await _dbContext.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}
