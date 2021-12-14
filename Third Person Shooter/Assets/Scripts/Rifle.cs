using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField]
    private StarterAssetsInputs input;
    [SerializeField]
    private GameObject Muzzle;
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float fireCooldown;

    private bool onCooldown;
    private int poolSize;
    List<GameObject> ObjectPool;

    private void Start()
    {
        if (!Muzzle) Muzzle = GameObject.Find("Muzzle");
        poolSize = 100;
        ObjectPool = new List<GameObject>();
        for(int i=0; i<poolSize; i++)
        {
            GameObject bullet = Instantiate(BulletPrefab, Muzzle.transform);
            ObjectPool.Add(bullet);
        }
        
    }

    private void Update()
    {
        if (!onCooldown)
        {
            if (input.aim && input.shoot)
            {   
                Shoot();
                StartCoroutine(Cooldown(fireCooldown));
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = getBullet();
        if(bullet != null)
        {
            bullet.transform.position = Muzzle.transform.position;
            bullet.SetActive(true);
            Ray aim = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;
            if (Physics.Raycast(aim, out hit, 100))
            { 
                bullet.GetComponent<Rigidbody>().velocity = (hit.point - Muzzle.transform.position) * bulletSpeed;
            }
        }
    }

    private IEnumerator Cooldown(float duration)
    {
        onCooldown = true;
        yield return new WaitForSeconds(duration);
        onCooldown = false;

    }

    private GameObject? getBullet()
    {
        for(int i = 0; i<poolSize; i++)
        {
            if(!ObjectPool[i].activeInHierarchy)
            {
                return ObjectPool[i];
            }
        }
        return null;
    }
}
