using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentCenter.Model
{
    partial class EmploymentCenterEntities
    {
        private static EmploymentCenterEntities _Context;

        public static EmploymentCenterEntities GetContext()
        {
            if (_Context == null) _Context = new EmploymentCenterEntities();
            return _Context;
        }
    }
}
