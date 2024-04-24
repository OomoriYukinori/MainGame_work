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
	// �L�����N�^�[�R���g���[���i�J�v�Z���R���C�_�j�̈ړ���
	internal Vector3 velocity;
	internal float vertical;

	// �O�i���x
	public float forwardSpeed = 7.0f;
	// ��ޑ��x
	public float backwardSpeed = 2.0f;
	// ���񑬓x
	public float rotateSpeed = 2.0f;

	private void Start()
	{
		state = new IdleState();
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");              // ���̓f�o�C�X�̐�������h�Œ�`
		float v = Input.GetAxis("Vertical");                // ���̓f�o�C�X�̐�������v�Œ�`
		animator.SetFloat("Speed", v);                          // Animator���Őݒ肵�Ă���"Speed"�p�����^��v��n��
		animator.SetFloat("Direction", h);                      // Animator���Őݒ肵�Ă���"Direction"�p�����^��h��n��
		currentBaseState = animator.GetCurrentAnimatorStateInfo(0); // �Q�Ɨp�̃X�e�[�g�ϐ���Base Layer (0)�̌��݂̃X�e�[�g��ݒ肷��
		rb.useGravity = true;//�W�����v���ɏd�͂�؂�̂ŁA����ȊO�͏d�͂̉e�����󂯂�悤�ɂ���

		// �ȉ��A�L�����N�^�[�̈ړ�����
		velocity = new Vector3(0, 0, v);        // �㉺�̃L�[���͂���Z�������̈ړ��ʂ��擾
												// �L�����N�^�[�̃��[�J����Ԃł̕����ɕϊ�
		velocity = transform.TransformDirection(velocity);

		//�ȉ���v��臒l�́AMecanim���̃g�����W�V�����ƈꏏ�ɒ�������
		if (v > 0.1)
		{
			velocity *= forwardSpeed;       // �ړ����x���|����
		}
		else if (v < -0.1)
		{
			velocity *= backwardSpeed;  // �ړ����x���|����
		}
		// �㉺�̃L�[���͂ŃL�����N�^�[���ړ�������
		transform.localPosition += velocity * Time.fixedDeltaTime;

		// ���E�̃L�[���͂ŃL�����N�^��Y���Ő��񂳂���
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
		animator.SetBool("Jump", true);     // Animator�ɃW�����v�ɐ؂�ւ���t���O�𑗂�
	}

}