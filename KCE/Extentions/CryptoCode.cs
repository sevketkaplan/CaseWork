using System.Text;

namespace KCE.Extentions
{
    public static class CryptoCode
    {
        static char[] valid_code_arr = "ACDEFGHKLMNPRTXYZ234579".ToCharArray();
        public static string Generate()
        {
            char[] valid_tmp_arr = new char[8];
            // ==============  1. hane karakter oluşturması ==============
            long t1 = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
            var rand_index1_1 = new Random().Next(0, 1000000) + new Random().Next(0, 1000000);

            var tmp_index1_1 = (t1 + rand_index1_1) % 23;
            if (tmp_index1_1 == 22)
                tmp_index1_1 = 1;
            if (tmp_index1_1 % 2 == 0)
                tmp_index1_1 += 1;
            tmp_index1_1 = tmp_index1_1 % 23;

            valid_tmp_arr[0] = valid_code_arr[tmp_index1_1];

            // ==============  2. hane karakter oluşturması ==============
            Task.Delay(new Random().Next(1, 17)).Wait();
            long t2 = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();
            var rand_index1_2 = new Random().Next(0, 1000000) + new Random().Next(0, 1000000);
            var tmp_index1_2 = (t2 - t1 + rand_index1_2 + rand_index1_1) % 23;
            if (tmp_index1_2 % 2 == 1)
                tmp_index1_2 += 1;
            tmp_index1_2 = tmp_index1_2 % 23;

            valid_tmp_arr[1] = valid_code_arr[Math.Abs(tmp_index1_2)];

            // ==============  3. hane karakter oluşturması ==============
            var rand_index1_3 = (t2 + t1 - rand_index1_2 + rand_index1_1 + new Random().Next(0, 1000000) + new Random().Next(0, 10000)) % 23;
            valid_tmp_arr[2] = valid_code_arr[Math.Abs(rand_index1_3)];


            // ==============  4. hane karakter oluşturması ==============

            var tmp_index0_4 = Array.IndexOf(valid_code_arr, valid_tmp_arr[2]);

            Task.Delay(new Random().Next(1, 71)).Wait();
            long t4 = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();

            var rand_index1_4 = new Random().Next(0, 1000000);

            // eğer 3. karakter index tek ise 4. karakter index de tek olacak değil ise çift


            if (tmp_index0_4 % 2 == 0)
            {
                var tmp_index1_4 = (t4 - t2 + t1 + rand_index1_4 - rand_index1_2 + rand_index1_1 + Array.IndexOf(valid_code_arr, valid_tmp_arr[2])) % 23;

                if (tmp_index1_4 % 2 == 1)
                    tmp_index1_4 += 1;

                tmp_index1_4 = Math.Abs(tmp_index1_4) % 23;
                valid_tmp_arr[3] = valid_code_arr[tmp_index1_4];
            }
            else
            {
                var tmp_index1_4 = (t2 + t1 - t4 + rand_index1_4 + rand_index1_2 + rand_index1_1 + Array.IndexOf(valid_code_arr, valid_tmp_arr[2])) % 23;
                if (tmp_index1_4 == 22)
                    tmp_index1_4 = 1;

                if (tmp_index1_4 % 2 == 0)
                    tmp_index1_4 += 1;

                tmp_index1_4 = Math.Abs(tmp_index1_4) % 23;
                valid_tmp_arr[3] = valid_code_arr[tmp_index1_4];
            }





            // ==============  5. hane karakter oluşturması ==============
            var rand_index1_5 = (t1 - t4 + rand_index1_2 + rand_index1_1 + new Random().Next(0, 1000000) + new Random().Next(0, 1000000)) % 23;
            valid_tmp_arr[4] = valid_code_arr[Math.Abs(rand_index1_5)];


            // ==============  6. hane karakter oluşturması ==============

            // 1, 3 ve 5. karakterler içermeyen yeni karakter kümesi üretildi
            var tmp_arr_6 = valid_code_arr.Where(i => i != valid_tmp_arr[0] && i != valid_tmp_arr[2] && i != valid_tmp_arr[4]).ToArray();
            // yeni dizide hedef karkteri tespit etmek için elede edecğimiz indexler
            var tmp_num1_str_6 = ((int)valid_tmp_arr[0]).ToString() + ((int)valid_tmp_arr[2]).ToString() + ((int)valid_tmp_arr[4]).ToString();
            var tmp_num1_6 = int.Parse(tmp_num1_str_6);

            var dest_index1_6 = tmp_num1_6 % tmp_arr_6.Length;
            valid_tmp_arr[5] = tmp_arr_6[dest_index1_6];


            // ==============  7. hane karakter oluşturması ==============

            // 2, 4 ve 6. karakterler içermeyen yeni karakter kümesi üretildi
            var tmp_arr_7 = valid_code_arr.Where(i => i != valid_tmp_arr[1] && i != valid_tmp_arr[3] && i != valid_tmp_arr[5]).ToArray();
            // yeni dizide hedef karkteri tespit etmek için elede edecğimiz indexler
            var tmp_num1_str_7 = ((int)valid_tmp_arr[1]).ToString() + ((int)valid_tmp_arr[3]).ToString() + ((int)valid_tmp_arr[5]).ToString();
            var tmp_num1_7 = int.Parse(tmp_num1_str_7);

            var dest_index1_7 = tmp_num1_7 % tmp_arr_7.Length;
            valid_tmp_arr[6] = tmp_arr_7[dest_index1_7];


            // ==============  8. hane karakter oluşturması ==============

            // 7. karakter içermeyen yeni karakter kümesi üretildi
            var tmp_arr_8 = valid_code_arr.Where(i => i != valid_tmp_arr[6]).ToArray();
            // yeni dizide hedef karkteri tespit etmek için elede edecğimiz indexler
            var tmp_num1_str_8 = "";
            for (int i = 0; i < tmp_arr_8.Length - 1; i++)
                tmp_num1_str_8 += (int)tmp_arr_8[i];

            var tmp_num2_str_8 = "";
            for (int i = 0; i < tmp_num1_str_8.Length; i += 3)
                tmp_num2_str_8 += tmp_num1_str_8[i];

            var tmp_num2_8 = long.Parse(tmp_num2_str_8);

            var dest_index1_8 = tmp_num2_8 % tmp_arr_8.Length;

            valid_tmp_arr[7] = tmp_arr_8[dest_index1_8];

            return new string(valid_tmp_arr);
        }

