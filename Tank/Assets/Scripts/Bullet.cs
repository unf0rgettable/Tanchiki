using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;

    [SerializeField]
    private float speed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider othe)
    {
        if (othe.gameObject != gameObject && othe.transform.tag != "Gun" && othe.transform.tag != "Bullet")
        {
            othe.transform.parent.gameObject.SetActive(false);
            GameObject.Find("GameManager").transform.GetComponent<Score>().updt_scr();
            gameObject.SetActive(false);
        }
    }
}
