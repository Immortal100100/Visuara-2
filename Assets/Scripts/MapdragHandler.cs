using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MapdragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public RectTransform Canvas;
    public Transform Panel;
    public GameObject Country;
    public GameObject Self;
    public GameObject Label;
    public GameObject Preeffect;
    public GameObject Aftereffect;
    public Mouserotate rotator;
    public float Score;
    public Scoring scoring;
    public AudioSource wrong;
    public AudioSource right;
    Vector3 Initialposition;

    void start(){
        Preeffect.SetActive(true);
        Aftereffect.SetActive(false);
    }

    public void OnMouseOver(){
        Label.SetActive(true);
    }

    public void OnMouseExit(){
        Label.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData){
        rotator.enabled = false;
        Label.SetActive(false);
        Initialposition = transform.position;
    }

    public void OnDrag(PointerEventData eventData){
        transform.SetParent(Canvas);
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData){
            Hitray();
            wrong.Play();
            transform.SetParent(Panel);
            transform.position = Initialposition ;
            rotator.enabled = true;
            scoring.Updatescore();
        }

    void Hitray(){
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(ray, out hit)){
        if(hit.collider.CompareTag(Self.tag)){
            Score++;
            right.Play();
            Preeffect.SetActive(false);
            Aftereffect.SetActive(true);
            Destroy(Self);
        }
        else{
            Score--;
        }
    }
    }

}
