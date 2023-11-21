using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class BattleManager : MonoBehaviour
{

    private int turn = 1;
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private GameObject pointerPrefab;
    [SerializeField] private GameObject gameManagerPrefab;

    private GameManager gameManager;
    private List<GameObject> playersList = new List<GameObject>();
    private List<GameObject> enemyList = new List<GameObject>();
    private List<GameObject> totalList = new List<GameObject>();
    //private Queue<GameObject> totalList = new();
    private List<int> turnList = new List<int>();
    private GameObject pointer;
    private int whichEnemy = 0;
    private bool isBattle = false;

    public void NextTurn()
    {
        if (turn <= totalList.Count)
        {
            turn++;
        }
        if (turn > totalList.Count)
        {
            turn = 1;
        }
    }

    //Saber que turno es
    public int QueTurno()
    {
        //Debug.Log(turn);
        return turn;
    }

    //Agregar a lista enemigos
    public void EnemyPost(GameObject gameObject)
    {
        //Debug.Log(gameObject.name);
        enemyList.Add(gameObject);
        totalList.Add(gameObject);
    }

    //Agregar a lista players
    public void PlayerPost(GameObject gameObject)
    {
        //Debug.Log(gameObject.name);
        playersList.Add(gameObject);
        totalList.Add(gameObject);
    }

    //Devolver que enemigo esta seleccionado
    public int WhichEnemyPost()
    {
        Debug.Log(whichEnemy);
        return whichEnemy;
    }

    // Start is called before the first frame update
    void Start()
    {
        pointer = Instantiate(pointerPrefab);
        gameManagerPrefab.TryGetComponent<GameManager>(out GameManager manager);
        gameManager = manager;
        for (int i = 1; i <= totalList.Count; i++)
        {
            turnList.Add(i);
        }

        foreach (var item in totalList)
        {
            //Debug.Log(turnList.Count);
            //Debug.Log(totalList.Count);
            int index = Random.Range(0, turnList.Count);

            if (item.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
            {
                enemyComponent.AssignTurn(turnList[index]);
                turnList.RemoveAt(index);
            }
            if (item.gameObject.TryGetComponent<Player>(out Player playerComponent))
            {
                playerComponent.AssignTurn(turnList[index]);
                turnList.RemoveAt(index);
            }
        }
    }

    public void popEnemyList(int index)
    {
        //Debug.Log("entre en el pop con el indice" + index);
        enemyList.RemoveAt(index);
    }
    //Eliminar de la lista al player
    public void popPlayersList(int index)
    {
        playersList.RemoveAt(index);
    }
    //Resetear que enemigo esta seleccionado
    public void resetWhichEnemy()
    {
        whichEnemy = 0;
    }
    //Devolver lista de enemigos
    public List<GameObject> EnemyListPost()
    {
        return enemyList;
    }
    //Devolver lista de players
    public List<GameObject> PlayerListPost()
    {
        return playersList;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playersList.Count);
        if (enemyList.Count != 0)
        {
            pointer.gameObject.transform.position = enemyList[whichEnemy].gameObject.transform.position + Vector3.up;
            if (Input.GetButtonUp("Next"))
            {
                if (whichEnemy < enemyList.Count - 1)
                {
                    whichEnemy++;
                }
                else
                {
                    whichEnemy = 0;
                }

            }
            if (Input.GetButtonUp("Back"))
            {
                if (whichEnemy > 0)
                {
                    whichEnemy--;
                }
                else
                {
                    whichEnemy = enemyList.Count - 1;
                }

            }
        }

        if (enemyList.Count == 0)
        {
            turn = 0;
            Debug.Log("ganaste");
            gameManager.ChangeFreeRoamScene();
        }
        
        if (playersList.Count == 0)
        {
            turn = 0;
            Debug.Log("perdiste");
            gameManager.ChangeFreeRoamScene();
        }
    }
}
