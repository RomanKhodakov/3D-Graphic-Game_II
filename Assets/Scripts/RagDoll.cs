using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDoll : MonoBehaviour
{

    [SerializeField] private Rigidbody RB;
    [SerializeField] private float killForce;
    [SerializeField] private Rigidbody[] RBs;
    [SerializeField] private Collider[] Colls;
    [SerializeField] private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        RBs = GetComponentsInChildren<Rigidbody>();
        Colls = GetComponentsInChildren<Collider>();
        Revive();
    }

    private void Kill ()
    {
        SetRagDoll(true);
        SetMain(false);
    }

    private void Revive ()
    {
        SetRagDoll(false);
        SetMain(true);
    }
    private void SetMain (bool active)
    {
        anim.enabled = active;
        RBs[0].isKinematic = !active;
        Colls[0].enabled = active;
    }

    private void SetRagDoll(bool active)
    {
        for (int i = 0; i < RBs.Length; i++)
        {
            RBs[i].isKinematic = !active;
        }
        for (int i = 0; i < Colls.Length; i++)
        {
            Colls[i].enabled = active;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Kill();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Revive();
        }
    }
}
