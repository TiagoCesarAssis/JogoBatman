﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

  // Use this for initialization
    void Start () {

    }

  // Update is called once per frame
    void Update () {

      transform.Rotate (Vector3.forward * 100 * Time.deltaTime);

    }
}
