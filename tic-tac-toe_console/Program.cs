using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

public class Program
{
    private static int Random_Choice_Player()
    {
        Random random_player = new Random();
        int random_choice_player = random_player.Next(0, 2);
        return random_choice_player;
    }
    private static String[] Field_Generated()
    {
        List<String> field = new List<String>();
        string[] newField = { "-", "-", "-", "-", "-", "-", "-", "-", "-" };
        field.AddRange(newField);
        return field.ToArray();
    }
    private static void Field_Output(String[] fields)
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
                        Field_Output(fields);
                        Console.WriteLine($"The {player} walks");
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
                    Field_Output(fields);
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
                        Field_Output(fields);
                        Console.WriteLine($"The {player} walks");
                        Console.Write($"Enter the value of x: {x_coord}");
                    }
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
                    Field_Output(fields);
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
                Field_Output(fields);
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
    private static void Main(String[] args)
    {
        while (true)
        {
            Console.WriteLine("Hello! This is a game of tic-tac-toe! | By DOROFEEV");
            int choice_player = Random_Choice_Player(); // Selection of a random player // 0 - cross; 1 - zero 
            String[] fields = Field_Generated(); // Generation of the game board
            while (true)
            {
                Field_Output(fields); // Output of the game field
                String player = InversionPlayer(choice_player); // Inversion of the player in the title
                Console.WriteLine($"The {player} walks");
                MakingMove(fields, player); // Making a move
                Console.Clear();
                List<String> check = CheckWin(fields, choice_player); // Check the winnings
                if (check[0] == "True") { Console.WriteLine($"Won the {player}"); break; }
                if (check[1] == "True") { Console.WriteLine($"Draw!"); break; }
                choice_player = ChangePlayer(choice_player); // Change player
            }
        }
    }
}

    