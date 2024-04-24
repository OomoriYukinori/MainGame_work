using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trans
{
    public MonsterData[] set;
}

public class Test3 : MonoBehaviour
{
    void Start()
    {
        Vector3 v3;
        string jsonStr = Resources.Load<TextAsset>("posController").ToString();
        var data = JsonUtility.FromJson<Trans>(jsonStr);
        foreach (var ps in data.set)
        {
            v3 = new Vector3 (ps.x, ps.y, ps.z);

            switch (ps.id)
            {
                case 1:
                    transform.position = v3;
                    break;
                case 2:
                    transform.rotation = Quaternion.Euler(v3);
                    break;
                case 3:
                    transform.localScale = v3;
                    break;
            }

        }
    }
}
