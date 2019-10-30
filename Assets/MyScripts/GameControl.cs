using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class GameControl : MonoBehaviour {
    public short TookBox;
    public bool PlayerIsDead;
   // public TMP_Text _TextMeshPro; WHY NOT WORK :((( :( :( :( 
    public Text _textToolBox;
    public GameObject _youWon;
    public GameObject _youLost;
    public GameObject _machinelight;
    //public MouseLook _mouseLook;
    public AndroidLook _androidLook;
    public VirtualJoyStick _virtualJoyStick;
    //public VirtualJoyStick _virtualJoyStick2;
    public NavigationEnemy _navigationEnemy;
    public GameObject _textRepairGate;
    public GameObject _textsToolBooxCount;
    bool onlyone = false;
    public GoogleMobileAdsGame _googleMobileAdsGame;
    public bool Win = false;
  

	// Use this for initialization
	void Start () {
        AudioListener.pause = false;
        PlayerIsDead = false;
        TookBox = 0;
        _youLost.SetActive(false);
       _youWon.SetActive(false);
        _textRepairGate.SetActive(false);
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
       _textToolBox.text = TookBox.ToString();
      
        if (Input.GetMouseButtonDown(0))
        {
            // Vector3 point = new Vector3(_Camera.pixelWidth / 2, _Camera.pixelHeight / 2, 0);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5f))
            {

                if (hit.collider.gameObject.CompareTag("Box"))
                {
                    Destroy(hit.collider.gameObject);

                    TookBox++;
                
                }
            }
        }
      
        if (TookBox >= 10 && !onlyone)
        {
            _textsToolBooxCount.SetActive(false);
            _machinelight.SetActive(true);
            _textRepairGate.SetActive(true);
            onlyone = true;
        }
        
        if (Win)
        {
            AudioListener.pause = true;
            _machinelight.SetActive(false);
            _textRepairGate.SetActive(false);
            Won();
           _androidLook.inputVector = Vector3.zero;
          _virtualJoyStick.inputVector = Vector3.zero;
            Time.timeScale = 0;


        }
        if(PlayerIsDead)
        {
            Lost();
            AudioListener.pause = true;
            _machinelight.SetActive(false);
            _textRepairGate.SetActive(false);
            _androidLook.inputVector = Vector3.zero;
            _virtualJoyStick.inputVector = Vector3.zero;
           
            Time.timeScale = 0;
            _googleMobileAdsGame.bannerView.Destroy();
            
        }

	}
    void Won()
    {
        _youWon.SetActive(true);
    }
    void Lost()
    {
        _youLost.SetActive(true);
    }
   public void Returning()
    {
        SceneManager.UnloadSceneAsync("HorrorGameLevel");
        SceneManager.LoadScene("Menu");
    }


  
}
