using UnityEngine;

namespace Interfaces
{
    public interface IContainer
    {
        public RectTransform RectTransform { get; }
        public void AddItem(IMergeItem item);
        public void RemoveItem(IMergeItem item);
    }
}