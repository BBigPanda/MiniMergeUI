using Interfaces;
using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    public class MergeItem : MonoBehaviour, IMergeItem
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private BoxCollider2D _collider;
        [SerializeField] private Image _image;
        [SerializeField] private Canvas _canvas;

        [SerializeField]   private int _index;

        private ItemData _data;

        public ItemData Data => _data;

        public int Index => _index;

        public RectTransform RectTransform => _rectTransform;

        public void SetData(ItemData data, int index)
        {
            _index = index;
            _data = data;
            _image.sprite = data.Sprite;
            _image.color = data.Color;
        }

        public void Take()
        {
            _canvas.overrideSorting = true;
            _collider.enabled = false;
        }

        public void Break()
        {
            _canvas.overrideSorting = false;
            _collider.enabled = true;
        }

        public void SetParent(IContainer container)
        {
            transform.SetParent(container.RectTransform);
        }

        public void SetMergeData(ItemData itemData)
        {
            if (itemData.Index == _data.Index)
            {
            }
        }
    }
}