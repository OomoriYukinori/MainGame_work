using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePlayer : MonoBehaviour
{
    public Vector3 playerpos;
    [SerializeField] TileCell tileCell;
    // Start is called before the first frame update
    void Start()
    {
        playerpos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (true)
        {
            Debug.Log("‰Ÿ‚³‚ê‚½");
        }
    }
}
