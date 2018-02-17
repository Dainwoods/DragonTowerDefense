using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrapDeck : MonoBehaviour, IDropHandler {

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("Dropped to " + gameObject.name);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            d.parentToReturnTo = this.transform;
        }
    }
}
