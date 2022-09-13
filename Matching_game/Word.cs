using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGame
{
    public class Word
    {
        public string HiddenWord { get; set; }
        public string X { get; set; }
        public bool IsHidden { get; set; }


        public string GetWord()
        {
            if (IsHidden == false)
                return HiddenWord;
            else 
                return X;
        }
    }
}
