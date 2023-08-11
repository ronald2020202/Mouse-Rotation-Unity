using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public Vector3 mousePos;
    float x;
    float y;
    float referenceangle;
    float angle;
    float currentangle;

    float originx;
    float originy;
    Quaternion target;
    public GameObject obect;//gun gameobject
    public Transform trans;//gun transform
    // Start is called before the first frame update
    void Start()
    {
        originx = Screen.width / 2;
        originy = Screen.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;

        x = mousePos.x;
        y = mousePos.y;

        referenceangle = Mathf.Rad2Deg*Mathf.Atan(Mathf.Abs(y-originy) / Mathf.Abs(x-originx));

        angle = Mathf.Round(referenceangle);

        if((x - originx) >= 0.00f)
        {
            if((y - originy) <= 0.00f)
            {
                angle = 360f - Mathf.Round(referenceangle);
            }
        }
        else if((x - originx) < 0.00f)
        {
            if((y - originy) >= 0.00f)
            {
                angle = 180f - Mathf.Round(referenceangle);
            }
            else if((y - originy) < 0.00f)
            {
                angle = 180f + Mathf.Round(referenceangle);
            }
        }
        Quaternion target = Quaternion.Euler(0, 0, Mathf.Round(angle));
        obect.transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * 100000f);
    }
}
