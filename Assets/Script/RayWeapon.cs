using UnityEngine;
using System.Collections;

public class RayWeapon : IWeapon
{
    Transform cameraT;
    public float distance = 100;
    public float force = 50;
    public float damage = 2;

    public void Awake()
    {
        cameraT = Camera.main.transform;
    }

    public override void Use()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(cameraT.position,cameraT.forward);
        
        if (Physics.Raycast(ray,out hitInfo,distance))
        {
            Rigidbody rb = hitInfo.collider.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddForce(ray.direction * force);
            }

            Damageable damageable = hitInfo.collider.GetComponent<Damageable>();
            if (damageable)
            {
                damageable.TakeDamage(damage);
            }
        }
    }
}
