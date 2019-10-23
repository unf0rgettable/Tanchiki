using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBull : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return StartCoroutine(Dead());
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
