using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int turn = 1;
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameObject player;
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
    private Vector3 posCharacter;


    private void Awake()
    {
        UpdateCharacterPos(player);
        CreateSingleton();
    }

    private void CreateSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
 
    }
    public void UpdateCharacterPos(GameObject player)
    {
        posCharacter = player.transform.position;
        Debug.Log(posCharacter);
    }

    public Vector3 postCharPos()
    {
        Debug.Log(posCharacter);
        return posCharacter;
    }

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
