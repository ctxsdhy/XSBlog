
namespace XS.Framework.Utility.Serialization
{
    /// <summary>
    /// 序列化接口
    /// </summary>
    public interface ISerializer
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string input);
    }
}