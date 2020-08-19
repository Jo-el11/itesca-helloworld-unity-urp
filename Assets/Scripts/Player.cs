using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed=2f;
    // Start is called before the first frame update
    Animator anim;
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        anim.SetFloat("movement",Mathf.Abs(Axis.magnitude));
    }

    void Movement()
    {
        transform.Translate( Axis*Time.deltaTime*moveSpeed);
    }
    Vector3 Axis => new Vector3(Input.GetAxis("Horizontal"), 0f,Input.GetAxis("Vertical"));
}

