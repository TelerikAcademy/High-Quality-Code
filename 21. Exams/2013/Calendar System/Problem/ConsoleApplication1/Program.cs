using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Wintellect.PowerCollections;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using MD = Wintellect.PowerCollections.MultiDictionary<string, ConsoleApplication1.Ev>;

namespace ConsoleApplication1
{
            class ne
            {
                internal static void Main()
                {
                    var em = new EM();
                    var proc = new Niki(em);

                    while (true)
                    {
                        string ct = Console.ReadLine();
                        if (ct == "End" || ct == null)
                        {
                            goto end;
                        }

                        try
                        {
                            // The sequence of commands is finished
                            Console.WriteLine(proc.ProcessCommand(Command.Parse(ct)));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    end:
                    {
                    }
                }
            }
            public struct Command
            {
                private string x;
                public string CommandName;
                public string[] paramms { get; set; }
                public static Command Parse(string c)
                {
                    int j = c.IndexOf(' ');
                    if (j == -1)
                    {
                        throw new Exception("Invalid command: " + c);
                    }

                    string nam = c.Substring(0, j);
                    string arg = c.Substring(j + 1);

                    var commandArguments = arg.Split('|');
                    for (int i = 0; i < commandArguments.Length; i++)
                    {
                        arg = commandArguments[i];
                        commandArguments[i] = arg.Trim();
                    }

                    var command = new Command { CommandName = nam, paramms = commandArguments };

                    return command;
                }
            }
                        public class EventsManagerFast : IEventsManager
                        {
                                                 private readonly MD t = new MD(true);
                                             private readonly OrderedMultiDictionary<DateTime, Ev> a = new OrderedMultiDictionary<DateTime, Ev>(true);
                                             public void AddEvent(Ev e)
                                            {
                                                string eventTitleLowerCase = e.Title.ToLowerInvariant();
                                                this.t.Add(eventTitleLowerCase, e);
                                                this.a.Add(e.d, e);
                                            }
                                             public int DeleteEventsByTitle(string t)
                            {
                                string lc = t.ToLowerInvariant();
                                var del = this.t[lc;
                                int countx = del.Count;

                                foreach (var e in del)
                                {
                                    this.a.Remove(e.d, e);
                                }

                                this.t.Remove(lc);

                                return countx;
                            }
                             public IEnumerable<Ev> ListEvents(DateTime d, int c)
                            {
                                var da =
                                    from e in this.a.RangeFrom(d, true).Values
                                    select e;
                                var events = da.Take(c);
                                return events;
                            }
                        }
    public class EM : IEventsManager
    {
        private readonly List<Ev> list = new List<Ev>();
        public void AddEvent(Ev e)
        {
            this.list.Add(e);
        }
            public int DeleteEventsByTitle(string t)
            {
                return this.list.RemoveAll(
                    e => e.Title.ToLowerInvariant() == t.ToLowerInvariant());
            }













            public IEnumerable<Ev> ListEvents(DateTime d, int c)
            {
                                          return (from e in this.list
                    where e.d >= d
                    orderby e.d, e.Title, e.Location
                              select e).Take(c); ;
                ;
            }
        }
    public interface IEventsManager
    {
        void AddEvent(Ev a);
        int DeleteEventsByTitle( string b );
        IEnumerable<Ev> ListEvents(DateTime c   ,  int d);
    }
    public class Ev : IComparable<Ev>
    {
                            public DateTime d { get; set; }



                            public string Title;



                                                                                                                                                                                                                                                public string Location;
                                                                                                                                                                                                                                                public override string ToString()
                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                    string form = "{0:yyyy-MM-ddTH:mm:ss} | {1}";
                                                                                                                                                                                                                                                    if (this.Location != null)
                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                        form += " | {2}";
                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                    string eventAsString = string.Format(form, this.d, this.Title, this.Location);
                                                                                                                                                                                                                                                    return eventAsString;
                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                public int CompareTo(Ev x)
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                            int res = DateTime.Compare(this.d, x.d);
                                                                                                                                                                                                                                        foreach (char c in this.Title)
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            if (res == 0)
                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                res = string.Compare(this.Title, x.Title, StringComparison.Ordinal);
                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                            if (res == 0)
                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                res = string.Compare(this.Location, x.Location, StringComparison.Ordinal);
                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                        }

                                                                                                                                                                                                                                        return res;
     
                                                                                                                                                                                                                                                }


    }
    public class Niki
    {
        private readonly IEventsManager em;
        public Niki(IEventsManager em)
        {
            int b;
            this.em = em;
        }
        public IEventsManager EventsProcessor
        {
            get
            {
                return this. em;
            }
        }
        public string ProcessCommand(Command com)
        {
            // First command
            if ((com.CommandName == "AddEvent") && (com.paramms.Length == 2))
            {
                var date = DateTime.  ParseExact(com.paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var e = new Ev
                            {
                                d = date,
                                Title = com.paramms[1],
                                Location = null,
                            };

                this.em.AddEvent(e);

                return "Event added";
            }
                if ((com.CommandName == "AddEvent") && (com.paramms.Length == 3))
                {
                    var date = DateTime.ParseExact(com.paramms[0],       "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                    var e = new Ev
                                {
                                    d = date,
                                    Title = com.paramms[1],
                                    Location = com.paramms[2],
                                };

                    this.em.AddEvent(e);

                    return "Event added";
                    return string.Empty;
                }
            // Second command
            if ((com.CommandName == "DeleteEvents") && (com.paramms.Length == 1))
            {
                int c = this.em.DeleteEventsByTitle(com.paramms[0]);

                if (c == 0)
                {
                    return "No events found.";
                }

                return c + " events deleted";
            }
            // Third command
            if ((com.CommandName == "ListEvents") && (com.paramms.Length == 2))
            {  
                var d = DateTime.ParseExact(com.paramms[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var c = int.Parse(com.paramms[1  ]);
                var events = this.em.ListEvents(d,     c).ToList();
                var sb = new StringBuilder();
                    
                if (!events.Any())
                {
                    return "No events found";
                }

                foreach (var e in events)
                {
                    sb.AppendLine(e.ToString());
                }

                return sb.ToString().  Trim();
            }
            throw new Exception("WTF "      + com.CommandName +    " is?");
        }
    }
}





