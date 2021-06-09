
using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
namespace CtyTinLuong.Constants
{
    internal static class CheckString
    {

        public static string CheckMailString(string str)
        {
            if (str.Length < 1)
            {
                return "Chưa nhập Mail";
            }
            if (str.Contains("@"))
            {
                string[] arrStr = str.Split('@');
                if (arrStr.Length == 2 && arrStr[0].Length > 0 && arrStr[1].Length > 0 && arrStr[1].Contains("."))
                {
                    byte[] asciiBytes = Encoding.ASCII.GetBytes(arrStr[0]);
                    for (int i = 0; i < asciiBytes.Length; ++i)
                    {

                        if ((asciiBytes[i] > 57 && asciiBytes[i] < 65) ||
                            (asciiBytes[i] > 90 && asciiBytes[i] < 95) || (asciiBytes[i] == 96) ||
                            (asciiBytes[i] > 122) || asciiBytes[i] == 47 || (asciiBytes[i] < 46))
                        {
                            return "Mail không đúng! Vui lòng kiểm tra lại!";
                        }
                    }
                    asciiBytes = Encoding.ASCII.GetBytes(arrStr[1]);
                    for (int i = 0; i < asciiBytes.Length; ++i)
                    {

                        if ((asciiBytes[i] > 57 && asciiBytes[i] < 65) ||
                            (asciiBytes[i] > 90 && asciiBytes[i] < 95) || (asciiBytes[i] == 96) ||
                            (asciiBytes[i] > 122) || asciiBytes[i] == 47 || (asciiBytes[i] < 46))
                        {
                            return "Mail không đúng! Vui lòng kiểm tra lại!";
                        }
                    }
                    return "OK";
                }
                else
                {
                    return "Mail không đúng! Vui lòng kiểm tra lại!";
                }
            }
            else
            {
                return "Mail không đúng! Vui lòng kiểm tra lại!";
            }
        }
        public static bool CheckSqlInjection(string str)
        {
            if (str.ToLower().Contains(" select ") || str.ToLower().Contains(" delete ") ||
                str.ToLower().Contains(" update ") || str.ToLower().Contains(" insert ") ||
                str.ToLower().Contains(" where ") || str.ToLower().Contains(" and ") ||
                str.ToLower().Contains(" or ") || str.ToLower().Contains(" create ") ||
                str.ToLower().Contains(" alter ") || str.ToLower().Contains(" exec "))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool CheckChuBay(string str)
        {
            if (str.ToLower().Replace(" ", "").Contains("địt"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("lồn"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("buồi"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("cặc"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("đụ"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("đéo"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("đít"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("chó"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("mẹ"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("đóng gạch"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("bướm"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("dái"))
            {
                return false;
            }
            //
            if (str.ToLower().Replace(" ", "").Contains("dái"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("tinh trùng"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("tinh trung"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("tinh chùng"))
            {
                return false;
            }
            //
            if (str.ToLower().Replace(" ", "").Contains("tinh chung"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("hạt le"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("dong gach"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("đóng gach"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("chim"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("chym"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("buòi"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("buôi"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("lòn"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("đù"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("má"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Contains("bím"))
            {
                return false;
            }
            //
            if (str.ToLower().Replace(" ", "").Contains("vú"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("zú"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("bố"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("lông"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("dkm"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("súcsinh"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("màngtrinh"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("conđỹ"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("cave"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("giaocấu"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("giaohợp"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("hạtle"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("liếm"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("đónggạch"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("thổikèn"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("sócrọ"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("vkl"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("dm"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("tinhtrùng"))
            {
                return false;
            }
            if (str.ToLower().Replace(" ", "").Replace(" ", "").Contains("vếu"))
            {
                return false;
            }
            return str.ToLower().Replace(" ", "").Replace(" ", "").Contains("thằngngu")
                ? false
                : !str.ToLower().Replace(" ", "").Replace(" ", "").Contains("cụ");
        }
        public static string CheckUserNameString(string userName)
        {
            if (userName.Length < 1)
            {
                return "Chưa nhập tài khoản";
            }
            if (userName.Length < 5)
            {
                return "Tài khoản > 4 ký tự";
            }
            if (!CheckChuBay(userName))
            {
                return "Hãy lịch sự";
            }
            byte[] asciiBytes = Encoding.ASCII.GetBytes(userName);
            for (int i = 0; i < asciiBytes.Length; ++i)
            {
                if (asciiBytes[i] < 48 || (asciiBytes[i] > 57 && asciiBytes[i] < 65) || (asciiBytes[i] > 90 && asciiBytes[i] < 97)
                    || (asciiBytes[i] > 122))
                {

                    return "Tài khoản chỉ gồm chữ không dấu và số";
                }
            }
            return "OK";
        }
        public static string CheckPassString(string str)
        {
            if (str.Length < 1)
            {
                return "Chưa nhập mật khẩu";
            }
            byte[] asciiBytes = Encoding.ASCII.GetBytes(str);
            for (int i = 0; i < asciiBytes.Length; ++i)
            {
                if (asciiBytes[i] < 33 || asciiBytes[i] > 126)
                {

                    return "Mật khẩu chứa tiếng việt và dấu cách";
                }
            }
            return "OK";
        }
        public static int CheckStrength(string password)
        {
            int score = 1;

            if (password.Length < 1)
                return 0;
            if (password.Length < 4)
            {
                return 1;
            }

            if (password.Length >= 8)
                score++;
            if (password.Length >= 12)
                score++;
            if (Regex.Match(password, @"/\d+/", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"/[a-z]/", RegexOptions.ECMAScript).Success &&
              Regex.Match(password, @"/[A-Z]/", RegexOptions.ECMAScript).Success)
                score++;
            if (Regex.Match(password, @"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).Success)
                score++;

            return score;
        }

        public static string RemoveUnicode(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
    "đ",
    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
    "í","ì","ỉ","ĩ","ị",
    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
    "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
    "d",
    "e","e","e","e","e","e","e","e","e","e","e",
    "i","i","i","i","i",
    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
    "u","u","u","u","u","u","u","u","u","u","u",
    "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }
    }
}
