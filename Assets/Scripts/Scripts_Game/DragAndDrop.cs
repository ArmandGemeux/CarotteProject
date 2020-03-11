using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    public GameObject prefab;
    private RectTransform rectTransform;
    private CanvasGroup buttonCanvasGroup;
    private Transform buttonPosition;

    private Vector3 buttonPosBeforeMoving;
    public Transform startPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        buttonCanvasGroup = GetComponent<CanvasGroup>();
        buttonPosition = GetComponent<Transform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        buttonCanvasGroup.blocksRaycasts = false;
        Debug.Log(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        buttonCanvasGroup.blocksRaycasts = true;
        Instantiate(prefab, buttonPosition.position, Quaternion.identity);
        transform.position = startPosition.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
    }

    // Use this for initialization
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }
}