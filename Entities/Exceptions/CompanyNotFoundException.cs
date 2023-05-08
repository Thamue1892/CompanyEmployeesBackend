using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CompanyNotFoundException:Exception
    {
        public CompanyNotFoundException(Guid companyId)
        :base($"Company with id: {companyId} doesn't exist in the database.")
        {
            
        }
    }
}
