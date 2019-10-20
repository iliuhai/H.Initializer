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
        internal static string DatabaseCreateUrl { get { return "/DbInit/DatabaseCreate"; } }

        /// <summary>
        /// 数据库更新页面地址
        /// </summary>
        internal static string DatabaseMigrateUrl { get { return "/DbInit/DatabaseMigrate"; } }

        /// <summary>
        /// 数据库异常页面地址
        /// </summary>
        internal static string DatabaseExceptionUrl { get { return "/DatabaseException"; } }

        /// <summary>
        /// 数据库是否可连接
        /// </summary>
        internal static bool CanConnect { get; set; }

        /// <summary>
        /// 数据库是否已迁移
        /// </summary>
        internal static bool IsMigrated { get; set; }
        
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
