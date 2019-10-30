using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTool : MonoBehaviour
{
    public GameObject[] point = new GameObject[10];
    public GameObject Box;



    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(Box, point[i].transform.position, Quaternion.identity);

        }




    }




}



