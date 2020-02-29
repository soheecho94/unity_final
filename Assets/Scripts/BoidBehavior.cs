// code from tutorial session w/ ege

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehavior : MonoBehaviour
{
    private List<GameObject> boids;

    private Rigidbody rigidbody;
    public float speed = 2f;
    public Vector3 velocity = new Vector3(1, 0, 0);

    void Start()
    {
      boids = GameObject.Find("Boid Spawner").GetComponent<SpawnBoids>().boids;
      rigidbody = GetComponent<Rigidbody>();
      rigidbody.AddForce(velocity);
    }

    // Update is called once per frame
    void Update()
    {
      Separate(boids, 10f);
      //Align(boids, 5f);
      //Cohesion(boids, 10f);
    }

    void Separate(List <GameObject> boids, float desiredSeparation) {
      Vector3 sum = new Vector3();
      int count = 0;

      foreach (var boid in boids) {
        //checking if the boid we're looping through is our own self, stop and do the next iteration if so,
        if (boid.transform == transform) continue;

        //getting position of target boid
        var boidPosition = boid.GetComponent<Transform>().position;
        float distance = Vector3.Distance(transform.position, boidPosition);

        if (distance < desiredSeparation) {
          Vector3 difference = transform.position - boidPosition;
          difference.Normalize();
          difference /= distance; //weigh by distance
          sum += difference;
          count++;
        }
      }

      if (count > 0) {
        //get the average of all the invading boid vectors
        sum /= count;
        sum.Normalize();
        sum *= speed;

        Vector3 steer = sum - transform.position;
        steer.Normalize();
        steer *= speed;
        rigidbody.AddForce(steer);
        transform.LookAt(rigidbody.velocity);
      }
    }

    void Align(List <GameObject> boids, float searchRadius) {
      Vector3 sum = new Vector3();
      int count = 0;

      foreach(var boid in boids) {
        if (boid.transform == transform) continue;
        var boidPosition = boid.GetComponent<Transform>().position;
        float distance = Vector3.Distance(transform.position, boidPosition);

        if (distance < searchRadius) {
          sum += boid.GetComponent<Rigidbody>().velocity;
          count++;
        }

        if (count > 0) {
          //get the average of all the invading boid vectors
          sum /= count;
          sum.Normalize();
          sum *= speed;

          Vector3 steer = sum - transform.position;
          steer.Normalize();
          steer *= speed;
          rigidbody.AddForce(steer);
          transform.LookAt(rigidbody.velocity);
        }
      }
    }

    void Cohesion(List <GameObject> boids, float searchRadius) {
      Vector3 sum = new Vector3();
      int count = 0;

      foreach(var boid in boids) {
        if (boid.transform == transform) continue;
        var boidPosition = boid.GetComponent<Transform>().position;
        float distance = Vector3.Distance(transform.position, boidPosition);

        if (distance < searchRadius) {
          sum += boidPosition;
          count++;
        }

        if (count > 0) {
          //get the average of all the invading boid vectors
          sum /= count;
          sum.Normalize();
          sum *= speed;

          Vector3 steer = sum - transform.position;
          steer.Normalize();
          steer *= speed;
          rigidbody.AddForce(steer);
          transform.LookAt(rigidbody.velocity);
        }
      }
    }


}
