using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundHandler : MonoBehaviour {

    private int curRound;
    private int[] enemyArr;
    private int aliveEnemies;
    private bool roundReady;
    private bool move;
    private float distance;

    public static int gold;

    public int firstRound;
    public int secondRound;
    public int thirdRound;
    public float spawnWait;
    public GameObject enemy;
    public int startGold;
    public Text goldText;
    public Text roundText;
    public GameObject background;
    public float travelDistance;
    public float speed;

    // Use this for initialization
    void Start () {
        curRound = 0;
        enemyArr = new int[3];
        enemyArr[0] = firstRound;
        enemyArr[1] = secondRound;
        enemyArr[2] = thirdRound;
        aliveEnemies = firstRound;
        roundReady = true;
        gold = startGold;
        move = false;
        distance = 0;
	}
	
    void spawnEnemy() {
        Vector3 spawnPosition = new Vector3(-10, 0, 0);
        Quaternion spawnRotiation = Quaternion.identity;
        Instantiate(enemy, spawnPosition, spawnRotiation);
        enemyArr[curRound]--;
        if (enemyArr[curRound] > 0) {
            Invoke("spawnEnemy", spawnWait);
        }
    }

	// Update is called once per frame
	void Update () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        aliveEnemies = enemies.Length;
        if(aliveEnemies == 0 && curRound < 3 && enemyArr[curRound] == 0) {
            destroyTraps();
            destroyCoins();
            roundReady = true;
            curRound++;
            gold += curRound * 2;
            move = true;
            distance = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && roundReady && curRound < 3) {
            roundReady = false;
            spawnEnemy();
        }
        if(Input.GetKeyDown(KeyCode.E) && aliveEnemies > 0) {
            Destroy(enemies[0]);
        }
        goldText.text = "" + gold;
        roundText.text = "Round: " + (curRound + 1);
        if(move && distance < travelDistance) {
            Vector3 oldPosition = background.transform.position;
            background.transform.Translate(-transform.right * Time.deltaTime * speed);
            Debug.Log(background.transform.position);
            distance += Vector3.Distance(oldPosition, background.transform.position);
        }
        else if(distance == travelDistance) {
            move = false;
        }
	}

    void destroyTraps() {
        GameObject[] traps = GameObject.FindGameObjectsWithTag("Trap");
        for(int i = 0; i < traps.Length ; i++) {
            Destroy(traps[i]);
        }
        traps = GameObject.FindGameObjectsWithTag("DamageableTrap");
        for (int i = 0; i < traps.Length; i++) {
            Destroy(traps[i]);
        }
    }

    void destroyCoins()
    {
        // Retrieve all fallen gold
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        for (int i = 0; i < coins.Length; i++)
        {
            Destroy(coins[i]);
            RoundHandler.gold += 1;
        }
    }
}
