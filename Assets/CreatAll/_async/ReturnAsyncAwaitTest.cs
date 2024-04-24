using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public class ReturnAsyncAwaitTest : MonoBehaviour
{
    private void Start()
    {
        var unitask = ReturnDelayAsync().ContinueWith(ut => Debug.Log(ut));
    }
    private async UniTask<string> ReturnDelayAsync()
    {
        Debug.Log("AsyncStart");
        await UniTask.Delay(1000);
        Debug.Log("AsyncEnd");
        return "TestReturn";
    }
}
