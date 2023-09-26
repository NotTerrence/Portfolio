using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
   public GameObject lastHit;
   public Vector3 collision = Vector3.zero;
   public LayerMask layer;
   public GameObject prefab;

   Vector3 targetObjectNextPosition;
   RaycastHit hit;
   Ray ray;

   float height;

   void Start()
   {
      targetObjectNextPosition = prefab.transform.position;
      height = prefab.transform.position.y;
   }

   void Update()
   {
      shootRay();
      if (Input.GetMouseButtonDown(0))
      {
         if (hit.collider == null)
         {
            Debug.Log("No hit");
         }
         else if (hit.collider.gameObject.tag == "NPC")
         {
            Teacher teacher = hit.transform.GetComponent<Teacher>();
            if (teacher != null)
            {
               teacher.onHit();
            }
         }
         else if (hit.collider.gameObject.tag == "Ground")
         {
            movePlayer();
         }
      }
   }

   void OnDrawGizmos()
   {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(collision, 0.2f);
   }

   void shootRay()
   {
      if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100.0f))
      {
         lastHit = hit.transform.gameObject;
         collision = hit.point;
         Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red, 0, true);
      }
   }

   // moves the player at gazed position
   void movePlayer()
   {
      targetObjectNextPosition = hit.point + new Vector3(0f, height, 0f);
      prefab.transform.position = targetObjectNextPosition;
   }
}