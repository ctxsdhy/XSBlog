using System;
using System.Text;

namespace XS.Framework.Utility
{
    /// <summary>
    /// 字符串操作工具集
    /// </summary>
    public class StringHelper
    {

        /// <summary>
        /// 从字符串中的尾部删除指定的字符串
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="removedString"></param>
        /// <returns></returns>
        public static string Remove(string sourceString, string removedString)
        {
            try
            {
                if (sourceString.IndexOf(removedString) < 0)
                    throw new Exception("原字符串中不包含移除字符串！");
                string result = sourceString;
                int lengthOfSourceString = sourceString.Length;
                int lengthOfRemovedString = removedString.Length;
                int startIndex = lengthOfSourceString - lengthOfRemovedString;
                string tempSubString = sourceString.Substring(startIndex);
                if (tempSubString.ToUpper() == removedString.ToUpper())
                {
                    result = sourceString.Remove(startIndex, lengthOfRemovedString);
                }
                return result;
            }
            catch
            {
                return sourceString;
            }
        }

        /// <summary>
        /// 获取拆分符右边的字符串
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static string RightSplit(string sourceString, char splitChar)
        {
            string result = null;
            string[] tempString = sourceString.Split(splitChar);
            if (tempString.Length > 0)
            {
                result = tempString[tempString.Length - 1];
            }
            return result;
        }

        /// <summary>
        /// 获取拆分符左边的字符串
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static string LeftSplit(string sourceString, char splitChar)
        {
            string result = null;
            string[] tempString = sourceString.Split(splitChar);
            if (tempString.Length > 0)
            {
                result = tempString[0];
            }
            return result;
        }

        /// <summary>
        /// 去掉最后一个逗号
        /// 修改因为原来会将 a,b,c输入处理后变成 a,b 输出，丢失了部分数据 shizy 20091211
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static string DeleteLastComma(string origin)
        {
            //if (origin.IndexOf(",") == -1)
            //{
            //    return origin;
            //}
            //return origin.Substring(0, origin.LastIndexOf(","));
            if (origin.IndexOf(",") == -1)
            {
                return origin;
            }
            if (origin.EndsWith(","))
                return origin.Substring(0, origin.LastIndexOf(","));
            else
                return origin;
        }

        /// <summary>
        /// 将两个带分隔符的短字符串合并
        /// 如 a,b 和 c,d 合并成为 a,b,c,d
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="seprator"></param>
        /// <returns></returns>
        public static string GetCorrectCommaListStr(string first, string second, string seprator)
        {
            string result = first;

            result = first + seprator + second;
            result = result.Replace(seprator + seprator, seprator);
            result = result.Trim();
            if (result.StartsWith(seprator))
                result = result.Substring(1);
            if (result.EndsWith(seprator))
                result = result.Substring(0, result.Length - 1);

            return result;
        }

        /// <summary>
        /// 删除不可见字符
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string DeleteUnVisibleChar(string sourceString)
        {
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder(131);
            for (int i = 0; i < sourceString.Length; i++)
            {
                int Unicode = sourceString[i];
                if (Unicode >= 16)
                {
                    sBuilder.Append(sourceString[i].ToString());
                }
            }
            return sBuilder.ToString();
        }

        /// <summary>
        /// 获取数组元素的合并字符串
        /// </summary>
        /// <param name="stringArray"></param>
        /// <returns></returns>
        public static string ArrayToString(string[] stringArray)
        {
            string totalString = null;
            for (int i = 0; i < stringArray.Length; i++)
            {
                totalString = totalString + stringArray[i];
            }
            return totalString;
        }

        /// <summary>
        ///		获取某一字符串在字符串数组中出现的次数
        /// </summary>
        /// <param name="stringArray" type="string[]">
        ///     <para>
        ///         
        ///     </para>
        /// </param>
        /// <param name="findString" type="string">
        ///     <para>
        ///         
        ///     </para>
        /// </param>
        /// <returns>
        ///     A int value...
        /// </returns>
        public static int GetStringCount(string[] stringArray, string findString)
        {
            int count = -1;
            string totalString = ArrayToString(stringArray);
            string subString = totalString;

            while (subString.IndexOf(findString) >= 0)
            {
                subString = totalString.Substring(subString.IndexOf(findString));
                count += 1;
            }
            return count;
        }

