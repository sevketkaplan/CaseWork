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

                //Alt b�l�mde verilen dosyan�n i�indeki json string okunuyor.
                using (StreamReader r = new StreamReader("../Extentions/response.json"))
                {
                    text = r.ReadToEnd();

                    //daha sonra da olu�turdu�um Classa d�n��t�rme yap�l�r.
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
            var keys = new Result<List<string>>();
            List<string> keylist = new List<string>();
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    var unique = CryptoCode.Generate();
                    Console.WriteLine("index : " + (i + 1) + " kod : " + unique);
                    System.Threading.Thread.Sleep(1);
                    //zamana milisaniye ekleyerek farkl� zaman gitmesini sa�l�yoruz.
                    keylist.Add(unique);
                }
                keys.IsSuccess = true;
                keys.Message = "1000 Adet Kod �retilmi�tir.";
                keys.Data = keylist;
            }
            catch (Exception ex)
            {
                keys.IsSuccess = false;
                keys.Data = null;
                keys.Message = $"Hata:{ex.Message} ";
            }
            return Ok(keys);
        }

        [Route("VerifyCode")]
        public ActionResult VerifyCode(string code)
        {
            Result<bool> result = new Result<bool>();
            int valid_key_count = 0;
            bool state = CryptoCode.VerifyCode(code);
            if (state)
            {
                result.IsSuccess = state;
                result.Message = "Do�rulama i�lemi ba�ar�l�";
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Do�rulama i�lemi ba�ar�s�z";
            }
            return Ok(result);

        }
    }
}