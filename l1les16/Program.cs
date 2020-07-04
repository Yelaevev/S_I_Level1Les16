using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static string[] ShopOLAP(int N, string[] items)
        {
            string[] ItemName = new string[items.Length];
            string[] ItemMount = new string[items.Length];
            int[] IntMount = new int[items.Length];
            string[] Not = { "initial conditions is not correct" };

            foreach (string t in items)
            {
                if (t == null) return Not;

            }

            if(N!=items.Length) return Not;

           if (N < 0) return Not;

            // string PartName = "!";
            for (int i = 0; i < items.Length; i++)
            {
                string[] part = items[i].Split(' ');
               // PartName = PartName.Insert(PartName.Length, part[0] + " ");
                ItemName[i] = part[0];
                ItemMount[i] = part[1];
                IntMount[i] = Convert.ToInt32(part[1]);

            }

            // Console.WriteLine(ItemName[0][ItemName[0].Length-1]);

            bool NEned = false;
            char test = ItemMount[items.Length - 1][ItemMount[items.Length - 1].Length - 1];// проверяем есть в конце строки '\n'
            if (test == '\n') NEned = true;
            //Console.WriteLine(NEned+ " "+ test);

            bool NMiddle = false;
            char test1 = ItemMount[0][ItemMount[0].Length - 1];// проверяем есть в конце строки '\n'
            if (test1 == '\n') NMiddle = true;
           // Console.WriteLine(NMiddle + " " + test1);

            //Console.WriteLine("список названий");
            //foreach (string t in ItemName) Console.Write(t + "\t");
            //Console.WriteLine(" ");
            //Console.WriteLine("список значений");
            //foreach (int t in IntMount) Console.Write(t + "\t");
            //Console.WriteLine(" ");


            List<string> NewNameList = new List<string>();
            List<string> NewPriceList = new List<string>();
            List<int> NewMountList = new List<int>();
            int ListLength = 0;

            //PartName = PartName.Remove(0, 1);
            //foreach (string l in items) Console.Write(l);
            //Console.WriteLine(PartName);
            //Console.WriteLine(" ");
            for (int compare = 0; compare < ItemName.Length; compare++)
            {
                if (ItemName[compare] != null)
                {
                    for (int i = compare; i < ItemName.Length; i++)
                    {
                        if (compare != i)
                        {
                            if (ItemName[compare] == ItemName[i])
                            {
                                IntMount[compare] = IntMount[compare] + IntMount[i];
                                Array.Clear(ItemName, i, 1);
                                Array.Clear(ItemMount, i, 1);
                                Array.Clear(IntMount, i, 1);

                            }

                        }

                    }
                    NewNameList.Add(ItemName[compare]);
                    NewMountList.Add(IntMount[compare]);
                    //NewPriceList.Add(ItemMount[compare]);
                    ListLength++;

                }
            }
            Array.Resize(ref IntMount, ListLength);
            Array.Resize(ref ItemName, ListLength);
            Array.Clear(IntMount, 0, IntMount.Length);
            Array.Clear(ItemMount, 0, ItemMount.Length);

            //Console.WriteLine(" ");
            //Console.WriteLine("список названий после объединения");
            //foreach (string t in NewNameList) Console.Write(t + "\t");
            //Console.WriteLine(" ");

            //foreach (int t in NewMountList) Console.Write(t + "\t");
            //Console.WriteLine(" ");
            //Console.WriteLine("список значений после объединения");
            //Console.WriteLine("новый размер списка= " + ListLength);


            for (int i = 0; i < ListLength; i++)
            {
                for (int j = 0; j < ListLength; j++)
                {
                    if (NewMountList[i] > NewMountList[j])
                    {
                        //int CompareMount = NewMountList[i];
                        //NewMountList[i] = NewMountList[j];
                        //NewMountList[j] = CompareMount;
                        //string CompareName = NewNameList[i];
                        //NewNameList[i] = NewNameList[j];
                        //NewNameList[j] = CompareName;
                        int CompareMount = NewMountList[j];
                        NewMountList[j] = NewMountList[i];
                        NewMountList[i] = CompareMount;
                        string CompareName = NewNameList[j];
                        NewNameList[j] = NewNameList[i];
                        NewNameList[i] = CompareName;
                    }

                    if (NewMountList[i] == NewMountList[j])
                    {
                        if (NewNameList[i].Length >= NewNameList[j].Length)
                        {

                            // string EqSmallName = NewNameList[i];
                            //// Console.WriteLine(EqSmallName + "=name of equals ");
                            // NewNameList[i] = NewNameList[j];
                            // NewNameList[j] = EqSmallName;
                            string EqSmallName = NewNameList[j];
                            // Console.WriteLine(EqSmallName + "=name of equals ");
                            NewNameList[j] = NewNameList[i];
                            NewNameList[i] = EqSmallName;
                        }

                    }

                }



            }

            //Console.WriteLine(" ");
            //Console.WriteLine("названия сортировка");
            //foreach (string t in NewNameList) Console.Write(t + "\t");
            //Console.WriteLine(" ");

            //foreach (int t in NewMountList) Console.Write(t + "\t");
            //Console.WriteLine(" ");
            //Console.WriteLine("значения сортировка");

            string[] NewMountArray = new string[ListLength];

            for (int i = 0; i < ListLength; i++)
            {
                NewNameList[i] = NewNameList[i].Insert(NewNameList[i].Length, " ");
            }
            //foreach (string t in NewNameList) Console.Write(t);
            for (int i = 0; i < ListLength; i++)
            {
                NewMountArray[i] = Convert.ToString(NewMountList[i]);
            }

            //foreach (string t in NewMountArray) Console.Write(t);
            //Console.WriteLine("");

            if (NMiddle)
            {
                for (int i = 0; i < ListLength - 1; i++)
                {
                    NewMountArray[i] = NewMountArray[i].Insert(NewMountArray[i].Length, "\n");
                }

            }

            // foreach (string t in NewMountArray) Console.Write(t);
            if (NEned) NewMountArray[ListLength - 1] = NewMountArray[ListLength - 1].Insert(NewMountArray[ListLength - 1].Length, "\n");

            //foreach (string t in NewMountArray) Console.Write(t);
            string[] rezult = new string[ListLength];
            for (int i = 0; i < ListLength; i++)
            {
                rezult[i] = "!";
                rezult[i] = rezult[i].Insert(rezult[i].Length, NewNameList[i]);
                rezult[i] = rezult[i].Insert(rezult[i].Length, NewMountArray[i]);
                rezult[i] = rezult[i].Remove(0, 1);


            }



            return rezult;
        }

        static void Main(string[] args)
        {
            //string[] items = { "пальто 12\n", "shuba 28\n", "платье1 5\n", "сумка32 4\n", "платье1 1\n", "сумка32 2\n", "сумка32 6\n" };
            //string[] items = { "платье1 5\n", "сумка32 2\n", "платье1 1\n", "сумка23 2\n", "сумка128 4\n" };
            string[] items = { "платье1 5\n"};
            foreach (string t in items) Console.Write(t);
            string[] rezult = ShopOLAP(1, items);

            Console.WriteLine(" ");
            foreach (string t in rezult) Console.Write(t);
        }

    }
}
