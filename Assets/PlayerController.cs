using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody _Rigidbody;
    Animator _Animator;
    int Direction = 1;
    public float Speed;
    float LookDirection = 90;
    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody>();
        _Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            Direction = 1;
            LookDirection = 90;
            _Animator.SetBool("Running", true);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            LookDirection = -90;
            Direction = -1;
            _Animator.SetBool("Running", true);
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            Direction = 0;
            _Animator.SetBool("Running", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_Animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            {
                _Animator.SetTrigger("Jump");
                _Rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
        }
    }
    private void FixedUpdate()
    {
        _Rigidbody.rotation = Quaternion.Euler(0, LookDirection, 0);
        _Rigidbody.position += Direction * Vector3.right * Time.fixedDeltaTime * Speed;
    }
}
