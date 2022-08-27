using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("selfDestruct");
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            Destroy(collision.gameObject);
        }
    }
}
