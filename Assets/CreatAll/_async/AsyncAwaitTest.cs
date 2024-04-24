using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncAwaitTest : MonoBehaviour
{
    private void Start()
    {
        var task = DelayAsync();
    }
    private async UniTask DelayAsync()
    {
        Debug.Log("Start");
        await Task.Delay(1000);
        Debug.Log("End");
    }
}
