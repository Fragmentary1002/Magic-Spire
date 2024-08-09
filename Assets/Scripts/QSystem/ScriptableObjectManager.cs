using System.Collections.Generic;
using QFramework;
using UnityEngine;
using UnityEditor;

namespace QSystem
{
    public class ScriptableObjectManager:AbstractSystem
    {
        private ResLoader mResLoader = ResLoader.Allocate();
        protected override void OnInit()
        {
            InitConfig();
        }

        private void InitConfig()
        {
           var cur= mResLoader.LoadSync<GameObject>("Cards");
            Debug.Log(cur);
        }
    }
}