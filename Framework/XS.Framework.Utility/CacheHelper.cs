using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;

namespace XS.Framework.Utility
{
    /// <summary>
    /// 缓存帮助类
    /// </summary>
    public class CacheHelper
    {
        private static readonly Cache Cache;

        private static readonly object SyncRoot = new object();

        /// <summary>
        /// 静态构造, 形成全局唯一，类似 singleton 模式
        /// </summary>
        static CacheHelper()
        {
            if (Cache == null) //确保不会受多线程影响
            {
                lock (SyncRoot)
                {
                    if (Cache == null)
                    {
                        Cache = HttpRuntime.Cache;
                    }
                }
            }
        }

        /// <summary>
        /// 通过缓存健值，取得相应的缓存对象
        /// </summary>
        /// <param name="cacheKey">缓存健值</param>
        /// <returns>缓存对象</returns>
        public static object GetCacheItem(string cacheKey)
        {
            return Cache[cacheKey];
        }

        /// <summary>
        /// 新增一个缓存对象，持久保存
        /// </summary>
        /// <param name="cacheKey">缓存健值</param>
        /// <param name="objObject">要新增的缓存对象</param>
        public static void Insert(string cacheKey, object objObject)
        {
            Cache.Insert(cacheKey, objObject);
        }

        /// <summary>
        /// 新增一个缓存对象，从当前开始计时，相对保存
        /// </summary>
        /// <param name="cacheKey">缓存健值</param>
        /// <param name="objObject">要新增的缓存对象</param>
        /// <param name="slidingExpiration">相对时间值</param>
        public static void Insert(string cacheKey, object objObject, TimeSpan slidingExpiration)
        {
            Cache.Insert(cacheKey, objObject, null, Cache.NoAbsoluteExpiration, slidingExpiration);
        }

        /// <summary>
        /// 新增一个缓存对象，以绝对时间保存
        /// </summary>
        /// <param name="cacheKey">缓存健值</param>
        /// <param name="objObject">要新增的缓存对象</param>
        /// <param name="absoluteExpiration">绝对时间值</param>
        public static void Insert(string cacheKey, object objObject, DateTime absoluteExpiration)
        {
            Cache.Insert(cacheKey, objObject, null, absoluteExpiration, Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 新增一个缓存对象，绝对过期与相对过期中只能选择一种保存
        /// </summary>
        /// <param name="cacheKey">缓存健值</param>
        /// <param name="objObject">要新增的缓存对象</param>
        /// <param name="absoluteExpiration">绝对时间值</param>
        /// <param name="slidingExpiration">相对时间值</param>
        public static void Insert(string cacheKey, object objObject, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            Cache.Insert(cacheKey, objObject, null, absoluteExpiration, slidingExpiration);
        }

        /// <summary>
        /// 新增一个缓存对象，文件依赖保存
        /// </summary>
        /// <param name="cacheKey">缓存健值</param>
        /// <param name="objObject">要新增的缓存对象</param>
        /// <param name="objDependency">文件依赖对象</param>
        public static void Insert(string cacheKey, object objObject, CacheDependency objDependency)
        {
            Cache.Insert(cacheKey, objObject, objDependency);
        }

        /// <summary>
        /// 新增一个缓存对象，文件依赖保存
        /// </summary>
        /// <param name="cacheKey">缓存健值</param>
        /// <param name="objObject">要新增的缓存对象</param>
        /// <param name="filePath">所依赖的文件名称</param>
        public static void Insert(string cacheKey, object objObject, string filePath)
        {
            var objDependency = new CacheDependency(filePath);
            Cache.Insert(cacheKey, objObject, objDependency);
        }

        /// <summary>
        /// 新增一个缓存对象，文件依赖和相对时间过期保存
        /// </summary>
        /// <param name="cacheKey">缓存健值</param>
        /// <param name="objObject">要新增的缓存对象</param>
        /// <param name="objDependency">文件依赖对象</param>
        /// <param name="slidingExpiration">相对时间</param>
        public static void Insert(string cacheKey, object objObject, CacheDependency objDependency, TimeSpan slidingExpiration)
        {
            Cache.Insert(cacheKey, objObject, objDependency, Cache.NoAbsoluteExpiration, slidingExpiration, CacheItemPriority.Normal, null);
        }

        /// <summary>
        /// 新增一个缓存对象，文件依赖和相对时间过期保存
        /// </summary>
        /// <param name="cacheKey">缓存健值</param>
        /// <param name="objObject">要新增的缓存对象</param>
        /// <param name="filePath">所依赖的文件名称</param>
        /// <param name="slidingExpiration">相对时间</param>
        public static void Insert(string cacheKey, object objObject, string filePath, TimeSpan slidingExpiration)
        {
            var objDependency = new CacheDependency(filePath);
            Cache.Insert(cacheKey, objObject, objDependency, Cache.NoAbsoluteExpiration, slidingExpiration, CacheItemPriority.Normal, null);
        }

        /// <summary>
        /// 新增一个缓存对象
        /// </summary>
        /// <param name="cacheKey">缓存健值</param>
        /// <param name="objObject">要新增的缓存对象</param>
        /// <param name="objDependency">文件依赖对象</param>
        /// <param name="absoluteExpiration">绝对时间</param>
        /// <param name="slidingExpiration">相对时间</param>
        /// <param name="priority">优先级</param>
        /// <param name="onRemoveCallback">缓存移除回调参数</param>
        public static void Insert(string cacheKey, object objObject, CacheDependency objDependency, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
        {
            Cache.Insert(cacheKey, objObject, objDependency, absoluteExpiration, slidingExpiration, priority, onRemoveCallback);
        }

        /// <summary>
        /// 新增一个缓存对象
        /// </summary>
        /// <param name="cacheKey">缓存健值</param>
        /// <param name="objObject">要新增的缓存对象</param>
        /// <param name="filePath">所依赖的文件名称</param>
        /// <param name="absoluteExpiration">绝对时间</param>
        /// <param name="slidingExpiration">相对时间</param>
        /// <param name="priority">优先级</param>
        /// <param name="onRemoveCallback">缓存移除回调参数</param>
        public static void Insert(string cacheKey, object objObject, string filePath, DateTime absoluteExpiration, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
        {
            var objDependency = new CacheDependency(filePath);
            Cache.Insert(cacheKey, objObject, objDependency, absoluteExpiration, slidingExpiration, priority, onRemoveCallback);
        }

        /// <summary>
        /// 删除一个缓存对象
        /// </summary>
        /// <param name="cacheKey">缓存健值</param>
        public static void RemoveCacheItem(string cacheKey)
        {
            if (!string.IsNullOrEmpty(cacheKey) && Cache[cacheKey] != null)
            {
                Cache.Remove(cacheKey);
            }
        }

        /// <summary>
        /// 通过正则表达式，匹配来删除一个或多个缓存对象
        /// </summary>
        /// <param name="pattern">正则表达式</param>
        public static void RemoveCacheItemByPattern(string pattern)
        {
            IDictionaryEnumerator enumerator = Cache.GetEnumerator();
            var regex1 = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            while (enumerator.MoveNext())
            {
                if (regex1.IsMatch(enumerator.Key.ToString()))
                {
                    Cache.Remove(enumerator.Key.ToString());
                }
            }
        }

        /// <summary>
        /// 删除全部缓存对象
        /// </summary>
        public static void RemoveAllCacheItem()
        {
            IDictionaryEnumerator enumerator = Cache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Cache.Remove(enumerator.Key.ToString());
            }
        }
    }
}
