using System;
using System.Collections.Generic;
using Components;
using Cysharp.Threading.Tasks;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class Container : MonoBehaviour, IContainer
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private VerticalLayoutGroup _verticalLayoutGroup;
    private List<IMergeItem> _mergeItems;

    public RectTransform RectTransform => _rectTransform;

    private void Awake()
    {
        _mergeItems = new List<IMergeItem>();
    }

    public void AddItem(IMergeItem item)
    {
        Debug.Log($"Adding item {(item as MergeItem).name}");
        _mergeItems.Add(item);
        item.SetParent(this);
        ResetLayout();
    }

    private async void ResetLayout()
    {
        _verticalLayoutGroup.enabled = false;
        await UniTask.DelayFrame(1);
        _verticalLayoutGroup.enabled = true;
    }

    public void RemoveItem(IMergeItem item)
    {
        _mergeItems.Remove(item);
    }
}