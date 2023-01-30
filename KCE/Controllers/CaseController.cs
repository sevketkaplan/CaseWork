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
            var keys = new Result<List<string>>();
            List<string> keylist = new List<string>();
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    var unique = CryptoCode.Generate();
                    Console.WriteLine("index : " + (i + 1) + " kod : " + unique);
                    System.Threading.Thread.Sleep(1);
                    //zamana milisaniye ekleyerek farklý zaman gitmesini saðlýyoruz.
                    keylist.Add(unique);
                }
                keys.IsSuccess = true;
                keys.Message = "1000 Adet Kod üretilmiþtir.";
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
                result.Message = "Doðrulama iþlemi baþarýlý";
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "Doðrulama iþlemi baþarýsýz";
            }
            return Ok(result);

        }
    }
}