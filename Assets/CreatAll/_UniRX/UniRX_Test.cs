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
        //�w��t���[����ɌĂ�
        Observable.NextFrame().Subscribe(_ =>
        {
            Debug.Log("1�t���[����Ɏ��s");
        }).AddTo(this);

        Observable.Timer(TimeSpan.FromMilliseconds(100)).Subscribe(_ =>
        {
            Debug.Log("100�~���Z�J���h��");
        }).AddTo(this);

        Observable.TimerFrame(2).Subscribe(_ =>
        {
            Debug.Log("2�t���[����");
        }).AddTo(this);

        //100ms���ƂɌĂ�(���[�v)
        Observable.Interval(TimeSpan.FromMilliseconds(100)).Subscribe(_ =>
        {
            Debug.Log("100ms�o����");
        }).AddTo(this);

        //�C�x���g��2�b�ȓ��ɘA�����Ă����ꍇ�A�ŏ������ʂ��Ă���ȊO�𖳎�����
        this.UpdateAsObservable()
         .Where(_ => Input.GetKeyDown(KeyCode.Space))
         .ThrottleFirst(TimeSpan.FromSeconds(2))
         .Subscribe(_ => Debug.Log("�X�y�[�X�L�[�������ꂽ�I"));


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
