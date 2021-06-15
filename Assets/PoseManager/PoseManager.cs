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

    private static RepeatedField<NormalizedLandmark> landmarks;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPose(RepeatedField<NormalizedLandmark> newLandmarks)
    {
        if (newLandmarks.Count > 0)
        {
            landmarks = newLandmarks;
            get2DAngle(pose.L_WRIST, pose.L_ELBOW, pose.L_SHOULDER);
        }
    }

    public void get2DAngle(pose idx_first, pose idx_mid, pose idx_last)
    {
        var first = landmarks[(int) idx_first];
        var mid = landmarks[(int) idx_mid];
        var last = landmarks[(int) idx_last];
        var result = Mathf.Rad2Deg * (Mathf.Atan2(last.Y-mid.Y,last.X-mid.X)-Mathf.Atan2(first.Y-mid.Y,first.X-mid.X));
        result = Mathf.Abs(result);
        if (result > 180)
        {
            result = 360 - result;
        }
        Debug.Log(result);
    }
}
