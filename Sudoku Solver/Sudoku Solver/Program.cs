using System;


namespace Sudoku_Solver
{
    class Program
    {
      /* First Attempt
       * private static int[][] solve(int[][] board)
        {
            int num = 0;
            for(int i = 0; i < 9; i++)
            {
                for(int k = 0; k < 9; k++)
                {
                    if(board[i][k] == 0)
                    {
                        for(int n = 1;n<= 9;n++)
                        {
                            
                            if (check_row(board, n, i, k)&& check_col(board, n, i, k)&&subgraph(board, n, i, k))
                            {
                            board[i][k] = n;
                                
                            }
                            
                        }
                    }
                }
            }

            return board;
        }
      */

        //is num in the row
        private static bool check_row(int[][] board,int num,int row,int col)
        {
            for(int i = 0; i < 9; i++)
            {
                if (i == col)
                {
                    continue;
                }
                if (num==board[row][i])
                {
                    return false;
                }
            }
            return true;
        }
        //is num in the col
        private static bool check_col(int[][] board,int num, int row, int col)
        {
            for(int i = 0; i < 9;i++)
                {
                if(i == row)
                {
                    continue;
                }
                if(num == board[i][col])
                {
                    return false;
                }
            }
            return true;
        }
      
        //is num in the subgraph false if num is in, true if number is not in
        private static bool subgraph(int[][] board, int num, int row, int col)
        {
            //checks the first 3 rows
            if (row < 3&& row>=0)
            {
                //checks the first 3 col
                if(col<3 && col >= 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for(int k = 0; k < 3; k++)
                        {
                            if(i == row && k == col)
                            {
                                continue;
                            }
                            if (board[i][k] == num)
                            {
                                return false;
                            }
                        }
                    }
                }
                //checks the mid 3 col
                if (col < 6 && col >= 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int k = 3; k < 6; k++)
                        {
                            if (i == row && k == col)
                            {
                                continue;
                            }
                            if (board[i][k] == num)
                            {
                                return false;
                            }
                        }
                    }
                }
                //check last 3
                if (col < 9 && col >= 6)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int k = 6; k < 9; k++)
                        {
                            if (i == row && k == col)
                            {
                                continue;
                            }
                            if (board[i][k] == num)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            //check the mid 3 rows
            if (row < 6 && row >= 3)
            {
                //checks the first 3 col
                if (col < 3 && col >= 0)
                {
                    for (int i = 3; i < 6; i++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (i == row && k == col)
                            {
                                continue;
                            }
                            if (board[i][k] == num)
                            {
                                return false;
                            }
                        }
                    }
                }
                //checks mid 3 col
                if (col < 6 && col >= 3)
                {
                    for (int i = 3; i < 6; i++)
                    {
                        for (int k = 3; k < 6; k++)
                        {
                            if (i == row && k == col)
                            {
                                continue;
                            }
                            if (board[i][k] == num)
                            {
                                return false;
                            }
                        }
                    }
                }
                if (col < 9 && col >= 6)
                {
                    for (int i = 3; i < 6; i++)
                    {
                        for (int k = 6; k < 9; k++)
                        {
                            if (i == row && k == col)
                            {
                                continue;
                            }
                            if (board[i][k] == num)
                            {
                                return false;
                            }
                        }
                    }
                }

            }
            //check last 3 rows
            if (row < 9 && row >= 6)
            {
                //checks the first 3 col
                if (col < 3 && col >= 0)
                {
                    for (int i = 6; i < 9; i++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            if (i == row && k == col)
                            {
                                continue;
                            }
                            if (board[i][k] == num)
                            {
                                return false;
                            }
                        }
                    }
                }
                //checks the first 3 col
                if (col < 6 && col >= 3)
                {
                    for (int i = 6; i < 9; i++)
                    {
                        for (int k = 3; k < 6; k++)
                        {
                            if (i == row && k == col)
                            {
                                continue;
                            }
                            if (board[i][k] == num)
                            {
                                return false;
                            }
                        }
                    }
                }
                if (col < 9 && col >= 6)
                {
                    for (int i = 6; i < 9; i++)
                    {
                        for (int k = 6; k < 9; k++)
                        {
                            if (i == row && k == col)
                            {
                                continue;
                            }
                            if (board[i][k] == num)
                            {
                                return false;
                            }
                        }
                    }
                }

            }
            return true;
        }

        //check if a number is valid in the board, true if valid, false if not
        private static bool valid(int[][] board, int num, int row, int col)
        {
            if(subgraph(board,num,row,col)&&check_col(board, num, row, col)&&check_row(board, num, row, col))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static int[] find_empty(int[][] board)
        {
            int[] pos = new int[2];
            for(int i = 0; i < 9; i++)
            {
                for(int k = 0; k < 9; k++)
                {
                    if (board[i][k] == 0)
                    {
                        pos[0] = i;
                        pos[1] = k;
                        return pos;
                    }
                }
            }

            pos[0] = 99;
            pos[1] = 99;
            return pos;
        }

        /* private static void solve(int[][] board,int row, int col)
         {
             int[] find = new int[2];
             find = find_empty(board, row, col);
             int empty_row=find[0];
             int empty_col = find[1];
             //if there are not more empty rows/col end the solve
             if (empty_row > 80 && empty_col > 80)
             {
                 return;
             }
             for(int i =1; i < 10; i++)
             {
                 if (valid(board, i, empty_row, empty_col))
                 {
                     board[empty_row][empty_col] = i;
                     if (empty_row == 8 && empty_col == 8)
                     {
                         break;
                     }
                     if (empty_col == 8)
                     {
                         solve(board, empty_row + 1, 0);
                     }
                     else
                     {
                         solve(board, empty_row, empty_col + 1);
                     }
                 }
                 else
                 {
                     if (i == 9)
                     {
                         board[empty_row][empty_col] = 0;
                     }
                 }


             }

         }
        */
        private static bool solve(int[][] board)
        {
            int[] find = find_empty(board);
            int empty_row = find[0];
            int empty_col = find[1];
            if (find[0] > 80 && find[1] > 80)
            {
                return true;
            }
            else
            {
                for(int i = 1; i < 10; i++)
                {
                    if (valid(board, i, empty_row, empty_col)){
                        board[empty_row][empty_col] = i;
                        if (solve(board))
                        {
                            return true;
                        }
                        board[empty_row][empty_col] = 0;
                    }
                }
            }
            return false;
        }

        private static void printboard(int[][] board)
        {
            for(int i =0; i < 9; i++)
            {
                
                for (int k =0; k< 9; k++)
                {
                    
                    Console.Write(" "+board[i][k]);
                    if(k == 8)
                    {
                        Console.WriteLine();
                    }
                    if (k==2||k==5)
                    {
                        Console.Write('|');
                    }
                    
                }
            if ((i + 1) % 3 == 0 && i != 0)
                {
                    Console.WriteLine("---------------------");
                }
            }
        }
        private static string user_input_row(string row)
        {
            row = Console.ReadLine();
            if (row.Length < 9||row.Length>9)
            {
                Console.WriteLine("To many numbers or not enought numbers, try the row again");
                row = user_input_row(row);
                return row;
            }
            else
            {
                return row;
            }
        }


        static void Main(string[] args)
        {
            
            string num = string.Empty;
            int[][] arr = new int[9][];
            Console.WriteLine("Insert all numbers in order");
            Console.WriteLine("That means from left to right, row by row");
            Console.WriteLine("Input a Zero for blanks");
            Console.WriteLine("Don't Seperate the numbers by spaces");
            Random rnd = new Random();
            string[] insults = {"I can't believe you couldn't solve this","This was so easy, give me something harder next time",
                "Stop using me and solve the next one yourself","Yawn (not the word yawn but the action, implying the puzzle was not a challenge)",
                "If you want to build a ship, don't drum up people to collect wood and don't assign them tasks and work, but rather teach them to long for the endless immensity of the sea." +System.Environment.NewLine +"-Antoine de Saint-Exupery"};
            int iIndex = rnd.Next(insults.Length);

            /*
            arr[0] = new int[9] { 6, 0, 0, 1, 5, 7, 0, 0, 0};
            arr[1] = new int[9] { 3, 0, 0, 2, 0, 4, 0, 9, 0 };
            arr[2] = new int[9] { 0, 1, 0, 0, 0, 6, 0, 4, 0 };
            arr[3] = new int[9] { 2, 6, 0, 0, 1, 0, 8, 0, 3 };
            arr[4] = new int[9] { 5, 0, 0, 0, 0, 0, 9, 2, 4 };
            arr[5] = new int[9] { 0, 0, 3, 9, 0, 0, 0, 0, 5 };
            arr[6] = new int[9] { 1, 3, 0, 6, 0, 2, 0, 0, 0 };
            arr[7] = new int[9] { 9, 4, 6, 8, 3, 1, 7, 0, 0 };
            arr[8] = new int[9] { 7, 0, 0, 0, 4, 9, 0, 1, 0 };
            */
            arr[0] = new int[9] ;
            arr[1] = new int[9] ;
            arr[2] = new int[9] ;
            arr[3] = new int[9] ;
            arr[4] = new int[9] ;
            arr[5] = new int[9] ;
            arr[6] = new int[9] ;
            arr[7] = new int[9] ;
            arr[8] = new int[9] ;

            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Input the next row");
                num = user_input_row(num);
                for(int k =0; k < 9; k++)
                {
                    arr[i][k] = Convert.ToInt32(Char.ToString(num[k])); 
                }
            }


            Console.WriteLine("The OG Board");
            Console.WriteLine();
            printboard(arr);
            Console.WriteLine("Solved Board");
            Console.WriteLine();
            if (solve(arr))
            {
                printboard(arr);
                
                

            Console.WriteLine("{0}", insults[iIndex]);

            }
            else
            {
                Console.WriteLine("Invalid Board");
            }

            

            Console.Read();
        }
    }
}
