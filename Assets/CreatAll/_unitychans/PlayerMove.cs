using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Statepatans
{
	public Animator animator;
	public Rigidbody rb;

	private IPlayerState state;
	internal AnimatorStateInfo currentBaseState;
	public float jumpPower = 3.0f;
	// キャラクターコントローラ（カプセルコライダ）の移動量
	internal Vector3 velocity;
	internal float vertical;

	// 前進速度
	public float forwardSpeed = 7.0f;
	// 後退速度
	public float backwardSpeed = 2.0f;
	// 旋回速度
	public float rotateSpeed = 2.0f;

	private void Start()
	{
		state = new IdleState();
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");              // 入力デバイスの水平軸をhで定義
		float v = Input.GetAxis("Vertical");                // 入力デバイスの垂直軸をvで定義
		animator.SetFloat("Speed", v);                          // Animator側で設定している"Speed"パラメタにvを渡す
		animator.SetFloat("Direction", h);                      // Animator側で設定している"Direction"パラメタにhを渡す
		currentBaseState = animator.GetCurrentAnimatorStateInfo(0); // 参照用のステート変数にBase Layer (0)の現在のステートを設定する
		rb.useGravity = true;//ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする

		// 以下、キャラクターの移動処理
		velocity = new Vector3(0, 0, v);        // 上下のキー入力からZ軸方向の移動量を取得
												// キャラクターのローカル空間での方向に変換
		velocity = transform.TransformDirection(velocity);

		//以下のvの閾値は、Mecanim側のトランジションと一緒に調整する
		if (v > 0.1)
		{
			velocity *= forwardSpeed;       // 移動速度を掛ける
		}
		else if (v < -0.1)
		{
			velocity *= backwardSpeed;  // 移動速度を掛ける
		}
		// 上下のキー入力でキャラクターを移動させる
		transform.localPosition += velocity * Time.fixedDeltaTime;

		// 左右のキー入力でキャラクタをY軸で旋回させる
		transform.Rotate(0, h * rotateSpeed, 0);

		vertical = v;

		/*
		if (Input.GetButtonDown("Jump"))
		{
			state = state.Jump(this);
		}*/

		if (Input.GetKeyDown(KeyCode.Space))
		{
			state = state.Jump(this);
		}

		state = state.Update(this);
	}

	public void Jump()
	{
		rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
		animator.SetBool("Jump", true);     // Animatorにジャンプに切り替えるフラグを送る
	}

}