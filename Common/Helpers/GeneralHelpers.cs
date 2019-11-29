using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class GeneralHelpers
    {
        public static void SetValues(IEnumerable<Parameters> tableParameters, object objectToSetValuesFor)
        {
            if (!tableParameters.Any() || tableParameters == null)
            {
                throw new NullReferenceException("Parameters table is null or empty");
            }

            foreach (var tableParameter in tableParameters)
            {
                if (tableParameter.Value != string.Empty)
                {
                    var param = objectToSetValuesFor.GetType().GetProperty(tableParameter.Field);
                    var typeToSet = Nullable.GetUnderlyingType(param.PropertyType) ?? param.PropertyType;
                    param.SetValue(objectToSetValuesFor, Convert.ChangeType(tableParameter.Value, typeToSet));
                }
            }
        }
    }
}
