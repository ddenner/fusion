using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionServices.Contracts.Data
{
    /// <summary>
    /// Check any field restrictions on the data
    /// </summary>
    public interface IValidate
    {
        void Validate();
    }
}
