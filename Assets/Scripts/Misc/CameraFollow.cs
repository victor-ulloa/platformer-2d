using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeReference] float minXClamp;
    [SerializeReference] float maxXClamp;

    private void LateUpdate()
    {
        if (GameManager.instance.playerInstance)
        {
            Vector3 cameraPosition = transform.position;
            cameraPosition.x = Mathf.Clamp(GameManager.instance.playerInstance.transform.position.x, minXClamp, maxXClamp);
            cameraPosition.y = GameManager.instance.playerInstance.transform.position.y;
            transform.position = cameraPosition;
        }
    }
}
