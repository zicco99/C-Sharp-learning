using MasterMind.Models;

Game g = new Game();
Console.WriteLine("Daje, giochiamo!");

bool res = false;
do{
    string command = Console.ReadLine() ?? "";
    res = g.attempt(command.Split(" "));
}while(res!=true);

Console.WriteLine("Hai vinto :)");







