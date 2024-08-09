// using UnityEditor;
// using UnityEngine;
// using System;
// using System.Linq;
// using System.Collections.Generic;
// using System.IO;
// using System.Reflection;
//
// namespace Config.Gem
// {
//     public class GemEditorWindow : EditorWindow
//     {
//         private const float WIDTH_DIVISON = 0.3f;           // 左栏比例
//         private int selectedGemIndex = -1;                  // 选中Gem序号
//         private Vector2 leftScrollPos = Vector2.zero;
//         private GemCollection SO;                           // Gem SO
//         private SerializedObject SO_SO;
//
//         private SerializedObject currentGemSO;
//         private SerializedProperty currentGemSP;
//
//         private int maxLengthBuffer;
//         private static readonly string assetBundleName = "Gem";
//         public static readonly string defaultSOName = "GemCollection.asset";
//         public static readonly string defaultTagSOName = "GemTagData.asset";
//         private int selectedSubclassIndex = 0;
//         private int lastSelectSubclassIndex = 0;
//         private bool changedSubClassSelection = false;
//         private List<Type> subClasses;
//         private string[] subClassNames;
//
//         private void OnEnable()
//         {
//             Initialize();
//         }
//
//         [MenuItem("Tools/GemEditor")]
//         public static void OpenWindow()
//         {
//             GemEditorWindow wd = GetWindow<GemEditorWindow>();       // 唤出窗口
//             wd.titleContent = new GUIContent("Gem 编辑器"); // 添加标题
//             wd.Initialize();
//         }
//
//         private void Initialize()
//         {
//             UpdateSubClass();
//             UpdateLeftList();
//         }
//
//         private void UpdateSubClass()
//         {
//             Type baseType = typeof(BaseGem);
//             subClasses = Assembly.GetAssembly(baseType).GetTypes()
//                 .Where(t => t.IsSubclassOf(baseType) && !t.IsAbstract)
//                 .ToList();
//             subClassNames = subClasses.Select(c => c.Name).ToArray();
//             selectedSubclassIndex = 0;
//             lastSelectSubclassIndex = 0;
//             changedSubClassSelection = false;
//         }
//
//         private void UpdateLeftList()
//         {
//             string[] assetPaths = AssetDatabase.FindAssets("t:GemCollection");
//             if (assetPaths.Length <= 0)
//             {
//                 Debug.Log("没有数据");
//                 if (!Directory.Exists(GemPath.SO_PATH)) Directory.CreateDirectory(GemPath.SO_PATH);
//                 SO = CreateInstance<GemCollection>();
//                 var path = Path.Combine(GemPath.SO_PATH, defaultSOName);
//                 AssetDatabase.CreateAsset(SO, path);
//             }
//             else
//             {
//                 string assetPath = AssetDatabase.GUIDToAssetPath(assetPaths[0]);
//                 SO = AssetDatabase.LoadAssetAtPath<GemCollection>(assetPath);
//             }
//             maxLengthBuffer = SO.gemList.Count;
//             SO_SO = new SerializedObject(SO);
//         }
//
//         private void OnGUI()
//         {
//             // 左侧
//             float leftWidth = position.width * WIDTH_DIVISON;
//             Rect leftRect = new Rect(0, 0, leftWidth, position.height);
//             GUILayout.BeginArea(leftRect, EditorStyles.helpBox);
//             leftScrollPos = GUILayout.BeginScrollView(leftScrollPos);
//             GUIStyle leftListButtonStyle = new GUIStyle(GUI.skin.button)
//             {
//                 alignment = TextAnchor.MiddleLeft
//             };
//
//             for (int i = 0; i < SO.Size; i++)
//             {
//                 leftListButtonStyle.normal.textColor = i == selectedGemIndex ? Color.green : Color.white;
//                 if (GUILayout.Button(new GUIContent(string.Format("{0:000}", i) + ":" +
//                     ((SO.gemList[i] == null || string.IsNullOrEmpty(SO.gemList[i].GemName)) ? "NULL" : SO.gemList[i].GemName))
//                     , leftListButtonStyle))
//                 {
//                     if (selectedGemIndex == i) break;
//                     selectedGemIndex = i;
//                     GUIUtility.keyboardControl = 0;
//
//                     int index;
//                     if (SO.gemList[i] == null)
//                     {
//                         index = 0;
//                     }
//                     else
//                     {
//                         string t = SO.gemList[i].GetType().Name;
//                         index = Array.IndexOf(subClassNames, t);
//                         index = index < 0 ? 0 : index;
//                         currentGemSO = new SerializedObject(SO.gemList[i]);
//                     }
//
//                     lastSelectSubclassIndex = index;
//                     selectedSubclassIndex = index;
//                     changedSubClassSelection = false;
//                 }
//             }
//             GUILayout.FlexibleSpace();
//             GUILayout.EndScrollView();
//             GUILayout.BeginHorizontal();
//             maxLengthBuffer = EditorGUILayout.IntField(new GUIContent("最大Gem数量"), maxLengthBuffer);
//             if (GUILayout.Button(new GUIContent("修改")))
//             {
//                 if (maxLengthBuffer < SO.Size)
//                 {
//                     bool set = EditorUtility.DisplayDialog("重设最大Gem数量", "减少最大Gem数量会删除末尾的Gem，确认要修改吗？", "是", "否");
//                     if (set)
//                     {
//                         SO.Resize(maxLengthBuffer);
//                         selectedGemIndex = -1;
//
//                         DirectoryInfo directory = new DirectoryInfo(GemPath.GEM_PATH);
//                         FileInfo[] files = directory.GetFiles("Gem*.asset");
//
//                         foreach (FileInfo file in files)
//                         {
//                             string fileName = Path.GetFileNameWithoutExtension(file.Name);
//                             string fileIndexString = fileName.Substring(3).Split('.')[0];
//
//                             int index = int.Parse(fileIndexString);
//                             if (index >= SO.Size)
//                             {
//                                 AssetDatabase.DeleteAsset(Path.Combine(GemPath.GEM_PATH, file.Name));
//                                 Debug.Log("删除Gem：" + file.Name);
//                             }
//                         }
//                     }
//                 }
//                 else SO.Resize(maxLengthBuffer);
//             }
//             GUILayout.EndHorizontal();
//             GUILayout.EndArea();
//
//             if (selectedGemIndex < 0) return;
//
//             // 右侧
//             Rect rightRect = new Rect(leftWidth, 0, position.width - leftWidth, position.height);
//             GUILayout.BeginArea(rightRect, EditorStyles.helpBox);
//
//             selectedSubclassIndex = EditorGUILayout.Popup("类", selectedSubclassIndex, subClassNames);
//
//             changedSubClassSelection = selectedSubclassIndex != lastSelectSubclassIndex;
//             lastSelectSubclassIndex = selectedSubclassIndex;
//
//             if (changedSubClassSelection)
//             {
//                 SO.gemList[selectedGemIndex] = BaseGem.CreateInstance(selectedSubclassIndex == 0 ? "Gem" : subClassNames[selectedSubclassIndex], selectedGemIndex);
//                 CreateGemAsset(selectedGemIndex);
//                 currentGemSO = new SerializedObject(SO.gemList[selectedGemIndex]);
//             }
//
//             EditorGUILayout.Separator();
//             DrawDivider();
//
//             if (selectedSubclassIndex != 0)
//             {
//                 currentGemSP = currentGemSO.GetIterator();
//                 currentGemSP.NextVisible(true);
//                 currentGemSO.UpdateIfRequiredOrScript();
//                 while (currentGemSP.NextVisible(true))
//                 {
//                     EditorGUILayout.PropertyField(currentGemSP, true);
//                 }
//                 if (GUI.changed)
//                 {
//                     currentGemSO.ApplyModifiedProperties();
//                     SO_SO.ApplyModifiedProperties();
//                     EditorUtility.SetDirty(SO.gemList[selectedGemIndex]);
//                     EditorUtility.SetDirty(SO);
//                     AssetDatabase.SaveAssets();
//                 }
//             }
//
//             GUILayout.FlexibleSpace();
//             GUILayout.EndArea();
//         }
//
//         private void DrawDivider()
//         {
//             EditorGUILayout.BeginHorizontal();
//             GUILayout.FlexibleSpace();
//             GUILayout.Label("---------------------------------------------------------------------------------------------------------------");
//             GUILayout.FlexibleSpace();
//             EditorGUILayout.EndHorizontal();
//         }
//
//         private void CreateGemAsset(int index)
//         {
//             string fileName = "Gem" + string.Format("{0:000}", index) + ".asset";
//             string dir = Path.Combine(GemPath.GEM_PATH, fileName);
//             if (File.Exists(dir)) File.Delete(dir);
//
//             BaseGem gem = SO.gemList[index];
//             AssetDatabase.CreateAsset(gem, dir);
//         }
//     }
//
//     public static class GemPath
//     {
//         public static string SO_PATH
//         {
//             get
//             {
//                 var l = AssetDatabase.FindAssets("GemMgr t:Prefab");
//                 if (l.Length <= 0) throw new Exception("GemMgr.prefab丢失,请重新导入GemSystem");
//                 else if (l.Length > 1) Debug.LogError("请保证项目中只有一个GemMgr.prefab");
//                 var path = AssetDatabase.GUIDToAssetPath(l[0]).Replace("Base/GemMgr.prefab", "Data/GemData");
//                 return path;
//             }
//         }
//
//         public static string GEM_PATH => SO_PATH + "/Gems";
//     }
// }
