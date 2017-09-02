using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Neon_X.Scripts.View
{
    public class PanelBase
    {//Panel基类
        protected GameObject panelObject;//panel的根节点对象
        public PanelBase() {

        }
        public PanelBase(GameObject obj, Transform parent)
        {
            panelObject = obj;
            panelObject.transform.SetParent(parent);
            panelObject.transform.localPosition = Vector3.forward * 20;
            panelObject.transform.localScale = Vector3.one;
            InitPanel();
        }
        public virtual void InitPanel() { }//实现方法来缓存实际要用的子对象
        public virtual void Show()
        {
            if (panelObject != null)
            {
                panelObject.SetActive(true);
            }
        }
        public virtual void Hide()
        {
            if (panelObject != null)
            {
                panelObject.SetActive(false);
            }
        }
        public virtual void Clean() { }
    }
}
