using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Neon_X.Scripts.View
{
    public class StartPanel : PanelBase
    {//Start页面view类
        public GameObject StartBtn;
        public StartPanel(GameObject obj, Transform parent) : base(obj, parent)
        {
            Debug.Log("StartPanel OnCreate");
        }
        public override void InitPanel()
        {
            Debug.Log("StartPanel InitPanel");
            base.InitPanel();
            StartBtn = panelObject.transform.Find("StartBtn").gameObject;
            StartBtn.AddComponent<UIEventListener>();
        }
    }
}
