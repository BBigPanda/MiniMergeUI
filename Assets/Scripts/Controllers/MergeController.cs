using System;
using System.Collections.Generic;
using Components;
using ScriptableObjects;
using UnityEngine;

namespace Controllers
{
    public class MergeController : MonoBehaviour
    {
        [SerializeField] private List<RectTransform> _itemsContainers;
        [SerializeField] private ItemsConfig _itemsConfig;
        [SerializeField] private MergeItem _mergeItemPrefab;
        
        private List<MergeItem> _mergeItems;

        public void Start()
        {
            _mergeItems =  new List<MergeItem>();
            for (int i = 0; i < _itemsContainers.Count; i++)
            {
                _mergeItems.Add(Instantiate(_mergeItemPrefab,  _itemsContainers[i].transform));
                _mergeItems[i].SetData(_itemsConfig.GetRandomItem(), i);
            }
        }

        public void CheckMerge(int from, int to)
        {
            if (_mergeItems[from].Data.Index == _mergeItems[to].Data.Index)
            {
                // _mergeItems[to].SetData(_itemsConfig.GetItem(_mergeItems[to].Data.Index+1),to);
                // _mergeItems[from].SetData(_itemsConfig.GetRandomItem(), from);
            }
        }
    }
}