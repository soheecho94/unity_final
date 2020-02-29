// code from tutorial session w/ ege


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoids : MonoBehaviour
{
  public List<GameObject> boids;
  public GameObject boidPrefab;
  public int numberOfBoids;
  // Start is called before the first frame update
  void Start() {

    boids = new List<GameObject>();


    for (int i = 0; i < numberOfBoids; i++) {
      Vector3 randomPosition = Random.insideUnitSphere * 6.5f;
      var newBoid = Instantiate(boidPrefab, randomPosition, Quaternion.identity);
      boids.Add(newBoid);
    }
  }

}
