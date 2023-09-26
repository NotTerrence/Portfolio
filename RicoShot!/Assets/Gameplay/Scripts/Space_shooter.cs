using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Space_shooter: MonoBehaviour
{
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;

    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;

    //Enter the Speed of the Bullet from the Component Inspector.
    public float Bullet_Forward_Force;

    public Button shootButton;

    // Use this for initialization
    void Start()
    {
        Button btn1 = shootButton.GetComponent<Button>();
        btn1.onClick.AddListener(shootBall);
    }

    void shootBall()
    {
        Debug.Log("Shoot");
        
        //The Bullet instantiation happens here.
        GameObject Temporary_Bullet_Handler;
        SphereCollider m_Collider;

        Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

        //Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
        //This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
        Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);
        Temporary_Bullet_Handler.tag = "Ball";


        Rigidbody gameObjectsRigidBody = Temporary_Bullet_Handler.AddComponent<Rigidbody>();
        gameObjectsRigidBody.useGravity = false;
        gameObjectsRigidBody.angularDrag = 0f;
        gameObjectsRigidBody.mass = 0.5f;

        m_Collider = Temporary_Bullet_Handler.gameObject.AddComponent<SphereCollider>();
        m_Collider.material.bounciness = 1;
        m_Collider.material.staticFriction = 0;
        m_Collider.material.dynamicFriction = 0;
        m_Collider.material.frictionCombine = PhysicMaterialCombine.Minimum;
        m_Collider.material.bounceCombine = PhysicMaterialCombine.Maximum;

        //Retrieve the Rigidbody component from the instantiated Bullet and control it.
        Rigidbody Temporary_RigidBody;
        Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

        //Tell the bullet to be "pushed" forward by an amount set by Bullet_Forward_Force. 
        Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);

        SumScore.Add(1);
        //Basic Clean Up, set the Bullets to self destruct after 10 Seconds, I am being VERY generous here, normally 3 seconds is plenty.
        //Destroy(Temporary_Bullet_Handler, 10.0f);
    }
    
}