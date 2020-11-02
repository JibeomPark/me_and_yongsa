﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public int HP, MP, max_HP, max_MP;
    public int AD, AP, DEF, RES;    // Attack Damage(물공), Ability Power(마공), Defense(물방), Resistanse(마저)
    public int AS;   // 공속
    public string unitName;
    public Sprite unitIcon;
    public GameObject nextEnemy;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}