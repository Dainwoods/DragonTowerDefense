using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundHandler : MonoBehaviour {

    private int curRound;
    private int enemiesRemaining;
    private bool roundReady;
    private int enemiesToSpawn;
    private bool move;
    private float distance;

    public static int gold;
    private float _nextAttack = 0;
    
    public GameObject Player;
    public GameObject Fireball;
    
    public float FireDelay = 5;
    private bool isFiring = false;
    public static RoundHandler roundHandler;

    public List<int> RoundEnemyCounts;
    public float spawnWait;
    public GameObject enemy;
    public int startGold;
    public Text goldText;
    public Text roundText;
    public Text roundReadyText;
    public Button nextRoundButton;
    public GameObject background;
    public float travelDistance;
    public float speed;

    public bool IsFiring
    {
        get { return isFiring; }
        set
        {
            if (!value)
            {
                isFiring = value;
            }
            else if (CanFire() && value)
            {
                isFiring = value;
            }
        }
    }

    public bool CanFire()
    {
        return Time.time >= _nextAttack;
    }
    
    // Use this for initialization
    void Start () {
        curRound = 0;
        roundReady = true;
        gold = startGold;
        move = false;
        distance = 0;

        nextRoundButton.onClick.AddListener(startNextRound);
        roundHandler = this;
    }

    public void startNextRound() {
        Debug.Log("Starting round");
        if (roundReady && curRound < RoundEnemyCounts.Count) {
            Debug.Log("Inside starting round");
            roundReady = false;
            nextRoundButton.gameObject.SetActive(false);
            enemiesToSpawn = RoundEnemyCounts[curRound];
            spawnEnemy();
        }
    }
    
    void spawnEnemy() {
        
        if (enemiesToSpawn > 0)
        {
            Vector3 spawnPosition = new Vector3(-10, 0, 0);
            Quaternion spawnRotiation = Quaternion.identity;
            Instantiate(enemy, spawnPosition, spawnRotiation);
            enemiesToSpawn -= 1;
            
            Invoke("spawnEnemy", spawnWait);
        }
    }

	// Update is called once per frame
	void Update () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int aliveEnemies = enemies.Length;

        if (gold <= 0){
            bool goldOnScreen = false;
            for (int i = 0; i < enemies.Length; i++){
                goldOnScreen = goldOnScreen || enemies[i].GetComponent<Enemy>().HasGold;
            }
            if (!goldOnScreen){
                SceneManager.LoadScene("Main", LoadSceneMode.Single);
            }
        }

        if (!roundReady && aliveEnemies == 0 && curRound < RoundEnemyCounts.Count && enemiesToSpawn == 0) {
            Debug.Log("Ending Round");
            destroyTraps();
            destroyCoins();
            roundReady = true;
            nextRoundButton.gameObject.SetActive(true);
            curRound++;
            gold += curRound * 2;
            move = true;
            distance = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && roundReady && curRound < RoundEnemyCounts.Count) {
            startNextRound();
        }
	    
        goldText.text = "" + gold;
        roundText.text = "Round: " + (curRound + 1);

        if (move && distance < travelDistance) {
            Vector3 oldPosition = background.transform.position;
            background.transform.Translate(-transform.right * Time.deltaTime * speed);
            distance += Vector3.Distance(oldPosition, background.transform.position);
        }
        else if (distance == travelDistance) {
            move = false;
        }
	    
		if (isFiring && CanFire() && Input.GetMouseButton(0)) {
			var fireball = Instantiate(Fireball, Player.transform.position, Player.transform.rotation);
			Vector2 target = Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x, 
				Input.mousePosition.y));

		    var fireballBody = fireball.GetComponent<Rigidbody2D>();
		    
			Vector2 fireOrigin = new Vector2 (fireballBody.position.x, fireballBody.position.y);
			Vector2 fireDirection = target - fireOrigin;
			fireDirection.Normalize();
			fireballBody.velocity = fireDirection * 10f;
		    _nextAttack = Time.time + FireDelay;
		    isFiring = false;
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
