using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Renderer rend;

    public GameObject pair;

    public int offSet = 75;

    float delay;

    // Start is called before the first frame update
    void Start()
    {
        delay = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ship") || other.CompareTag("Pilot") || other.CompareTag("Bullet") ||
            other.CompareTag("BouncyBullet"))
        {
            float angle = transform.rotation.ToEulerAngles().y;
            float pairAngle = pair.transform.rotation.ToEulerAngles().y;

            Debug.Log("teleport");

            //offset of ship to portal
            if (delay < 0)
            {
                delay = 0.25f;

                Debug.Log("teleport2");

                Vector3 dif = other.transform.position - transform.position;
                dif.y = other.transform.position.y;

                other.transform.position = Quaternion.AngleAxis(180 * (pairAngle - angle) / Mathf.PI, Vector3.up)
        * dif + pair.transform.position;

                other.transform.Rotate(new Vector3(0, (pairAngle - angle) * 180 / Mathf.PI + 180, 0));

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
                    other.transform.position -= new Vector3(Mathf.Cos(pairAngle) * offSet, 0, Mathf.Sin(pairAngle) * offSet);
                }
                else
                {
                    other.transform.position += new Vector3(Mathf.Cos(pairAngle) * offSet, 0, Mathf.Sin(pairAngle) * offSet);
                }
            }
        }
    }
}
