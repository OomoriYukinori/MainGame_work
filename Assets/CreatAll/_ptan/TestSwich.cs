using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwich : MonoBehaviour 
{
    bool test;
    [SerializeField] Collider collider;
    [SerializeField] Collider collider2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(test == true)
            {
                switch (collider)
                {
                    case BoxCollider:
                        Debug.Log("��");
                        break;
                    case SphereCollider:
                        Debug.Log("��");
                        break;
                    case CapsuleCollider:
                        Debug.Log("�J�v�Z��");
                        break;

                }
            }

            else
            {
                switch (collider,collider2)
                {
                    case (BoxCollider, BoxCollider):
                        Debug.Log("������");
                        break;
                    case (SphereCollider, SphereCollider):
                        Debug.Log("������");
                        break;
                    default:
                        Debug.Log("���Ɗ�");
                        break;
                }
            }
        }
    }
}
