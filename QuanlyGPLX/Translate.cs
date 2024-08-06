using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace QuanlyGPLX
{
    public class Translate
    {
        private static readonly Dictionary<string, string> ReplacementMap = new Dictionary<string, string>
        {
            {"Ê̆", "E"}, {"Ơ̆", "O"}, {"Ô̆", "O"}, {"Ư̆", "U"}, {"H'", "E"},
        {"Ŭ", "U"}, {"Ĕ", "E"}, {"Ĭ", "I"}, {"Ñ", "N"}, {"Ŏ", "O"}, {"Č", "C"}, {"Ƀ", "B"},
        {"Ô", "O"}, {"Ă", "A"}, {"Ê", "E"}
          
        };

        public static string RemoveDiacritics(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Thay thế ký tự theo bản đồ
            string replacedString = input;
            foreach (var kvp in ReplacementMap)
            {
                replacedString = replacedString.Replace(kvp.Key, kvp.Value);
            }

            // Normalize the string to FormD (decomposed form)
            string normalizedString = replacedString.Normalize(NormalizationForm.FormD);

            // Create a StringBuilder to hold the result
            StringBuilder stringBuilder = new StringBuilder();

            // Iterate through each character in the normalized string
            foreach (char c in normalizedString)
            {
                // Check if the character is a non-spacing mark (diacritic)
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    // Append the character if it's not a diacritic
                    stringBuilder.Append(c);
                }
            }

            // Normalize the result back to FormC (composed form)
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        public static string ConvertDateToEng(string dateStr)
        {
            // Dictionary to map month numbers to month names in English
            var monthDict = new Dictionary<string, string>
            {
                { "01", "January" },
                { "02", "February" },
                { "03", "March" },
                { "04", "April" },
                { "05", "May" },
                { "06", "June" },
                { "07", "July" },
                { "08", "August" },
                { "09", "September" },
                { "10", "October" },
                { "11", "November" },
                { "12", "December" }
            };

            // Check if the input is in the correct format
            if (dateStr.Length != 8 || !int.TryParse(dateStr, out _))
            {
                return "Invalid date format";
            }

            // Parse the date
            if (DateTime.TryParseExact(dateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                // Get day and month with leading zeros
                string day = date.Day.ToString("D2");
                string monthNumber = date.Month.ToString("D2");
                string monthName = monthDict.ContainsKey(monthNumber) ? monthDict[monthNumber] : "Unknown";
                string year = date.Year.ToString();

                // Format date to English with leading zeros
                string englishDate = $"{day} {monthName} {year}";

                return englishDate;
            }
            else
            {
                return "Invalid date format";
            }
        }

        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Split the input into words
            var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Capitalize the first letter of each word
            for (int i = 0; i < words.Length; i++)
            {
                if (!string.IsNullOrEmpty(words[i]))
                {
                    // Capitalize the first letter and make the rest of the letters lowercase
                    words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                }
            }

            // Join the words back into a single string
            return string.Join(" ", words);
        }


        public static string ConvertDateVN(string dateStr)
        {
            // Check if the input is in the correct format
            if (dateStr.Length != 8 || !int.TryParse(dateStr, out _))
            {
                return "Invalid date format";
            }

            // Parse the date
            if (DateTime.TryParseExact(dateStr, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                // Format date to "dd/MM/yyyy"
                string formattedDate = date.ToString("dd/MM/yyyy");

                // Format date to English
                string englishDate = date.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture);

                return formattedDate;
            }
            else
            {
                return "Invalid date format";
            }
        }

        public static string XepLoaiEng(string vietnameseGrade)
        {
            // Dictionary to map lowercase Vietnamese grades to English equivalents
            var gradeDictionary = new Dictionary<string, string>
            {
                { "xuất sắc", "Excellent" },
                { "giỏi", "Very good" },
                { "khá", "Good" },
                { "trung bình khá", "Average good" },
                { "trung bình", "Ordinary" }
            };

            // Convert the input grade to lowercase
            string lowercaseGrade = vietnameseGrade.ToLowerInvariant();

            // Check if the grade exists in the dictionary and return the English equivalent
            if (gradeDictionary.TryGetValue(lowercaseGrade, out string englishGrade))
            {
                return englishGrade;
            }
            else
            {
                // Return the original input if no translation is found
                return vietnameseGrade;
            }
        }

        public static string formatChuDauTienVietHoa(string input)
        {
            // Kiểm tra chuỗi đầu vào có null hoặc rỗng hay không
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            // Chuyển toàn bộ chuỗi thành chữ thường
            input = input.ToLowerInvariant();

            // Viết hoa chữ cái đầu tiên và nối với phần còn lại của chuỗi
            return char.ToUpper(input[0]) + input.Substring(1);
        }

    }
}
