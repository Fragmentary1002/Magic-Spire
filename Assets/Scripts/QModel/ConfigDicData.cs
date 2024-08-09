using System.Collections.Generic;
using QFramework;
using UnityEngine;

namespace QModel
{
    public class ConfigDicData:AbstractModel
    {

        public Dictionary<string, Dictionary<string,GameObject>> ConfigDic=new Dictionary<string,Dictionary<string,GameObject>>();
        protected override void OnInit()
        {
        }
        
        public void SetFragDic(string poolName, string s,GameObject go)
        {
            ConfigDic[poolName][s] = go;
        }
        
    }
}