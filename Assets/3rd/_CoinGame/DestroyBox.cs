using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class DestroyBox : MonoBehaviour
{
    static public ReactiveProperty<int> myCoins = new ReactiveProperty<int>();
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        myCoins.Subscribe(value => coinText.text= value.ToString());
        myCoins.Value = 10;
        //coinText.text = myCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        myCoins.Value+=1;
        coinText.text = myCoins.ToString();
    }
}
