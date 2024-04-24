using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MonsterData
{
    public int id;
    public string name;
    public bool isHuman;

    //ˆÈ‰º‰Û‘è
    public int hp;
    public int attackPoint;
    public int x;
    public int y;
    public int z;
}

public class Test1 : MonoBehaviour
{
    void Start()
    {
        string jsonStr = Resources.Load<TextAsset>("TestJson").ToString();
        var monster = JsonUtility.FromJson<MonsterData>(jsonStr);
        Debug.Log("id " + monster.id);
        Debug.Log("name " + monster.name);
        Debug.Log("isHuman " + monster.isHuman);
        Debug.Log("hp " + monster.hp);
        Debug.Log("attackPoint " + monster.attackPoint);
    }
}
