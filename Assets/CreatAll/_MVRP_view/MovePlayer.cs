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
        // 左キーを押したら左方向へ進む
        if (Input.GetKey(KeyCode.LeftArrow))
            playerSpeed = -speed;
        // 右キーを押したら右方向へ進む
        else if (Input.GetKey(KeyCode.RightArrow))
            playerSpeed = speed;
        // 何も押されていない場合は停止
        else
            playerSpeed = 0;

        // 上キーを押したら前進、下キーを押したら後退
        float verticalInput = Input.GetAxis("Vertical");
        float verticalSpeed = verticalInput * speed;

        // 移動ベクトルを作成し、Rigidbodyに適用
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
        // 地面またはプラットフォームに接触したらジャンプできる状態に戻す
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