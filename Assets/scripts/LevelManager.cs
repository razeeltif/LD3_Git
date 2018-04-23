using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public enum STATE { isWaiting, isPlaying, isAttacking};
    public STATE statePlayer1 {
        get { return _statePlayer1; }
    }

    private STATE _statePlayer1;

    public STATE statePlayer2 {
        get { return _statePlayer2; }
    }

    private STATE _statePlayer2;

    public int PLAYER_1 = 1;
    public int PLAYER_2 = 2;

    public int player1health = 50;
    public int player2health = 50;

    public bool isDefenseplayer1 = false;
    public bool isDefenseplayer2 = false;

    // instance du levelManager
    private static LevelManager instance;

    void Awake() {
        if (instance == null)
            instance = this;
        _statePlayer1 = STATE.isWaiting;
        _statePlayer2 = STATE.isWaiting;
    }

    public void SetStateWait(int pPlayer) {
        if (pPlayer == 1) _statePlayer1 = STATE.isWaiting;
        if (pPlayer == 2) _statePlayer2 = STATE.isWaiting;
    }

    public void SetStateAttack(int pPlayer) {
        if (pPlayer == 1) _statePlayer1 = STATE.isAttacking;
        if (pPlayer == 2) _statePlayer2 = STATE.isAttacking;
    }

    public void SetStatePlay(int pPlayer) {
        if (pPlayer == 1) _statePlayer1 = STATE.isPlaying;
        if (pPlayer == 2) _statePlayer2 = STATE.isPlaying;
    }

    public void Attack(int pPlayer, int pDamage) {
        if (pPlayer == 1) {
            if (!isDefenseplayer2) {
                player2health -= pDamage;
                if (player2health <= 0) GameManager.getInstance().Death(pPlayer);
            }
            _statePlayer1 = STATE.isWaiting;
        }

        if (pPlayer == 2) {
            if (!isDefenseplayer1) {
                player1health -= pDamage;
                if (player1health <= 0) GameManager.getInstance().Death(pPlayer);
            }
            _statePlayer2 = STATE.isWaiting;
        }

    }

    public void SetDefense(int pPlayer, bool isDef) {
        if (pPlayer == 1) isDefenseplayer1 = isDef;
        if (pPlayer == 2) isDefenseplayer2 = isDef;
    }

    static public LevelManager getInstance() {
        return instance;
    }
}
