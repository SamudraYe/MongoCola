﻿/*
 * Created by SharpDevelop.
 * User: scs
 * Date: 2015/1/12
 * Time: 10:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.IO;
using ResourceLib.Method;

namespace MongoCola.Config
{
    /// <summary>
    ///     Description of SystemManager.
    /// </summary>
    public static class SystemConfig
    {
        #region"通用"

        /// 配置
        /// </summary>
        public static Config Config = new Config();

        /// <summary>
        ///     版本号
        /// </summary>
        public static string Version = string.Empty;

        /// <summary>
        ///     测试模式
        /// </summary>
        public static bool DebugMode = false;

        /// <summary>
        ///     是否为MONO
        /// </summary>
        public static bool MonoMode = false;

        #endregion

        #region"多语言"

        /// <summary>
        ///     是否使用默认语言
        /// </summary>
        /// <returns></returns>
        private static bool IsUseDefaultLanguage
        {
            get
            {
                if (Config == null)
                {
                    return true;
                }
                return (Config.LanguageFileName == "English.xml" ||
                        string.IsNullOrEmpty(Config.LanguageFileName));
            }
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public static void InitLanguage()
        {
            GuiConfig.IsUseDefaultLanguage = IsUseDefaultLanguage;
            //语言的初始化
            if (!IsUseDefaultLanguage)
            {
                var languageFile = "Language" + Path.DirectorySeparatorChar + Config.LanguageFileName;
                if (File.Exists(languageFile))
                {
                    GuiConfig.MStringResource.InitLanguage(languageFile);
                }
            }
        }

        #endregion
    }
}