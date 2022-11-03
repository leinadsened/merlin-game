using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int _playerScore;
    [SerializeField] private int _playerHearts;
    [SerializeField] private TMP_Text _scoreText;

    private int ghostSpawn = 0;
    public GameObject ghostPrefab;
    public GameObject[] spawnPoints;
    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        _playerScore = 0;
        _playerHearts = 3;

    }

    // Update is called once per frame
    void Update()
    {
        if (_playerHearts < 1) {
            if (SceneManager.GetActiveScene().name == "WitchLevel"){
            SceneManager.LoadScene("RestartSceneWitch", LoadSceneMode.Single);
            }
            if (SceneManager.GetActiveScene().name == "GameScene"){
            SceneManager.LoadScene("RestartScene", LoadSceneMode.Single);    
            }
            if (SceneManager.GetActiveScene().name == "FightScene"){
            SceneManager.LoadScene("RestartSceneFight", LoadSceneMode.Single);
            }    
        }
        if (SceneManager.GetActiveScene().name == "WitchLevel" && _playerScore > 100 ){
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        if (SceneManager.GetActiveScene().name == "GameScene" && _playerScore > 200){
            SceneManager.LoadScene("FightScene", LoadSceneMode.Single);
        }
        if (SceneManager.GetActiveScene().name == "FightScene" && _playerScore > 50000){
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        }
    }
    public void UpdateScore(){
        _playerScore += 1;
        source.PlayOneShot(clip);
        UpdateText();
        if (SceneManager.GetActiveScene().name == "FightScene"){
            SpawnGhost();
            int shallWeSpawnAnother = UnityEngine.Random.Range(0, 3);
            print(shallWeSpawnAnother);
            if ( shallWeSpawnAnother > 1){
                SpawnGhost();
            }
        }
        if (SceneManager.GetActiveScene().name == "GameScene" || SceneManager.GetActiveScene().name == "WitchLevel"){
            if (_playerScore > 20 && ghostSpawn < 1) {
                SpawnGhost();
            }
            if (_playerScore > 40 && ghostSpawn < 2) {
                SpawnGhost();
            }
            if (_playerScore > 60 && ghostSpawn < 3) {
                SpawnGhost();
            }
            if (_playerScore > 80 && ghostSpawn < 4) {
                SpawnGhost();
            }
        }
    }
    public void SpawnGhost(){
        Vector3 spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].transform.position;
        Instantiate(ghostPrefab, spawnPoint, transform.rotation);
        ghostSpawn++;
    }
    public void DamageKing(){
        _playerHearts -= 1;
        UpdateText();
        if (SceneManager.GetActiveScene().name == "FightScene"){
            SpawnGhost();
        }
    }
    public void UpdateText(){
        _scoreText.text = "Score: " + _playerScore.ToString() + "   Lives: " + _playerHearts.ToString();
    }
}
