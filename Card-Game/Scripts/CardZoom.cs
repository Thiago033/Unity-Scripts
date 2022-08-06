using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject canvas;

    private GameObject zoomCard;

    [SerializeField]
    GameObject zoomedCard;

    private DragAndDrop isInDropZone;

    void Awake()
    {
        isInDropZone = FindObjectOfType<DragAndDrop>();
        canvas = GameObject.Find("Main Canvas");
    }

    public void OnHoverEnter()
    {
        //Debug.Log(isInDropZone.isOverPlayerDropZone);

        if (!isInDropZone.isOverPlayerDropZone)
        {
            zoomCard = Instantiate(zoomedCard, new Vector2(0,0), Quaternion.identity);
            zoomCard.transform.SetParent(canvas.transform, false);
            zoomCard.layer = LayerMask.NameToLayer("Zoom");

            RectTransform rect = zoomCard.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(340,532); 
        }
    }

    public void OnHoverExit()
    {
        Destroy(zoomCard);
    }
}
