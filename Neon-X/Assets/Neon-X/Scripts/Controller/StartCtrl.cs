using Assets.Neon_X.Scripts.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Neon_X.Scripts.Controller
{
    public class StartCtrl:CtrlBase
    {//Start页面控制器
        public StartPanel view;
        public StartCtrl(PanelBase _view):base(_view){}
        public override void Init(PanelBase _view)
        {
            view = (StartPanel)_view;
            Debug.Log("StartCtrl Init");
            UIEventListener.Get(view.StartBtn).onClick += OnStartBtnClick;
        }

        private void OnStartBtnClick(GameObject go)
        {
            Debug.Log(go.name+" click");
        }
    }
}
