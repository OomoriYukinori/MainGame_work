using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeView : MonoBehaviour
{
    [SerializeField] List<GameObject> lifes;

    public void SetLife(int lifeCount)
    {
        for (int i = 0; i < lifes.Count; i++)
        {
            GameObject life = lifes[i];
            life.SetActive(lifeCount > i);
        }
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
