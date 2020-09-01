using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Utilities
{
    public interface IGenerateID
    {
        /// <summary>
        /// Generate unique id of 42 characters
        /// </summary>
        /// <returns>Id of 42 latters</returns>
        string GeneratID();
    }
}
