using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GhostWhite : MonoBehaviour
{

    public NavMeshAgent _Agent;
    public NavigationEnemy _NavEnemy;
    public GameObject _Player;
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
    bool control = true;
    public float speed = 5f;
    public AudioSource _AudioSource;
    public AudioClip _ScaryWhenFound;

    // Use this for initialization
    void Start()
    {

        _AudioSource = gameObject.AddComponent<AudioSource>();
        _AudioSource.volume = 0.1f;

        _Agent.speed = speed;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check if player stand forward ghost
        Vector3 dirFromAtoB = (_Player.transform.position - _Agent.transform.position).normalized;
        float dotProd = Vector3.Dot(dirFromAtoB, _Agent.transform.forward);
        if (_Agent.pathStatus == NavMeshPathStatus.PathComplete && _Agent.remainingDistance < 1 && control)
        {
            _NavEnemy.IsFindPlayerByGhost = false;

            Targeting();
        }
        else if (dotProd > 0.9)
        {
            float dist = Vector3.Distance(_Player.transform.position, _Agent.transform.position);
            //dist of seeing 14m.
            if (dist < 14f)
            {
                _NavEnemy.IsFindPlayerByGhost = true;
                _Agent.SetDestination(_Player.transform.position);
                StartCoroutine(PlaySound());
            }
        }



    }




    //play sound when the player was found by ghost
    IEnumerator PlaySound()
    {

        _AudioSource.PlayOneShot(_ScaryWhenFound);

        yield return new WaitForSeconds(4);
    }
    //Random of target, where can move ghost
    public void Targeting()
    {


        int a = Random.Range(0, 9);
        //Debug.Log(a);
        switch (a)
        {
            case 0: { _Agent.SetDestination(point0.transform.position); break; }
            case 1: { _Agent.SetDestination(point1.transform.position); break; }
            case 2: { _Agent.SetDestination(point2.transform.position); break; }
            case 3: { _Agent.SetDestination(point3.transform.position); break; }
            case 4: { _Agent.SetDestination(point4.transform.position); break; }
            case 5: { _Agent.SetDestination(point5.transform.position); break; }
            case 6: { _Agent.SetDestination(point6.transform.position); break; }
            case 7: { _Agent.SetDestination(point7.transform.position); break; }
            case 8: { _Agent.SetDestination(point8.transform.position); break; }
            case 9: { _Agent.SetDestination(point9.transform.position); break; }

        };

    }
}
