using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MTS.API.Base
{
    /// <summary>
    /// Base repository for comman responces
    /// </summary>
    public interface IBaseRepo
    {
        /// <summary>
        /// Comman responce for api
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        ObjectResult CustomResponce(int statusCode, bool success, string message, dynamic data);


        /// <summary>
        /// Comman responce for api
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        ObjectResult CustomResponce(int statusCode, bool success, string message, string data);

        /// <summary>
        /// Comman responce for api
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        ObjectResult CustomResponce<T>(int statusCode, bool success, string message, T data);

        /// <summary>
        /// Comman responce for api
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        ObjectResult CustomResponce<T>(int statusCode, bool success, string message, List<T> data);
    }
}
