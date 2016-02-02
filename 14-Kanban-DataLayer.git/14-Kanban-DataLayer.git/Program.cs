using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace _14_Kanban_DataLayer.git
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Do you want to display the updated table? press Y for yes");
                    var Y = Console.ReadLine();
                    while (Y == "Y")
                    {
                        Y = null;
                        using (var db = new FilmsEntities())
                        {
                            foreach (var l in db.Lists)
                            {
                                var list = l;
                                Console.WriteLine(list.Name);
                                foreach (var card in list.Cards)
                                {
                                    Console.WriteLine("\t" + "\t" + "\t" + "\t" + card.Text);
                                }
                            }
                            Console.WriteLine("If you want to add a list press 1, or press 2 if you want to add card, press 3 to delete a list or 4 to delete a card");
                            try
                            {
                                int AddListorCard = int.Parse(Console.ReadLine());
                                switch (AddListorCard)
                                {
                                    case 1:
                                        {
                                            try
                                            {
                                                Console.WriteLine("Enter a new list name");
                                                String listName = null;
                                                listName = Console.ReadLine();
                                                var lists = db.Set<List>();
                                                lists.Add(new List { ListId = 0, Name = listName, CreatedDate = DateTime.Now });
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine("you have entered an invalid value" + ex.Message);
                                            }
                                        }
                                        break;
                                    case 2:
                                        try
                                        {
                                            Console.WriteLine("Selelet one of the following List IDs");
                                            foreach (var l in db.Lists)
                                            {
                                                Console.WriteLine(l.ListId + "-" + l.Name);
                                            }
                                            int listId2 = 0;
                                            listId2 = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Enter a new card text");
                                            string cardtext = null;
                                            cardtext = Console.ReadLine();
                                            var cards = db.Set<Card>();
                                            cards.Add(new Card { ListID = listId2, Text = cardtext, CreatDate = DateTime.Now });
                                        }
                                        catch (Exception ex2)
                                        {
                                            Console.WriteLine("you have entered an invalid value" + ex2.Message);
                                        }
                                        break;
                                    case 3:

                                        Console.WriteLine("Enter the list name which you want to delete or type all, You can't delete a list that has cards try to delete its cards first, press e to exit");
                                        var Tname = Console.ReadLine();
                                        if (Tname == "e") break;
                                        foreach (var l in db.Lists)
                                        {
                                            var list = l;
                                            if ((Tname == "All") || (Tname == list.Name))
                                            {
                                                db.Entry(list).State = EntityState.Deleted;
                                            }
                                        }
                                        break;
                                    case 4:

                                        Console.WriteLine("Enter the card name which you want to delete or type all");
                                        var Cname = Console.ReadLine();
                                        foreach (var cc in db.Cards)
                                        {
                                            var card = cc;
                                            if ((Cname == "All") || (Cname == card.Text))
                                            {
                                                db.Entry(card).State = EntityState.Deleted;
                                            }
                                        }
                                        break;
                                }
                            }

                            catch (Exception ex3)
                            {
                                Console.WriteLine("you have entered an invalid value" + ex3.Message);
                            }
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex4)
            {
                Console.WriteLine("you have entered an invalid value" + ex4.Message);
            }

        }
    }
}
        
    

    

