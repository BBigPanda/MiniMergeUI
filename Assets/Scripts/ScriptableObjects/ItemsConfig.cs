using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemsConfig", menuName = "ScriptableObjects/ItemsConfig", order = 0)]
    public class ItemsConfig : ScriptableObject
    {
        [SerializeField] private List<ItemData> _items;

        public ItemData GetItem(int index)
        {
            return _items.FirstOrDefault(item => item.Index == index);
        }
        public ItemData GetRandomItem()
        {
            return _items[Random.Range(0, _items.Count)];
        }
    }
}