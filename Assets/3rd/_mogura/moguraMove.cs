using UnityEngine;

public class MoguraMove : MonoBehaviour
{
    private bool canClick;
    private float canMovenum;
    private bool canMove = true ;
    float moveTime;
    float coolTime;
    // Start is called before the first frame update
    void Start()
    {
        coolTime = Random.Range(4f, 5f);//初期設定
        InvokeRepeating(nameof(MoveMogura), 
            Random.Range(1f, 3f),coolTime);//定期呼び出し
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove) 
        {
            moveTime += 0.05f; 
            float newY = Mathf.Lerp(-6, 1, (Mathf.Sin(moveTime * 3) + 1) / 2);//-6から1の間で上下に動かす
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, newY, gameObject.transform.position.z);//モグラを動かす
        }

        if (gameObject.transform.position.y <= -5 && canMove == true)//初期位置より下ならば
        {
            moveTime = 0;//各種リセット
            canMove = false;
            canClick = true;
            canMovenum = 100;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,-6, gameObject.transform.position.z);
        }
        if ((int)Time.time > 30)
        {
            coolTime = 6- Time.time / 10;//終わりに近づくと出る間隔が早くなる
        }
        else
        {
            coolTime = Random.Range(3f, 5f);//3f~5fの間でモグラがでる
        }
    }
    private void OnMouseDown()
    {
        if (canClick)
        {
            TextManeger.myScore.Value += 1;//モグラに触れたら1ポイント
            canClick = false;
        }
    }
    void MoveMogura()
    {
        canMovenum = UnityEngine.Random.Range(0f, 100f);
        if (canMovenum <= 33) canMove = true;//約三分の一の確率で動く
        //Debug.Log(canMovenum);
    }

    private void OnDestroy()
    {
        // Destroy時に登録したInvokeをすべてキャンセル
        CancelInvoke();
    }
}
