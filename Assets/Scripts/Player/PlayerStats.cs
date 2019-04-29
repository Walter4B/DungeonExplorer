using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PlayerStats : MonoBehaviour
{
    public int Health = 100;
    public int Mana = 100;
    public int Armor = 0;
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
    private int activeScene;

    private InventoryPanel inventory;

    private void Awake()
    {
        currentHealth = Health;
        currentMana = Mana;
        HealthBar.value = Health;
        ManaBar.value = Mana;
        inventory = gameObject.GetComponent<InventoryPanel>();
    }

    private void Start()
    {
        PlayerMana.text = currentMana + "/" + Mana;
        UpdatePotions();
    }

    private void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            ManaPotions--;
            currentMana += 50;
            PlayerMana.text = currentMana + "/" + Mana;
            UpdatePotions();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            HealthPotions--;
            UpdatePotions();
            UpdatePlayerHealth(50);
        }
    }

    public void TakeDamage(int damage)
    {
        if (CanTakeDamage)
        {
            CanTakeDamage = false;
            currentHealth -= GetDamage(damage);

            inventory.UpdateStats();

            PlayerArmor.text = Armor.ToString();
            UpdatePlayerHealth();
        }
    }

    IEnumerator DamageTimer()
    {
        yield return new WaitForSeconds(2);
    }

    public void UpdatePlayerHealth(int healthToAdd = 0)
    {
        currentHealth = currentHealth + healthToAdd > Health ? Health : currentHealth + healthToAdd;
        HealthBar.value = currentHealth;
        PlayerHealth.text = currentHealth + "/" + Health;
    }

    private int GetDamage(int damage)
    {
        if (Armor == 0)
        {
            return damage;
        }

        var armourPieces = inventory.GetItemsFromSlots();
        //u ovom ifu se gleda jel je damage veci ili jednak od ukupnog armora
        if (damage >= Armor)
        {
            //ako je, onda postavi količinsku vrijednost na svakom armour piecu na 0
            foreach (var armour in armourPieces)
            {
                if (armour != null)
                {
                    armour.ArmourValue = 0;
                }
            }

            //vrati razliku damage-a i ukupnog armoura da se oduzme od healtha
            return damage - Armor;
        }

        var rnd = new System.Random();
        var armourValue = 0;
        var index = 0;

        do
        {
            index = rnd.Next(armourPieces.Count);

            if (armourPieces.ElementAt(index) != null)
            {
                armourValue = armourPieces.ElementAt(index).ArmourValue;

                if (damage > armourValue)
                {
                    armourPieces.ElementAt(index).ArmourValue = 0;
                }
                else
                {
                    armourPieces.ElementAt(index).ArmourValue -= damage;
                }

                damage -= armourValue;
            }
        } while (damage > 0);

        return damage;
    }

    private void UpdatePotions()
    {
        NumOfHealthPotions.text = HealthPotions.ToString();
        NumOfManaPotions.text = ManaPotions.ToString();
    }
}
