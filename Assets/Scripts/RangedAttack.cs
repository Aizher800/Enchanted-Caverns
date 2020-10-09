using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject rangedAtt;
    private Touch touch;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {

            if (Input.touchCount == 1)
                touch = Input.GetTouch(0);
            {

                if (touch.phase == TouchPhase.Began)
                {

                }
            }
        }
    }
}