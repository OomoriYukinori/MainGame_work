using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStage : MonoBehaviour
{
    GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = child.gameObject.transform;
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
        //other.transform.localScale = new Vector3(1, 0.03f, 1);
    }
}
