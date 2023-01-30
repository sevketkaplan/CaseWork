using Core.ResultType;
using DataObjects;
using KCE.Extentions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace KCE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaseController : ControllerBase
    {

        [Route("CaseTwo")]
        public ActionResult CaseTwo()

        {
            var text = string.Empty;
            List<JsonResponse> jsonResponse = new List<JsonResponse>();
            Result<List<JsonResponse>> result = new Result<List<JsonResponse>>();
            try
            {

                //Alt bölümde verilen dosyanýn içindeki json string okunuyor.
                using (StreamReader r = new StreamReader("../Extentions/response.json"))
                {
                    text = r.ReadToEnd();

                    //daha sonra da oluþturduðum Classa dönüþtürme yapýlýr.
                    jsonResponse = JsonConvert.DeserializeObject<List<JsonResponse>>(text);
                }
                result.IsSuccess = true;
                result.Message = "Json Parse Successfully!";
                result.Data = jsonResponse;
            }
            catch (Exception ex)
            {
                result.IsSuccess = true;
                result.Message = $"Json Parse Get Exception Error:{ex.Message}";
            }
            return Ok(result);
        }

        [Route("GenerateCode")]
        public ActionResult GenerateCode()
        {
            Function.GetUniqueKey();
            return Ok();
        }

    }
}