using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fourth.TH.Automation.RestDriver;
using Newtonsoft.Json;

namespace Common.Helpers
{
    public static class JsonConvertExtentions
    {
        public static TEntity GetData<TEntity>(this Fourth.TH.Automation.RestDriver.IResponse response)
        {
            string jsonContent = response.Content;

            if (response.Content == string.Empty)
            {
                throw new Exception($"Response is Empty, {response.StatusCodeNumber}, {response.StatusCodeText}");
            }

            TEntity entity = JsonConvert.DeserializeObject<TEntity>(jsonContent);
            return entity;
        }

        public static TEntity GetDecoratedData<TEntity>(this IResponse response)
      where TEntity : class
        {
            string jsonContent = response.Content;

            if (response.Content == string.Empty)
            {
                throw new Exception($"Response is Empty, {response.StatusCodeNumber}, {response.StatusCodeText}");
            }

            var entity = JsonConvert.DeserializeObject<DecoratedResponse<TEntity>>(jsonContent);
            return entity.value;
        }
    }
}