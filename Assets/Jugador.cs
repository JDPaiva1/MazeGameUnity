using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Jugador : MonoBehaviour {
    public float velocidadMovimiento = 0.05f;
    private int puntos = 0;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            gameObject.transform.Translate(Vector3.up * velocidadMovimiento);
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            gameObject.transform.Translate(Vector3.down * velocidadMovimiento);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            gameObject.transform.Translate(Vector3.left * velocidadMovimiento);
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            gameObject.transform.Translate(Vector3.right * velocidadMovimiento);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "maze") {
            Debug.Log("Has perdido");
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.name);
        }
        if(other.gameObject.name.Contains("Triangle")) {
            puntos++;
            Debug.Log(puntos);
            GameObject.Find("textPoints").GetComponent<TMP_Text>().text = "Puntos: " + puntos.ToString();
            Destroy(other.gameObject);
        }
        if(other.gameObject.name == "Win") {
            GameObject.Find("Victoria").GetComponent<TMP_Text>().text = "¡Victoria!";
        }
    }
}
