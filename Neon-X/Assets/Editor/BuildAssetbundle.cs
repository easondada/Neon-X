using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildAssetbundle : MonoBehaviour {

    [MenuItem("BuildAssetBundles/BuildAssetBundle for Android")]
    private static void BuildAssetBundleForAndroid()//
    {//此方法用于打包assetbundle
     //将目标文件夹下的prefab全部打包到StreamingAssets文件下
     //编译到目标平台前才需要做
     //测试时不需要打包
        string exportPath = Application.streamingAssetsPath + "/";
        Debug.Log(Application.streamingAssetsPath);
        string[] guids = AssetDatabase.FindAssets("t:GameObject", new string[] { "Assets/Neon-X/Prefabs/UI" });
        //从GUID获得资源所在路径
        List<string> paths = new List<string>();//资源的路径
        for (int i = 0; i < guids.Length; i++)
        {
            paths.Add(AssetDatabase.GUIDToAssetPath(guids[i]));
        }
        List<GameObject> objs = new List<GameObject>();//资源对象
        paths.ForEach(p =>
        {
            objs.Add(AssetDatabase.LoadAssetAtPath(p, typeof(GameObject)) as GameObject);
        });
        objs.ForEach(o =>
        {
            string targetPath = exportPath + o.name + ".assetbundle";
            BuildPipeline.BuildAssetBundle(o, null, targetPath,
                BuildAssetBundleOptions.CollectDependencies, BuildTarget.Android);
        });
    }
    [MenuItem("BuildAssetBundles/CheckAssets")]
    private static void CheckAssets()
    {     //string targetPath = EditorUtility.OpenFolderPanel("选择文件夹","","");
          //Debug.Log("目标文件夹" + targetPath);
          //Selection.GetFiltered
        string[] guids = AssetDatabase.FindAssets("t:GameObject", new string[] { "Assets/Neon-X/Prefabs/UI" });
            //从GUID获得资源所在路径
        List<string> paths = new List<string>();
        for (int i = 0; i < guids.Length; i++)
        {          
            paths.Add(AssetDatabase.GUIDToAssetPath(guids[i]));
        }
        for (int i = 0; i < paths.Count; i++)
        {
            Debug.Log(">>" + paths[i]);
        }
    }

}
