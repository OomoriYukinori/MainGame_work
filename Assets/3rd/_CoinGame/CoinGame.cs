using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGame : MonoBehaviour
{
    [Header("生成されるコインの数を入力")]
    [SerializeField]
    private int manyCoin;
    [Header("CoinのPrefabを入れてください")]
    [SerializeField]
    private GameObject Coin;
    [Header("Coinの生成場所を入れてください")]
    [SerializeField]
    private GameObject CoinSponPoint;
    [Header("動く台を入れてください")]
    [SerializeField]
    private GameObject Stage;
    [Header("CountBoxを入れてください")]
    [SerializeField]
    private GameObject DestroyBoxs;
    [Header("スイッチを入れてください")]
    [SerializeField]
    private bool on;
    // Start is called before the first frame update
    void Start()
    {
        SponCoin(manyCoin);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (on == true)
        {
            if(Input.GetKeyDown(KeyCode.Space) && DestroyBox.myCoins.Value > 0)
            {
                SponCoin(1);
                DestroyBox.myCoins.Value -= 1;
            }
            Stage.transform.position = new Vector3 (0,1,Mathf.Sin(Time.time)*2+5.25f);

            if (Coin.transform.parent == null)
            {
                Coin.transform.localScale =new Vector3(1, 0.03f, 1);
            }
        }
    }

    void SponCoin(int num)
    {
        for (int i = 0; i < num; i++)
        {
           Instantiate(Coin, CoinSponPoint.transform.position + new Vector3(Random.Range(-4.0f,4.0f),0, Random.Range(-4.0f, 8.0f)),Quaternion.Euler(0,0,0)); 
        }
    }


}
