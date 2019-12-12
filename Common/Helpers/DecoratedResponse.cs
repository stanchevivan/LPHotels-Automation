using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class DecoratedResponse<T>
         where T : class
    {
        public DecoratedResponse(T entity)
        {
            value = entity;
        }

        public T value { get; set; }
    }
}
