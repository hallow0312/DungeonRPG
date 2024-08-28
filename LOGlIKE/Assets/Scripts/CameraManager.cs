using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoBehaviour
{
   [SerializeField] CinemachineVirtualCamera virtualCamera;
   [SerializeField] GameObject player;
    [SerializeField] float offset_y;
    [SerializeField] float offset_z;
    

    private void Start()
    {
        virtualCamera= GetComponent<CinemachineVirtualCamera>();
        Setting();
       
    }
  
    void Setting()
    {
        player = GameObject.FindWithTag("Player");
        
        virtualCamera.Follow = player.transform;
        virtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0, offset_y, offset_z);
       
    }
  
}
