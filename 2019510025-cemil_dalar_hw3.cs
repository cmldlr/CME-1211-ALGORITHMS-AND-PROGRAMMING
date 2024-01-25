using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace homework_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
         
            string[] str = File.ReadAllLines("D://poem.txt");
          

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("This is your poem");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------");
            
            for (int q = 0; q < str.Length; q++)
            {
                Console.WriteLine(str[q]);
            }
            Console.WriteLine("----------------------------------");
            Console.ResetColor();
            int counter1;
            int counter;
            int f = 0;
            string str2 = "";
         
            string[] last = new string[str.Length];
         
            //find word,additional and phrase ryhme 
            
            for (int g = 0; g < str.Length; g++)
            {
                counter = 0;
                for (int k = 0; k < str.Length; k++)
                {
                    for (f = 0; f < str[g].Length - 1; f++)
                    {
                        if (k > g&& k < str.Length)
                        {
                            if (str[g].Length - 1 - f < 0 || str[k].Length - 1 - f < 0)
                            {
                                continue;
                            }
                            if (str[g][str[g].Length - 1 - f] == str[k][str[k].Length - 1 - f])
                            {
                                counter++;
                            }
                            else if (str[g][str[g].Length - 1 - f] != str[k][str[k].Length - 1 - f])
                            {
                                break;
                            }
                        }
                    }
                
                    str2 = str[g].Substring(str[g].Length - f);
                    
                    counter1 = 0;
                    for (int m = 0; m < str2.Length; m++)
                    {
                        if (str2[m] == ' ')
                        {
                            counter1++;
                        }
                    }
                    if (counter1 == 1 && k > g)
                    {

                        last[g] = str2;
                        last[k] = str2;
                        Console.WriteLine("REPETİTİON:--->:" + str2 +" "+g+".statment "+ " with " + (k) + ".statement   " + " type:--->Word Ryhme");

                    }
                    if (counter1 > 1 && k > g)
                    {

                        last[g] = str2;
                        last[k] = str2;
                        Console.WriteLine("REPETİTİON:--->" + str2 +"   "+ g+".statment "+ "  with   " + (k)+".statment   "  + " type:--->Phrase Rhyme");
                    }
                    if ((str[g][str[g].Length - 1] == str[k][str[k].Length - 1]) && counter1 == 0 && k > g)
                    {
                        last[g] = str2;
                        last[k] = str2;
                        Console.WriteLine("REPETİTİON:--->" + str2 + "  " + g  +".statement "+ "  with   " + (k) + ".statement  " + " type:--->Additional Rhyme");
                    }
                    

                }

            }
           //find the types of ryhme
            bool straightryhme = true;
            bool alternatingrhyme = true;
            bool windingrhyme = true;
            bool hoarseryhme = true;
            string A , B, C, D;
            
            if (last.Length%4==0)
            {
                for (int x = 0; x < last.Length; x++)
                {

                    if (x%4== 0 && (last[x] != last[x + 3] || last[x + 1] != last[x + 2] || last[x] == last[x + 2] || last[x + 1] == last[x + 3]))
                    {
                       
                        windingrhyme = false;
                        continue;
                    }

                    if (x < last.Length - 1 && last[x] == last[x + 1])
                    {
                        straightryhme = true;
                        if (x < last.Length - 2 && last[x] == last[x + 2])
                        {
                            alternatingrhyme = false;
                        }
                       

                    }
                    
                    if (x < last.Length - 1 && last[x] != last[x + 1])
                    {
                        straightryhme = false;
                        if (x< last.Length - 2 && last[x] != last[x + 2])
                        {
                            alternatingrhyme = false;
                        }
                       
                    }
                   
                    if (x < last.Length - 1 && last[x] != last[x + 1])
                    {
                        straightryhme = false;
                        if (x < last.Length - 2 && last[x] == last[x + 2])
                        {
                            alternatingrhyme = true;
                        }
                        
                    }
                    if (last.Length%3!=0)
                    {
                        hoarseryhme = false;
                    }
                    



                }
            }
            if (last.Length%3==0)
            {
                for (int y = 0; y < last.Length; y++)
                {
                    if ( last.Length % 4 != 0)
                    {
                        alternatingrhyme = false;
                        windingrhyme = false;
                    }
                    else if (last.Length % 4 == 0)
                    {
                        if (y == 0 && (last[y] != last[y + 3] || last[y + 1] != last[y + 2] || last[y] == last[y + 2] || last[y + 1] == last[y + 3]))
                        {
                            windingrhyme = false;

                        }
                        if (y < last.Length - 1 && last[y] == last[y + 1])
                        {
                            straightryhme = true;
                            if (y < last.Length - 2 && last[y] == last[y + 2])
                            {
                                alternatingrhyme = false;
                            }


                        }

                        if (y< last.Length - 1 && last[y] != last[y + 1])
                        {
                            straightryhme = false;
                            if (y < last.Length - 2 && last[y] != last[y + 2])
                            {
                                alternatingrhyme = false;
                            }

                        }

                        if (y < last.Length - 1 && last[y] != last[y + 1])
                        {
                            straightryhme = false;
                            if (y< last.Length - 2 && last[y] == last[y + 2])
                            {
                                alternatingrhyme = true;
                            }

                        }
                    }
                    if ( y<last.Length-1  && last[y] != last[y + 1])
                    {
                        straightryhme = false;
                    }
                    if (last.Length==3)
                    {
                        if (y==0 &&last[y]==last[y+2])
                        {
                            if (last[y] == last[y + 1] || last[y+1] == last[y + 2])
                            {
                                hoarseryhme = false;
                               
                            }
                        }
                        else if(y == 0 && last[y] != last[y + 2])
                        {
                            hoarseryhme = false;
                           
                        }
                    }
                    if (last.Length==6)
                    {
                        if (y==0 && last[y] == last[y + 2])
                        {
                            if (last[y+1] == last[y + 3] && last[y+3] == last[y + 5] && last[y + 1] == last[y + 5])
                            {
                                if (last[y ] == last[y + 1]|| last[y ] == last[y + 3]|| last[y ] == last[y + 5] || last[y + 2] == last[y + 1] || last[y + 2] == last[y + 3] || last[y + 2] == last[y + 5])
                                {
                                    hoarseryhme = false;
                                    
                                }
                            }
                            else if(last[y + 1] != last[y + 3] || last[y + 3] != last[y + 5] || last[y + 1] != last[y + 5])
                            {
                                hoarseryhme = false;
                               
                            }
                            else if (last[y + 4] == last[y]|| last[y + 4] == last[y + 1]|| last[y + 4] == last[y + 2]|| last[y + 4] == last[y + 3]|| last[y + 4] == last[y + 5])
                            {
                                   hoarseryhme = false;
                                   
                            }
                        }
                        else if (y == 0 && last[y] != last[y + 2])
                        {
                            hoarseryhme = false;
                           
                        }
                    }
                    if (last.Length==9)
                    {
                        if (y== 0&&last[y] == last[y + 2])
                        {
                            if (last[y + 1] == last[y + 3] && last[y + 3] == last[y + 5] && last[y + 1] == last[y + 5])
                            {
                                if (last[y+4]==last[y+6]&&last[y+4]==last[y+8])
                                {
                                    if (last[y]== last[y + 1]|| last[y ]== last[y + 3]|| last[y ]== last[y + 5])
                                    {
                                        hoarseryhme = false;
                                    }
                                    if (last[y ]==last[y + 4]|| last[y] == last[y + 6]| last[y] == last[y + 8])
                                    {
                                        hoarseryhme = false;
                                    }
                                    if (last[y+1]==  last[y + 4]|| last[y + 1] == last[y + 6]|| last[y + 1] == last[y + 8])
                                    {
                                        hoarseryhme = false;
                                    }
                                }
                            }
                            else if (last[y + 1] != last[y + 3] || last[y + 3] != last[y + 5] || last[y + 1] != last[y + 5])
                            {
                                hoarseryhme = false;
                            }
                            else if (last[y + 6] == last[y] || last[y + 6] == last[y + 1] || last[y + 6] == last[y + 2] || last[y + 6] == last[y + 3] || last[y + 6] == last[y + 4] || last[y + 6] == last[y + 5] || last[y + 6] == last[y + 7] || last[y + 6] == last[y + 8])
                            {
                                hoarseryhme = false;
                            }
                           
                        }
                        else if (y == 0 && last[y] != last[y + 2])
                        {
                            hoarseryhme = false;
                        }
                    }
                }
            }
            else if(last.Length%3!=0 &&last.Length%4!=0)
            {
                for (int z = 0; z < last.Length; z++)
                {
                    hoarseryhme = false;
                    alternatingrhyme = false;
                    windingrhyme = false;
                    if (z<last.Length-1 && last[z] != last[z+1])
                    {
                        straightryhme = false;
                    }
                }
            }
       
            
            int counter2;
            int counter3;
            counter2 = 0;
            counter3 = 0;
            for (int a = 0; a < last.Length; a++)
            {
               
                
                for (int b = 0; b < last.Length; b++)
                {
                    if (last[a] ==last[b])
                    {
                        counter2++;
                    }
                    else if(last[a]!= last[b])
                    {
                        counter3++;
                    }
                }
            }
          
            if (straightryhme ==true)
            {
                if (counter2==counter3)
                {
                    A =  last[0];
                    Console.WriteLine("A-" + A);
                    Console.WriteLine("Type=Straight Ryhme");
                }
                if (str.Length==2)
                {
                    A = last[0];
                    Console.WriteLine("A-" + A);
                    Console.WriteLine("Type=Straight Ryhme");
                }
                if (str.Length==3)
                {
                    A = last[0];
                    Console.WriteLine("A-" + A);
                    Console.WriteLine("Type=Straight Ryhme");
                }
                if (str.Length==4)
                {
                    A = last[2];
                    Console.WriteLine("A-"+A);
                    Console.WriteLine("Type=Straight Ryhme");
                }
               
                if (str.Length==8)
                {
                    A = last[2];
                    B = last[6];
                    Console.WriteLine("A-"+A);
                    Console.WriteLine("B-"+B);
                    Console.WriteLine("Type=Straight Ryhme");
                }
                if (str.Length==12)
                {
                    A= last[2];
                    B = last[6];
                    C = last[10];
                    Console.WriteLine("A-" + A);
                    Console.WriteLine("B-" + B);
                    Console.WriteLine("C-" + C);
                    Console.WriteLine("Type=Straight Ryhme");
                }
                if (str.Length==16)
                {
                    A = last[2];
                    B = last[6];
                    C = last[10];
                    D = last[14];
                    Console.WriteLine("A-" + A);
                    Console.WriteLine("B-" + B);
                    Console.WriteLine("C-" + C);
                    Console.WriteLine("D-" + D);
                    Console.WriteLine("Type=Straight Ryhme");

                }
            }
            else if (alternatingrhyme==true)
            {
                if (str.Length==4)
                {
                    A = last[0];
                    B = last[1];
                    Console.WriteLine("A-" + A);
                    Console.WriteLine("B-" + B);
                    Console.WriteLine("Type=Alternating Ryhme");
                }
                if (str.Length==8)
                {
                    A = last[0];
                    B = last[1];
                    C = last[4];
                    D = last[5];
                    Console.WriteLine("A-" + A);
                    Console.WriteLine("B-" + B);
                    Console.WriteLine("C-" + C);
                    Console.WriteLine("D-" + D);
                    Console.WriteLine("Type=Alternating Ryhme");
                }
            }
            else if (windingrhyme==true)
            {
                if (str.Length == 4)
                {
                    A = last[0];
                    B = last[1];                    
                    Console.WriteLine("A-" + A);
                    Console.WriteLine("B-" + B);                  
                    Console.WriteLine("Type=Winding Ryhme");
                }
                if (str.Length == 8)
                {
                    A = last[0];
                    B = last[1];
                    C = last[4];
                    D = last[5];
                    Console.WriteLine("A-" + A);
                    Console.WriteLine("B-" + B);
                    Console.WriteLine("C-" + C);
                    Console.WriteLine("D-" + D);
                    Console.WriteLine("Type=Winding Ryhme");
                }
            }
            else if(hoarseryhme==true)
            {
                if (str.Length==3)
                {
                    A = last[0];
                    B = last[1];
                    Console.WriteLine("A-" + A);
                    Console.WriteLine("B-" + B);
                    Console.WriteLine("Type=Hoarse Ryhme");

                }
                if (str.Length==6)
                {
                    A = last[0];
                    B = last[1];
                    C = last[4];
                    Console.WriteLine("A-" + A);
                    Console.WriteLine("B-" + B);
                    Console.WriteLine("C-" + C);
                    Console.WriteLine("Type=Hoarse Ryhme");
                }
                if (str.Length==9)
                {
                    A = last[0];
                    B = last[1];
                    C = last[4];
                    D = last[5];
                    Console.WriteLine("A-" + A);
                    Console.WriteLine("B-" + B);
                    Console.WriteLine("C-" + C);
                    Console.WriteLine("D-" + D);
                    Console.WriteLine("Type=Hoarse Ryhme");
                }
            }
            else if (straightryhme==false&&alternatingrhyme==false&&windingrhyme==false&&hoarseryhme==false)
            {
                Console.WriteLine("This poem has no rhyme.");
            }
            Console.ReadKey();








        }

    }
}