﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_or : MonoBehaviour {

    public obj_output in1, in2;
    public obj_input output;// entry gates and output
    public UnityEngine.GameObject on, off; // image of state of gate
    public bool fix;// draging possible?
    public int state;
    public selfdestruct self;
    // Use this for initialization
    void Start()
    {
        state = 0;
    }

   

    public int ExitOfGate()
    {

        if ((in1.InIsnotnull() && in2.InIsnotnull()) && (in1.Getinstate() != 0 && in2.Getinstate() != 0))
        {
            self.condition.SetLink(true);
            if ((in1.Getinstate() == 1 && in2.Getinstate() == 1))
            {
                state = 1;
                self.condition.SetLight(false);
            }
            else
            {
                self.condition.SetLight(true);
                state = 2;
            }
            return state;
        }
        state = 0;

        self.condition.SetLink(false);
        self.condition.SetLight(false);
        return state;
    }

    // Update is called once per frame
    void Update () {
        output.ininfo.SetState(ExitOfGate());
    }
}
