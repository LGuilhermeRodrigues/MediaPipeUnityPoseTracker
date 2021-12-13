using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleCounter : MonoBehaviour
{

  private enum Pose
  {
    Anatomical,
    ArmCoronal,
    ArmSagital,
    Other
  };
  
  private PoseManager _poseManager;
  private Pose currentPose = Pose.Other;
  private Pose lastPose = Pose.Other;
  private int coronalCounter = 0;
  private int sagittalCounter = 0;
  private int transverseCounter = 0;
  public UnicodeInlineText upAngleText;
  public UnicodeInlineText frontAngleText;
  public UnicodeInlineText coronalCounterText;
  public UnicodeInlineText sagittalCounterText;
  public UnicodeInlineText transverseCounterText;

    void Start()
    {
      _poseManager=GameObject.Find("PoseManager").GetComponent<PoseManager>();
    }

    // Update is called once per frame
    void Update()
    {
      if (!_poseManager.hasPose())
      {
        return;
      }
      var currentUpAngle = _poseManager.get3DAngle(
        PoseManager.pose.L_HIP,
        PoseManager.pose.L_SHOULDER,
        PoseManager.pose.L_WRIST);
      upAngleText.text = currentUpAngle.ToString("#.");
      
      var currentFrontAngle = _poseManager.get3DAngle(
        PoseManager.pose.R_SHOULDER,
        PoseManager.pose.L_SHOULDER,
        PoseManager.pose.L_WRIST);
      frontAngleText.text = currentFrontAngle.ToString("#.");
      
      if (currentUpAngle<30)
      {
        currentPose = Pose.Anatomical;
      } else if (currentUpAngle>70)
      {
        if (currentFrontAngle>160)
        {
          currentPose = Pose.ArmCoronal;
        } else if (currentFrontAngle < 120)
        {
          currentPose = Pose.ArmSagital;
        }
        else
        {
          currentPose = Pose.Other;
        }
      }
      else
      {
        currentPose = Pose.Other;
      }
      
      if (lastPose == Pose.Anatomical && currentPose == Pose.ArmCoronal)
      {
        coronalCounter++;
      }

      if (coronalCounterText==null)
      {
        return;
      }
      coronalCounterText.text = "Coronal: "+coronalCounter.ToString();
      if (lastPose == Pose.Anatomical && currentPose == Pose.ArmSagital)
      {
        sagittalCounter++;
      }
      sagittalCounterText.text = "Sagittal: "+sagittalCounter.ToString();
      if (lastPose == Pose.ArmCoronal && currentPose == Pose.ArmSagital)
      {
        transverseCounter++;
      }
      transverseCounterText.text = "Transverse: "+transverseCounter.ToString();
      
      if (currentPose!=Pose.Other)
      {
        lastPose = currentPose;
      }
    }
}
