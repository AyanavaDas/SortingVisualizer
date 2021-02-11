using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateArray : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int Height = 100;
    [SerializeField] public int SizeofArray = 25;
    [SerializeField] public int initPos = 0;
    [SerializeField] public int initZ = 0;
    [SerializeField] Material color;
    public GameObject[] Array;
     public void StartQuickSort()
    {
        Init();
        //mergeSort(0,SizeofArray-1,Array);
        StartCoroutine(quicksort(0, SizeofArray - 1, Array));
    }
    void delay()
    {
        return;
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

    IEnumerator quicksort(int l,int r ,GameObject[] Arr)
    {
        if(l<r)
        {
            int Partition = partititon(l, r, Arr);
            
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(quicksort(l, Partition-1, Arr));
            yield return new WaitForSeconds(1.5f);
            StartCoroutine(quicksort(Partition + 1, r, Arr));
        }
    }

    private int partititon(int l, int r,  GameObject[] arr)
    {
        int pivot = r;
        int i = l - 1;

        for(int j = l ; j < r; j++ )
        {
            if(arr[j].transform.localScale.y<arr[pivot].transform.localScale.y)
            {
                //print(j);
                i++;
                //print(i);
                Invoke("delay", 1.5f);
                GameObject t;
                
                print(arr[j].transform.localPosition.x);
                print(arr[i].transform.localPosition.x);
                t = arr[j];
                arr[j] = arr[i];
                arr[i] = t;
                /*print(arr[j].transform.localPosition.x);
                print(arr[i].transform.localPosition.x);*/
                Vector3 temp= arr[j].transform.localPosition;
                //print(temp.x);
                //print(arr[i].transform.localPosition.x);
                arr[j].transform.localPosition = 
                    new Vector3(arr[i].transform.localPosition.x, temp.y, temp.z);
                arr[i].transform.localPosition = 
                    new Vector3(temp.x, arr[i].transform.localPosition.y, arr[i].transform.localPosition.z);
                

                /*LeanTween.moveLocalX(arr[j], arr[i].transform.localPosition.x, 1);
                LeanTween.moveLocalZ(arr[j], -3, 0.5f).setLoopPingPong(1);
                LeanTween.moveLocalX(arr[i], temp.x, 1);
                LeanTween.moveLocalZ(arr[i], 3, 0.5f).setLoopPingPong(1);
                */
                //print(arr[j].transform.localPosition.x);
                //print(arr[i].transform.localPosition.x);
                //print("Swapped");
            }
        }
        Invoke("delay", 1.5f);
        GameObject T;
        T = arr[i + 1];
        arr[i + 1] = arr[pivot];
        arr[pivot] = T;

        Vector3 Temp = arr[i+1].transform.localPosition;
        arr[i + 1].transform.localPosition = 
            new Vector3(arr[pivot].transform.localPosition.x, Temp.y, Temp.z);
        arr[pivot].transform.localPosition = 
            new Vector3(Temp.x, arr[pivot].transform.localPosition.y, arr[pivot].transform.localPosition.z);

        
        /*LeanTween.moveLocalX(arr[i+1], arr[pivot].transform.localPosition.x, 1);
        LeanTween.moveLocalZ(arr[i+1], -3, 0.5f).setLoopPingPong(1);
        LeanTween.moveLocalX(arr[pivot], Temp.x, 1);
        LeanTween.moveLocalZ(arr[pivot], 3, 0.5f).setLoopPingPong(1);
        */
        return (i + 1);
        
    }

    private void Init()
    {
        Array = new GameObject[SizeofArray];
        for(int i=0;i<SizeofArray;i++)
        {
            int randomHeight = UnityEngine.Random.Range(1, Height + 1);

            GameObject element = GameObject.CreatePrimitive(PrimitiveType.Cube);
            element.transform.localScale= new Vector3(0.85f,randomHeight,1f);
            element.transform.position = new Vector3(i,randomHeight/2,0);
            element.transform.parent = this.transform;
            Array[i] = element;

            
        }
        transform.position = new Vector3(-SizeofArray / 2f, -Height / 2f, 0);
    }

}
