using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Exception
{
    public class AssetNotMaintainException : System.Exception
    {
        // Constructor that takes a message
        public AssetNotMaintainException(string message)
            : base(message) // Ensure this is correct
        {
        }

        // Constructor that takes a message and an inner exception
        public AssetNotMaintainException(string message, System.Exception innerException)
            : base(message, innerException) // Ensure this is correct
        {
        }
    }

}