        /// <summary>
        ///     获取某一字符串在字符串中出现的次数
        /// </summary>
        /// <param name="sourceString" type="string">
        ///     <para>
        ///         原字符串
        ///     </para>
        /// </param>
        /// <param name="findString" type="string">
        ///     <para>
        ///         匹配字符串
        ///     </para>
        /// </param>
        /// <returns>
        ///     匹配字符串数量
        /// </returns>
        public static int GetStringCount(string sourceString, string findString)
        {
            int count = 0;
            int findStringLength = findString.Length;
            string subString = sourceString;

            while (subString.IndexOf(findString) >= 0)
            {
                subString = subString.Substring(subString.IndexOf(findString) + findStringLength);
                count += 1;
            }
            return count;
        }

        /// <summary>
        /// 截取从startString开始到原字符串结尾的所有字符   
        /// </summary>
        /// <param name="sourceString" type="string">
        ///     <para>
        ///         
        ///     </para>
        /// </param>
        /// <param name="startString" type="string">
        ///     <para>
        ///         
        ///     </para>
        /// </param>
        /// <returns>
        ///     A string value...
        /// </returns>
        public static string GetSubString(string sourceString, string startString)
        {
            try
            {
                int index = sourceString.ToUpper().IndexOf(startString);
                if (index > 0)
                {
                    return sourceString.Substring(index);
                }
                return sourceString;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 删除从beginRemovedString开始到endRemovedString字符串结尾的所有字符   
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="beginRemovedString"></param>
        /// <param name="endRemovedString"></param>
        /// <returns></returns>
        public static string GetSubString(string sourceString, string beginRemovedString, string endRemovedString)
        {
            try
            {
                if (sourceString.IndexOf(beginRemovedString) != 0)
                    beginRemovedString = "";

                if (sourceString.LastIndexOf(endRemovedString, sourceString.Length - endRemovedString.Length) < 0)
                    endRemovedString = "";

                int startIndex = beginRemovedString.Length;
                int length = sourceString.Length - beginRemovedString.Length - endRemovedString.Length;
                if (length > 0)
                {
                    return sourceString.Substring(startIndex, length);
                }
                return sourceString;
            }
            catch
            {
                return sourceString;
            }
        }

        /// <summary>
        /// 返回字符串的真实长度，一个汉字字符相当于两个单位长度(使用Encoding类)
        /// </summary>
        /// <param name="str">指定字符串</param>
        /// <returns></returns>
        public static int GetByteCount(string str)
        {
            int intResult = 0;
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            byte[] bytes = gb2312.GetBytes(str);
            intResult = bytes.Length;
            return intResult;
        }

        /// <summary>
        /// 按字节数要在字符串的位置
        /// </summary>
        /// <param name="intIns">字符串的位置</param>
        /// <param name="strTmp">要计算的字符串</param>
        /// <returns>字节的位置</returns>
        public static int GetByteIndex(int intIns, string strTmp)
        {
            int intReIns = 0;
            if (strTmp.Trim() == "")
            {
                return intIns;
            }
            for (int i = 0; i < strTmp.Length; i++)
            {
                if (System.Text.UTF8Encoding.UTF8.GetByteCount(strTmp.Substring(i, 1)) == 3)
                {
                    intReIns = intReIns + 2;
                }
                else
                {
                    intReIns = intReIns + 1;
                }
                if (intReIns >= intIns)
                {
                    intReIns = i + 1;
                    break;
                }
            }
            return intReIns;
        }

        /// <summary>
        /// 左对齐字符串，并在右边以“...”填充字符串以达到指定的长度。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string PadRight(string str, int length)
        {
            string newString = "";
            if (str != "")
            {
                length = length - 3;
                if (length > 0 && str.Length > length)
                {
                    newString = str.Substring(0, length) + "...";
                }
                else
                {
                    newString = str;
                }
            }
            return newString;
        }

        /// <summary>
        /// 左对齐字符串，并在右边以指定的长度填充字符串以达到指定的长度。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <param name="replace"></param>
        /// <returns></returns>
        public static string PadRight(string str, int length, string replace)
        {
            string newString = "";
            if (str != "")
            {
                length = length - 3;
                if (length > 0 && str.Length > length)
                {
                    newString = str.Substring(0, length - 2) + replace;
                }
                else
                {
                    newString = str;
                }
            }
            return newString;
        }

        /// <summary>
        /// 字符串剪切
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CutString(string str)
        {
            string newString = "";
            if (str != "")
            {
                string[] aa = str.Split(',');
                if (aa.Length > 3)
                {
                    newString = aa[0] + "," + aa[1] + "," + aa[2] + "等";
                }

                else
                {
                    newString = str;
                }
            }
            return newString;
        }

        /// <summary>
        /// 剪切右边的字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutRightString(object obj, int length)
        {
            string str = obj.ToString();
            string newString = str;
            if (str != "" && str.Length > length)
            {
                newString = str.Substring(str.Length - length);
            }
            return newString;
        }

        /// <summary>
        /// 将字符串转换到Html标记
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string ToHtml(string inputValue)
        {
            inputValue = inputValue.Replace("<", "&lt;");
            inputValue = inputValue.Replace(">", "&gt;");
            inputValue = inputValue.Replace("\n", "<br/>");
            inputValue = inputValue.Replace("\r\n", "<br/>");
            inputValue = inputValue.Replace(" ", "&nbsp;");
            inputValue = inputValue.Trim();
            return inputValue;
        }

        /// <summary>
        /// 将Html标记转换到字符串
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public static string ToText(string inputValue)
        {
            inputValue = inputValue.Replace("<br/>", "\r\n");
            inputValue = inputValue.Replace("&lt;", "<");
            inputValue = inputValue.Replace("&gt;", ">");
            inputValue = inputValue.Replace("&nbsp;", " ");
            inputValue = inputValue.Trim();
            return inputValue;
        }

        /// <summary>
        /// 去除不合法的字符，防止SQL注入式攻击
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static string SqlReplace(string strSql)
        {
            if (strSql != "")
            {
                // 去除不合法的字符，防止SQL注入式攻击
                strSql = strSql.Replace("'", "''");
                strSql = strSql.Replace("--", "");
                strSql = strSql.Replace(";", "");
            }
            return strSql;
        }

        /// <summary>
        /// 过滤字符串
        /// </summary>
        /// <param name="ParaValue"></param>
        /// <returns></returns>
        public static string GetSafeString(string ParaValue)
        {
            string SafeValue = ParaValue.Trim().Replace("'", "’");
            SafeValue = SafeValue.Replace("\"", "“");
            return SafeValue;
        }

        /// <summary>
        /// 将指定字符串显示成固定长度 并且将省略部分以 postCHar 代替
        /// </summary>
        /// <param name="OldStr"></param>
        /// <param name="length"></param>
        /// <param name="postString"></param>
        /// <returns></returns>
        public static string GetPartString(string OldStr, int length, string postString)
        {
            string result = string.Empty;

            if (length <= 0)
            {
                result = OldStr;
                return result;
            }

            if (!String.IsNullOrEmpty(OldStr))
            {
                string tempNoBlank = OldStr.Trim();

                if (tempNoBlank.Length > length)
                {
                    result = tempNoBlank.Substring(0, length);
                    result += postString;
                }
                else
                    result = tempNoBlank;
            }

            return result;
        }


        /// <summary>
        /// 将指定字符串显示成固定长度，如果长度超过则以。。。结尾
        /// </summary>
        /// <param name="OldStr"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetPartStringEndDot(string OldStr, int length)
        {
            return GetPartString(OldStr, length, "...");
        }


        public static string GetPartStringEndDot(object OldStr, int length)
        {
            if (OldStr is string)
                return GetPartString(OldStr as string, length, "...");
            else
                return OldStr.ToString();
        }

        public static readonly int PART_ENT_NAME_SHORT = 14;
        public static readonly int PART_ENT_NAME_MIDDLE = 20;
        public static readonly int PART_ENT_NAME_LONG = 50;

        public static readonly int PART_POS_DIRECTOR_SHORT = 5;
        public static readonly int PART_POS_DIRECTOR_MIDDLE = 8;
        public static readonly int PART_POS_DIRECTOR_LONG = 11;
    }

}
