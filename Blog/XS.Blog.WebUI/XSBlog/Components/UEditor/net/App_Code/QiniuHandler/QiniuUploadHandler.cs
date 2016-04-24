using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Qiniu.IO;
using Qiniu.RS;
using XS.Blog.Components.Helper;

/// <summary>
/// UploadHandler 的摘要说明
/// </summary>
public class QiniuUploadHandler : Handler
{

    public UploadConfig UploadConfig { get; private set; }
    public UploadResult Result { get; private set; }

    public QiniuUploadHandler(HttpContext context, UploadConfig config)
        : base(context)
    {
        this.UploadConfig = config;
        this.Result = new UploadResult() { State = UploadState.Unknown };
    }

    public override void Process()
    {
        byte[] uploadFileBytes = null;
        string uploadFileName = null;

        try
        {
            if (UploadConfig.Base64)
            {
                uploadFileName = UploadConfig.Base64Filename;
                uploadFileBytes = Convert.FromBase64String(Request[UploadConfig.UploadFieldName]);
            }
            else
            {
                var file = Request.Files[UploadConfig.UploadFieldName];
                uploadFileName = file.FileName;

                if (!CheckFileType(uploadFileName))
                {
                    Result.State = UploadState.TypeNotAllow;
                    WriteResult();
                    return;
                }
                if (!CheckFileSize(file.ContentLength))
                {
                    Result.State = UploadState.SizeLimitExceed;
                    WriteResult();
                    return;
                }

                uploadFileBytes = new byte[file.ContentLength];
                try
                {
                    file.InputStream.Read(uploadFileBytes, 0, file.ContentLength);
                }
                catch (Exception)
                {
                    Result.State = UploadState.NetworkError;
                    WriteResult();
                }
            }

            Result.OriginFileName = uploadFileName;

            var savePath = PathFormatter.Format(uploadFileName, UploadConfig.PathFormat);
            var localPath = Server.MapPath(savePath);

            #region 不再需要储存文件到服务器

            //if (!Directory.Exists(Path.GetDirectoryName(localPath)))
            //{
            //    Directory.CreateDirectory(Path.GetDirectoryName(localPath));
            //}
            //File.WriteAllBytes(localPath, uploadFileBytes);
            //Result.Url = savePath;
            //Result.State = UploadState.Success;

            #endregion

            #region 旧代码

            //IOClient target = new IOClient();
            //var extra = new PutExtra();
            //extra.MimeType = "text/plain";
            //extra.Crc32 = 123;
            //extra.CheckCrc = CheckCrcType.CHECK;
            //extra.Params = new Dictionary<string, string>();
            //var put = new PutPolicy("ctxsdhy-blog");
            ////上传结束回调事件
            //target.PutFinished += new EventHandler<PutRet>((o, e) =>
            //{
            //file.Del();
            //if (e.OK)
            //{
            //    RSHelper.RSDel(Bucket, file.FileName);
            //}
            //});

            //PutRet ret = target.PutFile(put.Token(), Guid.NewGuid().ToString(), localPath, extra);
            //直接通过二进制流上传
            //PutRet ret = target.Put(put.Token(), Guid.NewGuid().ToString(), new MemoryStream(uploadFileBytes), extra);

            #endregion

            GetResult(uploadFileBytes);
        }
        catch (Exception e)
        {
            //Result.State = UploadState.FileAccessError;
            //Result.ErrorMessage = e.Message;
            GetResult(uploadFileBytes);
        }
        finally
        {
            WriteResult();
        }
    }

    private UploadResult GetResult(byte[] uploadFileBytes)
    {
        var ret = QiniuHelper.GetResult(uploadFileBytes);

        if (ret.OK)
        {
            Result.Url = QiniuHelper.GetUrl(ret.key); ;
            Result.key = ret.key;
            Result.State = UploadState.Success;
        }

        return Result;
    }

    private void WriteResult()
    {
        this.WriteJson(new
        {
            state = GetStateMessage(Result.State),
            url = Result.Url,
            title = Result.OriginFileName,
            original = Result.OriginFileName,
            error = Result.ErrorMessage,
            imageKey = Result.key
        });
    }

    private string GetStateMessage(UploadState state)
    {
        switch (state)
        {
            case UploadState.Success:
                return "SUCCESS";
            case UploadState.FileAccessError:
                return "文件访问出错，请检查写入权限";
            case UploadState.SizeLimitExceed:
                return "文件大小超出服务器限制";
            case UploadState.TypeNotAllow:
                return "不允许的文件格式";
            case UploadState.NetworkError:
                return "网络错误";
        }
        return "未知错误";
    }

    private bool CheckFileType(string filename)
    {
        var fileExtension = Path.GetExtension(filename).ToLower();
        return UploadConfig.AllowExtensions.Select(x => x.ToLower()).Contains(fileExtension);
    }

    private bool CheckFileSize(int size)
    {
        return size < UploadConfig.SizeLimit;
    }
}
