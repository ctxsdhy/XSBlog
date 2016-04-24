using System.Web.Script.Serialization;

namespace XS.Framework.Utility.Serialization
{
    /// <summary>
    /// 序列化Json数据格式类
    /// </summary>
    public class JsonSerializer:ISerializer
    {
        /// <summary>
        /// 定义一个静态只读的JavaScriptSerializer类
        /// </summary>
        private static readonly JavaScriptSerializer Serializer;

        /// <summary>
        /// 静态构造函数，构造一个JavaScriptSerializer一个类。
        /// </summary>
        static JsonSerializer()
        {
            Serializer = new JavaScriptSerializer();
        }
        /// <summary>
        /// 将对象序列为Json数据格式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Serialize<T>(T obj)
        {
            string result = Serializer.Serialize(obj);
            Serializer.MaxJsonLength = int.MaxValue;
            return result;
        }

        /// <summary>
        /// 将Json数据格式的字符串反序列化为一个对象
        /// </summary>
        /// <returns></returns>
        public T Deserialize<T>(string josnString)
        {
            T obj = Serializer.Deserialize<T>(josnString);
            Serializer.MaxJsonLength = int.MaxValue;
            return obj;
        }

        /// <summary>
        /// 将对象序列为Json数据格式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject<T>(T obj)
        {
            string result = Serializer.Serialize(obj);
            Serializer.MaxJsonLength = int.MaxValue;
            return result;
        }

        /// <summary>
        /// 将Json数据格式的字符串反序列化为一个对象
        /// </summary>
        /// <returns></returns>
        public static T DeserializeObject<T>(string josnString)
        {
            T obj = Serializer.Deserialize<T>(josnString);
            Serializer.MaxJsonLength = int.MaxValue;
            return obj;
        }
    }
} 