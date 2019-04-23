using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int Health = 100;
    public int Mana = 100;
    public int Armor = 1;
    public int HealthPotions = 0;
    public int ManaPotions = 0;

    public Slider HealthBar;
    public Slider ManaBar;

    public TextMeshProUGUI PlayerHealth;
    public TextMeshProUGUI PlayerMana;
    public TextMeshProUGUI PlayerArmor;
    public TextMeshProUGUI NumOfHealthPotions;
    public TextMeshProUGUI NumOfManaPotions;

    public bool CanTakeDamage = true;

    public GameObject UICanvas;

    private int currentHealth;
    private int currentMana;
    private int ActiveScene;

    private void Start()
    {
        currentHealth = Health;
        currentMana = Mana;
        HealthBar.value = Health;
        ManaBar.value = Mana;
    }

    private void Update()
    {
        PlayerHealth.text = currentHealth + "/" + Health;
        PlayerMana.text = currentMana + "/" + Mana;
        PlayerArmor.text = Armor.ToString();

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(1);
            Destroy(UICanvas);
            Destroy(gameObject);
        }

        if(!CanTakeDamage)
        {
            DamageTimer();
            CanTakeDamage = true;
        }
    }

    public void TakeDamage(int damage)
    {
        if (CanTakeDamage)
        {
            CanTakeDamage = false;
            currentHealth -= damage;
            HealthBar.value = currentHealth;
        }
    }

    IEnumerator DamageTimer()
    {
        yield return new WaitForSeconds(2);
    }
}
