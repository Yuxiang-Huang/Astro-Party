using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject pair;

    public bool once = true;

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
        Debug.Log("teleport2");

        float angle = transform.rotation.ToEulerAngles().y;
        float pairAngle = pair.transform.rotation.ToEulerAngles().y;

        //offset of ship to portal
        if (once)
        {
            Debug.Log("teleport");
            once = false;

            Vector3 dif = transform.position - collision.transform.position;
            dif.y = collision.transform.position.y;

            collision.transform.position = Quaternion.AngleAxis(180 * (pairAngle - angle) / Mathf.PI, Vector3.up)
                * dif + pair.transform.position;
            Debug.Log(collision.transform.position);

            while (pairAngle < 0)
            {
                pairAngle += 2 * Mathf.PI;
            }

            bool reverse = false;

            if (pairAngle < Mathf.PI)
            {
                pairAngle = Mathf.PI / 2 - pairAngle;
            }
            else
            {
                pairAngle -= Mathf.PI;
                pairAngle = Mathf.PI / 2 - pairAngle;
                reverse = true;
            }

            float offSet = 50;

            if (reverse)
            {
                collision.transform.position -= new Vector3(Mathf.Cos(pairAngle) * offSet, 0, Mathf.Sin(pairAngle) * offSet);
            }
            else
            {
                collision.transform.position += new Vector3(Mathf.Cos(pairAngle) * offSet, 0, Mathf.Sin(pairAngle) * offSet);
            }

            collision.transform.rotation = pair.transform.rotation;
        }
    }
}
