using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject pair;

    bool once = true;

    public int offSet = 75;

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
        float angle = transform.rotation.ToEulerAngles().y;
        float pairAngle = pair.transform.rotation.ToEulerAngles().y;

        //offset of ship to portal
        if (once)
        {
            StartCoroutine("wait");

            Vector3 dif = collision.transform.position - transform.position;
            dif.y = collision.transform.position.y;

            collision.transform.position = Quaternion.AngleAxis(180 * (pairAngle - angle) / Mathf.PI, Vector3.up)
    * dif + pair.transform.position;

            collision.transform.Rotate(new Vector3(0, (pairAngle - angle) * 180 / Mathf.PI + 180, 0));

            //add a little more offset
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

            if (reverse)
            {
                collision.transform.position -= new Vector3(Mathf.Cos(pairAngle) * offSet, 0, Mathf.Sin(pairAngle) * offSet);
            }
            else
            {
                collision.transform.position += new Vector3(Mathf.Cos(pairAngle) * offSet, 0, Mathf.Sin(pairAngle) * offSet);
            }
        }
    }

    IEnumerator wait()
    {
        once = false;
        yield return new WaitForSeconds(0.3f);
        once = true;
    }
}
