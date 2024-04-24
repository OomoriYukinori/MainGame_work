using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersArray
{
    public MonsterData[] monsters;
}

public class Test2 : MonoBehaviour
{
    void Start()
    {
        string jsonStr = Resources.Load<TextAsset>("TestArrayJson").ToString();
        var data = JsonUtility.FromJson<MonstersArray>(jsonStr);
        foreach (var monster in data.monsters)
        {
            Debug.Log("id " + monster.id);
            Debug.Log("name " + monster.name);
            Debug.Log("isHuman " + monster.isHuman);
        }
    }
}
