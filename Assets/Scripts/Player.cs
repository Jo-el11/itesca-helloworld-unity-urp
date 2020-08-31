using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textmesh;

    [SerializeField]
    float moveSpeed=2f;

    [SerializeField]
    float jumpforce= 5f;

    [SerializeField]
    GameObject go;
    // Start is called before the first frame update
    Animator anim;
    int score;
    GameInput gameInputs;
    Rigidbody rb;

    void Awake(){
        gameInputs=new GameInput();
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
    }

    void Start()
    {
        gameInputs.Land.Jump.performed+=_=>{
            rb.AddForce(Vector3.up*jumpforce, ForceMode.Impulse);
        };
        gameInputs.Land.Jump.performed+=_=>Debug.Log("salto");
    }
    
    void OnEnable()
    {
        gameInputs.Enable();
    }

    void OnDisable()
    {
        gameInputs.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        anim.SetFloat("movement",Mathf.Abs(Axis.magnitude));
    }

    void Movement()
    {
        if(IsMoving)
        {
            transform.Translate( Vector3.forward *Time.deltaTime*moveSpeed);
            transform.rotation =Quaternion.LookRotation(new Vector3(Axis.x, 0f,Axis.y));
        }
    }
    Vector2 Axis => gameInputs.Land.Move.ReadValue<Vector2>();
    bool IsMoving => Mathf.Abs(Axis.magnitude)>0;
    float AxisMagnitude => Mathf.Abs(Axis.magnitude);

    void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Collectable"))
        {
            score++;
            Instantiate(go);
            textmesh.text=$"Score: {score}";
            Destroy(other.gameObject);
        }
    }
}