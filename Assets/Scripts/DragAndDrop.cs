using Components;
using Controllers;
using DG.Tweening;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasRectTransform;
    [SerializeField] private MergeController _mergeController;
    private bool _moveable = true;
    private bool _isDragging = false;
    private Vector3 _offset;
    private Vector3 _startPosition;
    private MergeItem _mergeItem;

   

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(_canvasRectTransform, Input.mousePosition,
                Camera.main, out var worldPosition);
            Collider2D hit = Physics2D.OverlapPoint(worldPosition);
            if (hit != null)
            {
                _mergeItem = hit.GetComponent<MergeItem>();
                OnMouseDown();
            }
        }else if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }

        if (_isDragging)
        {
            _mergeItem.RectTransform.localPosition = Input.mousePosition + _offset;
        }
    }

    private void CheckCastObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(_mergeItem.RectTransform.position, Vector3.back);
        if (hit.collider != null)
        {
            Debug.unityLogger.Log(" hit:", hit.collider.name);
            
            if (hit.collider.CompareTag("Container"))
            {
            Debug.unityLogger.Log(" MG:", _mergeItem != null);
            Debug.unityLogger.Log(" CG:", hit.collider.gameObject.GetComponent<Container>() != null);
                
                hit.collider.gameObject.GetComponent<Container>()?.AddItem(_mergeItem);
            }
        }
    }


    private void OnMouseDown()
    {
        if (!_moveable)
            return;
        _mergeItem.Take();
        _startPosition = _mergeItem.RectTransform.localPosition;
        _offset = _mergeItem.RectTransform.localPosition - Input.mousePosition;
        _isDragging = true;
    }

    private void OnMouseUp()
    {
        CheckCastObject();
        _moveable = false;
        _isDragging = false;
        _mergeItem.Break();
        _mergeItem.RectTransform.DOLocalMove(_startPosition, 0.2f).SetEase(Ease.OutBack).OnComplete(() => { _moveable = true; });
    }
}