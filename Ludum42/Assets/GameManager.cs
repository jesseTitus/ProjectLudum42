using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public List<float> charactersCurrentHealth = new List<float>(); // a list that contains health of all characters
    public List<float> charactersMaxHealth = new List<float>();
    public Text textDisplayer;
    public Button nextButton;
    public GameObject detectiveButton;
    public GameObject artistButton;
    public GameObject surgeonButton;
    public GameObject priestButton;

    public List<GameObject> detectiveDeck;
    public List<GameObject> artistDeck;
    public List<GameObject> surgeonDeck;
    public List<GameObject> priestDeck;

    public Transform detectivePosition;
    public Transform artistPosition;
    public Transform surgeonPosition;
    public Transform priestPosition;

    GameObject detectiveCurrentCard;
    GameObject artistCurrentCard;
    GameObject surgeonCurrentCard;
    GameObject priestCurrentCard;

    bool hasDrawnCards = false;
    bool isEnemyRound = false;
    bool isPlayerRound = false;

    bool isDetectiveAlive = true;
    bool isArtistAlive = true;
    bool isSurgeonAlive = true;
    bool isPriestAlive = true;

    int hoodedHitPoints = 5;

    private enum States
    {
        Intro1, Opinions1, Combat1, Pass1
    }
    private States myState;

    // Use this for initialization
    void Start () {
        textDisplayer = GameObject.Find("TextDisplayer").GetComponent<Text>();
        charactersMaxHealth.Add(10f); // dective health   
        charactersMaxHealth.Add(10f); // artist health
        charactersMaxHealth.Add(10f); // surgeon health
        charactersMaxHealth.Add(10f); // priest health

        charactersCurrentHealth.Add(charactersMaxHealth[0]); // dective health   
        charactersCurrentHealth.Add(charactersMaxHealth[1]); // artist health
        charactersCurrentHealth.Add(charactersMaxHealth[2]); // surgeon health
        charactersCurrentHealth.Add(charactersMaxHealth[3]); // priest health

        detectiveButton = GameObject.Find("DetectiveButton");
        artistButton = GameObject.Find("ArtistButton");
        surgeonButton = GameObject.Find("SurgeonButton");
        priestButton = GameObject.Find("PriestButton");

        detectivePosition = GameObject.Find("DetectivePosition").transform;
        artistPosition = GameObject.Find("ArtistPosition").transform;
        surgeonPosition = GameObject.Find("SurgeonPosition").transform;
        priestPosition = GameObject.Find("PriestPosition").transform;

        myState = States.Intro1;
    }
	
	// Update is called once per frame
	void Update () {
        print(myState);
        if (myState == States.Intro1) { Intro1(); }
        else if (myState == States.Opinions1) { Opinions1(); }
        else if (myState == States.Pass1) { Pass1(); }
        else if (myState == States.Combat1) { Combat1(); }
    }

    void Intro1() {
        textDisplayer.text = "A hooded figure apears from shadow.";
    }

    void Opinions1() {
        textDisplayer.text = "Detective: Let's see the face under that hood. \n" +
            "Priest: Hold on, let me talk to him first.";
    }

    void Combat1() {
        textDisplayer.text = "hooded figure move to attack.";
        DisableDecks();
        CheckAlive();
        if (!hasDrawnCards) {
            DrawCards();
        }
        if (isEnemyRound) {
            EnemyActions("hooded");
        }
        if (isPlayerRound) {
            CardAction();
        }
    }

    void Pass1() {
        textDisplayer.text = "hooded figure disapeared back into shadow.";
    }

    public void Next() {
        if (myState == States.Intro1) { myState = States.Opinions1; }
    }

    public void OpinionDetective()
    {
        if (myState == States.Opinions1) { myState = States.Combat1; }
    }
    public void OpinionArtist()
    {
    }
    public void OpinionSurgeon()
    {
    }
    public void OpinionPriest()
    {
        if (myState == States.Opinions1) { myState = States.Pass1; }
    }

    private void DisableDecks()
    {
        detectiveButton.SetActive(false);
        artistButton.SetActive(false);
        surgeonButton.SetActive(false);
        priestButton.SetActive(false);
    }

    private void DrawCards()
    {
        print(detectiveDeck.Count);
        detectiveCurrentCard = detectiveDeck[Random.Range(0, detectiveDeck.Count)];
        artistCurrentCard = artistDeck[Random.Range(0, artistDeck.Count)];
        surgeonCurrentCard = surgeonDeck[Random.Range(0, surgeonDeck.Count)];
        priestCurrentCard = priestDeck[Random.Range(0, priestDeck.Count)];

        Instantiate(detectiveCurrentCard, detectivePosition);
        Instantiate(artistCurrentCard, artistPosition);
        Instantiate(surgeonCurrentCard, surgeonPosition);
        Instantiate(priestCurrentCard, priestPosition);

        hasDrawnCards = true;
        isEnemyRound = true;
    }

    private void EnemyActions(string enemy) {
        if (enemy == "hooded")
        {
            int randomNumber = Random.Range(1, 3);
            if (randomNumber == 1) // enemy will attack
            {
                print("attack");
            }
            else if (randomNumber == 2) // enemy will attack everyone
            {
                print("attack all");
            }
            else if (randomNumber == 3) // enemy will heal it self
            {
                print("heal itself");
            }
        }
        isEnemyRound = false;
        isPlayerRound = true;
    }

    private void CardAction() {


        if (Input.GetMouseButtonDown(0)) {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider.GetComponent<Antidote>())
            {
                if (isSurgeonAlive)
                {
                    print("antidote");
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<Bandage>())
            {
                if (isSurgeonAlive)
                {
                    print("bandage");
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<Bless>())
            {
                if (isPriestAlive)
                {
                    print("bless");
                    RedrawCards();
                } 
            }
            else if (hit.collider.GetComponent<Flashlight>())
            {
                if (isDetectiveAlive)
                {
                    print("flashlight");
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<Revolver>())
            {
                if (isDetectiveAlive)
                {
                    print("revolver");
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<Sketch>())
            {
                if (isArtistAlive)
                {
                    print("sketch");
                    RedrawCards();
                }
            }
            else {
            }

        } 
    }

    private void RedrawCards() {
        // destroy all current cards
        foreach (Transform child in detectivePosition)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in artistPosition)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in surgeonPosition)
        {
            GameObject.Destroy(child.gameObject);
        }
        foreach (Transform child in priestPosition)
        {
            GameObject.Destroy(child.gameObject);
        }

        isPlayerRound = false;
        hasDrawnCards = false;
    }

    void CheckAlive (){
        if (charactersCurrentHealth[0] <= 0) // if detective is died
        {
            isDetectiveAlive = false; // set is alive to false
            detectiveButton.SetActive(true); // use character sprite to cover cards
            detectiveButton.GetComponent<Image>().color = Color.red; // set color to red
        }
        else {
            isDetectiveAlive = true;
            detectiveButton.SetActive(false);
            detectiveButton.GetComponent<Image>().color = Color.white;
        }
        if (charactersCurrentHealth[1] <= 0)
        {
            isArtistAlive = false;
            artistButton.SetActive(true);
            artistButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            isArtistAlive = true;
            artistButton.SetActive(false);
            artistButton.GetComponent<Image>().color = Color.white;
        }
        if (charactersCurrentHealth[2] <= 0)
        {
            isSurgeonAlive = false;
            surgeonButton.SetActive(true);
            surgeonButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            isSurgeonAlive = true;
            surgeonButton.SetActive(false);
            surgeonButton.GetComponent<Image>().color = Color.white;
        }
        if (charactersCurrentHealth[3] <= 0)
        {
            isPriestAlive = false;
            priestButton.SetActive(true);
            priestButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            isPriestAlive = true;
            priestButton.SetActive(false);
            priestButton.GetComponent<Image>().color = Color.white;
        }
    }

}
