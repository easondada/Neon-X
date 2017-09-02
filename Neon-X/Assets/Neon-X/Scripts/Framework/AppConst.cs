using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Neon_X.Scripts.Framework
{
    public class AppConst
    {
        public static bool IsDebug = true;//是否是测试模式
        public static string LocalAssetsPath = "Assets/Neon-X/Prefabs/UI/";//本地的资源路径，测试用

        private static string _AssetsPath = Application.streamingAssetsPath + "/";//发布时的资源路径
        public static string AssetsPath {
            get {
                return _AssetsPath;
            }
        }
    }
}
