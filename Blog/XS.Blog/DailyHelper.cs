using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace XS.Blog
{
    public static class DailyHelper
    {
        /// <summary>
        /// 提取摘要
        /// </summary>
        /// <param name="content">文章内容</param>
        /// <param name="length">截取的长度</param>
        /// <param name="stripHtml">是否清除HTML代码</param>
        /// <returns></returns>
        public static string GetContentSummary(string content, int length, bool stripHtml)
        {
            var str = "";
            return GetContentSummary(content, length, stripHtml, true, ref str);
        }

        /// <summary>
        /// 提取摘要
        /// </summary>
        /// <param name="content">文章内容</param>
        /// <param name="length">截取的长度</param>
        /// <param name="stripHtml">是否清除HTML代码</param>
        /// <param name="hasImage">是否有图片</param>
        /// <param name="firstImageUrl">第一张图片的路径</param>
        /// <returns></returns>
        public static string GetContentSummary(string content, int length, bool stripHtml, bool hasImage, ref string firstImageUrl)
        {
            if (string.IsNullOrEmpty(content) || length == 0)
                return "";
            if (stripHtml)
            {
                var re = new Regex("<[^>]*>");
                content = re.Replace(content, "");
                content = content.Replace("　", "").Replace(" ", "");
                if (content.Length <= length)
                    return content;
                else
                    return content.Substring(0, length) + "……";
            }
            else
            {
                int pos = 0, npos = 0, size = 0, imgCount = 0;
                bool firststop = false, notr = false, noli = false;
                var sb = new StringBuilder();
                while (true)
                {
                    if (pos >= content.Length)
                        break;
                    string cur = content.Substring(pos, 1);
                    if (cur == "<")
                    {
                        string next = content.Substring(pos + 1, 3).ToLower();
                        if (next.IndexOf("p") == 0 && next.IndexOf("pre") != 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                        }
                        else if (next.IndexOf("/p") == 0 && next.IndexOf("/pr") != 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                                sb.Append("<br/>");
                        }
                        else if (next.IndexOf("br") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                                sb.Append("<br/>");
                        }
                        else if (next.IndexOf("img") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                if (imgCount < 3)
                                {
                                    if (imgCount == 0)
                                    {
                                        var url = content.Substring(pos, npos - pos);
                                        url = url.Substring(url.IndexOf("src=\"") + 5);
                                        firstImageUrl = url.Substring(0, url.IndexOf("\""));
                                    }
                                    if (hasImage)
                                    {
                                        sb.Append(content.Substring(pos, npos - pos));
                                    }
                                    imgCount++;
                                } 
                                //size += npos - pos + 1;
                            }
                        }
                        else if (next.IndexOf("li") == 0 || next.IndexOf("/li") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                            }
                            else
                            {
                                if (!noli && next.IndexOf("/li") == 0)
                                {
                                    sb.Append(content.Substring(pos, npos - pos));
                                    noli = true;
                                }
                            }
                        }
                        else if (next.IndexOf("tr") == 0 || next.IndexOf("/tr") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                            }
                            else
                            {
                                if (!notr && next.IndexOf("/tr") == 0)
                                {
                                    sb.Append(content.Substring(pos, npos - pos));
                                    notr = true;
                                }
                            }
                        }
                        else if (next.IndexOf("td") == 0 || next.IndexOf("/td") == 0)
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            if (size < length)
                            {
                                sb.Append(content.Substring(pos, npos - pos));
                            }
                            else
                            {
                                if (!notr)
                                {
                                    sb.Append(content.Substring(pos, npos - pos));
                                }
                            }
                        }
                        else
                        {
                            npos = content.IndexOf(">", pos) + 1;
                            sb.Append(content.Substring(pos, npos - pos));
                        }
                        if (npos <= pos)
                            npos = pos + 1;
                        pos = npos;
                    }
                    else
                    {
                        if (size < length)
                        {
                            sb.Append(cur);
                            size++;
                        }
                        else
                        {
                            if (!firststop)
                            {
                                sb.Append("…");
                                firststop = true;
                            }
                        }
                        pos++;
                    }

                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// 提取摘要
        /// </summary>
        /// <param name="content">文章内容</param>
        /// <param name="length">截取的长度</param>
        /// <param name="stripHtml">是否清除HTML代码</param>
        /// <param name="hasImage">是否有图片</param>
        /// <returns></returns>
        public static string GetContentSummary(string content, int length, bool stripHtml, bool hasImage)
        {
            var str = "";
            return GetContentSummary(content, length, stripHtml, hasImage, ref str);
        }
    }
}
