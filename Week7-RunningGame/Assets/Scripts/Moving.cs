using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]

public class Moving : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private Animator _animator;

    [SerializeField] private float _moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if(gameObject.transform.rotation != Quaternion.Euler(0, 0, 0))
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("isFastRun", true);
            Vector3 playerInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            Vector3 hizEklentisi = playerInput * Time.deltaTime * _moveSpeed;
            transform.Translate(hizEklentisi);                 
        }
        else
        { 
            _animator.SetBool("isFastRun", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _animator.SetBool("isBack", true);
            transform.Translate(new Vector3(0, 0, -2f) * Time.deltaTime);
        }
        else
        {
            _animator.SetBool("isBack", false);
        }

        if (Input.GetKey(KeyCode.Space)) //Zýplama
        {
            _animator.SetBool("isJump", true);
            transform.Translate(new Vector3(0, 3f, 0) * Time.deltaTime);

        }
        else
        {
            _animator.SetBool("isJump", false);
        }

        //Ölme

    }
}
