namespace Rubrica.Models
{
    // extends (java) -> : (c#)
    // [However this is not necessary, as everything has the common anchestor is Object]
    public class Contatto : Object
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName
        {
            get
            {
                return $"{this.Name} {this.Surname}";
            }
        }

        public Contatto(string name, string surname, string phonenumber)
        {
            this.Name = name;
            this.Surname = surname;
            this.PhoneNumber = phonenumber;
        }

        public override string ToString()
        {
            return $"{Name} {Surname} {PhoneNumber}";
        }

        //Usiamo virtual quando mi aspettiamo che ci saranno sottoclassi e potremo
        //sfruttare il riferimento a tempo di compilazione.
        public virtual void Contatta()
        {
            Console.WriteLine($"Sto chiamando {PhoneNumber} di {FullName}");
        }

        public virtual void Contatta(string Messaggio)
        {
            Console.WriteLine($"Sto mandando {Messaggio} da {PhoneNumber} di {FullName}");
        }

        public static Contatto getRandom(List<Contatto> lista, int index)
        {
            return lista[index];
        }

    }

    public class Contatto_v2 : Contatto
    {
        public string Email { set; get; }
        public Contatto_v2(string name, string surname, string phonenumber, string email) : base(name, surname, phonenumber)
        {
            this.Email = email;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {Email}";
        }

    }

    public class Rub
    {
        protected Dictionary<string, Contatto> _contatti;

        public Rub()
        {
            _contatti = new Dictionary<string, Contatto>();
        }
        public virtual void Add(Contatto c)
        {
            this._contatti.Add(c.FullName, c);
        }

        public virtual bool Remove(string name, string surname)
        {
            List<string> candidates = Search(name,surname);
            if(candidates.Count()==0) return false;
            if(candidates.Count()==1) return _contatti.Remove(candidates.ElementAt(0));

            //Ci sono più candidati, fai scegliere all'utente
            Console.WriteLine("Che dire, ci più utenti, quale volevi eliminare? : ");
            int i = 0;
            foreach (string candidate in candidates)
            {
                Console.WriteLine($"{i})" + _contatti[candidate]);
                i++;
            }
            
            do{
                string scelta = Console.ReadLine() ?? "scelta_non_valida"; //Se è null, sostituiscilo con 
                try{
                    int index = int.Parse(scelta);
                    _contatti.Remove(candidates[index - 1]);
                    break;
                }catch(Exception){
                    Console.WriteLine("Non è una scelta valida :(");
                }
            }while(true);

            return true;
        }

        public virtual List<string> Search(string name, string surname)
        {
            List<string> _candidateKeys = new List<string>();
            if (name == null && surname == null) return _candidateKeys;
            if (name == null || surname == null)
            {
                if (surname == null) // -> cerca per nome
                {
                    foreach (string key in _contatti.Keys) if (_contatti[key].Surname == surname) _candidateKeys.Add(key);
                }

                if (name == null) // -> cerca per cognome
                {
                    foreach (string key in _contatti.Keys) if (_contatti[key].Name == name) _candidateKeys.Add(key);
                }

                return _candidateKeys;
            }
            if(_contatti.ContainsKey($"{name} {surname}") == true) _candidateKeys.Add($"{name} {surname}");
            return _candidateKeys;
        }

        public override string ToString()
        {
            string result = "################# RUBRICA ###############" + Environment.NewLine;
            foreach(string key in _contatti.Keys) result += "-" + _contatti[key].ToString() + Environment.NewLine;
            result += "#########################################";
            return result;
        }
    }
}