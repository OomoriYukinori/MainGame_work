using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGame : MonoBehaviour
{
    [Header("���������R�C���̐������")]
    [SerializeField]
    private int manyCoin;
    [Header("Coin��Prefab�����Ă�������")]
    [SerializeField]
    private GameObject Coin;
    [Header("Coin�̐����ꏊ�����Ă�������")]
    [SerializeField]
    private GameObject CoinSponPoint;
    [Header("����������Ă�������")]
    [SerializeField]
    private GameObject Stage;
    [Header("CountBox�����Ă�������")]
    [SerializeField]
    private GameObject DestroyBoxs;
    [Header("�X�C�b�`�����Ă�������")]
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
