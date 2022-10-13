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

        bool reverse = false;

        if (angle < Mathf.PI)
        {
            angle = Mathf.PI / 2 - angle;
        }
        else
        {
            angle -= Mathf.PI;
            angle = Mathf.PI / 2 - angle;
            reverse = true;
        }

        if (reverse){
            collision.transform.position = pair.transform.position
- new Vector3(Mathf.Cos(angle) * offSet, 0, Mathf.Sin(angle) * offSet);

        }
        else
        {
            collision.transform.position = pair.transform.position
+ new Vector3(Mathf.Cos(angle) * offSet, 0, Mathf.Sin(angle) * offSet);
            
        }

        collision.transform.rotation = pair.transform.rotation;
    }
}
