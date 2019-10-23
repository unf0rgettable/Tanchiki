using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTank : MonoBehaviour
{
    //Пушка
    GameObject gun;
    //Есть цель
    bool TargetHave = false;
    //Цель
    private GameObject Target;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject point;

    private bool readyToShoot = true;

    [SerializeField]
    bool LOG = false;
    [SerializeField]
    float speed = 4;

    

    void Start()
    {
        gun = transform.gameObject;
    }

    private void OnEnable()
    {
        Target = null;
        gun = transform.gameObject;
        readyToShoot = true;
    }

    Vector3 currentDir;
    void Update()
    {
        if(TargetHave)
        {
            //gun.transform.LookAt(Target.transform);

            Vector3 dir = Target.transform.position - gun.transform.position;
            
            if (LOG)
            {
                Debug.DrawRay(gameObject.transform.position, dir, Color.red);
            }
            dir.Normalize();
            currentDir = Vector3.Lerp(currentDir, dir, Time.deltaTime * speed);

            gun.transform.forward = currentDir;

            if (readyToShoot)
            {
                StartCoroutine(shot());
            }
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject != gameObject && collision.transform.parent.tag == "Tank" && collision.transform.tag != "Telo")
        {
            if (LOG)
                Debug.Log("MyName:" + gameObject.name + " NameCol: " + collision.transform.name + " TagCol:" + collision.transform.tag);
            TargetHave = true;
            Target = collision.transform.gameObject;
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.transform.gameObject != gameObject && collision.transform.parent.tag == "Tank" && collision.transform.tag != "Telo")
    //    {
    //        TargetHave = false;
    //        Target = null;
    //    }
    //}

    IEnumerator shot()
    {
        TargetHave = false;
        readyToShoot = false;
        Instantiate(bullet, point.transform.position, point.transform.rotation);
        yield return new WaitForSeconds(3.5f);
        readyToShoot = true;
    }
}
