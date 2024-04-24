using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 3f;
    private float playerSpeed;
    public float jumpForce = 5.0f;
    Rigidbody rb;
    private bool canJump = true;


    bool _unirxTest;
    [SerializeField] PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        // ���L�[���������獶�����֐i��
        if (Input.GetKey(KeyCode.LeftArrow))
            playerSpeed = -speed;
        // �E�L�[����������E�����֐i��
        else if (Input.GetKey(KeyCode.RightArrow))
            playerSpeed = speed;
        // ����������Ă��Ȃ��ꍇ�͒�~
        else
            playerSpeed = 0;

        // ��L�[����������O�i�A���L�[������������
        float verticalInput = Input.GetAxis("Vertical");
        float verticalSpeed = verticalInput * speed;

        // �ړ��x�N�g�����쐬���ARigidbody�ɓK�p
        Vector3 movement = new Vector3(playerSpeed, 0, verticalSpeed);
        rb.velocity = movement;


        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, (ForceMode)ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �n�ʂ܂��̓v���b�g�t�H�[���ɐڐG������W�����v�ł����Ԃɖ߂�
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerData.Damage(1);
        }

        if (collision.gameObject.CompareTag("Heal"))
        {
            playerData.Damage(-2);
        }

    }
}