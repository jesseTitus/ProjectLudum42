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
        Intro1, Intro2, Intro3, Intro4, Intro5, Intro6, Intro7,
        Rear1, Rear2, Rear3, Rear4, Rear5, Rear6, Rear7, Rear8,
        Original1, Original2, Original3, Original4,
        Opinions1, Combat1, Pass1
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

        nextButton = GameObject.Find("NextButton").GetComponent<Button>();

        myState = States.Intro1;
    }
	
	// Update is called once per frame
	void Update () {
        print(myState);
        if (myState == States.Intro1) { Intro1(); }
        else if (myState == States.Intro2) { Intro2(); }
        else if (myState == States.Intro3) { Intro3(); }
        else if (myState == States.Intro4) { Intro4(); }
        else if (myState == States.Intro5) { Intro5(); }
        else if (myState == States.Intro6) { Intro6(); }
        else if (myState == States.Intro7) { Intro7(); }
        else if (myState == States.Rear1) { Rear1(); }
        else if (myState == States.Rear2) { Rear2(); }
        else if (myState == States.Rear3) { Rear3(); }
        else if (myState == States.Rear4) { Rear4(); }
        else if (myState == States.Rear5) { Rear5(); }
        else if (myState == States.Rear6) { Rear6(); }
        else if (myState == States.Rear7) { Rear7(); }
        else if (myState == States.Rear8) { Rear8(); }
        else if (myState == States.Original1) { Original1(); }
        else if (myState == States.Original2) { Original2(); }
        else if (myState == States.Original3) { Original3(); }
        else if (myState == States.Original4) { Original4(); }
        else if (myState == States.Opinions1) { Opinions1(); }
        else if (myState == States.Pass1) { Pass1(); }
        else if (myState == States.Combat1) { Combat1(); }
    }

    public void Next()
    {
        if (myState == States.Intro1) { myState = States.Intro2; }
        else if (myState == States.Intro2) { myState = States.Intro3; }
        else if (myState == States.Intro3) { myState = States.Intro4; }
        else if (myState == States.Intro4) { myState = States.Intro5; }
        else if (myState == States.Intro5) { myState = States.Intro6; }
        else if (myState == States.Intro6) { myState = States.Intro7; }
        else if (myState == States.Intro7) { myState = States.Rear1; }
        else if (myState == States.Rear1) { myState = States.Rear2; }
        else if (myState == States.Rear2) { myState = States.Rear3; }
        else if (myState == States.Rear3) { myState = States.Rear4; }
        else if (myState == States.Rear4) { myState = States.Rear5; }
        else if (myState == States.Rear5) { myState = States.Rear6; }
        else if (myState == States.Rear6) { myState = States.Rear7; }
        else if (myState == States.Rear7) { myState = States.Rear8; }
        else if (myState == States.Rear8) { myState = States.Original1; }
        else if (myState == States.Original1) { myState = States.Original2; }
        else if (myState == States.Original2) { myState = States.Original3; }
        else if (myState == States.Original3) { myState = States.Original4; }
        else if (myState == States.Original4) { myState = States.Combat1; }
    }

    void Intro1() {
        detectiveButton.SetActive(true);
        artistButton.SetActive(false);
        surgeonButton.SetActive(false);
        priestButton.SetActive(false);
        textDisplayer.text = "Darcy: Well, the squadron is reunited. Ledwell, still saving lives?";
    }

    void Intro2() {
        surgeonButton.SetActive(true);
        textDisplayer.text = "Ledwell: Sir! \n" +
            "Darcy: Talbot, how goes the sketch artist gig?";
    }

    void Intro3() {
        artistButton.SetActive(true);
        textDisplayer.text = "Talbot: They never give me enough time. \n" +
            "Darcy: Isn't that the point?";
    }

    void Intro4() {
        priestButton.SetActive(true);
        textDisplayer.text = "Darcy: Mason? \n" +
            "Mason: I sense an unholy presence on the train. \n" +
            "Darcy: ...";
    }

    void Intro5() {
        textDisplayer.text = "A disheveled man sits nearby. Staring straight ahead. \n" +
            "Another person, a woman, sits nearby humming to herself quietly.";
    }

    void Intro6()
    {
        textDisplayer.text = "'BANG' \n" +
            "A loud noise is heard from the back of the train.";
    }

    void Intro7()
    {
        textDisplayer.text = "Darcy: Well, looks like our investigation is starting early.";
    }

    void Rear1()
    {
        textDisplayer.text = "The team proceeds to the rear cabin.";
    }

    void Rear2()
    {
        textDisplayer.text = "Mason: It is here. \n" +
            "Darcy: I don't see anything. Let's go back and get some rest before -";
    }

    void Rear3()
    {
        textDisplayer.text = "A small crackling noise can be heard. \n" +
            "The team looks at the rear all at once.";
    }

    void Rear4()
    {
        textDisplayer.text = "The source of the crackling gives birth to a dime-sized shadow. \n" +
            "The shadow spiders out into a web of darkness.";
    }

    void Rear5()
    {
        textDisplayer.text = "Ledwell: Ok, now we leave. \n" +
            "Darcy: What the - ";
    }

    void Rear6()
    {
        textDisplayer.text = "* CRACK * \n" +
            "The rear-window slowly cracks as if effected by the shadow. ";
    }

    void Rear7()
    {
        textDisplayer.text = "*BANG*  \n" +
            "The window is sucked out and the rear of the train slowly peels away.";
    }

    void Rear8()
    {
        textDisplayer.text = "Darcy: RUN";
    }

    void Original1()
    {
        textDisplayer.text = "Darcy: You two need to get the hell out of here! Go to the next cabin NOW! \n" +
            "The woman turns and yells, 'huh ?'.";
    }

    void Original2()
    {
        textDisplayer.text = "Just then, the disheveled man that was sitting there seems to snap back to reality and stands up. \n" +
            "His arms stiffen and he begins to shake.";
    }

    void Original3()
    {
        textDisplayer.text = "Out of his back burst flesh in the shape of wings.  \n" +
            "His mouth opens in a deranged grin and he lunges for the woman.";
    }

    void Original4()
    {
        textDisplayer.text = "He begins nawing at her face. \n" +
            "Darcy fires his gun at the possessed man.";
    }

    void Opinions1() {
        textDisplayer.text = "Detective: Let's see the face under that hood. \n" +
            "Priest: Hold on, let me talk to him first.";
    }

    void Combat1() {
        textDisplayer.text = "Insert Battle Text Here.";
        DisableDecks();
        CheckAlive();
        nextButton.gameObject.SetActive(false);
        if (!hasDrawnCards) {
            DrawCards();
        }
        if (isEnemyRound) {
            EnemyActions("DemanMan");
        }
        if (isPlayerRound) {
            CardAction();
        }
    }

    void Pass1() {
        textDisplayer.text = "hooded figure disapeared back into shadow.";
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
        if (enemy == "DemanMan")
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

            if (hit.collider.GetComponent<Bandages>())
            {
                if (isSurgeonAlive)
                {
                    print("Bandages");
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<PlasticSurgery>())
            {
                if (isSurgeonAlive)
                {
                    print("PlasticSurgery");
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<Sawlimb>())
            {
                if (isSurgeonAlive)
                {
                    print("Sawlimb");
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<FalseIdol>())
            {
                if (isPriestAlive)
                {
                    print("FalseIdol");
                    RedrawCards();
                } 
            }
            else if (hit.collider.GetComponent<Sacrifice>())
            {
                if (isPriestAlive)
                {
                    print("Sacrifice");
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<EyeWitness>())
            {
                if (isDetectiveAlive)
                {
                    print("EyeWitness");
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<Spy>())
            {
                if (isDetectiveAlive)
                {
                    print("Spy");
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<Silhouette>())
            {
                if (isDetectiveAlive)
                {
                    print("Silhouette");
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
            else if (hit.collider.GetComponent<Erase>())
            {
                if (isArtistAlive)
                {
                    print("Erase");
                    RedrawCards();
                }
            }
            else {
                Debug.Log("Card does not exist.");
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
