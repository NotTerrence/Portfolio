using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distancethisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distancethisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distancethisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject effectinstance = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectinstance, 2f);
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
