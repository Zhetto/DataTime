using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EgitoCutscene : MonoBehaviour
{
    [SerializeField] SpriteRenderer player;
    [SerializeField] Sprite kelley, humphrey;
    // Start is called before the first frame update
    void Start()
    {
        player.sprite = GameController.playerChoice.name == "Kelley" ? kelley : humphrey;
        this.enabled = false;
    }
}
