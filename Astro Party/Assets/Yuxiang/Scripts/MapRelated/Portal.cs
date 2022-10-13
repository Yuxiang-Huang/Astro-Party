using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject pair;

    public int offSet = 50;

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

        while (angle < 0)
        {
            angle += 2 * Mathf.PI;
        }

        if (angle < Mathf.PI)
        {
            angle = Mathf.PI / 2 - angle;
        }
        else
        {
            angle += Mathf.PI / 2 - (angle - Mathf.PI) / 2;
        }

        collision.transform.position = pair.transform.position
+ new Vector3(Mathf.Cos(angle) * offSet, 0, Mathf.Sin(angle) * offSet);

        collision.transform.rotation = pair.transform.rotation;

        //if (angle > Mathf.PI)
        //{
        //    collision.transform.Rotate(new Vector3(0, 180, 0));
        //}
    }
}
