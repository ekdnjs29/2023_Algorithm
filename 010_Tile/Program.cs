﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _010_Tile
{
    internal class Program
    {
        static long[] tile = new long[51];
        static long[] tile2 = new long[51];
        static long[] tile3 = new long[51];

        static void Main(string[] args)
        {
            for (int i = 1; i <= 50; i++)
                Console.WriteLine("Tile({0}) = {1}", i, Tile(i));

            for (int i = 1; i <= 50; i++)
                Console.WriteLine("Tile2({0}) = {1}", i, Tile2(i));

            for (int i = 1; i <= 50; i++)
                Console.WriteLine("Tile3({0}) = {1}", i, Tile3(i));
        }

        // 3xn 크기의 직사각형을 1x2, 2x1 타일로 채우는 방법의 수 계산
        // Tile(2) = 3
        // Tile(n) = 3*Tile(n-2) + 2*(Tile(n-4) + Tile(n-6) + ... + Tile(0))
        private static long Tile3(int n)
        {
            if (n < 0 || n % 2 == 1)
                return 0;
            if (n == 0)
                return tile3[n] = 1;
            if (n == 2)
                return tile3[n] = 3;
            if (tile3[n] != 0)
                return tile3[n];

            long result = 3 * Tile3(n - 2);
            
            for (int i = 4; i<=n; i += 2)
                result += 2 * Tile3(n - i);

            return  tile3[n] = result;
        }

        // 2xn 크기의 직사각형을 1x2, 2x1, 2x2 타일로 채우는 방법의 수 계산
        // Tile(1) = 1
        // Tile(2) = 3
        // Tile(n) = Tile(n-1) + 2*Tile(n-2)
        private static long Tile2(int n)
        {
            if (n == 1)
                return tile2[n] = 1;
            else if (n == 2)
                return tile2[n] = 3;
            if (tile2[n] != 0)
                return tile2[n];
            return tile2[n] = Tile2(n - 1) + 2*Tile2(n - 2);
        }

        // 2xn 크기의 직사각형을 1x2, 2x1 타일로 채우는 방법의 수 계산
        // Tile(1) = 1
        // Tile(2) = 2
        // Tile(n) = Tile(n-1) + Tile(n-2)
        private static long Tile(int n)
        {
            if (n == 1)
                return tile[n] = 1;
            else if (n == 2)
                return tile[n] = 2;
            if (tile[n] != 0)
                return tile[n];
            return tile[n] = Tile(n - 1) + Tile(n - 2);
        }
    }
}
