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
    [SerializeField] Material color;
    public GameObject[] Array;
    void Start()
    {
        Init();
        mergeSort(0,SizeofArray-1,Array);
    }
    IEnumerator merge(int l,int m,int r, GameObject[] Arr)
    {
        //yield return new WaitForSeconds(1);
        GameObject[] L, R;
        int n1 = m - l + 1, n2 = r - m;
        L = new GameObject[m - l + 1];
        R = new GameObject[r - m];
        for(int a=0;a<n1;a++ )
        {
            L[a] = Arr[l + a];
        }
        for(int a=0;a<n2;a++)
        {
            R[a] = Arr[m + 1 + a];
        }
        int i = 0, j = 0, k = l;
        while(i<n1&&j<n2)
        {
            yield return new WaitForSeconds(1);
            if(L[i].transform.localScale.y<=R[j].transform.localScale.y)
            {
                Arr[k].transform.localScale = new Vector3(Arr[k].transform.localScale.x,L[i].transform.localScale.y,Arr[k].transform.localScale.z);
                Arr[k].transform.localPosition = new Vector3(Arr[k].transform.localPosition.x, Arr[k].transform.localScale.y / 2, Arr[k].transform.localPosition.z);
                i++;
            }
            else
            {
                Arr[k].transform.localScale = new Vector3(Arr[k].transform.localScale.x, R[j].transform.localScale.y, Arr[k].transform.localScale.z);

                Arr[k].transform.localPosition = new Vector3(Arr[k].transform.localPosition.x, Arr[k].transform.localScale.y / 2, Arr[k].transform.localPosition.z);
                j++;
            }
            k++;
        }
        while(i<n1)
        {
            yield return new WaitForSeconds(1);
            Arr[k].transform.localScale = new Vector3(Arr[k].transform.localScale.x, L[i].transform.localScale.y, Arr[k].transform.localScale.z);
            
            Arr[k].transform.localPosition = new Vector3(Arr[k].transform.localPosition.x, Arr[k].transform.localScale.y / 2, Arr[k].transform.localPosition.z);
            
            i++;
            k++;

        }
        while(j<n2)
        {
            yield return new WaitForSeconds(1);
            Arr[k].transform.localScale = new Vector3(Arr[k].transform.localScale.x, R[j].transform.localScale.y, Arr[k].transform.localScale.z);

            Arr[k].transform.localPosition= new Vector3(Arr[k].transform.localPosition.x, Arr[k].transform.localScale.y / 2, Arr[k].transform.localPosition.z);
            
            j++;
            k++;

        }


    }
    void mergeSort(int l,int r, GameObject[] Arr)
    {
        if(l<r)
        {
            int m = l + (r - l) / 2;
            //yield return new WaitForSeconds(1);
            mergeSort(l, m,  Arr);
            mergeSort(m + 1, r,  Arr);
            StartCoroutine(merge(l, m, r, Arr));


        }
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
            element.transform.parent = this.transform;
            Array[i] = element;

            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
