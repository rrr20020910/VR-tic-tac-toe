using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    public Renderer[] O_card = new Renderer[9];
    public Renderer[] X_card = new Renderer[9];
    public Material[] sign = new Material[14];
    public GameObject Object;
    int stage = 0;

    int[] board = new int[9];
    int[] n = new int[2] { 1, -1 };
    int turn = 0;
    int is_win = 0;


    void SetSign(Material m)
    {
        var renderer = Object.GetComponent<MeshRenderer>();
        Material[] materials = renderer.sharedMaterials;
        materials[0] = m;
        renderer.sharedMaterials = materials;
    }
 
    void Start()
    {
        for (int i = 0; i < 14; i++)
        {
            sign[i].shader = Shader.Find("Transparent/Diffuse");
        }
        SetSign(sign[0]);

        for (int i=0;i<9;i++)
        {
           O_card[i].enabled = false;
           X_card[i].enabled = false;
           board[i] = 0;
        }
        stage = 0;
        turn = n[Random.Range(0, 2)];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Return) && stage==0)
        {
            stage = 1;
        }
        else if(stage >9)
        {
            SetSign(sign[1]);
        }
        else if(stage>0&&stage<10)
        {
            SetSign(sign[stage + 4]);
            if (((board[0] == board[1]) && (board[1] == board[2]) && board[0] == turn) ||
               ((board[3] == board[4]) && (board[4] == board[5]) && board[3] == turn) ||
               ((board[6] == board[7]) && (board[7] == board[8]) && board[6] == turn) ||
               ((board[0] == board[3]) && (board[3] == board[6]) && board[0] == turn) ||
               ((board[1] == board[4]) && (board[4] == board[7]) && board[1] == turn) ||
               ((board[2] == board[5]) && (board[5] == board[8]) && board[2] == turn) ||
               ((board[0] == board[4]) && (board[4] == board[8]) && board[0] == turn) ||
               ((board[2] == board[4]) && (board[4] == board[6]) && board[2] == turn))
            {
                is_win = turn;
                for (int i = 0; i < 9; i++)
                {
                    O_card[i].enabled = false;
                    X_card[i].enabled = false;
                    board[i] = 0;
                }
                turn = n[Random.Range(0, 2)];
            }
           
            if (is_win == 1)
            {
                SetSign(sign[2]);
                stage++;
                is_win = 0;
               
            }
            else if(is_win == -1)
            {
                SetSign(sign[3]);
                is_win = 0;
            }
            for (int c = 0; c < 9; c++)
            {
                if (board[c] == 0) break;
                if (c == 8)
                {
                    is_win = -1;
                    for (int i = 0; i < 9; i++)
                    {
                        O_card[i].enabled = false;
                        X_card[i].enabled = false;
                        board[i] = 0;
                    }
                    turn = n[Random.Range(0, 2)];
                    SetSign(sign[4]);
                }
            }
            if (turn == 1)
            {
                if (Input.GetKeyDown("1") && board[0] == 0)
                {
                    board[0] = turn;
                    O_card[0].enabled = true;
                    turn *= -1;
                }
                else if (Input.GetKeyDown("2") && board[1] == 0)
                {
                    board[1] = turn;
                    O_card[1].enabled = true;
                    turn *= -1;
                }
                else if (Input.GetKeyDown("3") && board[2] == 0)
                {
                    board[2] = turn;
                    O_card[2].enabled = true;
                    turn *= -1;
                }
                else if (Input.GetKeyDown("4") && board[3] == 0)
                {
                    board[3] = turn;
                    O_card[3].enabled = true;
                    turn *= -1;
                }
                else if (Input.GetKeyDown("5") && board[4] == 0)
                {
                    board[4] = turn;
                    O_card[4].enabled = true;
                    turn *= -1;
                }
                else if (Input.GetKeyDown("6") && board[5] == 0)
                {
                    board[5] = turn;
                    O_card[5].enabled = true;
                    turn *= -1;
                }
                else if (Input.GetKeyDown("7") && board[6] == 0)
                {
                    board[6] = turn;
                    O_card[6].enabled = true;
                    turn *= -1;
                }
                else if (Input.GetKeyDown("8") && board[7] == 0)
                {
                    board[7] = turn;
                    O_card[7].enabled = true;
                    turn *= -1;
                }
                else if (Input.GetKeyDown("9") && board[8] == 0)
                {
                    board[8] = turn;
                    O_card[8].enabled = true;
                    turn *= -1;
                }
                
            }
            else
            {
                int value = Random.Range(0, 9);
                if (board[value] == 0)
                {
                    board[value] = turn;
                    X_card[value].enabled = true;
                    turn *= -1;
                }    
                
            }
            
        }
        
    }
}
