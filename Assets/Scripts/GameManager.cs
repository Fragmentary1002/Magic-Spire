using System;
using FightFSM;
using UnityEditor;
using UnityEngine;
using QFramework;
using System.Collections.Generic;
using System.Collections;


public class GameManager: MonoSingleton<GameManager>
{
    private void Awake()
    {
        ResKit.Init();
        UIKit.Root.SetResolution(1920,1080,0);
    }


}
