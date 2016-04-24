using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using XS.Framework.Common.Tip;

namespace XS.Framework.Utility
{
	/// <summary>
	/// ״̬��ʾ��
	/// </summary>
	public class TipHelper
	{
		/// <summary>
		/// �Ӵ���״̬�л����������˼
		/// </summary>
		/// <param name="status">����״̬</param>
		/// <returns></returns>
        public static string GetTip(ProcessStatus status)
		{
			foreach (MemberInfo mi in status.GetType().GetMembers())
			{
				if( mi.Name ==status.ToString())
					return ProcessCustomAttributes(mi);
			}
            return string.Empty;
        }

        /// <summary>
        /// �Ӵ���״̬�л����������˼
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetTip(string str)
		{
			try
			{
                ProcessStatus status = (ProcessStatus)Enum.Parse(typeof(ProcessStatus), str);
                return GetTip(status);
			}
			catch
			{
                return string.Empty;
            }
		}

        #region ͨ�ô���
        /// <summary>
        ///  �Ӵ���״̬�л����������˼
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetTip<T>(T status)
        {
            MemberInfo[] memberList = status.GetType().GetMembers();
            foreach (MemberInfo mi in memberList)
            {
                if (mi.Name == status.ToString())
                    return ProcessCustomAttributes(mi);
            }
            return string.Empty;
        }

        /// <summary>
        ///  �Ӵ���״̬�л����������˼
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetTip<T>(int status)
        {
            var enumStatus = (T)Enum.Parse(typeof(T), status.ToString());
            return GetTip(enumStatus);
        }

        /// <summary>
        /// ͨ�����ֵõ�Ӣ���ַ���
        /// </summary>
        public static string GetTip<T>(Type enumType, int intItems)
        {
            Array list = Enum.GetValues(enumType);
            foreach(T item in list)
            {
                if (Convert.ToInt32(item) == intItems)
                    return GetTip(item);
            }
            return string.Empty;
        }

	    /// <summary>
        /// ��ó�Ա�����������Ϣ
        /// </summary>
        /// <param name="info">��Ա��Ϣ</param>
        /// <returns></returns>
        private static string ProcessCustomAttributes(MemberInfo info)
        {
            TipAttribute myAttr;
            object[] objList = info.GetCustomAttributes(false);
            foreach (Attribute a in objList)
            {
                myAttr = a as TipAttribute;
                if (myAttr != null)
                {
                    return myAttr.Description;
                }
            }
            return null;
        }

        /// <summary>
        /// ���ö��List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
	    public static Dictionary<string, string> GetTipList<T>()
	    {
            Dictionary<string, string> dicList = new Dictionary<string, string>();
            foreach (object o in Enum.GetValues(typeof(T)))
            {
                var item = (T)Enum.Parse(typeof(T), o.ToString());
                dicList.Add(((int)o).ToString(), GetTip(item));
            }
	        return dicList;
	    } 
        #endregion
	}
}
