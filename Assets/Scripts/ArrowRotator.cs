using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotator : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform _Target;

    void Start()
    {
        _Target = GameObject.FindGameObjectWithTag("Finish").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_Target, Vector3.up);
        transform.rotation *= Quaternion.Euler(90f, 90f, 0);
    }
}
