using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    void OnApplicationQuit()
    {
        Debug.Log("Application ending after " + Time.time + " seconds");
    }
}