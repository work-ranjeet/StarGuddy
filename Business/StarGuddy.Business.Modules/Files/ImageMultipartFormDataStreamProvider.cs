// -------------------------------------------------------------------------------
// <copyright file="ImageMultipartFormDataStreamProvider.cs" company="StarGuddy India">
// Copyright (c) 2017. All rights reserved.
// </copyright>
// -------------------------------------------------------------------------------
namespace StarGuddy.Business.Modules.Files
{
    using System.Net.Http;

    /// <summary>
    /// Image Multi Part Form Data Stream Provider
    /// </summary>
    public class ImageMultipartFormDataStreamProvider //: MultipartFormDataStreamProvider
    {
        public ImageMultipartFormDataStreamProvider(string path) //: base(path)
        {
        }

        //public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        //{
        //    //Make the file name URL safe and then use it & is the only disallowed url character allowed in a windows filename
        //    var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName) ? headers.ContentDisposition.FileName : "NoName";
        //    return name.Trim(new char[] { '"' })
        //                .Replace("&", "and");
        //}
    }
}