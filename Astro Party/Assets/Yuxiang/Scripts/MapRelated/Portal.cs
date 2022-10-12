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

        Debug.Log(angle);
        Debug.Log(new Vector3(Mathf.Cos(angle) * offSet, 0, Mathf.Sin(angle) * offSet));

        while (angle < 0)
        {
            angle += Mathf.PI;
        }

        collision.transform.position = pair.transform.position
    + new Vector3(Mathf.Cos(angle) * offSet, 0, Mathf.Sin(angle) * offSet);

        ////special 
        //if ((angle > Mathf.PI / 2 && angle < Mathf.PI) || (angle > 3 * Mathf.PI / 2)){
        //    collision.transform.rotation = pair.transform.rotation;
        //    collision.transform.Rotate(new Vector3(0, 180, 0));
        //}
        //else
        //{
            collision.transform.rotation = pair.transform.rotation;
        
    }
}
