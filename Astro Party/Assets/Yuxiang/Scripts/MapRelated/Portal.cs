using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject pair;

    public int offSet = 50;

    public bool reverse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        float angle = pair.transform.rotation.ToEulerAngles().y;

        collision.transform.position = pair.transform.position
+ new Vector3(Mathf.Cos(angle) * offSet, 0, Mathf.Sin(angle) * offSet);

        collision.transform.rotation = pair.transform.rotation;

        if (reverse)
        {
            collision.transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
