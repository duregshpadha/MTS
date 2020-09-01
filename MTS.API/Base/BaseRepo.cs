using Microsoft.AspNetCore.Mvc;
using MTS.API.Models;
using System.Collections.Generic;

namespace MTS.API.Base
{
    /// <summary>
    /// Base repository for comman responces
    /// </summary>
    public class BaseRepo : ControllerBase, IBaseRepo
    {
        /// <summary>
        /// Comman responce for api
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public ObjectResult CustomResponce(int statusCode, bool success, string message, dynamic data)
        {
            var responce = new ApiResponce()
            {
                Success = success,
                Message = message,
                Data = data
            };
            return StatusCode(statusCode: statusCode, value: responce);
        }

        /// <summary>
        /// Comman responce for api
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public ObjectResult CustomResponce(int statusCode, bool success, string message, string data)
        {
            var responce = new ApiResponceString()
            {
                Success = success,
                Message = message,
                Data = data
            };
            return StatusCode(statusCode: statusCode, value: responce);
        }


        /// <summary>
        /// Comman responce for api
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public ObjectResult CustomResponce<T>(int statusCode, bool success, string message, T data)
        {
            var responce = new ApiResponceT<T>()
            {
                Success = success,
                Message = message,
                Data = data
            };
            return StatusCode(statusCode: statusCode, value: responce);
        }


        /// <summary>
        /// Comman responce for api
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public ObjectResult CustomResponce<T>(int statusCode, bool success, string message, List<T> data)
        {
            var responce = new ApiResponceList<T>()
            {
                Success = success,
                Message = message,
                Data = data
            };
            return StatusCode(statusCode: statusCode, value: responce);
        }
    }
}
