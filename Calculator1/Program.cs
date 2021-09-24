using System;

namespace Calculator1
{
    class Program
    {
        static void Main(string[] args)
        {

            double total = 0;
            string lastOp = "";
            string totText = total.ToString();

            while (true)
            {
                CalcMenu(totText, lastOp);

                string inPut = Console.ReadLine();

                if (inPut.Length == 0) // If user just presses enter
                {
                    if (lastOp.Length == 0) //And without prior operations
                        continue; 
                    
                    inPut = lastOp; //reuses the last operation
                }

                int operType = 0;
                int operPos = 0;
                
                operType = FindOp(inPut, out operPos); // Finds + - * / C and E


                if(operPos == -1) // || operPos == (inPut.Length-1))
                {
                    double.TryParse(inPut, out total);
                    lastOp = total.ToString();
                    totText = lastOp;
                    continue;
                }

                double inTot = total;
                switch(operType)
                {
                    case 0: //mul
                        Mul(inPut, operPos, inTot, out total) ;
                        Console.WriteLine(total);
                        Console.ReadKey();

                        break;

                    case 1: // div
                        if(!Div(inPut, operPos, inTot, out total))
                        {
                            totText = "ERROR: DIVIDE BY ZERO";
                            lastOp = "";
                            total = 0;
                            continue;
                        }

                        break;

                    case 2: // add
                        Add(inPut, operPos, inTot, out total);
                   
                        break;

                    case 3: // sub
                        Sub(inPut, operPos, inTot, out total);

                        break;

                    case 4: // C
                    case 5:
                        total = 0;
                        lastOp = "";
                        totText = "";
                        continue;

                    default: //exit
                        return;
                }


                totText = total.ToString();
                lastOp = inPut;
                
            }

                     
        }


        static int FindOp(string text, out int indOp)
        {
            char[] alternativ = { '*', '/', '+', '-', 'C', 'c', 'E', 'e' };
            indOp = text.IndexOfAny(alternativ);
            if (indOp == -1)
                return indOp;

            for (int i = 0; i < 8; i++)
            {
                if (text[indOp] == alternativ[i])
                    return i;

            }

            return 7; // Exit, but should not happen
        }  
        
        static void CalcMenu(string menTot,string menOp)
        {
            Console.Clear();
            Console.WriteLine("Basic Calculator - E for exit");
            Console.WriteLine("Total: {0}", menTot);
            Console.WriteLine("Last operation: {0}", menOp);
            Console.Write("> ");

        }

        static void Mul(string inString, int mulPos, double inTot, out double mulTot)
        {
            //double num1 = 0;
            
            double num2 = 0;
            if (mulPos > 0)
                double.TryParse(inString.Substring(0, mulPos), out inTot);
            double.TryParse((inString.Substring(mulPos+1)), out num2);
            mulTot = inTot * num2;
            return;
        }

        static bool Div(string inString, int divPos, double inTot, out double divTot)
        {
            //double num1 = divTot;
            double num2 = 0;
            if (divPos > 0)
                double.TryParse(inString.Substring(0, divPos), out inTot);

            double.TryParse(inString.Substring(divPos+1), out num2);
            if (num2 == 0)
            {
                divTot = 0;
                return false;
            }
                

            divTot = inTot / num2;
            return true;
        }

        static void Add(string inString, int addPos, double inTot, out double addTot)
        {
            double num2 = 0;
            if (addPos > 0)
                double.TryParse(inString.Substring(0, addPos), out inTot);
            double.TryParse(inString.Substring(addPos+1), out num2);
            addTot = inTot + num2;
            return;
        }

        static void Sub(string inString, int subPos, double inTot, out double subTot)
        {
            double num2 = 0;
            if (subPos > 0)
                double.TryParse(inString.Substring(0, subPos), out inTot);
            double.TryParse(inString.Substring(subPos+1), out num2);
            subTot = inTot - num2;
            return;
        }






    }

    
}
