using System;
using System.Runtime.InteropServices;

abstract class Character
{
    public string CharacterType {get; private set;}
    public string CharacterState { get; set;}

    protected Character(string characterType)
    {
        this.CharacterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        if (CharacterType == "Wizard" && CharacterState != "SpellPrepared")
        {
            return true;
        } else
        {
            return false;
        }
    }

    public override string ToString()
    {
        return $"Character is a {CharacterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (target.CharacterType == "Wizard" && target.CharacterState != "SpellPrepared")
        {
            return 10;
        } else
        {
            return 6;
        }
    }

}

class Wizard : Character
{ 
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (CharacterState == "SpellPrepared")
        {
            return 12;
        } else
        {
            return 3;
        }
    }

    public void PrepareSpell()
    {
        CharacterState = "SpellPrepared";
    }

}
