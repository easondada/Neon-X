using Assets.Neon_X.Scripts.Controller;
using Assets.Neon_X.Scripts.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlManager : MonoBehaviour {

    //保存全局的控制器,字典的key保证每个ctrl只有一个实例
    private static Dictionary<string, CtrlBase> ctrlDict
        = new Dictionary<string, CtrlBase>();
    private static Transform uicamera;
    public static void Init()
    {
        ResourceManager.LoadPrefabAsync("UIRoot", obj =>
        {
            uicamera = obj.GetComponentInChildren<UICamera>().transform;
            PanelManager.CreatePanels(uicamera,ctrls =>
            {
                ctrls.ForEach(o => {
                    ctrlDict.Add(o.GetType().Name,(CtrlBase)o);
                });
            });
        });
    }
    public static CtrlBase GetCtrl(string name)
    {
        return ctrlDict[name];
    }
}
