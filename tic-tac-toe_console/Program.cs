using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Xml.Serialization;

public class Program
{
    private static int RandomChoicePlayer()
    {
        Random random_player = new Random();
        int random_choice_player = random_player.Next(0, 2);
        return random_choice_player;
    }
    private static String[] FieldGenerated()
    {
        List<String> field = new List<String>();
        string[] newField = { "-", "-", "-", "-", "-", "-", "-", "-", "-" };
        field.AddRange(newField);
        return field.ToArray();
    }
    private static void FieldOutput(String[] fields)
    {
        Console.WriteLine();
        short i = 0;
        while (i < 9)
        {
            if (i == 3 | i == 6 | i == 9) { Console.WriteLine(); }
            Console.Write(fields[i] + " ");
            i++;
        }
        Console.WriteLine();
    }
    private static String InversionPlayer(int choice_player)
    {
        String player = "";
        if (choice_player == 0) { player = "cross"; }
        else if (choice_player == 1) { player = "zero"; }
        return player;
    }
    private static int ChoosingMode()
    {
        while (true)
        {
            Console.Write("Choose the game mode (1 - with another person, 2 - with a bot): ");
            String? answer = Console.ReadLine();
            if (answer == "1") { Console.Clear(); Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV"); return 1; }
            else if (answer == "2") { Console.Clear(); Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV"); return 2; }
            else { Console.Clear(); Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV"); }
        }
    }
    private static void MakingMove(String[] fields, String player)
    {
        while (true)
        {
            String? x_coord, y_coord = "";
            while (true)
            {
                try
                {
                    Console.Write("Enter the value of x: ");
                    x_coord = Console.ReadLine();
                    if (0 < int.Parse(x_coord) & int.Parse(x_coord) < 4)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
                        FieldOutput(fields);
                        Console.WriteLine($"The {player} walks");
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
                    FieldOutput(fields);
                    Console.WriteLine($"The {player} walks");
                }
            }
            while (true)
            {                                         
                try
                {
                    Console.Write("Enter the value of y: ");
                    y_coord = Console.ReadLine();
                    if (0 < int.Parse(y_coord) & int.Parse(y_coord) < 4)
                    {
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
                        FieldOutput(fields);
                        Console.WriteLine($"The {player} walks");
                        Console.Write($"Enter the value of x: {x_coord}");
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
                    FieldOutput(fields);
                    Console.WriteLine($"The {player} walks");
                    Console.Write($"Enter the value of x: {x_coord}");
                }
            }
            String sign = "";
            if (player == "cross") { sign = "X"; }
            if (player == "zero") { sign = "O"; }
            int coords = 0;
            if (short.Parse(y_coord) == 1) { coords = short.Parse(x_coord) - 1; }
            else if (short.Parse(y_coord) == 2) { coords = short.Parse(x_coord) + 2; }
            else if (short.Parse(y_coord) == 3) { coords = short.Parse(x_coord) + 5; }
            if (fields[coords].Equals("-")) { fields[coords] = $"{sign}"; Console.Clear(); Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV"); break; }
            else
            {
                Console.Clear();
                Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
                FieldOutput(fields);
                Console.WriteLine($"The {player} walks");
            }
        }
    }
    private static int ChangePlayer(int player)
    {
        if (player == 0) { player = 1; }
        else if (player == 1) { player = 0; }
        return player;
    }
    private static List<String> CheckWin(String[] fields, int player)
    {
        bool win = false;
        bool isDraw = false;
        if (fields[0] == fields[4] && fields[4] == fields[8]) { win = true; }
        else if (fields[2] == fields[4] && fields[4] == fields[6] && fields[4] != "-") { win = true; }
        else if (fields[0] == fields[3] && fields[3] == fields[6] && fields[3] != "-") { win = true; }
        else if (fields[1] == fields[4] && fields[4] == fields[7] && fields[4] != "-") { win = true; }
        else if (fields[2] == fields[5] && fields[5] == fields[8] && fields[5] != "-") { win = true; }
        else if (fields[0] == fields[1] && fields[1] == fields[2] && fields[1] != "-") { win = true; }
        else if (fields[3] == fields[4] && fields[4] == fields[5] && fields[4] != "-") { win = true; }
        else if (fields[6] == fields[7] && fields[7] == fields[8] && fields[7] != "-") { win = true; }
        else if (fields[0] != "-" && fields[1] != "-" && fields[2] != "-" && fields[3] != "-" && 
            fields[4] != "-" && fields[5] != "-" && fields[6] != "-" && fields[7] != "-" && fields[8] != "-")
        {
            isDraw = true;
        }
        List<String> data = new List<String>();
        string[] newData = { win.ToString(), isDraw.ToString() };
        data.AddRange(newData);
        return data;
    }
    private static void MakingMoveWithBot(String[] fields, String player, int random_choice)
    {
        while (true)
        {
            if (random_choice == 0)
            {
                String signx = "", signo = "";
                if (player == "cross") { signo = "O"; }
                if (player == "zero") { signo = "X"; }
                if (player == "cross") { signx = "X"; }
                if (player == "zero") { signx = "O"; }
                int count = fields.Count(x => x == "-");

                if (fields[0] == fields[4] && fields[4] == signx && fields[8] == "-") { fields[8] = signx; break; }
                else if (fields[8] == fields[4] && fields[4] == signx && fields[0] == "-") { fields[0] = signx; break; }
                else if (fields[8] == fields[0] && fields[0] == signx && fields[4] == "-") { fields[4] = signx; break; }
                else if (fields[2] == fields[4] && fields[4] == signx && fields[6] == "-") { fields[6] = signx; break; }
                else if (fields[6] == fields[4] && fields[4] == signx && fields[2] == "-") { fields[2] = signx; break; }
                else if (fields[6] == fields[2] && fields[2] == signx && fields[4] == "-") { fields[4] = signx; break; }
                else if (fields[0] == fields[3] && fields[3] == signx && fields[6] == "-") { fields[6] = signx; break; }
                else if (fields[6] == fields[3] && fields[3] == signx && fields[0] == "-") { fields[0] = signx; break; }
                else if (fields[0] == fields[6] && fields[6] == signx && fields[3] == "-") { fields[3] = signx; break; }
                else if (fields[1] == fields[4] && fields[4] == signx && fields[7] == "-") { fields[7] = signx; break; }
                else if (fields[7] == fields[4] && fields[4] == signx && fields[1] == "-") { fields[1] = signx; break; }
                else if (fields[1] == fields[7] && fields[7] == signx && fields[4] == "-") { fields[4] = signx; break; }
                else if (fields[2] == fields[5] && fields[5] == signx && fields[8] == "-") { fields[8] = signx; break; }
                else if (fields[8] == fields[5] && fields[5] == signx && fields[2] == "-") { fields[2] = signx; break; }
                else if (fields[2] == fields[8] && fields[8] == signx && fields[5] == "-") { fields[5] = signx; break; }
                else if (fields[0] == fields[1] && fields[1] == signx && fields[2] == "-") { fields[2] = signx; break; }
                else if (fields[2] == fields[1] && fields[1] == signx && fields[0] == "-") { fields[0] = signx; break; }
                else if (fields[0] == fields[2] && fields[2] == signx && fields[1] == "-") { fields[1] = signx; break; }
                else if (fields[3] == fields[4] && fields[4] == signx && fields[5] == "-") { fields[5] = signx; break; }
                else if (fields[5] == fields[4] && fields[4] == signx && fields[3] == "-") { fields[3] = signx; break; }
                else if (fields[3] == fields[5] && fields[5] == signx && fields[4] == "-") { fields[4] = signx; break; }
                else if (fields[6] == fields[7] && fields[7] == signx && fields[8] == "-") { fields[8] = signx; break; }
                else if (fields[8] == fields[7] && fields[7] == signx && fields[6] == "-") { fields[6] = signx; break; }
                else if (fields[6] == fields[8] && fields[8] == signx && fields[7] == "-") { fields[7] = signx; break; }

                if (fields[0] == fields[4] && fields[4] == signo && fields[8] == "-") { fields[8] = signx; break; }
                else if (fields[8] == fields[4] && fields[4] == signo && fields[0] == "-") { fields[0] = signx; break; }
                else if (fields[0] == fields[8] && fields[8] == signo && fields[4] == "-") { fields[4] = signx; break; }
                else if (fields[2] == fields[4] && fields[4] == signo && fields[6] == "-") { fields[6] = signx; break; }
                else if (fields[6] == fields[4] && fields[4] == signo && fields[2] == "-") { fields[2] = signx; break; }
                else if (fields[2] == fields[6] && fields[6] == signo && fields[4] == "-") { fields[4] = signx; break; }
                else if (fields[0] == fields[3] && fields[3] == signo && fields[6] == "-") { fields[6] = signx; break; }
                else if (fields[6] == fields[3] && fields[3] == signo && fields[0] == "-") { fields[0] = signx; break; }
                else if (fields[0] == fields[6] && fields[6] == signo && fields[3] == "-") { fields[3] = signx; break; }
                else if (fields[1] == fields[4] && fields[4] == signo && fields[7] == "-") { fields[7] = signx; break; }
                else if (fields[7] == fields[4] && fields[4] == signo && fields[1] == "-") { fields[1] = signx; break; }
                else if (fields[1] == fields[7] && fields[7] == signo && fields[4] == "-") { fields[4] = signx; break; }
                else if (fields[2] == fields[5] && fields[5] == signo && fields[8] == "-") { fields[8] = signx; break; }
                else if (fields[8] == fields[5] && fields[5] == signo && fields[2] == "-") { fields[2] = signx; break; }
                else if (fields[2] == fields[8] && fields[8] == signo && fields[5] == "-") { fields[5] = signx; break; }
                else if (fields[0] == fields[3] && fields[3] == signo && fields[6] == "-") { fields[6] = signx; break; }
                else if (fields[0] == fields[1] && fields[1] == signo && fields[2] == "-") { fields[2] = signx; break; }
                else if (fields[2] == fields[1] && fields[1] == signo && fields[0] == "-") { fields[0] = signx; break; }
                else if (fields[0] == fields[2] && fields[2] == signo && fields[1] == "-") { fields[1] = signx; break; }
                else if (fields[3] == fields[4] && fields[4] == signo && fields[5] == "-") { fields[5] = signx; break; }
                else if (fields[5] == fields[4] && fields[4] == signo && fields[3] == "-") { fields[3] = signx; break; }
                else if (fields[3] == fields[5] && fields[5] == signo && fields[4] == "-") { fields[4] = signx; break; }
                else if (fields[6] == fields[7] && fields[7] == signo && fields[8] == "-") { fields[8] = signx; break; }
                else if (fields[8] == fields[7] && fields[8] == signo && fields[6] == "-") { fields[6] = signx; break; }
                else if (fields[6] == fields[8] && fields[8] == signo && fields[7] == "-") { fields[7] = signx; break; }

                if (count == 9) { if (fields[4] == "-") { fields[4] = signx; break; } }
                else if (count == 7)
                {
                    if (fields[0] == "-" && fields[8] == signo) { fields[0] = signx; break; }
                    if (fields[2] == "-" && fields[6] == signo) { fields[2] = signx; break; }
                    if (fields[6] == "-" && fields[2] == signo) { fields[6] = signx; break; }
                    if (fields[8] == "-" && fields[0] == signo) { fields[8] = signx; break; }
                    else
                    {
                        if (fields[0] == "-" && fields[1] == signo) { fields[0] = signx; break; }
                        else if (fields[2] == "-" && fields[1] == signo) { fields[2] = signx; break; }
                        else if (fields[0] == "-" && fields[3] == signo) { fields[0] = signx; break; }
                        else if (fields[6] == "-" && fields[3] == signo) { fields[6] = signx; break; }
                        else if (fields[2] == "-" && fields[5] == signo) { fields[2] = signx; break; }
                        else if (fields[8] == "-" && fields[5] == signo) { fields[8] = signx; break; }
                        else if (fields[6] == "-" && fields[7] == signo) { fields[6] = signx; break; }
                        else if (fields[8] == "-" && fields[7] == signo) { fields[8] = signx; break; }
                    }
                }
                else if (count == 5)
                {
                    if (fields[0] == fields[4] && fields[1] == signo && fields[6] == "-") { fields[6] = signx; break; }
                    else if (fields[2] == fields[4] && fields[1] == signo && fields[8] == "-") { fields[8] = signx; break; }
                    else if (fields[0] == fields[4] && fields[3] == signo && fields[2] == "-") { fields[2] = signx; break; }
                    else if (fields[6] == fields[4] && fields[3] == signo && fields[8] == "-") { fields[8] = signx; break; }
                    else if (fields[2] == fields[4] && fields[5] == signo && fields[0] == "-") { fields[0] = signx; break; }
                    else if (fields[8] == fields[4] && fields[5] == signo && fields[6] == "-") { fields[6] = signx; break; }
                    else if (fields[6] == fields[4] && fields[7] == signo && fields[0] == "-") { fields[0] = signx; break; }
                    else if (fields[8] == fields[4] && fields[7] == signo && fields[2] == "-") { fields[2] = signx; break; }
                }
                else
                {
                    Random rand = new Random();
                    while (true)
                    {
                        int random1 = rand.Next(0, 9);
                        if (fields[random1] == "-") { fields[random1] = signx; break; }
                    }
                    break;
                }
            }
            else if (random_choice == 1)
            {

                if (fields[0] != "-" && fields[1] != "-" && fields[2] != "-" && fields[3] != "-"
                    && fields[4] != "-" && fields[5] != "-" && fields[6] != "-" && fields[7] != "-" && fields[8] != "-")
                { break; }
                Console.Clear();
                Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
                FieldOutput(fields);
                Console.WriteLine($"The {player} walks");
                String? x_coord = "", y_coord = "";
                while (true)
                {
                    try
                    {
                        Console.Write("Enter the value of x: ");
                        x_coord = Console.ReadLine();
                        if (0 < int.Parse(x_coord) & int.Parse(x_coord) < 4)
                        {
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
                            FieldOutput(fields);
                            Console.WriteLine($"The {player} walks");
                        }
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
                        FieldOutput(fields);
                        Console.WriteLine($"The {player} walks");
                    }
                }                                 
                while (true)
                {
                    try
                    {
                        Console.Write("Enter the value of y: ");
                        y_coord = Console.ReadLine();
                        if (0 < int.Parse(y_coord) & int.Parse(y_coord) < 4)
                        {
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
                            FieldOutput(fields);
                            Console.WriteLine($"The {player} walks");
                            Console.Write($"Enter the value of x: {x_coord}");
                        }
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
                        FieldOutput(fields);
                        Console.WriteLine($"The {player} walks");
                        Console.Write($"Enter the value of x: {x_coord}");
                    }
                }
                String sign = "";
                if (player == "cross") { sign = "X"; }
                if (player == "zero") { sign = "O"; }
                int coords = 0;
                if (short.Parse(y_coord) == 1) { coords = short.Parse(x_coord) - 1; }
                else if (short.Parse(y_coord) == 2) { coords = short.Parse(x_coord) + 2; }
                else if (short.Parse(y_coord) == 3) { coords = short.Parse(x_coord) + 5; }
                if (fields[coords].Equals("-")) { fields[coords] = $"{sign}"; Console.Clear(); Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV"); break; }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
                    FieldOutput(fields);
                    Console.WriteLine($"The {player} walks");
                }
            }
        }
    }
    private static void Main(String[] args)
    {
        while (true)
        {
            Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
            Random random = new Random();
            int random_choice = 0; //random.Next(0, 2);
            int choice_player = RandomChoicePlayer(); // Selection of a random player // 0 - cross; 1 - zero 
            String[] fields = FieldGenerated(); // Generation of the game board
            int mode = ChoosingMode(); // Choosing a mode ( 1 - with another person, 2 - with a bot )
            while (true)
            {
                FieldOutput(fields); // Output of the game field
                String player = InversionPlayer(choice_player); // Inversion of the player in the title

                if (mode == 1)
                {
                    Console.WriteLine($"The {player} walks");
                    MakingMove(fields, player); // Making a move
                }
                else if (mode == 2)
                {
                    MakingMoveWithBot(fields, player, random_choice);
                    if (random_choice == 0) { random_choice = 1; }
                    else if (random_choice == 1) { random_choice = 0; }
                }

                Console.Clear();
                List<String> check = CheckWin(fields, choice_player); // Check the winnings
                if (check[0] == "True") { FieldOutput(fields); Console.WriteLine($"Won the {player}"); break; }
                if (check[1] == "True") { FieldOutput(fields); Console.WriteLine($"Draw!"); break; }
                choice_player = ChangePlayer(choice_player); // Change player
            }
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}