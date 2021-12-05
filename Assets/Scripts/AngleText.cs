using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleText : MonoBehaviour
{
  private PoseManager _poseManager;

  private int currentPose = 0;
  private int lastPose = 0;
  private int counter = 0;
  
  public UnicodeInlineText angleText;
  public UnicodeInlineText counterText;
    // Start is called before the first frame update
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
      var _currentAngle = _poseManager.get3DAngle(
        PoseManager.pose.L_HIP,
        PoseManager.pose.L_SHOULDER,
        PoseManager.pose.L_ELBOW);
      angleText.text = _currentAngle.ToString("#.");
      if (_currentAngle<40)
      {
        currentPose = 0;
      } else if (_currentAngle>80)
      {
        currentPose = 1;
      }
      else
      {
        currentPose = 2;
      }
      if (lastPose == 0 && currentPose == 1)
      {
        counter=1+counter;
      }

      if (currentPose!=2)
      {
        lastPose = currentPose;
      }
      counterText.text = counter.ToString();
    }
}
