using System;
using FightFSM;
using UnityEditor;
using UnityEngine;
using QFramework;
public class GameManager: MonoSingleton<GameManager>
{
    private void Start()
    {
        ResKit.Init();
        UIKit.Root.SetResolution(1920,1080,0);
    }
}
