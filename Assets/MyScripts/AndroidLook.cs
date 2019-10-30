using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AndroidLook : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Image _moveArea;
    [SerializeField] private Image _moveBG;
    [SerializeField] private Image _move;
   public  Vector3 inputVector;
    private Vector2 CenterJoystick = Vector2.zero;

    private void Start()
    {
        
        _moveArea = GetComponent<Image>();
        _moveBG = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        _move = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        _moveBG.enabled = false;
        _move.enabled = false;
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        _moveBG.enabled = true;
        _move.enabled = true;
                Vector2 pos;
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_moveBG.rectTransform, ped.position, ped.pressEventCamera, out pos))
                {




                    pos.x = (pos.x / _moveBG.rectTransform.sizeDelta.x);
                    pos.y = (pos.y / _moveBG.rectTransform.sizeDelta.y);

                    inputVector = new Vector3(pos.x * 2, 0, pos.y * 2);

                    inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;


                    _move.rectTransform.anchoredPosition = new Vector3(inputVector.x * (_moveBG.rectTransform.sizeDelta.x / 3)
                                             , inputVector.z * (_moveBG.rectTransform.sizeDelta.y / 3));




                }

    

    }





    public virtual void OnPointerDown(PointerEventData ped)
    {
        _moveBG.transform.SetPositionAndRotation(ped.pressPosition, Quaternion.identity);
        _moveBG.enabled = true;
        _move.enabled = true;
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        _move.rectTransform.anchoredPosition = Vector3.zero;
        _moveBG.enabled = false;
        _move.enabled = false;
    }
    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return 0;


    }
    public float Vertical()
    {
        if (inputVector.z != 0)
            return inputVector.z;
        else
            return 0;


    }

}
