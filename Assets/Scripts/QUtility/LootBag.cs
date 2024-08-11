using UnityEditor;
using System;
using System.Collections.Generic;
using QFramework;

namespace QUtility
{
    /// <summary>
    /// 实现了战利品接口，如果要使用随机战利品方式需要这个接口辅助
    /// 并且需要`GetChance`来实现几率判断。
    /// </summary>
    public interface ILoot
    {
        int GetChance();
    }

    public class LootBag : IUtility
    {
        public T GetDroppedItem<T>(List<T> lootList) where T : ILoot
        {
            if (lootList == null || lootList.Count == 0)
            {
                LogTool.Log("ILootList 不存在");
                return default;
            }

            Random random = new Random();
            int randomNum = random.Next(1, 101); // 生成1到100之间的随机数

            List<T> possibleItems = new List<T>();

            foreach (T item in lootList)
            {
                if (randomNum < item.GetChance())
                {
                    possibleItems.Add(item);
                }
            }

            if (possibleItems.Count > 0)
            {
                T droppable = possibleItems[random.Next(0, possibleItems.Count)];
                return droppable;
            }

            LogTool.Log("没有物品掉落");
            return default;
        }
    }
}
