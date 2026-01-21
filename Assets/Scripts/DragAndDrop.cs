using System;
using DG.Tweening;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private BoxCollider2D _boxCollider2D;

    private bool _moveable = true;
    private bool _isDragging = false;
    private Vector3 _offset;
    private Vector3 _startPosition;

    private void OnValidate()
    {
        if (_rectTransform == null)
            _rectTransform = GetComponent<RectTransform>();
        if (_boxCollider2D == null)
            _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (_isDragging)
        {
            _rectTransform.localPosition = Input.mousePosition + _offset;
        
        }
    }

    private void CheckCastObject()
    {
        _boxCollider2D.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(_rectTransform.position, Vector3.back);
        if (hit.collider != null)
        {
            Debug.unityLogger.Log(" hit:", hit.collider.name);
        }
        _boxCollider2D.enabled = true;
    }
    
    

    private void OnMouseDown()
    {
        if (!_moveable)
            return;
        Debug.unityLogger.Log("DragAndDropHandler", "OnMouseDown: " + _rectTransform.name);
        _startPosition = _rectTransform.localPosition;
        _offset = _rectTransform.localPosition - Input.mousePosition;
        _isDragging = true;
    }

    private void OnMouseUp()
    {
        Debug.unityLogger.Log("DragAndDropHandler", "OnMouseUp: " + _rectTransform.name);
        CheckCastObject();
        _moveable = false;
        _isDragging = false;
        _rectTransform.DOLocalMove(_startPosition, 0.2f).SetEase(Ease.OutBack).OnComplete(() => { _moveable = true; });
    }
}