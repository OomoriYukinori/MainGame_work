using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Refactoring_test : MonoBehaviour
{
    [SerializeField]
    //[FormerlySerializedAs("Num")]
    public int num;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 10.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 10.0f;
        rb.AddForce(x, 0, z, ForceMode.Impulse);
    }
}

