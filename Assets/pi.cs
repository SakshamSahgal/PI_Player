using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class pi : MonoBehaviour
{
    int no_of_digits = 0;
    public InputField nod;
    public Scrollbar bar;
    public GameObject Info_Pallette;
    public GameObject sound_pannel;
    public GameObject play_button;
    public GameObject set_no_of_digits;
    public int[] digits = new int[0];
    public int numerator = 355;
    public int denomator = 113;
    public AudioSource[] sounds = new AudioSource[10];
    public GameObject Panel;
    public GameObject[] numbers = new GameObject[10];
    public GameObject[] instantiated_numbers = new GameObject[0];
    // Start is called before the first frame update
    void Start()
    {
        sound_pannel.SetActive(false);
        play_button.SetActive(false);
        Info_Pallette.SetActive(false);
       // if (instantiated_numbers.Length != 0)
           // Clear_Numbers();
        //bar.size = no_of_digits;


    }
    public void close_sound_pannel()
    {
        sound_pannel.SetActive(false);
    }
    public void open_sound_pannel()
    {
        sound_pannel.SetActive(true);
    }

   public void Info() 
    {
        Info_Pallette.SetActive(true);
    }
    public void cross_palette() 
    {
        Info_Pallette.SetActive(false);
    }
    public void play_it() 
    {
        play_button.SetActive(false);
        if (instantiated_numbers.Length != 0)
              Clear_Numbers();

       // set_no_of_Digits_from_button();
        Array.Resize<int>(ref digits, no_of_digits);
        Array.Resize<GameObject>(ref instantiated_numbers, no_of_digits);
        Calculate_Digits();
        Create_Number();
        StartCoroutine("play");

    }
    public void set_no_of_Digits_from_button() 
    {
        play_button.SetActive(true);
        set_no_of_digits.SetActive(false);
        no_of_digits = int.Parse(nod.text);
    }
    public void Clear_Numbers() 
    {
        for (int i=0;i<instantiated_numbers.Length;i++) 
        {
            Destroy(instantiated_numbers[i]);
        }
        Array.Resize<int>(ref digits,0);
    }
    void Create_Number()
    {

        for (int i = 0; i < no_of_digits; i++)
        {
            GameObject new_number = Instantiate(numbers[digits[i]]) as GameObject;
            instantiated_numbers[i] = new_number;
            new_number.transform.SetParent(Panel.transform, false);
        }
           
    }
    void Calculate_Digits()
    {
        numerator = 355;
        denomator = 113;
        numerator %= denomator;
        for (int i = 0; i < no_of_digits; i++)
        {
            numerator = numerator * 10;
            digits[i] = (numerator / denomator);
            numerator %= denomator;
        }
    }
    
    public void play_zero()
    {
        sounds[0].Play();
    }
    public void play_one()
    {
        sounds[1].Play();
    }
    public void play_two()
    {
        sounds[2].Play();
    }
    public void play_three()
    {
        sounds[3].Play();
    }
    public void play_four()
    {
        sounds[4].Play();
    }
    public void play_five()
    {
        sounds[5].Play();
    }
    public void play_six()
    {
        sounds[6].Play();
    }
    public void play_seven()
    {
        sounds[7].Play();
    }
     public void play_eight()
    {
        sounds[8].Play();
    }

    public void play_nine()
    {
        sounds[9].Play();
    }
    IEnumerator play() 
    {
        //double j = 0;
        for (int i = 1; i <= no_of_digits; i++)
        {
            sounds[digits[i-1]].Play();
            Debug.Log(digits[i - 1]);
            //bar.value = (float)j;
            yield return new WaitForSeconds(0.2f);
            instantiated_numbers[i - 1].gameObject.SetActive(false);
        }
       // bar.value = 1f;
        set_no_of_digits.SetActive(true);
    }
}
