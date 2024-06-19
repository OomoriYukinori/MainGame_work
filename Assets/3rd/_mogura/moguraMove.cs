using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class moguraMove : MonoBehaviour
{
    private bool canClick;
    private float canMovenum;
    private bool canMove = true ;
    float cooltime;
    float cool;
    // Start is called before the first frame update
    void Start()
    {
        cool = UnityEngine.Random.Range(4f, 5f);
        InvokeRepeating(nameof(MoveMogura), UnityEngine.Random.Range(1f, 3f),cool);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove) 
        {
            cooltime += 0.05f; 
            float newY = Mathf.Lerp(-6, 1, (Mathf.Sin(cooltime * 3) + 1) / 2);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, newY, gameObject.transform.position.z);
        }

        if (gameObject.transform.position.y <= -5 && canMove == true)
        {
            cooltime = 0;
            canMove = false;
            canClick = true;
            canMovenum = 100;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,-6, gameObject.transform.position.z);
        }
        if ((int)Time.time > 30)
        {
            cool = 6- Time.time / 10;
        }
        else
        {
            cool = UnityEngine.Random.Range(3f, 5f);
        }
    }
    private void OnMouseDown()
    {
        if (canClick)
        {
            TextManeger.myScore.Value += 1;
            canClick = false;
        }
    }
    void MoveMogura()
    {
        canMovenum = UnityEngine.Random.Range(0f, 100f);
        if (canMovenum <= 33) canMove = true;
            Debug.Log(canMovenum);
    }

    private void OnDestroy()
    {
        // DestroyŽž‚É“o˜^‚µ‚½Invoke‚ð‚·‚×‚ÄƒLƒƒƒ“ƒZƒ‹
        CancelInvoke();
    }
}
