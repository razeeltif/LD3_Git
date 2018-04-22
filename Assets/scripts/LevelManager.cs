using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public enum STATE { wait, selectedIngredient, play, attack};
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

    // instance du gameManager
    private static LevelManager instance;

    void Awake() {
        if (instance == null)
            instance = this;
        _statePlayer1 = STATE.wait;
        _statePlayer2 = STATE.wait;
    }

    public void SetStateWait(int pPlayer) {
        if (pPlayer == 1) _statePlayer1 = STATE.wait;
        if (pPlayer == 2) _statePlayer2 = STATE.wait;
    }

    public void SetStateAttack(int pPlayer) {
        if (pPlayer == 1) _statePlayer1 = STATE.attack;
        if (pPlayer == 2) _statePlayer2 = STATE.attack;
    }

    public void SetStateSelectedIngredient(int pPlayer) {
        if (pPlayer == 1) _statePlayer1 = STATE.selectedIngredient;
        if (pPlayer == 2) _statePlayer2 = STATE.selectedIngredient;
    }

    static public LevelManager getInstance() {
        return instance;
    }
}
