using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateArray : MonoBehaviour
{
   
    [SerializeField] public int Height = 100;
    [SerializeField] public int SizeofArray = 25;
    //[SerializeField] public int initPos = 0;
    //[SerializeField] public int initZ = 0;
    //[SerializeField] Material color;
    public GameObject[] Array;
    public void StartSelectionSort()
    {
        Init();
        StartCoroutine(selectionsort(Array));
    }
    public void StartBubbleSort()
    {
        Init();
        StartCoroutine(bubblesort(Array));

    }
    public void StartQuickSort()
    {
        Init();
        //mergeSort(0,SizeofArray-1,Array);
        StartCoroutine(quicksort(0, SizeofArray - 1, Array));
    }
    public void StartMergeSort()
    {
        Init();
        mergeSort(0, SizeofArray - 1, Array);
    }
    private void swap(GameObject [] arr,int i ,int j)
    {
        //Invoke("delay", 1.5f);
        GameObject t;

        t = arr[j];
        arr[j] = arr[i];
        arr[i] = t;
        Vector3 temp = arr[j].transform.localPosition;
        arr[j].transform.localPosition =
            new Vector3(arr[i].transform.localPosition.x, temp.y, temp.z);
        arr[i].transform.localPosition =
            new Vector3(temp.x, arr[i].transform.localPosition.y, arr[i].transform.localPosition.z);

    }
    public void delay()
    {
        return;
    }
    void merge(int l,int m,int r, GameObject[] Arr)
    {
        //yield return new WaitForSeconds(1);
        int [] L, R;
        int n1 = m - l + 1, n2 = r - m;
        L = new int[m - l + 1];
        R = new int[r - m];
        for(int a=0;a<n1;a++ )
        {
            L[a] = l + a;
        }
        for(int a=0;a<n2;a++)
        {
            R[a] = m + 1 + a;
        }
        int i = 0, j = 0, k = l;
        while(i<n1&&j<n2)
        {
            //yield return new WaitForSeconds(1);
            if(Arr[L[i]].transform.localScale.y<=Arr[R[j]].transform.localScale.y)
            {
                Arr[k] = Arr[L[i]];
                //Arr[k].transform.localPosition = Arr[L[i]].transform.position;
                //swap(Arr, k, L[i]);
                i++;
            }
            else
            {

                Arr[k] = Arr[R[j]];
                //Arr[k].transform.localPosition = Arr[R[j]].transform.position;
                //swap(Arr, k, R[j]);

                j++;
            }
            k++;
        }
        while(i<n1)
        {
            //yield return new WaitForSeconds(1);
            //swap(Arr, k, L[i]);

            Arr[k] = Arr[L[i]];
            //Arr[k].transform.localPosition = Arr[L[i]].transform.position;
            i++;
            k++;

        }
        while(j<n2)
        {
            // yield return new WaitForSeconds(1);

            Arr[k] = Arr[R[j]];
            //Arr[k].transform.localPosition = Arr[R[j]].transform.position;
            //swap(Arr, k, R[j]);
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
            //StartCoroutine(merge(l, m, r, Arr));
            merge(l, m, r, Arr);

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
                
                t = arr[j];
                arr[j] = arr[i];
                arr[i] = t;
                Vector3 temp= arr[j].transform.localPosition;
                arr[j].transform.localPosition = 
                    new Vector3(arr[i].transform.localPosition.x, temp.y, temp.z);
                arr[i].transform.localPosition = 
                    new Vector3(temp.x, arr[i].transform.localPosition.y, arr[i].transform.localPosition.z);


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

        return (i + 1);
        
    }
    IEnumerator bubblesort(GameObject [] Arr)
    {
        for(int i=0;i<SizeofArray-1;i++)
        {
            yield return new WaitForSeconds(0.5f);
            for (int j=0;j<SizeofArray-1-i;j++)
            {
                
                if(Arr[j].transform.localScale.y>Arr[j+1].transform.localScale.y)
                {
                    //yield return new WaitForSeconds(1);
                    swap(Arr, j, j + 1);
                }
            }
            LeanTween.color(Arr[SizeofArray - 1 - i], Color.green, 0.5f);
        }
        LeanTween.color(Arr[0], Color.green,0.5f);
    }
    IEnumerator selectionsort(GameObject[] arr)
    {
        int mn;
        for(int i=0;i<SizeofArray-1;i++)
        {
            yield return new WaitForSeconds(0.5f);
            mn = i;
            for(int j=i+1;j<SizeofArray;j++)
            {
                if(arr[j].transform.localScale.y<arr[mn].transform.localScale.y)
                {
                    mn = j;
                }
                
            }
            swap(arr, mn, i);
            LeanTween.color(arr[i], Color.green, 0.5f);
        }
        LeanTween.color(arr[SizeofArray-1], Color.green, 0.5f);
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
