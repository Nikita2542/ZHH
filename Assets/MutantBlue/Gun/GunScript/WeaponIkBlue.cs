using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[System.Serializable]
public class HumanBone
{
    public HumanBodyBones bone;
    public float weight = 1.0f;
}

public class WeaponIkBlue : MonoBehaviour
{    
    public Transform targetTransform;
    public Transform aimTransform;
    
    [Space(10)]
    public int iterations = 10;
    [Range(0, 1)]
    public float weight = 1.0f;

    public float angleLimit = 90.0f;
    public float distanceLimit = 1.5f;

    public HumanBone[] humanBones;
    Transform[] boneTransform;

    public bool isStopAim;

    void Start()
    {
       
        Animator animator = GetComponent<Animator>();
        boneTransform = new Transform[humanBones.Length];
        for(int i = 0; i < humanBones.Length; i++)
        {
            boneTransform[i] = animator.GetBoneTransform(humanBones[i].bone);
        }
        isStopAim = false;
    }

    Vector3 GetTargetPosition()
    {
        Vector3 targetDirection = targetTransform.position - aimTransform.position;
        Vector3 aimDirection = aimTransform.forward;
        float blendOut = 0.0f; 

        float targetAngle = Vector3.Angle(targetDirection, aimDirection);
        if(targetAngle > angleLimit)
        {
            blendOut += (targetAngle - angleLimit) / 50.0f;
        }

        float targetDistance = targetDirection.magnitude;
        if(targetDistance < distanceLimit)
        {
            blendOut += distanceLimit - targetDistance;
        }

        Vector3 direction = Vector3.Slerp(targetDirection, aimDirection, blendOut);
        return aimTransform.position + direction;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isStopAim == false)
        {
            if (aimTransform == null)
            {
                return;
            }
            if (targetTransform == null)
            {
                return;
            }


            Vector3 targetPosition = GetTargetPosition();
            for (int i = 0; i < iterations; i++)
            {
                for (int b = 0; b < humanBones.Length; b++)
                {
                    Transform bone = boneTransform[b];
                    float boneWeight = humanBones[b].weight * weight;
                    AimAtTarget(bone, targetPosition, boneWeight);
                }

            }
        }     
    }

    private void AimAtTarget(Transform bone, Vector3 targetPosition, float weight)
    {
        Vector3 aimDirection = aimTransform.forward;
        Vector3 targetDirection = targetPosition - aimTransform.position;
        Quaternion aimToward = Quaternion.FromToRotation(aimDirection, targetDirection);
        Quaternion blendedRotation = Quaternion.Slerp(Quaternion.identity, aimToward, weight);
        bone.rotation = blendedRotation * bone.rotation;
    }

    public void SetTargetTransform(Transform target)
    {
        targetTransform = target;
    }

    public void SetAimTransform(Transform aim)
    {
        aimTransform = aim;
    }
}
