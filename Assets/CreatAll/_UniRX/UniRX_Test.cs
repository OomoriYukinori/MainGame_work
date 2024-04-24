using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using UniRx.Triggers;

public class UniRX_Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //指定フレーム後に呼ぶ
        Observable.NextFrame().Subscribe(_ =>
        {
            Debug.Log("1フレーム後に実行");
        }).AddTo(this);

        Observable.Timer(TimeSpan.FromMilliseconds(100)).Subscribe(_ =>
        {
            Debug.Log("100ミリセカンド後");
        }).AddTo(this);

        Observable.TimerFrame(2).Subscribe(_ =>
        {
            Debug.Log("2フレーム後");
        }).AddTo(this);

        //100msごとに呼ぶ(ループ)
        Observable.Interval(TimeSpan.FromMilliseconds(100)).Subscribe(_ =>
        {
            Debug.Log("100ms経った");
        }).AddTo(this);

        //イベントが2秒以内に連続してきた場合、最初だけ通してそれ以外を無視する
        this.UpdateAsObservable()
         .Where(_ => Input.GetKeyDown(KeyCode.Space))
         .ThrottleFirst(TimeSpan.FromSeconds(2))
         .Subscribe(_ => Debug.Log("スペースキーが押された！"));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
