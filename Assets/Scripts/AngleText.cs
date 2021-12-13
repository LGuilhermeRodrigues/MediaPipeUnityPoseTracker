using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleText : MonoBehaviour
{
  private enum CalculationType
  {
    Unity,Mathf
  }

  [SerializeField] private CalculationType calculationType = CalculationType.Mathf;
  
  private PoseManager _poseManager;
  public UnicodeInlineText TextObject;

  public PoseManager.pose angle1;
  public PoseManager.pose angle2;
  public PoseManager.pose angle3;
    // Start is called before the first frame update
    void Start()
    {
      _poseManager=GameObject.Find("PoseManager").GetComponent<PoseManager>();
    }

    // Update is called once per frame
    void Update()
    {
      if (_poseManager.hasPose())
      {
        var currentUpAngle = _poseManager.get3DAngle(
          angle1,
          angle2,
          angle3);
        if (calculationType==CalculationType.Unity)
        {
          var p1 = _poseManager.getRawPoint(angle1);
          var p2 = _poseManager.getRawPoint(angle2);
          var p3 = _poseManager.getRawPoint(angle3);
          currentUpAngle = Vector3.Angle(p1 - p2, p3 - p2);
        }
        TextObject.text = currentUpAngle.ToString("#.");
      }
    }
}
