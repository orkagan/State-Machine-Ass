using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        Patrol, 
        Chase, 
        Search,
    }

    [SerializeField] private State _state;
    private void Start()
    {
        NextState();
    }
    private void NextState()
    {
        switch (_state)
        {
            case State.Patrol:
                StartCoroutine(PatrolState());
                break;
            case State.Chase:
                StartCoroutine(AlertState());
                break;
            /*case State.Search:
                StartCoroutine(SearchState());
                break;*/
            default:
                Debug.Log("404 State not found, State does not exist in NextState function, stoppings statemachine \n_state: " + _state);
                break;
        }
    }
    private IEnumerator PatrolState()
    {
        while (_state == State.Patrol) //while loop runs once per game step
        {
            //run this code
            yield return null;
        }
        Debug.Log("State: Exiting Patrol");
        NextState();
    }

    private IEnumerator AlertState()
    {
        while (_state == State.Chase)
        {
            //run this code
            yield return null;
        }
        Debug.Log("State: Exiting Alert");
        NextState();
    }
}
