﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits=16;
    [SerializeField] float paddleWidthinUnits = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.mousePosition.x/Screen.width*screenWidthInUnits);
        float mouseXPosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mouseXPosInUnits, paddleWidthinUnits/2, screenWidthInUnits - (paddleWidthinUnits / 2));
        
        transform.position = paddlePos;
    }
}
