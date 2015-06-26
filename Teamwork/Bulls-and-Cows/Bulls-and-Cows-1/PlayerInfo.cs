using System;

public class PlayerInfo : IComparable<PlayerInfo>
{
    private string nickName;

    public string NickName
    {
        get
        {


            return nickName;
        }
        set
        {
            if (nickName == String.Empty)
            {
                throw new ArgumentException("NickName should have at least 1 symbol!");
            }
            else
            {
                nickName = value;
            }
        }
    }

    public int Guesses { get; set; }

    public PlayerInfo(string nickName, int guesses)
    {
        this.NickName = nickName;
        this.Guesses = guesses;
    }

    public int CompareTo(PlayerInfo other)
    {
        if (this.Guesses.CompareTo(other.Guesses) == 0)
        {
            return this.NickName.CompareTo(other.NickName);
        }
        else
        {
            return this.Guesses.CompareTo(other.Guesses);
        }
    }

    public override string ToString()
    {
        string result = String.Format("{0,3}    | {1}", Guesses, NickName);
        return result;
    }
}