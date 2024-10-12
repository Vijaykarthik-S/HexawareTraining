using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAssetManagement.Exception
{
    public class AssetNotFoundException : System.Exception
    {
        public AssetNotFoundException(string message) : base(message) { }

        public AssetNotFoundException(string message, System.Exception innerException)
            : base(message, innerException) { }
    }
}