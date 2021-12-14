using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed;
    private GameObject muzzle;

    private void Awake()
    {
        muzzle = GameObject.Find("Muzzle");
    }

    public float GetBulletSpeed() { return this.bulletSpeed; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != muzzle)
        {
            gameObject.SetActive(false);
        }
    }
}
