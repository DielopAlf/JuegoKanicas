using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    private void Update()
    {
        //Player
        #region
        player.transform.eulerAngles = new Vector3(player.transform.rotation.x, Camera.main.transform.eulerAngles.y, player.transform.rotation.z);
        #endregion
    }
}
