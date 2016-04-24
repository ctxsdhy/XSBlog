using System;
using System.Collections;
using System.Reflection;

namespace XS.Framework.Utility
{
    /// <summary>
    /// 类解析助手
    /// </summary>
    public class TypeResolverHelper
    {
        private static readonly Hashtable AssemblyCaches = Hashtable.Synchronized(new Hashtable());
        /// <summary>
        /// 从程序集中获得类型
        /// </summary>
        /// <param name="assemblyString">程序集</param>
        /// <param name="classString">类名称</param>
        /// <returns></returns>
        public static Type ResolveType(string assemblyString, string classString)
        {
            //if (_assemblyCaches == null)
            //    _assemblyCaches = new Hashtable();
            if (!string.IsNullOrEmpty(assemblyString) && !string.IsNullOrEmpty(classString))
            {
                var s = new string[2] { classString, assemblyString };
                var assem = (Assembly)AssemblyCaches[s[1].Trim()];
                if (assem == null)
                {
                    assem = Assembly.Load(s[1].Trim());
                    if (!AssemblyCaches.Contains(s[1].Trim()))
                    {
                        lock (AssemblyCaches.SyncRoot)
                        {
                            AssemblyCaches.Add(s[1].Trim(), assem);
                        }
                    }
                }
                return assem.GetType(s[0]);
            }
            return null;
        }

        /// <summary>
        /// 创建一个类型的实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assemblyString"></param>
        /// <param name="classString"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(string assemblyString, string classString)
        {
            Type type = ResolveType(assemblyString, classString);
            var instance = (T)Activator.CreateInstance(type);

            return instance;
        }
    }
}
