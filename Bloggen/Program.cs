using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bloggen
{
    internal class Program
    {
        //Input - Sökord, elementet vi jämför med, first, last
        //OutPut - Svar huruvida sökordet och elementet överensstämmer.
        static string BinarySearch(string key, string element, int last, int first)
        {
            //Metoden utgår ifrån att elementet inte finns, så när den
            //och hittar en matchning, ändras meddelandet från
            //att vi inte hittade sökordet, till att sökordet finns.
            string message = "Sökordet finns inte";
            int mid = first + last / 2;
            if (key.CompareTo(element) == -1)
            {
                last = last - mid;
            }
            else if (key.CompareTo(element) == 1)
            {
                first = first + mid;
            }
            else
            {
                message = "finns på plats ";
            }
            return message;
        }

        //Input - sökord, listans läng, elementet vi jämför med
        //OutPut - Svar huruvida sökordet och elementet överensstämmer.
        static string LinearSearch(string key, int length, string element)
        {
            string message = "";
            for (int i = 0; i < length; i++)
            {
                //OM sökningen matchar en titel i inlägget
                //Skrivs det ut att inlägget finns på plats X.
                if (key.ToUpper() == element.ToUpper())
                {
                    message = "Inlägget finns på plats ";
                    break;
                }
                //ANNARS skrivs det ut att motsvarande titel inte finns 
                else
                {
                    message = "";
                    break;
                }
            }
            return message;
        }

        //Metod för att återvända till menyn.
        static void ReturnToMenu()
        {
            Console.WriteLine("\tTryck ENTER för att återvända till menyn.");
            Console.ReadLine();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            //Skapa listor
            List<string[]> blogginlägg = new List<string[]>();

            //Skapa bool som kollar om listan är sorterad
            bool sortTitle = false;
            bool sortInput = false;
            bool sortDate = false;

            //Skapa meny (kontrollerad av bool)
            bool menu = true;

            while (menu)
            {
                //Skriv ut menyn.
                Console.WriteLine("\n\tVälkommen till bloggen! Vad vill du göra?"
                    + "\n\t1) Skriva ett inlägg" +
                    "\n\t2) Skriv ut alla inlägg" +
                    "\n\t3) Radera ett inlägg" +
                    "\n\t4) Sortera inlägg" +
                    "\n\t5) Linjär sökning" +
                    "\n\t6) Binär sökning" +
                    "\n\t7) Avsluta programmet");
                Console.Write("\tAnge svar här: ");
                /*Invänta menysvar.
                Det finns en risk att användaren
                Skriver fel. Därför måste vi felsöka koden så
                att användaren inte får programmet att krascha.*/
                Int32.TryParse(Console.ReadLine(), out int svar);

                switch (svar)
                {
                    //Val 1 - Nytt inlägg
                    case 1:
                        //Rensa konsolfönstret
                        Console.Clear();
                        string[] post = new string[3];
                        //Be användaren mata in en titel.
                        Console.Write("Ange titel: ");
                        //Lägg strängen i titel-vektorn
                        string title = Console.ReadLine();
                        post[0] = title;

                        //Be användaren skriva lite text.
                        Console.Write("Ange innehåll: ");
                        //Lägg strängen i inläggs-vektorn
                        string text = Console.ReadLine();
                        post[1] = text;

                        //Spara datumet inlägget skapades
                        DateTime present = DateTime.Now;
                        //Konvertera datum till string
                        string present2 = present.ToShortDateString();
                        //Lägg datumet i datum-vektorn
                        post[2] = present2;

                        //Lägg vektorn i blogginläggs-listan
                        blogginlägg.Add(post);
                        Console.Clear();
                        break;
                    //--------------------------------

                    //Val 2 - Skriv ut alla inlägg
                    case 2:
                        Console.Clear();
                        /*Struktur = lista med sträng[].
                        Strängvektorn har 3 element.
                        FOREACH är snabbare då man bara behöver
                        tänka på strängvektorn.*/

                        /*OM listan är tom, skriv att
                        vi inte har några inlägg och be
                        användaren att lägga till några.*/
                        if (blogginlägg.Count <= 0)
                        {
                            Console.WriteLine("\n\tDet finns inga inlägg" +
                               "\n\tVar god skriv till några.");
                        }
                        //ANNARS skriver vi ut titel, innehåll 
                        //och datum i konsollen.
                        else
                        {
                            foreach (string[] blogg in blogginlägg)
                            {
                                Console.WriteLine("\n\tTitel: " + blogg[0]);
                                Console.WriteLine("\tInnehåll: " + blogg[1]);
                                Console.WriteLine("\tSkrivet: " + blogg[2]);
                                Console.WriteLine("\t----------");
                            }
                        }
                        ReturnToMenu();
                        break;
                    //-----------------------------------------------------------------------------------------------

                    //Val 3 - Radering av inlägg
                    case 3:
                        Console.Clear();
                        //Kolla om det finns några inlägg
                        bool testA = true;

                        if (blogginlägg.Count() > 0)
                        {
                            //OM det finns några inlägg
                            //får användaren ange ett index.
                            while (testA == true)
                            {
                                Console.Write("\n\tDu vill radera ett inlägg." +
                                 "\n\tAnge inläggets platsnummer: ");

                                /*Det finns en risk för att man anger ett index
                                som är för högt, eller en bokstav. Därför
                                används TryParse som en bool likväl som
                                felhantering för inmatning.*/

                                bool A = Int32.TryParse(Console.ReadLine(), out int index);
                                if (A == true && index <= blogginlägg.Count())
                                {
                                    //Skriv ut elementet som finns på indexplats
                                    //användartal-1. Anledningen till detta är för 
                                    //att listan börjar på 0, men människan
                                    //räknar från 1. På det här sättet blir det
                                    //lättare för användaren att söka efter ett inlägg
                                    //som den vill ta bort.
                                    Console.WriteLine("\n\tBlogginlägg " + index + " ser ut såhär:" +
                                        "\n\t---------------------------------------------------");
                                    Console.WriteLine("\tTitel: " + blogginlägg[index - 1][0]);
                                    Console.WriteLine("\tInnehåll: " + blogginlägg[index - 1][1]);
                                    Console.WriteLine("\tSkrivet: " + blogginlägg[index - 1][2]);
                                    Console.WriteLine("\t---------------------------------------------------");
                                    string answerS = "";
                                    //Dubelkolla att användaren vill radera
                                    //inlägget.
                                    while (answerS != "J" && answerS != "j" && answerS != "N" && answerS != "n")
                                    {
                                        Console.Write("\tÖnskar du ta bort detta inlägg? J/N: ");
                                        answerS = Console.ReadLine();
                                        //Om användaren skriver "j"/"J", 
                                        //Tas inlägget bord och instruktioner
                                        //för att återvända till menyn skrivs ut.
                                        if (answerS == "J" || answerS == "j")
                                        {
                                            blogginlägg.RemoveAt(index - 1);
                                            Console.WriteLine("\tInlägget har tagits bort.");
                                            ReturnToMenu();
                                            testA = false;
                                            break;
                                        }
                                        /*ANNARS OM användaren skriver "N" eller "n",
                                        Tas inlägget inte bort. Raderingsfunktionen 
                                        Avslutas.*/
                                        else if (answerS == "N" || answerS == "n")
                                        {
                                            Console.Clear();
                                            testA = false;
                                            break;
                                        }
                                        /*ANNARS om användaren anger något annat,
                                        får dem ett felmeddelande som säger
                                        åt dem att ange rätt svar*/
                                        else
                                        {
                                            Console.WriteLine("\tVar god ange antingen J/N: ");
                                            continue;
                                        }
                                    }
                                }
                                /*Om användaren anger ett
                                inkorrekt index, 
                                Skrivs ett felmiddelande ut*/
                                else
                                {
                                    Console.WriteLine("\n\tVar god ange ett korrekt index.");
                                }
                            }
                        }
                        /*Om det inte finns några inlägg,
                        //ombeds användaren att lägga till några.*/
                        else
                        {
                            Console.WriteLine("\n\tDet finns inga inlägg." +
                                "\n\tVar god skriv till några.");
                            ReturnToMenu();
                            Console.Clear();
                            break;
                        }
                        Console.Clear();
                        break;
                    //-----------------------------------------------------------------------------------------------

                    //Val 4 - Sortering
                    case 4:
                        Console.Clear();
                        //Datorn kollar först om det finns några inlägg.
                        bool runing = true;
                        while (runing)
                        {
                            if (blogginlägg.Count() > 0)
                            {
                                //Användaren presenteras
                                //för tre olika sätt att sortera 
                                //listan.
                                Console.WriteLine("\n\tHur vill du sortera?" +
                                           "\n\t1) Titel" +
                                           "\n\t2) Sökord" +
                                           "\n\t3) Datum");
                                Console.Write("\tSkriv in ditt svar: ");

                                //Inmatningen kontrolleras av TryParse
                                bool E = Int32.TryParse(Console.ReadLine(), out int answerA);

                                if (E == true && answerA < 4 && answerA > 0)
                                {
                                    switch (answerA)
                                    {
                                        //Sortera per titel.
                                        case 1:
                                            //Struktur - Blogginlägg[inlägg i][titel j]
                                            //För i antal element i listan.
                                            for (int i = 0; i < (blogginlägg.Count() - 1); i++)
                                            {
                                                //För inlägget i fråga.
                                                for (int j = 0; j < ((blogginlägg.Count() - 1) - i); j++)
                                                {
                                                    //blogginlägg[j][titel[0]]
                                                    if (blogginlägg[j][0].CompareTo(blogginlägg[j + 1][0]) == 1)
                                                    {
                                                        //Skapa tre temporära variabler
                                                        string tempTitle = blogginlägg[j][0];
                                                        string tempInput = blogginlägg[j][1];
                                                        string tempDate = blogginlägg[j][2];
                                                        //Lägg det minsta värdet i variablerna.

                                                        //Ändra så att det nuvarande indexet får värdet av det största talet
                                                        blogginlägg[j][0] = blogginlägg[j + 1][0];
                                                        blogginlägg[j][1] = blogginlägg[j + 1][1];
                                                        blogginlägg[j][2] = blogginlägg[j + 1][2];

                                                        //Flytta så att indexet under får värdena
                                                        //från dem temporära variablerna.
                                                        blogginlägg[j + 1][0] = tempTitle;
                                                        blogginlägg[j + 1][1] = tempInput;
                                                        blogginlägg[j + 1][2] = tempDate;
                                                    }
                                                }
                                            }
                                            Console.WriteLine("\n\tListan har sorterats");
                                            ReturnToMenu();
                                            sortTitle = true;
                                            sortDate = false;
                                            sortInput = false;
                                            runing = false;
                                            break;

                                        case 2:
                                            //Sortera per input.
                                            //Struktur - Blogginlägg[inlägg i][titel j]
                                            //För i antal element i listan.
                                            for (int i = 0; i < (blogginlägg.Count() - 1); i++)
                                            {
                                                //För inlägget i fråga
                                                for (int j = 0; j < ((blogginlägg.Count() - 1) - i); j++)
                                                {
                                                    //blogginlägg[j][input[1]]
                                                    if (blogginlägg[j][1].CompareTo(blogginlägg[j + 1][1]) == 1)
                                                    {//Skapa tre temporära variabler
                                                        string tempTitle = blogginlägg[j][0];
                                                        string tempInput = blogginlägg[j][1];
                                                        string tempDate = blogginlägg[j][2];
                                                        //Lägg det minsta värdet i variablerna.

                                                        //Ändra så att det nuvarande indexet får värdet av det största talet
                                                        blogginlägg[j][0] = blogginlägg[j + 1][0];
                                                        blogginlägg[j][1] = blogginlägg[j + 1][1];
                                                        blogginlägg[j][2] = blogginlägg[j + 1][2];

                                                        //Flytta så att indexet under får värdena
                                                        //från dem temporära variablerna.
                                                        blogginlägg[j + 1][0] = tempTitle;
                                                        blogginlägg[j + 1][1] = tempInput;
                                                        blogginlägg[j + 1][2] = tempDate;
                                                    }
                                                }
                                            }
                                            Console.WriteLine("\n\tListan har sorterats");
                                            ReturnToMenu();
                                            sortTitle = false;
                                            sortDate = false;
                                            sortInput = true;
                                            runing = false;
                                            break;

                                        case 3:
                                            //Sortera per datum.
                                            //Struktur - Blogginlägg[inlägg i][titel j]
                                            //För i antal element i listan.
                                            for (int i = 0; i < (blogginlägg.Count() - 1); i++)
                                            {
                                                //För inlägget i fråga (som har en titel)
                                                for (int j = 0; j < ((blogginlägg.Count() - 1) - i); j++)
                                                {
                                                    //blogginlägg[j][datum][2]]
                                                    if (blogginlägg[j][2].CompareTo(blogginlägg[j + 1][2]) == 1)
                                                    {
                                                        //Skapa tre temporära variabler
                                                        string tempTitle = blogginlägg[j][0];
                                                        string tempInput = blogginlägg[j][1];
                                                        string tempDate = blogginlägg[j][2];
                                                        /*Lägg det minsta värdet
                                                        i variablerna.*/

                                                        /*Ändra så att det nuvarande
                                                        indexet får värdet av det
                                                        största talet*/
                                                        blogginlägg[j][0] = blogginlägg[j + 1][0];
                                                        blogginlägg[j][1] = blogginlägg[j + 1][1];
                                                        blogginlägg[j][2] = blogginlägg[j + 1][2];

                                                        /*Flytta så att indexet under
                                                        får värdena från dem
                                                        temporära variablerna.*/
                                                        blogginlägg[j + 1][0] = tempTitle;
                                                        blogginlägg[j + 1][1] = tempInput;
                                                        blogginlägg[j + 1][2] = tempDate;
                                                    }
                                                }
                                            }
                                            Console.WriteLine("\n\tListan har sorterats");
                                            ReturnToMenu();
                                            sortTitle = false;
                                            sortDate = true;
                                            sortInput = false;
                                            runing = false;
                                            break;
                                    }
                                }
                                //Om användaren skriver fel, får den ett
                                //felmeddelande.
                                else
                                {
                                    Console.WriteLine("\n\tVar god ange en siffra mellan 1-3");
                                }
                            }
                            /*Om det inte finns några inlägg,
                            ombeds användaren lägga till några.*/
                            else
                            {
                                Console.WriteLine("\tDet finns inga inlägg." +
                                     "\n\tVar god skriv till några.");
                                ReturnToMenu();
                                Console.Clear();
                                break;
                            }

                        }
                        break;
                    //--------------------------------------------------------------

                    //Val 5 - Linjär sökning
                    case 5:
                        /*Linjär sökning går igenom ett element 
                        i taget och är bra för kortare listor.
                        
                        Då algoritmen troligvis kommer behöva kallas på ofta,
                        kan vi skapa en metod.*/

                        bool answerB = true;
                        Console.Clear();
                        /*Kolla i listan efter blogginlägg.
                        Om det finns blogginlägg, får
                        anändaren mata in en sökning*/
                        if (blogginlägg.Count() > 0)
                        {
                            while (answerB)
                            {
                                /*Användaren ombeds välja vad den
                                Vill söka på*/
                                Console.WriteLine("\n\tVad vill du söka efter?" +
                                                  "\n\t1) Titel" +
                                                  "\n\t2) Sökord" +
                                                  "\n\t3) Datum");
                                Console.Write("\tSkriv in ditt svar: ");

                                //Felsökning för val av sök-kategori.
                                Int32.TryParse(Console.ReadLine(), out int answer);

                                switch (answer)
                                {
                                    //Sök per titel
                                    case 1:
                                        //Användaren matar in en titel.
                                        Console.Write("\n\tAnge titel: ");
                                        string key = Console.ReadLine();
                                        string message = "";
                                        int place = 0;
                                        bool found = false;
                                        string message1 = "";
                                        string message2 = "";

                                        for (int i = 0; i < blogginlägg.Count(); i++)
                                        {
                                            /*Kalla på metoden LinearSearch,
                                            som tar in nyckelordet,
                                            längden på listan, samt
                                            elemntet på plats [i]*/
                                            message = LinearSearch(key, blogginlägg.Count(), blogginlägg[i][0]);
                                            /*LinearSearch returnerar ett meddelande
                                            som berättar om sökordet
                                            finns eller inte*/
                                            if (message == "")
                                            {
                                                /*Om vi får ett meddelande som 
                                                säger att sökordet inte finns, 
                                                finns två alternativ: 

                                                Alternativ A - Titeln finns 
                                                inte i listan.*/
                                                message1 = "\n\tMotsvarande titel saknas";
                                                /*Alternativ B - Titeln finns 
                                                i listan, men inte på det här 
                                                indexet. Då får vi köra ett 
                                                varv till, tills dess att vi 
                                                antinngen hittar elementet
                                                eller inte.*/
                                                continue;
                                            }
                                            /*Om vi hittar elementet
                                            sparar vi platsen som index
                                            och säger att vi hittat
                                            den genom att ändra våran
                                            bool till true. Sedan ändrar 
                                            vi meddelandet så att det säger 
                                            att vi hittat elementet.*/
                                            else
                                            {

                                                place = (i + 1);
                                                found = true;
                                                message2 = "\n\t" + message + " " + place;
                                                break;
                                            }
                                        }
                                        /*Baserat på om vi hittat elementet
                                        eller inte (found = true/false)
                                        Skriver vi ut ett passande meddelande*/
                                        if (found == true)
                                        {
                                            Console.WriteLine(message2);
                                        }
                                        else
                                        {
                                            Console.WriteLine(message1);
                                        }
                                        ReturnToMenu();
                                        answerB = false;
                                        break;

                                    //Sök per sökord i inlägg
                                    case 2:
                                        Console.Write("\n\tAnge sökord: ");
                                        key = Console.ReadLine();
                                        message = "";
                                        found = false;
                                        message1 = "";
                                        message2 = "";
                                        for (int i = 0; i < blogginlägg.Count(); i++)
                                        {//Kalla på metoden LinearSearch,
                                            //som tar in nyckelordet,
                                            //längden på listan, samt
                                            //elemntet på plats [i]
                                            message = LinearSearch(key, blogginlägg.Count(), blogginlägg[i][1]);
                                            //LinearSearch returnerar
                                            //ett meddelande som berättar
                                            //om sökordet finns eller inte
                                            if (message == "")
                                            {
                                                /*Om vi får ett meddelande som 
                                                säger att sökordet inte finns, 
                                                finns två alternativ: 

                                                Alternativ A - Titeln finns 
                                                inte i listan.*/
                                                message1 = "\n\tMotsvarande titel saknas";
                                                /*Alternativ B - Titeln finns 
                                                i listan, men inte på det här 
                                                indexet. Då får vi köra ett 
                                                varv till, tills dess att vi 
                                                antinngen hittar elementet
                                                eller inte.*/
                                                continue;
                                            }

                                            /*Om vi hittar elementet
                                            sparar vi platsen som index
                                            och säger att vi hittat
                                            den genom att ändra våran
                                            bool till true. Sedan ändrar vi
                                            meddelandet så att det säger 
                                            att vi hittat elementet.*/
                                            else
                                            {

                                                place = (i + 1);
                                                found = true;
                                                message2 = "\n\t" + message + " " + place;
                                                break;
                                            }
                                        }
                                        /*Baserat på om vi hittat elementet
                                        eller inte (found = true/false)
                                        Skriver vi ut ett passande meddelande*/
                                        if (found == true)
                                        {
                                            Console.WriteLine(message2);
                                        }
                                        else
                                        {
                                            Console.WriteLine(message1);
                                        }
                                        ReturnToMenu();
                                        answerB = false;
                                        break;

                                    //Sök per datum
                                    case 3:
                                        Console.Write("\n\tAnge datum (ÅÅÅÅ-MM-DD): ");
                                        key = Console.ReadLine();
                                        message = "";
                                        found = false;
                                        message1 = "";
                                        message2 = "";
                                        for (int i = 0; i < blogginlägg.Count(); i++)
                                        {
                                            message = LinearSearch(key, blogginlägg.Count(), blogginlägg[i][2]);
                                            if (message == "")
                                            { /*Om vi får ett meddelande som 
                                                säger att sökordet inte finns, 
                                                finns två alternativ: 

                                                Alternativ A - Titeln finns 
                                                inte i listan.*/
                                                message1 = "\n\tMotsvarande datum saknas";
                                                /*Alternativ B - Titeln finns 
                                                i listan, men inte på det här 
                                                indexet. Då får vi köra ett 
                                                varv till, tills dess att vi 
                                                antinngen hittar elementet
                                                eller inte.*/
                                                continue;
                                            }
                                            else
                                            {
                                                place = (i + 1);
                                                found = true;
                                                message2 = "\n\t" + message + " " + place;
                                                break;
                                            }
                                        }
                                        /*Baserat på om vi hittat elementet
                                        eller inte (found = true/false)
                                        Skriver vi ut ett passande meddelande*/
                                        if (found == true)
                                        {
                                            Console.WriteLine(message2);
                                        }
                                        else
                                        {
                                            Console.WriteLine(message1);
                                        }
                                        ReturnToMenu();
                                        answerB = false;
                                        break;
                                    /*OM användaren skriver fel får 
                                    den ett felmeddelande*/
                                    default:
                                        Console.WriteLine("\n\tAnge ett tal mellan 1-3.");
                                        break;
                                }
                            }
                        }
                        /*Om det inte finns några inlägg, ombeds användaren
                        att lägga till några*/
                        else
                        {
                            Console.WriteLine("\n\tDet finns inga inlägg." +
                                "\n\tVar god skriv till några.");
                            ReturnToMenu();
                        }
                        answerB = false;
                        break;
                    //----------------------------------------------------------------------------

                    //Val 6 - binär sökning
                    case 6:
                        bool answerC = true;
                        Console.Clear();
                        //Kolla så att det finns inlägg
                        if (blogginlägg.Count() > 0)
                        {
                            while (answerC)
                            {
                                //Presentera alternativ.
                                Console.WriteLine("\n\tVad vill du söka efter?" +
                                    "\n\t1) Titel" +
                                    "\n\t2) Sökord" +
                                    "\n\t3) Datum");
                                Console.Write("\tSkriv in ditt svar: ");
                                //Kolla så att användaren matar in rätt värde
                                bool T = Int32.TryParse(Console.ReadLine(), out int answerD);
                                if (T)
                                {
                                    switch (answerD)
                                    {
                                        case 1:
                                            if (sortTitle == true)
                                            {
                                                //Användaren matar in en titel
                                                Console.Write("\n\tAnge titel: ");
                                                string key = Console.ReadLine();
                                                int last = (blogginlägg.Count() - 1);
                                                int first = 0;
                                                int mid = first + last / 2;
                                                string message = "";
                                                int i = 0;
                                                for (i = 0; i < blogginlägg.Count(); i++)
                                                {
                                                    /*Kalla på BinarySearch
                                                    och ange sökord, element
                                                    first och last*/
                                                    message = BinarySearch(key, blogginlägg[i][0], last, first);
                                                    /*BinarySearch returnerar
                                                    ett meddelande som
                                                    analyseras*/
                                                    if (message != "Sökordet finns inte")
                                                    {
                                                        break;
                                                    }
                                                }
                                                if (message == "Sökordet finns inte")
                                                {
                                                    Console.WriteLine("\n\tMotsvarande titel saknas");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n\tTiteln " + message + "" + (i + 1));
                                                }
                                                ReturnToMenu();
                                                answerC = false;
                                            }
                                            /*Om listan inte är sorterad, ber 
                                            datorn att anvädnaren sorterar
                                            listan på rätt sätt.*/
                                            else
                                            {
                                                Console.WriteLine("\n\tVar god sortera enligt titel.");
                                                ReturnToMenu();
                                                answerC = false;
                                            }
                                            break;

                                        case 2:
                                            if (sortInput == true)
                                            {
                                                Console.Write("\n\tAnge sökord: ");
                                                string key = Console.ReadLine();
                                                int last = (blogginlägg.Count() - 1);
                                                int first = 0;
                                                int mid = first + last / 2;
                                                string message = "";
                                                int i = 0;
                                                for (i = 0; i < blogginlägg.Count(); i++)
                                                {
                                                    /*Kalla på BinarySearch
                                                    //och ange sökord, element
                                                    //first och last*/
                                                    message = BinarySearch(key, blogginlägg[i][1], last, first);
                                                    /*BinarySearch returnerar
                                                    ett meddelande som
                                                    analyseras*/
                                                    if (message != "Sökordet finns inte")
                                                    {
                                                        break;
                                                    }
                                                }
                                                if (message == "Sökordet finns inte")
                                                {
                                                    Console.WriteLine("\n\tMotsvarande sökord saknas");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n\tTiteln " + message + "" + (i + 1));
                                                }
                                                ReturnToMenu();
                                                answerC = false;
                                            }
                                            /*Om listan är felsorterad,
                                            berättar datorn hur användaren
                                            ska sortera för att algoritmen
                                            ska fungera.*/
                                            else
                                            {
                                                Console.WriteLine("\n\tVar god sortera per innehåll.");
                                                ReturnToMenu();
                                                answerC = false;
                                            }
                                            break;

                                        case 3:
                                            if (sortDate == true)
                                            {
                                                Console.Write("\n\tAnge datum (ÅÅÅÅ-MM-DD): ");
                                                string key = Console.ReadLine();
                                                int last = (blogginlägg.Count() - 1);
                                                int first = 0;
                                                int mid = first + last / 2;
                                                string message = "";
                                                int i = 0;
                                                for (i = 0; i < blogginlägg.Count(); i++)
                                                {
                                                    /*Kalla på BinarySearch
                                                    och ange sökord, element
                                                    first och last*/
                                                    message = BinarySearch(key, blogginlägg[i][2], last, first);
                                                    /*BinarySearch returnerar
                                                    ett meddelande som
                                                    analyseras*/
                                                    if (message != "Sökordet finns inte")
                                                    {
                                                        break;
                                                    }
                                                }
                                                if (message == "Sökordet finns inte")
                                                {
                                                    Console.WriteLine("\n\tMotsvarande datum finns inte");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n\tDatumet " + message + "" + (i + 1));
                                                }
                                                ReturnToMenu();
                                            }
                                            /*Om listan är felsorterad
                                            ombeds användaren att sortera 
                                            listan på rätt sätt.*/
                                            else
                                            {
                                                Console.WriteLine("\n\tVar god sortera listan per datum.");
                                                ReturnToMenu();
                                            }
                                            answerC = false;
                                            break;
                                    }
                                }
                                /*Om användaren skriver fel, får den
                                ett felmeddelande*/
                                else
                                {
                                    Console.WriteLine("\n\tVar god ange en siffra mellan 1-3");
                                }
                            }
                        }
                        //Om det inte finns några inlägg ska vi meddela
                        //detta så att användaren kan lägga till några.
                        else
                        {
                            Console.WriteLine("\n\tDet finns inga inlägg." +
                                "\n\tVar god skriv till några.");
                            ReturnToMenu();
                        }
                        break;
                    //----------------------------------------------------------------------------
                    //Val 7 - Avsluta
                    //Förslagsvis en bool som sätts till falsk.
                    case 7:
                        menu = false;
                        break;
                    //----------------------------------------------------------------------------

                    //Felhantering av felaktig inmatning:
                    default:
                        Console.WriteLine("\n\tVar god ange ett tal mellan 1-7.");
                        break;
                }
            }
        }
    }
}



