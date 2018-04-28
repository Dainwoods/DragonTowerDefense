﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    
    public GameObject TrapToCreate = null;
    public int cost;

    private Camera _camera = null;
    private GameObject _trapIndicator;
    
	public void Update () {
	    if (RoundHandler.roundHandler)
	    {
            if (RoundHandler.roundHandler.IsFiring)
            {
                GetComponent<CanvasGroup>().alpha = 0.5f;
            }
            else
            {
                GetComponent<CanvasGroup>().alpha = 1;
            }
	    }
	}

    public void OnBeginDrag(PointerEventData eventData) {
        // Create an indicator of where the trap will land
        _trapIndicator = CreateOnPosition(eventData.position);
        if(_trapIndicator.layer != 9 && !RoundHandler.roundHandler.CanFire()) {
            Debug.Log("destrot fireball");
            Destroy(_trapIndicator);
        }
        else if(_trapIndicator != null && _trapIndicator.layer == 9){
            Debug.Log("fireball not destroy");
            _trapIndicator.GetComponent<Trap>().Deactivate();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RoundHandler.roundHandler.IsFiring)
        {
            return;
        }
        
        // Have trap indicator follow under draggable
        if (_trapIndicator != null)
        {
            Vector3 trapPosition = _trapIndicator.transform.position;
            Vector3 ownPosition = _camera.ScreenToWorldPoint(eventData.position);
            Debug.Log(_trapIndicator.layer);
            if(_trapIndicator.layer == 9) {
                _trapIndicator.transform.position = new Vector3(ownPosition.x, trapPosition.y, trapPosition.z);
            }
            else {
                _trapIndicator.transform.position = new Vector3(ownPosition.x, ownPosition.y, trapPosition.z);
            }

            if(canPlace()) {
                _trapIndicator.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
            }
            else {
                _trapIndicator.GetComponent<SpriteRenderer>().color = new Color(1f, 0.3f, 0.3f, .5f);
            }
        }
    }

    public bool canPlace()
    {
        var trapLayer = LayerMask.GetMask("Trap");
        return !_trapIndicator.GetComponent<BoxCollider2D>().IsTouchingLayers(trapLayer);
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("OnEndDrag");
        if(_trapIndicator != null) {
            GetComponent<CanvasGroup>().blocksRaycasts = true;

            if(canPlace() && RoundHandler.gold > cost) {
                if(_trapIndicator.layer != 9) {
                    RoundHandler.roundHandler.setFire();
                }
                else {
                    CreateOnPosition(eventData.position);
                }

                // Update current gold
                RoundHandler.gold = RoundHandler.gold - cost;
            }
            Destroy(_trapIndicator);
        }

    }

    public GameObject CreateOnPosition(Vector2 position)
    {
        Debug.Log("Creating object");
        if (_camera == null)
        {
            _camera = Camera.main;
        }
        Vector3 point = _camera.ScreenToWorldPoint(position);
        point = new Vector3(point.x, point.y, 0);
        Debug.Log(TrapToCreate);
        return Instantiate(TrapToCreate, point, Quaternion.identity);
    }
}
