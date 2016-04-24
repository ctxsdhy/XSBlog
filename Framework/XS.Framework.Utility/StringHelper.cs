using System;
using System.Text;

namespace XS.Framework.Utility
{
    /// <summary>
    /// �ַ����������߼�
    /// </summary>
    public class StringHelper
    {

        /// <summary>
        /// ���ַ����е�β��ɾ��ָ�����ַ���
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="removedString"></param>
        /// <returns></returns>
        public static string Remove(string sourceString, string removedString)
        {
            try
            {
                if (sourceString.IndexOf(removedString) < 0)
                    throw new Exception("ԭ�ַ����в������Ƴ��ַ�����");
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
        /// ��ȡ��ַ��ұߵ��ַ���
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
        /// ��ȡ��ַ���ߵ��ַ���
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
        /// ȥ�����һ������
        /// �޸���Ϊԭ���Ὣ a,b,c���봦����� a,b �������ʧ�˲������� shizy 20091211
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
        /// ���������ָ����Ķ��ַ����ϲ�
        /// �� a,b �� c,d �ϲ���Ϊ a,b,c,d
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
        /// ɾ�����ɼ��ַ�
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
        /// ��ȡ����Ԫ�صĺϲ��ַ���
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
        ///		��ȡĳһ�ַ������ַ��������г��ֵĴ���
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
        ///     ��ȡĳһ�ַ������ַ����г��ֵĴ���
        /// </summary>
        /// <param name="sourceString" type="string">
        ///     <para>
        ///         ԭ�ַ���
        ///     </para>
        /// </param>
        /// <param name="findString" type="string">
        ///     <para>
        ///         ƥ���ַ���
        ///     </para>
        /// </param>
        /// <returns>
        ///     ƥ���ַ�������
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
        /// ��ȡ��startString��ʼ��ԭ�ַ�����β�������ַ�   
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
        /// ɾ����beginRemovedString��ʼ��endRemovedString�ַ�����β�������ַ�   
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
        /// �����ַ�������ʵ���ȣ�һ�������ַ��൱��������λ����(ʹ��Encoding��)
        /// </summary>
        /// <param name="str">ָ���ַ���</param>
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
        /// ���ֽ���Ҫ���ַ�����λ��
        /// </summary>
        /// <param name="intIns">�ַ�����λ��</param>
        /// <param name="strTmp">Ҫ������ַ���</param>
        /// <returns>�ֽڵ�λ��</returns>
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
        /// ������ַ����������ұ��ԡ�...������ַ����Դﵽָ���ĳ��ȡ�
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
        /// ������ַ����������ұ���ָ���ĳ�������ַ����Դﵽָ���ĳ��ȡ�
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
        /// �ַ�������
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
                    newString = aa[0] + "," + aa[1] + "," + aa[2] + "��";
                }

                else
                {
                    newString = str;
                }
            }
            return newString;
        }

        /// <summary>
        /// �����ұߵ��ַ���
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
        /// ���ַ���ת����Html���
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
        /// ��Html���ת�����ַ���
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
        /// ȥ�����Ϸ����ַ�����ֹSQLע��ʽ����
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static string SqlReplace(string strSql)
        {
            if (strSql != "")
            {
                // ȥ�����Ϸ����ַ�����ֹSQLע��ʽ����
                strSql = strSql.Replace("'", "''");
                strSql = strSql.Replace("--", "");
                strSql = strSql.Replace(";", "");
            }
            return strSql;
        }

        /// <summary>
        /// �����ַ���
        /// </summary>
        /// <param name="ParaValue"></param>
        /// <returns></returns>
        public static string GetSafeString(string ParaValue)
        {
            string SafeValue = ParaValue.Trim().Replace("'", "��");
            SafeValue = SafeValue.Replace("\"", "��");
            return SafeValue;
        }

        /// <summary>
        /// ��ָ���ַ�����ʾ�ɹ̶����� ���ҽ�ʡ�Բ����� postCHar ����
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
        /// ��ָ���ַ�����ʾ�ɹ̶����ȣ�������ȳ������ԡ�������β
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
