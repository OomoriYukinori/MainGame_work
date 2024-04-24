using Cysharp.Threading.Tasks;
using System.Threading.Tasks;
using UnityEngine;
public class StartAsyncTest : MonoBehaviour
{
    private async void Start()
    {
        await DelayAsync();
        Debug.Log("StartAsyncTestEnd");
    }
    private async UniTask DelayAsync()
    {
        Debug.Log("AsyncStart");
        await Task.Delay(1000);
        Debug.Log("AsyncEnd");
    }
}
