using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System.Linq;

public class ImageTrackSingle : MonoBehaviour
{
    private ARTrackedImageManager arTrackedImageManager;
    public string ReferenceImageName;
    public GameObject prefab, spawnHordePrefab;
    public Dictionary<Vector3, GameObject> targets = new Dictionary<Vector3, GameObject>();
    public List<GameObject> points = new List<GameObject>();
    public Text text, text2;
    public Button addPoint, play;
    private LineRenderer lines;
    private void Awake()
    {
        arTrackedImageManager = GetComponent<ARTrackedImageManager>();
        addPoint.onClick.AddListener(SetPoint);
        play.onClick.AddListener(SpawnHorde);
    }
    private void Start()
    {
        lines = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LineRenderer>();
    }
    private void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;       
    }
    private void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }
    public void SetPoint()
    {
        GameObject ob = GameObject.FindGameObjectWithTag("Point");
        GameObject target = Instantiate(prefab, ob.transform.position, prefab.transform.rotation);
        targets.Add(target.transform.position, target);
        points.Add(target);
    }
    public void SpawnHorde()
    {
        Vector3 position = Vector3.zero;
        foreach(var target in targets)
        {
            position += target.Key;
        }
        position /= targets.Count - 1;
        Instantiate(spawnHordePrefab, position, spawnHordePrefab.transform.rotation);
    }
    private void Update()
    {
        //If we hit play, then the horde begins. 
        //Before this, insert the tower near to the path. 
        lines.positionCount = targets.ToArray().Length;
        lines.SetPositions(targets.Keys.ToArray());
    }
    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
    }
}
