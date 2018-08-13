using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    #region jesse
    public Music musicPlayer;
    public SoundEffects soundFXPlayer;
    bool goodEnding;

    public Choice choice1;
    public Choice choice2;


    #endregion

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

    public bool isWomanDied = false;
    public bool hearLedwell = false;

    public int bossHitPoints = 5;

    private enum States
    {
        Intro1, Intro2, Intro3, Intro4, Intro5, Intro6, Intro7,
        Rear1, Rear2, Rear3, Rear4, Rear5, Rear6, Rear7, Rear8,
        Original1, Original2, Original3, Original4,
        Combat1,
        CombatEnd1, CombatEnd2, Selection1, WomanHint1, WomanHint2,
        NextCabin, NextCabin2,
        Selection2,
        ArtistLive1, ArtistLive2,
        Combat2, Epliogue1,
        ArtistDied1, ArtistDied2,
        Ending
    }
    private States myState;

    // Use this for initialization
    void Start() {
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
    void Update() {
        //print(myState);
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
        else if (myState == States.Combat1) { Combat1(); }
        else if (myState == States.CombatEnd1) { CombatEnd1(); }
        else if (myState == States.CombatEnd2) { CombatEnd2(); }
        else if (myState == States.Selection1) { Selection1(); }
        else if (myState == States.WomanHint1) { WomanHint1(); }
        else if (myState == States.WomanHint2) { WomanHint2(); }
        else if (myState == States.NextCabin) { NextCabin(); }
        else if (myState == States.Selection2) { Selection2(); }
        else if (myState == States.NextCabin2) { NextCabin2(); }
        else if (myState == States.ArtistLive1) { ArtistLive1(); }
        else if (myState == States.ArtistLive2) { ArtistLive2(); } 
        else if (myState == States.ArtistDied1) { ArtistDied1(); }
        else if (myState == States.ArtistDied2) { ArtistDied2(); }
        else if (myState == States.Combat2) { Combat2(); }
        else if (myState == States.Epliogue1) { Epilogue1(); }
        else if (myState == States.Ending) { Ending(); }
    }

    void Ending()
    {
        if (goodEnding)
        {
            SceneManager.LoadScene("GoodEnding");
        } else if (!goodEnding)
        {
            SceneManager.LoadScene("BadEnding");
        }
    }

    public void Next()
    {
        //Jesse
        //if (myState == States.Combat1 || myState == States.Combat2) musicPlayer.ChangeMusic(true);          // Combat begins - start combat music
        //if (myState == States.CombatEnd1 || myState == States.CombatEnd2) musicPlayer.ChangeMusic(false);   // Combat ends - switch music (TODO - fix timing)


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
        else if (myState == States.CombatEnd1) { myState = States.CombatEnd2; }
        else if (myState == States.CombatEnd2) { myState = States.Selection1; }
        else if (myState == States.WomanHint1) { myState = States.WomanHint2; }
        else if (myState == States.WomanHint2) { myState = States.NextCabin; }
        else if (myState == States.NextCabin) { myState = States.Selection2; }
        else if (myState == States.NextCabin2)
        {
            print("Ledwell spoke? " + hearLedwell);
            print("Woman spoke? " + isWomanDied);
            if (!hearLedwell && !isWomanDied)
            {
                myState = States.ArtistLive1;
                goodEnding = true;
            }
            else
            {
                myState = States.ArtistDied1;
                goodEnding = false;
            }
            print(myState);
        }
        else if (myState == States.ArtistLive1) { myState = States.ArtistLive2; }
        else if (myState == States.ArtistLive2) { myState = States.Combat2; }
        else if (myState == States.ArtistDied1) { myState = States.ArtistDied2; }
        else if (myState == States.ArtistDied2) { myState = States.Combat2; }
        else if (myState == States.Epliogue1) { myState = States.Ending; }
        
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

    void Combat1() {
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
            if (bossHitPoints <= 0)
            {
                myState = States.CombatEnd1;
                ResetCombat();
                bossHitPoints = 5;
            }
        }
    }

    void CombatEnd1()
    {
        textDisplayer.text = "Darcy: What in god's name was that? \n" +
            "Ledwell: The physiology is like nothing I've seen!";
    }

    void CombatEnd2()
    {
        textDisplayer.text = "The bloodied woman lies still on the cabin floor. \n" +
            "The black void has reached the next cabin. The cabin windows begins to shake. ";
    }

    void Selection1() {
        choice1.Display("Ledwell: That woman needed our help!");
        choice2.Display("Darcy: This isn't the time Ledwell!");
        textDisplayer.text = "";
        //textDisplayer.text = "Ledwell: That woman needed our help! \n" + 
        //    "Darcy: This isn't the time Ledwell!";
    }

    void WomanHint1() {
        textDisplayer.text = "Ledwell bandages the woman's wounds. She is dying. \n" +
            "Woman: Who would do that? Just hurt someone for no reason? All I did was hum...";
    }

    void WomanHint2()
    {
        textDisplayer.text = "The woman has passed away.";
    }

    void NextCabin() {
        textDisplayer.text = "The team proceeds to the next cabin. \n" +
            "Ledwell: We need to talk right now about what just happened.";
    }

    void Selection2()
    {
        choice1.Display("Darcy: I won't hear another word. \n");
        choice2.Display("Talbot: Hear her out please.");
        textDisplayer.text = "";
        //textDisplayer.text = "Darcy: I won't hear another word. \n" +     // just no...
        //    "Talbot: Hear her out please.";
    }

    void NextCabin2()
    {
        textDisplayer.text = "The team proceeds to the next cabin. \n" +
            "This cabin has a small bathroom. Talbot knocks on the door and opens to check for survivors. ";
    }

    void ArtistLive1() {
        textDisplayer.text = "A tall man lunges toward Talbot with his arms stretched out. \n" +
            "Darcy: Wait!";
    }

    void ArtistLive2()
    {
        textDisplayer.text = "Talbot jumps back.";
    }

    void Combat2()
    {
        DisableDecks();
        CheckAlive();

        nextButton.gameObject.SetActive(false);
        if (!hasDrawnCards)
        {
            DrawCards();
        }
        if (isEnemyRound)
        {
            EnemyActions("DemanMan");
        }
        if (isPlayerRound)
        {
            CardAction();
            if (bossHitPoints <= 0)
            {
                myState = States.Epliogue1;
                ResetCombat();
                bossHitPoints = 5;
            }
        }
    }

    void Epilogue1 (){
        textDisplayer.text = "Close your eyes. \n" +
            "Close your eyes. \n" +
            "Close your eyes. And sleep... \n" +
            "A siren roars.";
    }

    void ArtistDied1() {
        textDisplayer.text = "A tall man lunges toward Talbot with his arms stretched out. \n" +
            "Darcy: Wait!";
    }

    void ArtistDied2()
    {
        textDisplayer.text = "Talbot: Aaaaaaah! \n" +
            "Talbot's eyes are gouged out and he drops to his knees.";
        charactersCurrentHealth[1] = 0;
    }

    public void OpinionDetective()
    {
        print("Detective choice during: " + myState);
        if (myState == States.Selection1)
        {
            isWomanDied = true;
            print("isWomanDied? " + isWomanDied);
            myState = States.NextCabin;
        }
        if (myState == States.Selection2)
        {
            print("Ignored Ledwell");
            hearLedwell = false;
            myState = States.NextCabin2;
        }
    }
    public void OpinionArtist()
    {
        print("Artist choice during: " + myState);
        if (myState == States.Selection2)
        {
            print("Surgeon makes noise");
            hearLedwell = true;
            myState = States.NextCabin2;
        }
    }
    public void OpinionSurgeon()
    {
        print("Surgeon choice during: " + myState);
        if (myState == States.Selection1)
        {
            print("Woman speaks");
            isWomanDied = false;
            print("isWomanDied? " + isWomanDied);
            myState = States.WomanHint1;
        }
    }
    public void OpinionPriest()
    {
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
        //print(detectiveDeck.Count);
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
                int target = Random.Range(0, 3);
                charactersCurrentHealth[target] -= 2;
                if (target == 0)
                {
                    textDisplayer.text = "Creature attacks Darcy.";
                }
                else if (target == 1)
                {
                    textDisplayer.text = "Creature attacks Talbot.";
                }
                else if (target == 2)
                {
                    textDisplayer.text = "Creature attacks Ledwell.";
                }
                else if (target == 3)
                {
                    textDisplayer.text = "Creature attacks Mason.";
                }
            }
            else if (randomNumber == 2) // enemy will attack everyone
            {
                textDisplayer.text = "Creature sweeps floor.";
                charactersCurrentHealth[0] -= 1;
                charactersCurrentHealth[1] -= 1;
                charactersCurrentHealth[2] -= 1;
                charactersCurrentHealth[3] -= 1;
            }
            else if (randomNumber == 3) // enemy will heal it self
            {
                bossHitPoints += 1;
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
                    textDisplayer.text = "Bandages";
                    charactersCurrentHealth[0] += 1;
                    charactersCurrentHealth[1] += 1;
                    charactersCurrentHealth[2] += 1;
                    charactersCurrentHealth[3] += 1;
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<PlasticSurgery>())
            {
                if (isSurgeonAlive)
                {
                    textDisplayer.text = "Plastic Surgery";
                    charactersCurrentHealth[0] += 1;
                    charactersCurrentHealth[1] += 1;
                    charactersCurrentHealth[2] += 1;
                    charactersCurrentHealth[3] += 1;
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<Sawlimb>())
            {
                if (isSurgeonAlive)
                {
                    textDisplayer.text = "Sawlimb";
                    bossHitPoints -= 1;
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<FalseIdol>())
            {
                if (isPriestAlive)
                {
                    textDisplayer.text = "False Idol";
                    bossHitPoints -= 1;
                    RedrawCards();
                } 
            }
            else if (hit.collider.GetComponent<Sacrifice>())
            {
                if (isPriestAlive)
                {
                    textDisplayer.text = "Sacrifice";
                    bossHitPoints -= 1;
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<EyeWitness>())
            {
                if (isDetectiveAlive)
                {
                    textDisplayer.text = "EyeWitness";
                    bossHitPoints -= 1;
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<Spy>())
            {
                if (isDetectiveAlive)
                {
                    textDisplayer.text = "Spy";
                    bossHitPoints -= 1;
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<Silhouette>())
            {
                if (isDetectiveAlive)
                {
                    textDisplayer.text = "Silhouette";
                    charactersCurrentHealth[0] += 1;
                    charactersCurrentHealth[1] += 1;
                    charactersCurrentHealth[2] += 1;
                    charactersCurrentHealth[3] += 1;
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<Sketch>())
            {
                if (isArtistAlive)
                {
                    textDisplayer.text = "Sketch";
                    bossHitPoints -= 1;
                    RedrawCards();
                }
            }
            else if (hit.collider.GetComponent<Erase>())
            {
                if (isArtistAlive)
                {
                    textDisplayer.text = "Erase";
                    charactersCurrentHealth[0] += 1;
                    charactersCurrentHealth[1] += 1;
                    charactersCurrentHealth[2] += 1;
                    charactersCurrentHealth[3] += 1;
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

    void ResetCombat() {
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

        detectiveButton.SetActive(true);
        artistButton.SetActive(true);
        surgeonButton.SetActive(true);
        priestButton.SetActive(true);

        charactersCurrentHealth[0] = 10;
        charactersCurrentHealth[1] = 10;
        charactersCurrentHealth[2] = 10;
        charactersCurrentHealth[3] = 10;

        nextButton.gameObject.SetActive(true);
    }
}
