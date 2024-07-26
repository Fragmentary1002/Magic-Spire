using System;
using FightFSM;
using UnityEditor;
using UnityEngine;
using QFramework;
using System.Collections.Generic;
using System.Collections;

[Serializable]
public class OpenPanelName
{
    /// <summary>
    /// 页面的名字
    /// </summary>
    public string PanelName;

    /// <summary>
    /// 层级名字
    /// </summary>
    public UILevel Level;

    [SerializeField] public List<UIPanelTesterInfo> mOtherPanels;

}


public class GameManager: MonoSingleton<GameManager>
{
    [SerializeField]public List<OpenPanelName> pages;
    
    private void Awake()
    {
        ResKit.Init();
        
    }

    private IEnumerator Start()
    {
        UIKit.Root.SetResolution(1920,1080,0);

        foreach (var page in pages)
        {
            yield return new WaitForSeconds(0.2f);
            
            UIKit.OpenPanel(page.PanelName, page.Level);

            page.mOtherPanels.ForEach(panelTesterInfo => { UIKit.OpenPanel(panelTesterInfo.PanelName, panelTesterInfo.Level); });
        }
    }
}
