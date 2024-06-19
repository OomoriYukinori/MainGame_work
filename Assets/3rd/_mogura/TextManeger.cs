using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class TextManeger : MonoBehaviour
{
    static public ReactiveProperty<int> myScore = new();
    float time;
    
    // Start is called before the first frame update
    [SerializeField] Text scoreText;
    [SerializeField] Text timserText;
    void Start()
    {
        myScore.Subscribe(value => scoreText.text =　"スコア_"+ value.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        time = 60 - (int)Time.time;
        timserText.text = "残り"+time.ToString()+"秒" ;
        if (time <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
