using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RunpathCodingTest.Contracts
{
    public class VoidJsonResponse : IVoidJsonResponse
    {
        public bool Failed => !Succeeded;

        public bool Succeeded { get; set; }

        public ICollection<ErrorResponse> ValidationErrors { get; set; }

        public VoidJsonResponse()
        {
            ValidationErrors = new Collection<ErrorResponse>();
        }

        public virtual void DeserialiseResponse(HttpResponseMessage response, string responseString)
        {
            if (response.IsSuccessStatusCode)
            {
                Succeeded = true;
            }
            else
            {
                Succeeded = false;
                DeserialiseErrors(response, responseString);
            }
        }

        private void DeserialiseErrors(HttpResponseMessage response, string responseString)
        {
            if (!string.IsNullOrWhiteSpace(responseString))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ValidationErrors = JsonConvert.DeserializeObject<ICollection<ErrorResponse>>(responseString);
                }
                else
                {
                    try
                    {
                        ValidationErrors = new[] { JsonConvert.DeserializeObject<ErrorResponse>(responseString) };
                    }
                    catch
                    {
                        throw new Exception("Could not deserialize response object", new Exception(responseString));
                    }
                }
            }
        }
        public void AddErrorMessage(string errorMessage)
        {
            ValidationErrors.Add(new ErrorResponse(errorMessage));

            Succeeded = false;
        }
    }
}
