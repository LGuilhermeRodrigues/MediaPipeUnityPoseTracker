using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

public class GraphSelectorController : MonoBehaviour {
  [SerializeField] GameObject faceDetectionGraph = null;
  [SerializeField] GameObject faceMeshGraph = null;
  [SerializeField] GameObject irisTrackingGraph = null;
  [SerializeField] GameObject handTrackingGraph = null;
  [SerializeField] GameObject poseTrackingGraph = null;
  [SerializeField] GameObject holisticGraph = null;
  [SerializeField] GameObject hairSegmentationGraph = null;
  [SerializeField] GameObject objectDetectionGraph = null;
  [SerializeField] GameObject objectDetection3dGraph = null;
  [SerializeField] GameObject boxTrackingGraph = null;
  [SerializeField] GameObject instantMotionTrackingGraph = null;
  [SerializeField] GameObject officialDemoGraph = null;

  private GameObject sceneDirector;
  private Dictionary<string, GameObject> graphs;

  void Start() {
    sceneDirector = GameObject.Find("SceneDirector");

    var graphSelector = GetComponent<Dropdown>();
    graphSelector.onValueChanged.AddListener(delegate { OnValueChanged(graphSelector); });

    InitializeOptions();
  }

  void InitializeOptions() {
    graphs = new Dictionary<string, GameObject>();

    AddGraph("Pose Tracking", poseTrackingGraph);
    AddGraph("Hand Tracking", handTrackingGraph);

    var graphSelector = GetComponent<Dropdown>();
    graphSelector.ClearOptions();
    graphSelector.AddOptions(graphs.Select(pair => pair.Key).ToList());

    OnValueChanged(graphSelector);
  }

  void AddGraph(string label, GameObject graph) {
    if (graph != null) {
      graphs.Add(label, graph);
    }
  }

  void OnValueChanged(Dropdown dropdown) {
    var option = dropdown.options[dropdown.value];
    var graph = graphs[option.text];

    Debug.Log($"Graph Changed: {option.text}");
    sceneDirector.GetComponent<SceneDirector>().ChangeGraph(graph);
  }
}
