using System;
using System.Collections.Generic;

namespace PokerGamesProject
{
    class Program
    {
        public static int[] match_array = new int[3] { 3, 5, 7 }; //定义一个二维数组存放火柴数；
        public static int row = 0; //初始化要取的火柴行数为0
        public static int column = 0; //初始化要去的火柴列数为0

        static void Main(string[] args)
        {
            Random rd = new Random();
            int num = rd.Next(0, 2);
            while (true)
            {
                Console.WriteLine("火柴数：");//每回合先展示剩余火柴数
                for (int i = 0; i < match_array.Length; i++)
                {
                    string match_show = "";
                    for (int j = 0; j < match_array[i]; j++)
                    {
                        match_show += " 1 ";
                    }
                    Console.WriteLine(match_show);
                }
                num = 1 - num;//如果初始是1号玩家，接下来则是0号玩家，一直重复如此

                while (true) {
                    Console.WriteLine((Player)num + ",请输入你要取的火柴行数：");//确定玩家要取的火柴行数
                    try
                    {
                        row = int.Parse(Console.ReadLine());
                        if (row < 1 || row > 3 || match_array[row - 1] < 1)
                        {
                            throw new Exception("行数不合法");
                        }
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("所输行数不合法，请重新输入");
                        continue;
                    }
                }

                while (true) {
                    Console.WriteLine((Player)num + ",请输入你在该行要取的火柴数：");//确定玩家要取的火柴列数
                    try
                    {
                        column = int.Parse(Console.ReadLine());
                        if (column < 1 || column > match_array[row - 1])
                        {
                            throw new Exception("列数不合法");
                        }
                        match_array[row - 1] -= column;
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("所输火柴数不合法，请重新输入");
                        continue;
                    }
                }

                //判断剩余火柴数是否为1或0，从而判断获胜者
                int surplus_match = 0;
                for (int i = 0; i < match_array.Length; i++)
                {
                    surplus_match += match_array[i];
                }
                if (surplus_match == 0)
                {
                    num = 1 - num;
                    Console.WriteLine((Player)num + ",恭喜获胜！");
                    break;
                }
                else if (surplus_match == 1) 
                {
                    Console.WriteLine((Player)num + ",恭喜获胜！");
                    break;
                }
            }
            Console.ReadKey();
        }

    }

    /// <summary>
    /// 玩家枚举
    /// </summary>
    public enum Player
    {
        player1,
        player2
    }
}
