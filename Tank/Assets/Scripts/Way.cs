using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour
{
    //public GameObject target;
    private float speed = 5f;
    private float speedRotation = 2f;
    private Vector3 target;
    private Quaternion TargetRot;
    void Start()
    {
        RandomPos();
    }

    private void OnEnable()
    {
        RandomPos();
    }

    public void RandomPos()
    {
        target = new Vector3(UnityEngine.Random.Range(-22, 22), 0, UnityEngine.Random.Range(-22, 22));
        TargetRot = Quaternion.LookRotation(target - transform.position, Vector3.up);  
    }

    void Update()
    {
        
        if (Math.Abs(Quaternion.Dot(transform.rotation, TargetRot)) > 0.9998f)
        {
            Vector3 Dir = target - transform.position;
            transform.Translate(Dir.normalized * speed * Time.deltaTime, Space.World);
            if (Vector3.Distance(transform.position, target) <= 0.2f)
            {
                RandomPos();
            }
        }
        else
        {
            if(gameObject.activeSelf)
                transform.rotation = Quaternion.Lerp(transform.rotation, TargetRot, Time.deltaTime * speedRotation);
        }
    }
}
