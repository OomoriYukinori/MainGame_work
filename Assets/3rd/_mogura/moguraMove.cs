using UnityEngine;

public class MoguraMove : MonoBehaviour
{
    private bool canClick;
    private float canMovenum;
    private bool canMove = true ;
    float moveTime;
    float coolTime;
    readonly int startPosY = -5;
    // Start is called before the first frame update
    void Start()
    {
        coolTime = Random.Range(4f, 5f);//�����ݒ�
        InvokeRepeating(nameof(MoveMogura), 
        Random.Range(1f, 3f),coolTime);//����Ăяo��
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove) 
        {
            moveTime += 0.05f; 
            float newY = Mathf.Lerp(-6, 1, (Mathf.Sin(moveTime * 3) + 1) / 2);//����-6����1�̊Ԃŏ㉺�ɓ�����
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, newY, gameObject.transform.position.z);//���O���𓮂���
        }

        if (gameObject.transform.position.y <= startPosY && canMove == true)//�����ʒu��艺�Ȃ��
        {
            moveTime = 0;//�e�탊�Z�b�g
            canMove = false;
            canClick = true;
            canMovenum = 100;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,startPosY-1, gameObject.transform.position.z);
        }
        if ((int)Time.time > 30)
        {
            coolTime = 6- Time.time / 10;//�I���ɋ߂Â��Əo��Ԋu�������Ȃ�
        }
        else
        {
            coolTime = Random.Range(3f, 5f);//3f~5f�̊��o�Ń��O�����ł�
        }
    }
    private void OnMouseDown()
    {
        if (canClick)
        {
            TextManeger.myScore.Value += 1;//���O���ɐG�ꂽ��1�|�C���g
            canClick = false;
        }
    }
    void MoveMogura()
    {
        canMovenum = UnityEngine.Random.Range(0f, 100f);
        if (canMovenum <= 33) canMove = true;//��O���̈�̊m���œ���
        if (Time.timeScale == 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -6, gameObject.transform.position.z);
        }
        //Debug.Log(canMovenum);
    }

    private void OnDestroy()
    {
        // Destroy���ɓo�^����Invoke�����ׂăL�����Z��
        CancelInvoke();
    }
}
