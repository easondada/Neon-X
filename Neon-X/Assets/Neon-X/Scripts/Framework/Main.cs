using Assets.Neon_X.Scripts.Controller;
using Assets.Neon_X.Scripts.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    //整个游戏的入口
    private UIRoot root;
    // Use this for initialization
    void Start () {
        root = GetComponentInChildren<UIRoot>(true);
        root.gameObject.SetActive(true);
        DontDestroyOnLoad(this.gameObject);
        //添加管理器组件
        ManagerCenter.resourceManager = gameObject.AddComponent<ResourceManager>();
        ManagerCenter.ctrlManager = gameObject.AddComponent<CtrlManager>();

        CtrlManager.Init();
        root.gameObject.SetActive(false);
    }   

}
