using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LifePresenter : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] LifeView lifeView;
    // Start is called before the first frame update
    void Start()
    {
        playerData.Life.Subscribe(life =>
        {
            lifeView.SetLife(life);
        }).AddTo(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
