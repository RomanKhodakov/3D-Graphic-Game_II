using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class IKforLeftHand : MonoBehaviour
{
    [SerializeField] private Animator animatorGO;
    [SerializeField] private Transform handObj;
    [SerializeField] private Transform lookObj;
    [SerializeField] private float leftHandWeight;
    [SerializeField] private bool ikActive;
    [SerializeField] private Transform headThatLook;
    void Start()
    {
        animatorGO = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if(ikActive)
        {
            if (Vector3.Distance(headThatLook.position, lookObj.position) < 2)
            {
                if (lookObj)
                {
                    animatorGO.SetLookAtWeight(1);
                    animatorGO.SetLookAtPosition(lookObj.position);
                }
            }

            if (handObj)
            {
                animatorGO.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandWeight);
                animatorGO.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandWeight);
                animatorGO.SetIKPosition(AvatarIKGoal.LeftHand, handObj.position);
                animatorGO.SetIKRotation(AvatarIKGoal.LeftHand, handObj.rotation);
            }

        } else
        {
            animatorGO.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            animatorGO.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            animatorGO.SetLookAtWeight(0);

        }
    }
}
