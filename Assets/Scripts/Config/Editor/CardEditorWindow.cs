using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Config.Card;

public class CardEditorWindow : EditorWindow
{
    private List<BaseCard> cards; // 保存卡牌列表
    private Vector2 scrollPos; // 滚动视图的位置
    private int selectedCardIndex = -1; // 当前选中的卡牌索引
    private SerializedObject serializedCard; // 当前选中卡牌的序列化对象
    private string cardFolder = "Assets/Data/Cards"; // 卡牌保存的文件夹路径
    
    //程序集
    private const string ASSEMBLY_NAME = "Assembly-CSharp";
    private Assembly assembly;
    
    //子类选择
    int selectedSubclassIndex = 0;
    int lastSelectSubclassIndex = 0;
    bool changedSubClassSelection = false;
    const string PLACEHOLDER_BUFF_NAME = "PlaceholderBuff";
    const string NONE_TYPE = "[NONE]";
    //类    
    List<Type> subClasses;
    string[] subClassNames;

    // 在Unity菜单中添加一个菜单项，用于打开这个编辑器窗口
    [MenuItem("Tools/Card Editor")]
    public static void OpenWindow()
    {
        GetWindow<CardEditorWindow>("Card Editor"); // 打开窗口并设置窗口标题为“Card Editor”
    }

    // 窗口启用时调用的方法
    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        LoadCards(); // 加载所有卡牌
    }

    
    // 从指定文件夹中加载所有卡牌
    private void LoadCards()
    {

        cards = new List<BaseCard>();
        string[] guids = AssetDatabase.FindAssets("t:BaseCard", new[] {cardFolder});
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            BaseCard card = AssetDatabase.LoadAssetAtPath<BaseCard>(path);
            if (card != null)
            {
                cards.Add(card);
            }
        }
    }


    // 绘制编辑器窗口的GUI
    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal(); // 开始水平布局
        DrawCardList(); // 绘制卡牌列表
        DrawCardDetails(); // 绘制卡牌详细信息
        EditorGUILayout.EndHorizontal(); // 结束水平布局

        // 绘制保存所有卡牌的按钮
        if (GUILayout.Button("Save All"))
        {
            SaveAllCards();
        }
    }

    // 绘制卡牌列表
    private void DrawCardList()
    {
        EditorGUILayout.BeginVertical(GUILayout.Width(200)); // 开始垂直布局并设置宽度
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos); // 开始滚动视图

        // 绘制每个卡牌的按钮
        for (int i = 0; i < cards.Count; i++)
        {
            if (GUILayout.Button(cards[i].CardTitle))
            {
                SelectCard(i); // 选中卡牌
            }
        }

        EditorGUILayout.EndScrollView(); // 结束滚动视图

        // 绘制添加新卡牌的按钮
        if (GUILayout.Button("Add Card"))
        {
            AddCard();
        }

        EditorGUILayout.EndVertical(); // 结束垂直布局
    }
    // 绘制卡牌详细信息
    private void DrawCardDetails()
    {
        
        if (selectedCardIndex >= 0 && selectedCardIndex < cards.Count)
        {
            // 如果序列化对象不存在或目标对象不是当前选中的卡牌，重新创建序列化对象
            if (serializedCard == null || serializedCard.targetObject != cards[selectedCardIndex])
            {
                //serializedCard = new SerializedObject(cards[selectedCardIndex]);
            }

            EditorGUILayout.BeginVertical(); // 开始垂直布局

            serializedCard.Update(); // 更新序列化对象
            DrawProperties(serializedCard); // 绘制卡牌的所有属性
            serializedCard.ApplyModifiedProperties(); // 应用修改

            // 绘制删除卡牌的按钮
            if (GUILayout.Button("Delete Card"))
            {
                DeleteCard(selectedCardIndex);
            }

            EditorGUILayout.EndVertical(); // 结束垂直布局
        }
        else
        {
            EditorGUILayout.LabelField("Select a card to view details."); // 提示信息，当没有选中卡牌时显示
        }
    }
    


    // 绘制序列化对象的所有属性
    private void DrawProperties(SerializedObject obj)
    {
        SerializedProperty prop = obj.GetIterator(); // 获取序列化属性的迭代器
        bool enterChildren = true;
        while (prop.NextVisible(enterChildren)) // 遍历所有可见属性
        {
            enterChildren = false;
            EditorGUILayout.PropertyField(prop, true); // 绘制属性字段
        }
    }
    
    // 添加新卡牌
    private void AddCard()
    {
        BaseCard newCard = ScriptableObject.CreateInstance<BaseCard>(); // 创建新的ScriptableObject实例
        newCard.cardId = cards.Count + 1; // 设置卡牌ID
        newCard.name = "Card " + newCard.cardId; // 设置卡牌名称

        // 检查并创建文件夹路径
        if (!AssetDatabase.IsValidFolder(cardFolder))
        {
            string[] folders = cardFolder.Split('/');
            string currentPath = "";
            foreach (var folder in folders)
            {
                if (string.IsNullOrEmpty(currentPath))
                {
                    currentPath = folder;
                }
                else
                {
                    if (!AssetDatabase.IsValidFolder(currentPath + "/" + folder))
                    {
                        AssetDatabase.CreateFolder(currentPath, folder);
                    }
                    currentPath = currentPath + "/" + folder;
                }
            }
        }

        string path = $"{cardFolder}/{newCard.name}.asset"; // 生成卡牌的保存路径
        AssetDatabase.CreateAsset(newCard, path); // 创建卡牌资源
        AssetDatabase.SaveAssets(); // 保存资源

        cards.Add(newCard); // 将新卡牌添加到列表中
        SelectCard(cards.Count - 1); // 选中新添加的卡牌
    }

    // 删除指定索引的卡牌
    private void DeleteCard(int index)
    {
        string path = AssetDatabase.GetAssetPath(cards[index]); // 获取卡牌的资源路径
        AssetDatabase.DeleteAsset(path); // 删除资源
        cards.RemoveAt(index); // 从列表中移除卡牌
        selectedCardIndex = -1; // 重置选中的卡牌索引
    }

    // 选中指定索引的卡牌
    private void SelectCard(int index)
    {
        selectedCardIndex = index;
        serializedCard = new SerializedObject(cards[index]); // 创建选中卡牌的序列化对象
    }

    // 保存所有卡牌
    private void SaveAllCards()
    {
        foreach (BaseCard card in cards)
        {
            EditorUtility.SetDirty(card); // 标记卡牌为已修改
        }
        AssetDatabase.SaveAssets(); // 保存所有资源
    }
}
