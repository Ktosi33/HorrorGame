using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavigationEnemy : MonoBehaviour
{
    public NavMeshAgent _Agent;
    public GameObject _Player;
    public bool IsFindPlayerByGhost = false;
    public Animator _DemonAnimator;
    private Vector3 previousPosition = new Vector3(0, 0, 0);
    float currentSpeed = 0f;
    public GameObject point0;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject point5;
    public GameObject point6;
    public GameObject point7;
    public GameObject point8;
    public GameObject point9;
    public GameObject _whereLook;
    private bool check = false;
    public bool Attack = false;
    public GameControl _gameControl;
    public GameObject _IsComing;
    float distanceToDirection;
    Vector3 Position = new Vector3(0, 0, 0);
    
    // Use this for initialization
    void Start()
    {
        previousPosition = new Vector3(0, 0, 0);
        Position = _Agent.transform.position;
        _IsComing.SetActive(false);
        IsFindPlayerByGhost = false;
       check = false;
       Attack = false;
       
}

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(_Player.transform.position, _Agent.transform.position);
        Vector3 currentMove = transform.position - previousPosition;
        currentSpeed = currentMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;
        _DemonAnimator.SetFloat("speed", currentSpeed);
      
        //distrema != Mathf.infinite &&
        if (IsFindPlayerByGhost)
        {

            check = true;
            
        }
     
        if (check)
        {
            if (IsFindPlayerByGhost)
            {
                _Agent.speed = 8f;

                Position = _Player.transform.position;
               _Agent.SetDestination(Position);
                distanceToDirection = Vector3.Distance(_Agent.transform.position, Position);
              
                _IsComing.SetActive(true);

            }else
            {
                _IsComing.SetActive(false);
            }


            distanceToDirection = Vector3.Distance(_Agent.transform.position, Position); 
            if ( distanceToDirection <= 3.0f)
            {
                
                check = false;
                Debug.Log(check);

            }
        }

        if (!check)
        {
            distanceToDirection = Vector3.Distance(_Agent.transform.position, Position); 
            if (_Agent.pathStatus == NavMeshPathStatus.PathComplete && _Agent.remainingDistance == 0.0f && distanceToDirection <= 3.0f)
            {
                DemonSpeed();
                Targeting();
                _Agent.SetDestination(Position);
                distanceToDirection = Vector3.Distance(_Agent.transform.position, Position);

            }
        }














        if (dist < 15f)
        {
            Vector3 dirFromAtoB = (_Player.transform.position - _Agent.transform.position).normalized;
            float dotProd = Vector3.Dot(dirFromAtoB, _Agent.transform.forward);


            if (dotProd > 0.9)
            {

                dist = Vector3.Distance(_Player.transform.position, _Agent.transform.position);


                _Agent.speed = 7f;
                _Agent.SetDestination(_Player.transform.position);
           

            }
            else
            {
                _Agent.SetDestination(Position);
            }
         

        }
        else
        {
            _Agent.SetDestination(Position);
        }

        if (dist < 3f)
        {
            Attack = true;


            _Player.transform.LookAt(_whereLook.transform.position);
            Attack = true;
            _DemonAnimator.SetBool("Attack", true);
            _gameControl.PlayerIsDead = true;

            _Agent.isStopped = true;
            _DemonAnimator.SetBool("Attack", false);
            _DemonAnimator.SetBool("Glory", true);

            _DemonAnimator.SetBool("Glory", false);

        }
        if(_gameControl.Win)
        {
            _Agent.isStopped = true;
        }
        Debug.Log(Position);
    }




    void Seek()
    {

        int i = Random.Range(1, 2);
        
        switch (i)
        {
            case 1:
                Targeting();
                _Agent.speed = 4f;
                break;
            case 2:
                DemonSpeed();

                SeekPlayer();
                break;
        }

    }
    void SeekPlayer()
    {
        Vector3 Position;
        Position = _Player.transform.position;
        _Agent.SetDestination(Position);
    }
    public void Targeting()
    {


        int a = Random.Range(0, 9);
      
        switch (a)
        {
            case 0: {

                    Position = point0.transform.position;
                 

                    break; }
            case 1: {
                    Position = point1.transform.position;
                   
                    break;
                }
            case 2: {
                    Position = point2.transform.position;
                 
                    break;
                }
            case 3: {
                    Position = point3.transform.position;
                  
                    break;
                }
            case 4: {
                    Position = point4.transform.position;
                   
                    break;
                }
            case 5: {
                    Position = point5.transform.position;
                 
                    break;
                }
            case 6: {
                    Position = point6.transform.position;
                   
                    break;
                }
            case 7: {
                    Position = point7.transform.position;
              
                    break;
                }
            case 8: {
                    Position = point8.transform.position;
                 
                    break;
                }
            case 9: {
                    Position = point9.transform.position;
                  
                    break;
                }

        };

    }





    void DemonSpeed()
    {

        if (_gameControl.TookBox >= 0 && _gameControl.TookBox < 3)
        {
            _Agent.speed = 4f;
        }
        if (_gameControl.TookBox >= 3 && _gameControl.TookBox < 6)
        {
            _Agent.speed = 5f;
        }
        if (_gameControl.TookBox >= 6 && _gameControl.TookBox < 8)
        {
            _Agent.speed = 6f;
        }
        if (_gameControl.TookBox >= 8 && _gameControl.TookBox <= 10)
        {
            _Agent.speed = 7f;
        }

    }
    IEnumerator Kill()
    {


        yield  return new WaitForSeconds(1);
    }

}


