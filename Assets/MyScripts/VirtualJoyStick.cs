using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    [SerializeField] private Image _bgJimg;
    [SerializeField] private Image _JSimg;
    public Vector3 inputVector;
   private void Start()
    {
        _bgJimg = GetComponent<Image>();
        _JSimg = transform.GetChild(0).GetComponent<Image>();
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(_bgJimg.rectTransform, ped.position,ped.pressEventCamera,out pos))
        {
            pos.x = (pos.x / _bgJimg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / _bgJimg.rectTransform.sizeDelta.y);
            inputVector = new Vector3(pos.x * 2 , 0, pos.y * 2 );

            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            _JSimg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (_bgJimg.rectTransform.sizeDelta.x / 3)
                                                               ,inputVector.z * (_bgJimg.rectTransform.sizeDelta.y / 3));
        }

    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        _JSimg.rectTransform.anchoredPosition = Vector3.zero;
    }
  public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");

    }
    public float Vertical()
    {
        if (inputVector.z != 0)
            return inputVector.z;
        else
            return Input.GetAxis("Vertical");


    }

}
