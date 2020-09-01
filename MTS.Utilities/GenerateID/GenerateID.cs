using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Utilities
{
    class GenerateID : IGenerateID
    {
        /// <summary>
        /// Generate unique id of 42 characters
        /// </summary>
        /// <returns>Id of 42 latters</returns>
        public string GeneratID()
        {
            var guid = Guid.NewGuid().ToString();
            return DateTime.UtcNow.ToString("MMddyyyy-HHmmssfff-") + guid.Substring(0, 23);
        }
    }
}
