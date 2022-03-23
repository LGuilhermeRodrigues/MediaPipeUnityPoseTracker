using System.Collections;
using System.Collections.Generic;
using Google.Protobuf.Collections;
using Mediapipe;
using UnityEngine;

public class PoseManager : MonoBehaviour
{
    public enum pose {
        NOSE = 0,
        L_EYE_INNER = 1,
        L_EYE = 2,
        L_EYE_OUTER = 3,
        R_EYE_INNER = 4,
        R_EYE = 5,
        R_EYE_OUTER = 6,
        L_EAR = 7,
        R_EAR = 8,
        L_MOUTH = 9,
        R_MOUTH = 10,
        L_SHOULDER = 12,
        R_SHOULDER = 11,
        L_ELBOW = 14,
        R_ELBOW = 13,
        L_WRIST = 16,
        R_WRIST = 15,
        L_PINKY = 17,
        R_PINKY = 18,
        L_INDEX = 19,
        R_INDEX = 20,
        L_THUMB = 21,
        R_THUMB = 22,
        L_HIP = 24,
        R_HIP = 23,
        L_KNEE = 26,
        R_KNEE = 25,
        L_ANKLE = 28,
        R_ANKLE = 27,
        L_HEEL = 30,
        R_HEEL = 29,
        L_FINDEX = 32,
        R_FINDEX = 31
    }

    public enum rebasePose
    {
        
    }

    private static RepeatedField<NormalizedLandmark> landmarks;

    private int counter = 0;

    private bool startCounter = true;

    private bool poseFound = false;
    
    private int cameraResolutionWidth = 1280;
    private int cameraResolutionHeight = 720;

    public void SetPose(RepeatedField<NormalizedLandmark> newLandmarks)
    {
        if (startCounter)
        {
            StartCoroutine(FramesPerSecondCoroutine());
            startCounter = false;
        }
        
        if (newLandmarks.Count > 0)
        {
            poseFound = true;
            landmarks = newLandmarks;
            counter = counter + 1;
        }
        else
        {
          counter = counter + 1;
        }
    }

    public bool hasPose()
    {
        return poseFound;
    }

    public Vector3 getPoint(pose idx_point)
    {
        if (hasPose())
        {
            return new Vector3(
                landmarks[(int) idx_point].X*640,
                (1f-landmarks[(int) idx_point].Y)*480,
                -320*landmarks[(int) idx_point].Z);
        }
        else
        {
            return Vector3.zero;
        }
    }

    public Vector3 getRawPoint(pose idx_point)
    {
        if (hasPose())
        {
            return new Vector3(
                landmarks[(int) idx_point].X, 
                landmarks[(int) idx_point].Y,
                landmarks[(int) idx_point].Z);
        }
        else
        {
            return Vector3.zero;
        }
    }
    
    
    public float get3DAngle(pose idx_first, pose idx_mid, pose idx_last)
    {
        var first = getPoint(idx_first);
        var mid = getPoint(idx_mid);
        var last = getPoint(idx_last);
        return Vector3.Angle(first - mid, last - mid);
    }
    
    IEnumerator FramesPerSecondCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        Debug.Log(counter+" frames in 10 seconds");
    }
}
