using Assets.Neon_X.Scripts.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    private static ResourceManager instance;
    private void Awake()
    {
        instance = this;
    }
    //assetbundle资源管理类
    private IEnumerator LoadPrefabFromLocalAssetsPath(string name,Action<GameObject> OnLoadCompleted)
    {//此方法返回的是已经克隆后的预制体,debug,从本地项目文件加载未打包的prefab
        UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath(AppConst.LocalAssetsPath + name + ".prefab", typeof(GameObject));
        GameObject clone = (GameObject)Instantiate(prefab);
        yield return clone;
        OnLoadCompleted(clone);
    }
    private IEnumerator LoadPrefabsFromLocalAssetsPath(string[] names, Action<Dictionary<string,GameObject>> OnLoadCompleted)
    {//此方法返回的是已经克隆后的预制体数组,debug,从本地项目文件加载未打包的prefab数组
        Dictionary<string, GameObject> objects = new Dictionary<string, GameObject>();
        for (int i = 0; i < names.Length; i++)
        {
            UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath(AppConst.LocalAssetsPath + names[i] + "Panel.prefab", typeof(GameObject));
            GameObject clone = (GameObject)Instantiate(prefab);
            yield return clone;
            objects.Add(names[i], clone);
        }
        OnLoadCompleted(objects);
    }
    private IEnumerator LoadPrefabFromAssetbundle(string name, Action<GameObject> OnLoadCompleted)
    {//此方法返回的是已经克隆后的预制体，release，使用WWW加载打包好的Assetbundle
        WWW www = WWW.LoadFromCacheOrDownload(AppConst.AssetsPath,1);
        yield return www;
        UnityEngine.Object obj = www.assetBundle.LoadAsset(name);
        GameObject clone = (GameObject)Instantiate(obj);
        yield return clone;
        OnLoadCompleted(clone);
        www.assetBundle.Unload(false);
    }
    private IEnumerator LoadPrefabsFromAssetbundle(string[] names, Action<Dictionary<string, GameObject>> OnLoadCompleted)
    {//此方法返回的是已经克隆后的预制体，release，使用WWW加载打包好的Assetbundle
        WWW www = WWW.LoadFromCacheOrDownload(AppConst.AssetsPath, 1);
        yield return www;
        Dictionary<string, GameObject> objects = new Dictionary<string, GameObject>();
        for (int i = 0; i < names.Length; i++)
        {
            UnityEngine.Object obj = www.assetBundle.LoadAsset(names[i]+ "Panel");
            GameObject clone = (GameObject)Instantiate(obj);
            yield return clone;
            objects.Add(names[i], clone);
        }
        OnLoadCompleted(objects);
        www.assetBundle.Unload(false);
    }
    public static void LoadPrefabAsync(string name, Action<GameObject> OnLoadCompleted)
    {//加载单个预制体
#if UNITY_EDITOR    
        instance.StartCoroutine(instance.LoadPrefabFromLocalAssetsPath(name, OnLoadCompleted));
#elif UNITY_ANDROID
        instance.StartCoroutine(instance.LoadPrefabFromAssetbundle(name, OnLoadCompleted));
#endif
    }
    public static void LoadPrefabsAsync(string[] names, Action<Dictionary<string, GameObject>> OnLoadCompleted)
    {//批量加载预制体
#if UNITY_EDITOR    
        instance.StartCoroutine(instance.LoadPrefabsFromLocalAssetsPath(names, OnLoadCompleted));
#elif UNITY_ANDROID
        instance.StartCoroutine(instance.LoadPrefabsFromAssetbundle(names, OnLoadCompleted));
#endif
    }
}
