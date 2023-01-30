using System.Text;

namespace KCE.Extentions
{
    public class CryptoCode
    {
        private char[] chardata = { 'A', 'C', 'D', 'E', 'F', 'G', 'H', 'K', 'L', 'M', 'N', 'P', 'R', 'T', 'X', 'Y', 'Z', '2', '3', '4', '5', '7', '9' };

        private string secretkey = "KAIZEN";//başka birşey de tercih edilebilir.


        public void GenerateCode()
        {
            var rnd = new Random();
            int val;
            StringBuilder code= new StringBuilder();
            for (int index = 0; index < 8; index++)
            {
                int date = DateTime.Now.Millisecond;
                int mod;

                switch (index)
                {

                    case 0:
                       mod = date % 23;
                        if (mod % 2 == 0)
                        {
                            mod++;
                        }
                        code.Append(chardata[mod]);
                        break;
                    case 1:
                        mod = date % 23;
                        if (mod % 2 == 1)
                        {
                            mod++;
                        }
                        code.Append(chardata[mod]);
                        break;
                    case 2:

                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                    default:
                        break;
                }
                





            }

        }

    }
}
