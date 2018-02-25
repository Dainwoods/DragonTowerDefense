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
    private int distance;

    public int firstRound;
    public int secondRound;
    public int thirdRound;
    public float spawnWait;
    public GameObject enemy;
    public int startGold;
    public static int gold;
    public Text goldText;
    public GameObject background;
    public float travelDistance;

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
        Vector3 spawnPosition = new Vector3(-10, -4, 0);
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
            roundReady = true;
            curRound++;
            gold += curRound * 2;
            move = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && roundReady && curRound < 3) {
            roundReady = false;
            spawnEnemy();
        }
        if(Input.GetKeyDown(KeyCode.E) && aliveEnemies > 0) {
            Destroy(enemies[0]);
        }
        goldText.text = "Gold: " + gold;
        if(move && distance < travelDistance) {

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
}
