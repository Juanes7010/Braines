using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointerManager : MonoBehaviour
{
    public static CameraPointerManager instance;

    [SerializeField] GameObject pointer;
    [SerializeField] float maxDistancePointer = 4.5f;
    [Range(0,1)]
    [SerializeField] float dinstancePointerObject = 0.95f;
    [SerializeField] float _maxDistance = 10;
    private GameObject _gazedAtObject = null;

    readonly string interactableTag = "interactable";
    float scaleSize = 0.025f;

    [HideInInspector]
    public Vector3 hitPoint;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
        }
    }

    private void Start()
    {
        GazeManager.Instance.OnGazeSelection += gazeSelection;

        this.transform.position = new Vector3(
                this.transform.position.x,
                1.806f,
                this.transform.position.z
            );
    }

    void gazeSelection()
    {
        _gazedAtObject?.SendMessage("OnPointerClickXR", null, SendMessageOptions.DontRequireReceiver);
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            hitPoint = hit.point;
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject?.SendMessage("OnPointerExitXR", null, SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnterXR", null, SendMessageOptions.DontRequireReceiver);
                GazeManager.Instance.StartGazeSelection();
            }
            if(hit.transform.CompareTag(interactableTag))
            {
                pointerOnGaze(hit.point);
            }
            else
            {
                pointerOutGaze();
            }
        }
        else
        {
            _gazedAtObject?.SendMessage("OnPointerExitXR", null, SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClickXR", null, SendMessageOptions.DontRequireReceiver);
        }

        void pointerOnGaze(Vector3 hitPoint)
        {
            float scaleFactor = scaleSize * Vector3.Distance(transform.position, hitPoint);
            pointer.transform.localScale = Vector3.one * scaleFactor;
            pointer.transform.parent.position = CalculatePointerPosition(transform.position, hitPoint, dinstancePointerObject);
        }

        void pointerOutGaze()
        {
            pointer.transform.localScale = Vector3.one * 0.1f;
            pointer.transform.parent.transform.localPosition = new Vector3(0, 0, maxDistancePointer);
            pointer.transform.parent.parent.transform.rotation = transform.rotation;
            GazeManager.Instance.CancelGazeSelection();
        }

        Vector3 CalculatePointerPosition(Vector3 p0, Vector3 p1, float t)
        {
            float x = p0.x + t * (p1.x - p0.x);
            float y = p0.y + t * (p1.y - p0.y);
            float z = p0.z + t * (p1.z - p0.z);

            return new Vector3(x, y, z);
        }
    }
}
