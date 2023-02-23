using Rubrica.Models;
Random rnd = new Random();

//Init rubrica e aggiunta dati random
Rub rubrica = new Rub();

rubrica.Add(new Contatto("paolo","cefalo", "3313244234"));
rubrica.Add(new Contatto_v2("mario","cefalo", "3313244234","cefalo@gmail.com"));
rubrica.Add(new Contatto("paolino","paperino", "3313244234"));
rubrica.Add(new Contatto_v2("mario","paperino", "3313244234","paperino@gmail.com"));
rubrica.Add(new Contatto("lino","paperino", "3334244234"));
rubrica.Add(new Contatto_v2("prova","provola", "3344244234","prova.provola@gmail.com"));
rubrica.Add(new Contatto("lo","ha","3333333333"));
rubrica.Add(new Contatto_v2("lo","ha", "detto","lei"));

Console.WriteLine("Daje,usa questa rubrica");

Console.WriteLine("Comandi:");
Console.WriteLine("<add> [v1|v2] [<nome> <cognome> <telefono> || <nome> <cognome> <telefono> <email>");
Console.WriteLine("<remove> [nome] [cognome]");
Console.WriteLine("<search> [nome] [cognome]");
Console.WriteLine("<list>");

bool exit = false;
do
{
    Console.WriteLine(Environment.NewLine);
    try{
        bool op_done = true;
        string command = Console.ReadLine() ?? "";
        string[] tokens = command.Split(" ");
        switch (tokens[0])
        {
            case "add":
                {
                    switch (tokens[1])
                    {
                        case "v1":
                            rubrica.Add(new Contatto(tokens[2], tokens[3], tokens[4]));
                            break;

                        case "v2":
                            rubrica.Add(new Contatto_v2(tokens[2], tokens[3], tokens[4], tokens[5]));
                            break;

                        default:
                            op_done = false;
                            break;
                    }

                }
                break;

            case "remove":
                rubrica.Remove(tokens[1], tokens[2]);
                break;

            case "search":
                Console.WriteLine(Search(tokens[1], tokens[2]).ToString());
                break;

            case "list":
                Console.WriteLine(rubrica.ToString());
                break;

            case "exit":
                exit = true;
                break;

            default:
                op_done = false;
                break;
        }
        if(op_done==true){
            Console.WriteLine("Fatto :)");
        }
    }catch(Exception e){
        /*In realtà sarebbe da filtrare tra le Exception */
        Console.WriteLine("Errore: " + e.ToString());
    }Console.WriteLine("Errore nel comando, forse il numero di parametri è sbagliato etc.");

} while (exit != true);


Console.WriteLine("Alla prossima");



/*
-code

-stack -> pila di attivazione 
 Parametri:

 passaggio per valore (ci sono tipi che sono passati per value + struct)

 passaggio per reference (oggetti)
 possiamo passare per riferimento quei dati che tipicamente sono per valore attraverso
 il boxing, quando incapsuliamo in Object uno di quei tipi.

-heap -> qui vanno gli oggetti

Smash the stack for fun profit

c'è un checksum nella fine stack che se viene invalidato -> viene lanciato lo stack_overflow 
[analogia canarino di miniera figo :)]




Convenzioni
Pascal case : (class,record,struct,inerface,public)

*/



