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
            int x = 0;
            while (x < 2)
            {
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
                    Console.WriteLine("If you want to add a list press 1, or press 2 if you want to add card, press 3 to delete the whole table");
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
                                        Console.WriteLine(l.ListId);
                                    }
                                    int listId2 = 0;
                                    listId2 = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Enter a new card text");
                                    string cardtext = null;
                                    cardtext = Console.ReadLine();

                                    var cards = db.Set<Card>();
                                    cards.Add(new Card { ListID = listId2, CardId = 0, Text = cardtext, CreatDate = DateTime.Now });

                                }
                                catch (Exception ex2)
                                {
                                    Console.WriteLine("you have entered an invalid value" + ex2.Message);
                                }
                                break;

                              case 3:
                                {
                                    try
                                    {
                                        foreach (var l in db.Lists)
                                        {
                                            var list = l;
                                            db.Entry(list).State = EntityState.Deleted;
                                        }

                                        foreach (var c in db.Cards)
                                        {
                                            var card = c;
                                            db.Entry(card).State = EntityState.Deleted;
                                        }

                                    }
                                    catch (Exception ex4)
                                    {
                                        Console.WriteLine("you have entered an invalid value" + ex4.Message);
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
                x++;
            }
        }
    }
}
    

