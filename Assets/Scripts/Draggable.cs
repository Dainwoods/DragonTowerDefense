using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo = null;

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("onBeginDrag");

        if (this.transform.parent.name == "TrapUI") {
            GameObject clone = Instantiate(eventData.pointerDrag) as GameObject;
            clone.transform.SetParent(this.transform.parent);

            parentToReturnTo = this.transform.parent;
            this.transform.SetParent(this.transform.parent.parent);

            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

    }

    public void OnDrag(PointerEventData eventData) {
        if (parentToReturnTo.name == "TrapUI")
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");

        if (this.transform.parent.name == "TrapUI") {
            this.transform.SetParent(parentToReturnTo);
            parentToReturnTo = null;

            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}
