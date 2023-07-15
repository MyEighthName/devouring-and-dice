using Cinemachine;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachineCamera;
    public PlayerBox playerBox;
    public float zoomTime;

    private float oldSize;
    private float nextCameraSize;

    private float size => Mathf.Sqrt(playerBox.totalRTSize) * (1 + .025f * (playerBox.count - 1));

    private void Start()
    {
        oldSize = size;
        nextCameraSize = cinemachineCamera.m_Lens.OrthographicSize;
    }

    private float zoomSpeed;

    private void Update()
    {
        if (size == 0 || oldSize == 0)
            return;

        nextCameraSize *= size / oldSize;
        oldSize = size;
        cinemachineCamera.m_Lens.OrthographicSize = Mathf.SmoothDamp(
            cinemachineCamera.m_Lens.OrthographicSize, nextCameraSize, ref zoomSpeed, zoomTime
            );
    }
}
