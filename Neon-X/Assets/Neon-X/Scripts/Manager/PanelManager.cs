using Assets.Neon_X.Scripts.Controller;
using Assets.Neon_X.Scripts.View;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

    //private static Dictionary<string, PanelBase> panelDict
    //    = new Dictionary<string, PanelBase>();
    private static string[] panelNames = new string[]
    {
        "Start",
    };
    public static void CreatePanels(Transform parent,Action<List<System.Object>> OnCreatePanels)
    {
        List<System.Object> ctrls = new List<System.Object>();
        ResourceManager.LoadPrefabsAsync(panelNames, dict =>
        {
            foreach (var item in dict)
            {   //生成对应的panel类
                string className = "Assets.Neon_X.Scripts.View." + item.Key + "Panel";
                Type t = Type.GetType(className);
                object[] parameters = new object[2];
                parameters[0] = item.Value;
                parameters[1] = parent;
                object panel_instance = Activator.CreateInstance(t, parameters);
                //生成对应的controller类
                string className2 = "Assets.Neon_X.Scripts.Controller." + item.Key + "Ctrl";
                Type t2 = Type.GetType(className2);
                object[] parameters2 = new object[1];
                parameters2[0] = panel_instance;
                object ctrl_instance = Activator.CreateInstance(t2, parameters2);
                ctrls.Add(ctrl_instance);
            }
            OnCreatePanels(ctrls);
        });
    }
}
