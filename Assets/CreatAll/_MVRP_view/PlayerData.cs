using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public IntReactiveProperty Life = new IntReactiveProperty(5);

    public void Damage(int value)
    {
        Life.Value -= value;
    }

    private void OnDestroy()
    {
        Life.Dispose();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
