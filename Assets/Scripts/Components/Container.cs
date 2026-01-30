using System.Collections.Generic;
using Components;
using Interfaces;
using UnityEngine;

public class Container : MonoBehaviour, IContainer
{
    [SerializeField] private RectTransform _rectTransform;
    private List<IMergeItem> _mergeItems;

    public RectTransform RectTransform => _rectTransform;

    private void Awake()
    {
        _mergeItems = new List<IMergeItem>();
    }

    public void AddItem(IMergeItem item)
    {
        Debug.Log( $"Adding item {(item as MergeItem).name}");
        _mergeItems.Add(item);
        item.SetParent(this);
        
    }

    public void RemoveItem(IMergeItem item)
    {
        _mergeItems.Remove(item);
    }
}
