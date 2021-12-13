using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapYbot : MonoBehaviour
{
  private PoseManager _poseManager;
  
  public Transform shoulderRight;
  public Transform shoulderLeft;
  public Transform elbowRight;
  private Vector3 shoulderRightBase = new Vector3(0, -180, -90f);
  private Vector3 shoulderLeftBase = new Vector3(0, 180, 90f);
  
    // Start is called before the first frame update b
    void Start()
    {
      _poseManager=GameObject.Find("PoseManager").GetComponent<PoseManager>();
      
      //shoulderRight.localEulerAngles = new Vector3(0, -180, -90f);
    }

    // Update is called once per frame
    void Update()
    {
      if (_poseManager.hasPose())
      {
        var currentUpAngle = _poseManager.get3DAngle(
          PoseManager.pose.L_HIP,
          PoseManager.pose.L_SHOULDER,
          PoseManager.pose.L_ELBOW);
        var currentFrontAngle = _poseManager.get3DAngle(
          PoseManager.pose.R_SHOULDER,
          PoseManager.pose.L_SHOULDER,
          PoseManager.pose.L_ELBOW);
        shoulderRight.localEulerAngles = shoulderRightBase + new Vector3(0, currentFrontAngle, currentUpAngle);
        currentUpAngle = _poseManager.get3DAngle(
          PoseManager.pose.R_HIP,
          PoseManager.pose.R_SHOULDER,
          PoseManager.pose.R_ELBOW);
        currentFrontAngle = _poseManager.get3DAngle(
          PoseManager.pose.L_SHOULDER,
          PoseManager.pose.R_SHOULDER,
          PoseManager.pose.R_ELBOW);
        shoulderLeft.localEulerAngles = shoulderLeftBase + new Vector3(0, -currentFrontAngle, -currentUpAngle);
        currentUpAngle = _poseManager.get3DAngle(
          PoseManager.pose.L_SHOULDER,
          PoseManager.pose.L_ELBOW,
          PoseManager.pose.L_WRIST);
        Debug.Log("Elbow Right Angle - "+currentUpAngle.ToString());
        currentFrontAngle = _poseManager.get3DAngle(
          PoseManager.pose.R_SHOULDER,
          PoseManager.pose.L_SHOULDER,
          PoseManager.pose.L_ELBOW);
        //elbowRight.localEulerAngles = new Vector3(0,0,-180) + new Vector3(0, 0, currentUpAngle);
      }
    }
}
