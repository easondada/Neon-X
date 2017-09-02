using Assets.Neon_X.Scripts.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Neon_X.Scripts.Controller
{
    public class CtrlBase
    {//Controller基类

        public CtrlBase(PanelBase _view)
        {
            Init(_view);
        }
        public virtual void Init(PanelBase view) { }
    }
}
