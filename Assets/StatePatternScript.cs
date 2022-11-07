using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.PlayerLoop;

//状態遷移で動く(StatePattern)で動くキャラクター
public class StatePatternScript : MonoBehaviour
{

    
    public int StatePattern; //状態遷移番号

    private int Walk = 1;
    private int Rotate = 5;
    private float intervaltime = 0; //待ち時間(現在値)
    private float intervaltimeMax = 10;//待ち時間 (最大値)
    
    // Start is called before the first frame update
    void Start()
    {
        StatePattern = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //時間を増やす
        intervaltime += Time.deltaTime;
            
        if (StatePattern == 0)
        {
            //前進
            transform.Translate(0,0,Walk*Time.deltaTime);
            if (intervaltimeMax <= intervaltime)
            {//時間が一定時間を超えると下の動作へ
                StatePattern = 1;   //回転に遷移
            }
            
        }

        if (StatePattern == 1)
        {
            transform.Rotate(0,Rotate,0);
        }
        
    }

    private void OnGUI()
    {
       // GUILayout.Label("Time: "+);
    }
}
