using System.Collections;
using UnityEngine;

public class ObstacleSpwner : MonoBehaviour
{
    [SerializeField] GameObject IsometricObstacle;
    [SerializeField] GameObject HexagonObstacle;
    private float _leftSideSpawner;
    private float _rightSideSpawner;
    void Start()
    {
        StartCoroutine(IsoObsSpawn());
    }
    private IEnumerator IsoObsSpawn()
    {
        RandomNum();
        yield return new WaitForSeconds(20);
        switch (_leftSideSpawner)
        {
            case 0:
                //bottom left side//
                Instantiate(IsometricObstacle, new Vector2(-1.3f, -4), Quaternion.identity,this.transform);
                break;
            case 1:
                //top left side//
                Instantiate(IsometricObstacle, new Vector2(-1.3f, 4), Quaternion.identity, this.transform);
                break;
        }
        switch (_rightSideSpawner)
        {
            case 0:
                //bottom right side//
                Instantiate(IsometricObstacle, new Vector2(1.3f, -4), Quaternion.identity, this.transform);
                break;
            case 1:
                //top right side//
                Instantiate(IsometricObstacle, new Vector2(1.3f, 4), Quaternion.identity, this.transform);
                break;
        }
        StartCoroutine(HexObsSpawn());
    }
    private IEnumerator HexObsSpawn()
    {
        RandomNum();
        yield return new WaitForSeconds(10);
        switch (_leftSideSpawner)
        {
            case 0:
                //bottom left side//
                Instantiate(HexagonObstacle, new Vector2(-7.4f, -3.5f),Quaternion.identity, this.transform);
                break;
            case 1:
                //top left side//
                Instantiate(HexagonObstacle, new Vector2(-7.4f, 3.5f), Quaternion.identity, this.transform);
                break;
        }
        switch (_rightSideSpawner)
        {
            case 0:
                //bottom right side//
                Instantiate(HexagonObstacle, new Vector2(7.4f, -3.5f), Quaternion.identity, this.transform);
                break;
            case 1:
                //top right side//
                Instantiate(HexagonObstacle, new Vector2(7.4f, 3.5f), Quaternion.identity, this.transform);
                break;
        }
    }
    
    private void RandomNum()
    {
       _leftSideSpawner = Random.Range(0, 2);
       _rightSideSpawner = Random.Range(0, 2);
    }
}
