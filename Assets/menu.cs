using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GenerateArray script;
    public GenerateArray Activator;
    public void MergeSort()
    {
        Activator = Instantiate(script);
        Activator.StartMergeSort();
    }
    public void QuickSort()
    {
        Activator = Instantiate(script);
        Activator.StartQuickSort();

    }
    public void Reset()
    {
        Destroy(Activator.gameObject);
    }
    
}
