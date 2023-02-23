namespace MasterMind.Models
{
    // extends (java) -> : (c#)
    // [However this is not necessary, as everything has as common anchestor Object]
    public class Game{
        public enum Color
        {
            Green, Red, Blue, Yellow, Orange, White
        }

        public enum Peg
        {
            White,Black,Empty
        }


        protected class Combination : List<Color>,IEquatable<Combination>
        {
            public Combination()
            {
                Random rnd = new Random();
                Color[] possibile_colors = (Color[])Enum.GetValues(typeof(Color));
                for(int i=0;i<4;i++) this.Add(possibile_colors[(rnd.Next(possibile_colors.Length))]);
            }
            public Combination(Color c1, Color c2, Color c3, Color c4)
            {
                this.AddRange(new List<Color>{c1,c2,c3,c4});
            }

            public List<Peg> WeakEquals (Combination? attempt){
                if(attempt == null) return new List<Peg> { Peg.Empty, Peg.Empty, Peg.Empty, Peg.Empty };
                List<Peg> result = new List<Peg>();

                int pos = 0;
                foreach(Color c in attempt){
                    if (this.ElementAt(pos)==c) result.Add(Peg.Black);
                    else if (this.Contains(c)) result.Add(Peg.White);
                    else result.Add(Peg.Empty);
                    pos++;
                };
                
                return result;
            }

            public bool Equals (Combination? other_comb)
            {
                if(other_comb==null) return false;

                int pos=0;
                foreach(Color c in other_comb){
                    if (this.ElementAt(pos)!=c) return false;
                };

                return true;
            }
        }

        private Combination _combination;

        public Game(){
            _combination = new Combination();
        }

        public bool attempt(string[] attempt_stringy){

            if(attempt_stringy.Count()!=4) return false;

            //Costruisci l'oggetto combinazione 
            List<Color> attempt = new List<Color>();

            foreach(string c in attempt_stringy){
                if (Enum.TryParse<Color>(c, out Color col)) attempt.Add(col);
                else return false;
            }

            Combination _combinationAttempt = new Combination(attempt[0], attempt[1], attempt[2], attempt[3]);

            //Controlla se ha vinto 
            if(_combination == _combinationAttempt) return true;

            //Se non ha vinto, restituisci i peg resultanti come indizio
            List<Peg> pegs = _combination.WeakEquals(_combinationAttempt);

            //Stampa i peg
            Console.WriteLine(Environment.NewLine + "/////////////// CPU Responce ///////////////");
            string peg_string = "";
            foreach(Peg p in pegs){
                switch(p){
                    case Peg.Black: peg_string += " Black"; break;
                    case Peg.White: peg_string += " White"; break;
                    case Peg.Empty: peg_string += " Empty"; break;
                }
            }
            Console.WriteLine(peg_string);
            Console.WriteLine("////////////////////////////////////////" + Environment.NewLine);
            return false;
        }
    }
}