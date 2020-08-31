using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeLive : MonoBehaviour
{
    [SerializeField]
    float tl;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,tl);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