        public static bool VerifyCode(string code)
        {
            bool state = true;
            if (string.IsNullOrEmpty(code) || code.Length < 8)
                return false;

            // kodun tüm karakterleri kümde yer almalı
            var tmp_code_arr = code.ToCharArray();
            if (tmp_code_arr.Any(ch => !valid_code_arr.Contains(ch)))
                return false;

            // ==============  1. hane karakter doğrulamsı ==============
            // index tek olmalı
            if (Array.IndexOf(valid_code_arr, tmp_code_arr[0]) % 2 != 1)
                return false;

            // ==============  2. hane karakter doğrulamsı ==============
            // index çift olmalı
            if (Array.IndexOf(valid_code_arr, tmp_code_arr[1]) % 2 != 0)
                return false;

            // ==============  3. hane karakter doğrulamsı ==============
            // kümeden herhangi bir karakter olabilir
            if (!valid_code_arr.Contains(tmp_code_arr[2]))
                return false;


            // ==============  4. hane karakter doğrulamsı ==============

            // eğer 3. karakter indexi tek ise bu da tek olacak değil ise çift olmalı
            var tmp_index1_4 = Array.IndexOf(valid_code_arr, tmp_code_arr[2]);
            if (tmp_index1_4 % 2 == 1)
                if (Array.IndexOf(valid_code_arr, tmp_code_arr[3]) % 2 == 0)
                    return false;
            if (tmp_index1_4 % 2 == 0)
                if (Array.IndexOf(valid_code_arr, tmp_code_arr[3]) % 2 == 1)
                    return false;


            // ==============  5. hane karakter doğrulamsı ==============

            // kümeden herhangi bir karakter olabilir
            if (!valid_code_arr.Contains(tmp_code_arr[4]))
                return false;


            // ==============  6. hane karakter doğrulamsı ==============

            // 1, 3 ve 5. karakterler içermeyen yeni karakter kümesi üretildi
            var tmp_arr_6 = valid_code_arr.Where(i => i != tmp_code_arr[0] && i != tmp_code_arr[2] && i != tmp_code_arr[4]).ToArray();
            // yeni dizide hedef karkteri tespit etmek için elede edecğimiz indexler
            var tmp_num1_str_6 = ((int)tmp_code_arr[0]).ToString() + ((int)tmp_code_arr[2]).ToString() + ((int)tmp_code_arr[4]).ToString();
            var tmp_num1_6 = int.Parse(tmp_num1_str_6);

            var dest_index1_6 = tmp_num1_6 % tmp_arr_6.Length;

            if (tmp_code_arr[5] != tmp_arr_6[dest_index1_6])
                return false;

            // ==============  7. hane karakter doğrulamsı ==============

            // 2, 4 ve 6. karakterler içermeyen yeni karakter kümesi üretildi
            var tmp_arr_7 = valid_code_arr.Where(i => i != tmp_code_arr[1] && i != tmp_code_arr[3] && i != tmp_code_arr[5]).ToArray();
            // yeni dizide hedef karkteri tespit etmek için elede edecğimiz indexler
            var tmp_num1_str_7 = ((int)tmp_code_arr[1]).ToString() + ((int)tmp_code_arr[3]).ToString() + ((int)tmp_code_arr[5]).ToString();
            var tmp_num1_7 = int.Parse(tmp_num1_str_7);

            var dest_index1_7 = tmp_num1_7 % tmp_arr_7.Length;

            if (tmp_code_arr[6] != tmp_arr_7[dest_index1_7])
                return false;

            // ==============  8. hane karakter doğrulamsı ==============

            // 7. karakter içermeyen yeni karakter kümesi üretildi
            var tmp_arr_8 = valid_code_arr.Where(i => i != tmp_code_arr[6]).ToArray();
            // yeni dizide hedef karkteri tespit etmek için elede edecğimiz indexler
            var tmp_num1_str_8 = "";
            for (int i = 0; i < tmp_arr_8.Length - 1; i++)
                tmp_num1_str_8 += (int)tmp_arr_8[i];

            var tmp_num2_str_8 = "";
            for (int i = 0; i < tmp_num1_str_8.Length; i += 3)
                tmp_num2_str_8 += tmp_num1_str_8[i];

            var tmp_num2_8 = long.Parse(tmp_num2_str_8);

            var dest_index1_8 = tmp_num2_8 % tmp_arr_8.Length;

            if (tmp_code_arr[7] != tmp_arr_8[dest_index1_8])
                return false;

            return state;
        }
    }
}
