using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int turn = 1;
    private static GameManager instance;
    public static GameManager Instance => instance;
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemy;
    [SerializeField] private GameObject pointerPrefab;
    [SerializeField] private string BattleScene;
    [SerializeField] private string FreeroamScene;
    private List<GameObject> playersList = new List<GameObject>();
    private List<GameObject> enemyList = new List<GameObject>();
    private List<GameObject> totalList = new List<GameObject>();
    //private Queue<GameObject> totalList = new();
    private List<int> turnList = new List<int>();
    private GameObject pointer;
    private int whichEnemy = 0;
    private bool isBattle = false;

    private void Awake()
    {
        CreateSingleton();
        //ChangeSceneWin();
        //var dequeuedObject = totalList.Dequeue();
        //totalList.Enqueue(dequeuedObject);
    }

    private void CreateSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    /*//Cambios de turno
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
        Debug.Log(turn);
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
        return whichEnemy;
    }*/

    // Start is called before the first frame update
    void Start()
    {
       /* //Debug.Log(enemyList.Count);
        //Debug.Log(playersList.Count);
        //Debug.Log(totalList.Count);   
        
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
        }*/
    }
    /*//Eliminar de la lista al enemigo
    public void popEnemyList(int index)
    {
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
    } */
    //Cambiar a la escena de batalla
    public void ChangeBattleScene()
    {
        SceneManager.LoadScene(BattleScene);
        isBattle = true;
    }
    //Cambiar a la escena de freeroam
    public void ChangeFreeRoamScene()
    {
        SceneManager.LoadScene(FreeroamScene);
        isBattle = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
}
