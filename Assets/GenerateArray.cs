using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateArray : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int Height = 100;
    [SerializeField] public int SizeofArray = 100;
    [SerializeField] public int initPos = 0;
    [SerializeField] public int initZ = 0;
    public GameObject[] Array;
    void Start()
    {
        Init();
    }

    private void Init()
    {
        Array = new GameObject[SizeofArray];
        for(int i=0;i<SizeofArray;i++)
        {
            int randomHeight = UnityEngine.Random.Range(1, Height + 1);

            GameObject element = GameObject.CreatePrimitive(PrimitiveType.Cube);
            element.transform.localScale= new Vector3(0.85f,randomHeight,1f);
            element.transform.position = new Vector3(initPos+i,randomHeight/2,initZ);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
