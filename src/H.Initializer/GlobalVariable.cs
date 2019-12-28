using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace H.Initializer
{
    internal static class GlobalVariable
    {
        /// <summary>
        /// 数据库创建页面地址
        /// </summary>
        internal static string DatabaseCreateUrl { get { return "/Init/DatabaseCreate"; } }

        /// <summary>
        /// 数据库更新页面地址
        /// </summary>
        internal static string DatabaseUpdateUrl { get { return "/Init/DatabaseUpdate"; } }

        /// <summary>
        /// 初始化异常页面地址
        /// </summary>
        internal static string InitExceptionUrl { get { return "/Init/InitException"; } }

        /// <summary>
        /// 无权限页面地址
        /// </summary>
        internal static string NoPermissionUrl { get { return "/Init/NoPermission"; } }

        /// <summary>
        /// 数据库是否可连接
        /// </summary>
        internal static bool CanConnect { get; set; }

        /// <summary>
        /// 数据库是否已更新
        /// </summary>
        internal static bool IsUpdated{ get; set; }
        
        /// <summary>
        /// 初始化完成重定向地址
        /// </summary>
        internal static string CallbackUrl { get; set; }

        /// <summary>
        /// 数据库上下文对象
        /// </summary>
        internal static DbContext DbContext { get; set; }
    }
}
