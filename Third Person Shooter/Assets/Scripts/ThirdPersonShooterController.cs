using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerAimCamera;
    [SerializeField]
    private GameObject playerFollowCamera;
    private StarterAssetsInputs input;

    // Start is called before the first frame update
    void Start()
    {
        if (!playerAimCamera) playerAimCamera = GameObject.Find("PlayerAimCamera");
        if (!playerFollowCamera) playerFollowCamera = GameObject.Find("PlayerFollowCamera");
        input = GetComponent<StarterAssetsInputs>();
        playerAimCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(input.aim)
        {
            playerAimCamera.SetActive(true);
            playerFollowCamera.SetActive(false);
        } else
        {
            playerAimCamera.SetActive(false);
            playerFollowCamera.SetActive(true);
        }
    }
}
