using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(enemy))]
public class enemymovement : MonoBehaviour
{

      private Transform target;
        private int wavepointIndex = 0;
        private enemy _enemy;
    
        private void Start()
        {
            _enemy = GetComponent<enemy>();
                target = waypoints.points[0];
        }
        private void Update()
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized*  _enemy.speed * Time.deltaTime,Space.World);
            if (Vector3.Distance(transform.position,target.position)<=0.4f)
            {
                getnextwaypoint();
            }

            _enemy.speed = _enemy.startspeed;//reset speed
            
        }

        void getnextwaypoint()
        {
            if (wavepointIndex>=waypoints.points.Length-1)
            
            {
                Endpath();
                return;
            }
            wavepointIndex++;
            target = waypoints.points[wavepointIndex];
        
        }

        void Endpath()
        {
            playerstats.lives--;
            wavespawner.enemiesalive--;
            Destroy(gameObject);

        }
}
