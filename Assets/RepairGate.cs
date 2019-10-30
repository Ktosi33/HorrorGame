using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RepairGate : MonoBehaviour {
   public GameControl _gameControl;
   public  GameObject _notEnough;
   public GameObject _enough;
    public Slider _slider;
    public GameObject _player;
    public AndroidLook _androidLook;
    public VirtualJoyStick _virtualJoyStick;
    public GameObject _machineGate;
    public GameObject _machineGateLight;
    public GameObject _canRepairText;
    Vector3 position;
    bool done = false; // Controll var for check if gate was repaired
    // Use this for initialization
    void Start () {
        _notEnough.SetActive(false);
        
        _enough.SetActive(false);
        _slider.minValue = 0f;
        _slider.maxValue = 100f;
        _slider.value = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        //if player click the machine gate and he didnt done(it was bug because when player won he still could click for rapair)
        if (Input.GetMouseButtonDown(0) && !done)
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 4f))
            {

                if (hit.collider.gameObject.CompareTag("MachineGate"))
                {
                    _gameControl.TookBox = 10; // for testing

                    if(_gameControl.TookBox < 10)
                    {

                        StartCoroutine(WaitNotEnough());

                    }else if(_gameControl.TookBox >= 10)
                    {
                        _slider.value = 0f;
                        _canRepairText.SetActive(false);
                        _machineGateLight.SetActive(false);
                        StartCoroutine(Reparing());

                    }






                }
            }
        }
    }

  
    //Not enough tool boxes for repair
    IEnumerator WaitNotEnough()
    {
        _notEnough.SetActive(true);
        yield return new WaitForSeconds(3);
        _notEnough.SetActive(false);
    }

    //Reparing the gate system
    IEnumerator Reparing()
    {
        Vector3 dirFromAtoB = (_machineGate.transform.position - _player.transform.position).normalized;
        float dotProd = Vector3.Dot(dirFromAtoB, _player.transform.forward);

      
        if (_virtualJoyStick.inputVector == Vector3.zero)
        {
            _enough.SetActive(true);
            while (_slider.value < 98f)
            {
                //TEST player look for the machineGate
                dirFromAtoB = (_machineGate.transform.position - _player.transform.position).normalized;
                dotProd = Vector3.Dot(dirFromAtoB, _player.transform.forward);
                // system of loading and check player look for the machinegate or is moving
                if (_virtualJoyStick.inputVector == Vector3.zero && dotProd > 0.9)
                {
                   
                    _slider.value += 2f;
                    yield return new WaitForSeconds(0.1f);
                    done = true;
                }
                else //if player are moving or not looking for machinegate
                {
                    done = false;
                    _enough.SetActive(false);
                    _slider.value = 0f;
                    break;
                }
               
            }
            //did player repair gate.
            if (done)
            {
                _gameControl.Win = true;
                _enough.SetActive(false);
            }
        }
      
    }
}
