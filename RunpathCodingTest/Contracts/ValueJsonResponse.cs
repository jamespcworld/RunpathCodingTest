using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunpathCodingTest.Contracts
{
    public class ValueJsonResponse<T> : VoidJsonResponse, IValueJsonResponse<T>
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }

        /// <summary>
        /// Deserialises and sets the value.
        /// </summary>
        /// <param name="response">The response message.</param>
        /// <param name="responseString">The response string.</param>        
        public override void DeserialiseResponse(System.Net.Http.HttpResponseMessage response, string responseString)
        {
            base.DeserialiseResponse(response, responseString);

            if (Succeeded)
            {
                Value = JsonConvert.DeserializeObject<T>(responseString);
            }
        }
    }
}
