using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace bikove
{
    public class gameScore : IComparable
    {
        public gameScore(string ime, int guesses)
        {
            this.Name = ime;
            this.Guesses = guesses;
        }

        public string Name
        {
            get;
            private set;
        }
        public int Guesses
        {
            get;
            private set;
        }
        public override bool Equals(object obj)
        {
            gameScore objectToCompare = obj as gameScore;
            if (objectToCompare == null)
            {
                return false;
            }
            else
            {



                return this.Guesses.Equals(objectToCompare) && this.Name.Equals(objectToCompare);
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Guesses.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} --> {1} {2}", this.Name, this.Guesses, this.Guesses == 1 ? "guess" : "guesses");
        }

        public int CompareTo(object obj)
        {
            gameScore objectToCompare = obj as gameScore;
            if (objectToCompare == null)
            {
                return -1;
            }
            if (this.Guesses.CompareTo(objectToCompare.Guesses) == 0)
            {
                
				
				
				return this.Name.CompareTo(objectToCompare.Name);
            }
            else
            {
                return this.Guesses.CompareTo(objectToCompare.Guesses);
            }
        }

        public string Serialize()
        {
            return string.Format("{0}_:::_{1}", this.Name, this.Guesses);



        }
        public static gameScore Deserialize(string data)
        {
            string[] dataAsStringArray = data.Split(new string[] { "_:::_" }, StringSplitOptions.None);
            if (dataAsStringArray.Length != 2) return null;

            string name = dataAsStringArray[0];

            int guesses = 0;
            int.TryParse(dataAsStringArray[1], out guesses);

            return new gameScore(name, guesses);
        }
    }
}
