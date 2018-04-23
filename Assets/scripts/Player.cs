using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (GestionManette))]
public class Player : MonoBehaviour {

	// numéro du joueur (1 ou 2)
	public int playerNumber;

	public int pv = 50;

	public LevelManager.STATE state;

	private bool defense = false;
    [HideInInspector] public string namePlayer;
	[HideInInspector] public GestionManette manette;
    [HideInInspector] public Animation anim;

    // timer s'occupant de chronométrer le delai d'attaque
    Timer timerDelayAttacking;
    // temps de delais de l'attaque
    public float delayAttacking;
    PlayMusic playMusic;

	void Awake()
	{
		manette = GetComponent<GestionManette>();
        playMusic = GameManager.FindObjectOfType<PlayMusic>();
	}

	// Use this for initialization
	void Start () {
		manette.playerNumber = playerNumber;
        anim = GetComponent<Animation>();
        if(playerNumber == 1)
        {
            namePlayer = "Gus";
        }
        if(playerNumber == 2)
        {
            namePlayer = "Leo";
        }
        // initialisation du timer (il n'est pas lancé)
        timerDelayAttacking = Timer.Initialize(delayAttacking, this);
		
	}
	
	// Update is called once per frame
	void Update () {
		if(state == LevelManager.STATE.isAttacking && timerDelayAttacking.finished){
			setStateWaiting();
		}
		
	}

	/// <summary>
	/// fonction appelé à chaque fois que le joueur subit des dégats
	/// </summary>
	/// <param name="damage"></param>
	public void takeDamage(int damage){
		// si le joueur possède de la défense, on annule les dommages et enlève la défense
		if(defense){
			setDefense(false);
			return;
		}else{
			pv -= damage;
            if (pv <= (50*0.75)) {
                playMusic.PlaySelectedMusic(2);
                return;
            }
            else if (pv <= (50 * 0.5)) {
                playMusic.PlaySelectedMusic(3);
                return;
            }
            else if (pv <= (50 * 0.25)) {
                playMusic.PlaySelectedMusic(4);
                return;
            }
            else if(pv <= 0){
				GameManager.getInstance().Death(this);
                return;
			}
		}
	}

	public void Attack(int damage){
		// grenade farcie
		if(damage == 5){
            anim.Play(namePlayer+"|Action_LancerTomate");
            Debug.Log("GRENADE !");
		}else if( damage == 10){
            anim.Play(namePlayer+"|Action_LancerAssiette");
			Debug.Log("ASSIETTE !");
		}
	}

	public void setDefense(bool _def){
		if(defense != _def){
			defense = _def;
			if(defense == true){
                anim.Play(namePlayer + "|Action_BoireSoupe");
				// TODO : animation de la mise de défense
			}else{
				// TODO : animation de l'enlevage de défense
			}
		}
	}
 
	public void setStateAttacking(){
		if(state != LevelManager.STATE.isAttacking){
			Debug.Log("set attacking");
			state = LevelManager.STATE.isAttacking;
			actionDelay();
		}
	}

	public void setStateWaiting(){
		state = LevelManager.STATE.isWaiting;
	}

	public void setStatePlaying(){
		state = LevelManager.STATE.isPlaying;
	}

	// quand un plat est fini, il y a un petit temps de latence avant de pouvoir refaire un plat
	public void actionDelay(){
		timerDelayAttacking.start();
	}

}
