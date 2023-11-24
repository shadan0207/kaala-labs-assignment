using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator m_Animator;
    private NavMeshAgent navMeshAgent;
    private Transform homePosition; // Reference to the default position ('Home').
    private ScoreManager scoreManager;

    private int maxCollectables = 10; // Maximum number of collectable items
    private int currentCollectableIndex = 0; 

    public GameObject collectablePrefab; // Reference to the collectable prefab
    private CollectableObjects collectableObjects;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        homePosition = transform; // Set the default position as the initial home position.
        m_Animator = gameObject.GetComponentInChildren<Animator>();

        scoreManager = FindObjectOfType<ScoreManager>();

    }

    void Update()
    {
        // Check if the player has clicked
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Move the character to the clicked point
                MoveToDestination(hit.point);

                

            }
        }


        
        if (Input.GetMouseButtonDown(1) && !HasCollectableObjects())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If there are collectable objects, move to collect them
            if (Physics.Raycast(ray, out hit) & currentCollectableIndex < maxCollectables)
            {
                MoveToCollectableObject(currentCollectableIndex);
                // Create a collectable object at the clicked point
                CreateCollectableObject(hit.point);
            }
            // If no more collectables, return home
            else
            {

              MoveToDestination(homePosition.position);
            }
        }

    }

    void CreateCollectableObject(Vector3 position)
    {
        if (currentCollectableIndex < maxCollectables)
        {
            Instantiate(collectablePrefab, position, Quaternion.identity);
            currentCollectableIndex++;
        }
    }

    void MoveToCollectableObject(int index)
    {
        GameObject[] collectables = GameObject.FindGameObjectsWithTag("BoxOfPandora");
        if (index < collectables.Length)
        {
            MoveToDestination(collectables[index].transform.position);
        }
    }

    void MoveToDestination(Vector3 destination)
    {
        // Set the destination for the NavMeshAgent
        navMeshAgent.SetDestination(destination);
    }

    bool HasCollectableObjects()
    {
        
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bottle") || other.CompareTag("BoxOfPandora"))
        {
            Debug.Log("Hit goes");
            CollectableObjects collectableObjects = other.GetComponent<CollectableObjects>();

            collectableObjects.Collect();
            scoreManager.AddScore(10);
            scoreManager.MinusItem(1);
        }
    }


}


