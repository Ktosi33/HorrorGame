using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Player : MonoBehaviour {
     
    public GameObject _Player;
   public GameObject _Ghost;
    NavMeshAgent _Agent;
    GhostWhite _GhostWhite;
	// Use this for initialization
	void Start () {
      
        _Ghost.GetComponent<BoxCollider>();
        _Agent =  _Ghost.GetComponent<NavMeshAgent>();
        _GhostWhite = _Ghost.GetComponent<GhostWhite>();
	}

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        _Agent.SetDestination(_Player.transform.position);
    }
    private void OnCollisionStay(Collision collision)
    {
        _Agent.SetDestination(_Player.transform.position);
    }
    private void OnCollisionExit(Collision collision)
    {
        _GhostWhite.Targeting();
        
    }
    void Update () {
		
	}
}
