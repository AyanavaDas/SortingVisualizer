using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GenerateArray script;
    public GenerateArray Activator;

    public void SelectionSort()
    {
        //Destroy(Activator.gameObject);
        Activator = Instantiate(script);
        Activator.StartSelectionSort();

    }
    public void BubbleSort()
    {
        //Destroy(Activator.gameObject);
        Activator = Instantiate(script);
        Activator.StartBubbleSort();
    }
    public void QuickSort()
    {
        //Destroy(Activator.gameObject);
        Activator = Instantiate(script);
        Activator.StartQuickSort();

    }
    public void Reset()
    {
        Destroy(Activator.gameObject);
    }
    
}
