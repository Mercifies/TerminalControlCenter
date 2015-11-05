using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Control_Center
{
    class TermPing
    {
        

        string input = "";
        string address = ""; // 173.194.123.66
        long realTime = 0; // parse string to int for time in ms

        string[] domainEnd = {
            ".co", ".biz",".com",".jobs",".mobi",".travel",".net",".org",".pro",".tel",".info",".xxx",".name",".ac",".ag",".am",
            ".asia", ".at",".be",".bz",".cc",".cn",".cx",".de",".eu",".fm",".gs",".hn",".ht",".im",".in",".io",
            ".it", ".jp", ".ki", ".la", ".lc", ".me", ".mn", ".mx", ".nf", ".nl", ".sb", ".sc", ".se", ".sh", ".tl", ".tv", ".tw", 
            ".uk", ".us", ".vc", ".ws", ".gov", ".edu", ".mil", ".arpa", ".ad", ".ae", ".af", ".ag", ".ai", "al", ".an", ".ao", ".aq", 
            ".ar", ".as", ".au", ".aw", ".ax", ".az", ".ba", ".bb", ".bd", ".be", ".bf", ".bg", ".bh", ".bj", ".bm", ".bn", ".bo", ".bq", 
            ".br", ".bs", ".bt", ".bv", ".bw", ".by", ".ca", ".cc", ".cd", ".cf", ".cg", ".ch", ".ci", ".ck", ".cl", ".cm", ".cn", ".co", 
            ".cr", ".cs", ".cu", ".cv", ".cw", ".cx", ".cy", ".cz", ".dd", ".de", ".dj", ".dk", ".dm", ".do", ".dz", ".ec", ".ee", ".eg", ".eh", 
            ".er", ".es", ".et", ".fi", ".fj", ".fk", ".fo", ".fr", ".ga", ".gb", ".ge", ".gf", ".gg", ".gi", ".gl", ".gm", ".gn", ".gp", ".gq", 
            ".gr", ".gs", ".gt", ".gu", ".gw", ".gy", ".hk", ".hm", ".hn", ".hr", ".ht", ".hu", ".id", ".ie", ".il", ".im", ".in", ".iq", ".ir", ".is", ".it",
            ".je", ".jm", ".jo", ".jp", ".ke", ".kg", ".kh", ".ki", ".km", ".kn", ".kp", ".kr", ".kw", ".ky", ".kz", ".la", ".lb", ".lc", ".li", ".lk", ".lr", 
            ".ls", ".lt", ".lu", ".lv", ".ly", ".ma", ".mc", ".md", ".me", ".mg", ".mh", ".mk", ".ml", ".mm", ".mn", ".mo", ".mp", ".mq", ".mr", ".ms", 
            ".mt", ".mu", ".mv", ".mw", ".mx", ".my", ".mz", ".na", ".nc", ".ne", ".nf", ".ng", ".ni", ".nl", ".no", ".np", ".nr", ".nu", ".nz", ".om", 
            ".pa", ".pe", ".pf", ".pg", ".ph", ".pk", ".pl", ".pm", ".pm", ".pr", ".ps", ".pt", ".pw", ".py", ".qa", ".re", ".ro", ".rs", ".ru", ".rw", 
            ".sa", ".sb", ".sc", ".sd", ".se", ".sg", ".sh", ".si", ".sj", ".sk", ".sl", ".sm", ".sn", ".so", ".sr", ".ss", ".st", ".su", ".sv", ".sx", 
            ".sy", ".sz", ".tc", ".td", ".tf", ".tg", ".th", ".tj", ".tk", ".tl", ".tm", ".tn", ".to", ".tp", ".tr", ".tt", ".tv", ".tw", ".tz", ".ua", 
            ".ug", ".uk", ".us", ".uy", ".uz", ".va", ".vc", ".ve", ".vg", ".vi", ".vn", ".vu", ".wf", ".ws", ".ye", ".yt", ".yu", ".za", ".zm", ".zr", 
            ".zw", ".academy", ".accountant", ".accountants", ".active", ".actor", ".adult", ".aero", ".agency", ".airforce", ".apartments", ".app", 
            ".archi", ".army", ".associates", ".attorney", ".auction", ".audio", ".autos", ".band", ".bar", ".bargains", ".beer", ".best", ".bid", ".bike", 
            ".bingo", ".bio", ".biz", ".black", ".blackfriday", ".blog", ".blue", ".boo", ".boutique", ".build", ".builders", ".business", ".buzz", ".cab", 
            ".camera", ".camp", ".cancerreasearch", ".capital", ".cards", ".care", ".career", ".careers", ".cash", ".casino", ".catering", ".center", 
            ".ceo", ".channel", ".chat", ".cheap", ".christmas", ".church", ".city", ".claims", ".cleaning", ".click", ".clinic", ".clothing", ".club", 
            ".coach", ".codes", ".coffee", ".college", ".community", ".company", ".computer", ".condos", ".construction", ".consulting", ".contractors", 
            ".cooking", ".cool", ".country", ".coupons", ".credit", ".creditcard", ".cricket", ".cruises", ".dad", ".dance", ".date", ".dating", 
            ".day", ".deals",  ".degree", ".delivery", ".democrat", ".dental", ".dentist", ".design", ".diamonds", ".diet", ".digital", ".direct", 
            ".directory", ".discount", ".dog", ".domains", ".download", ".eat", ".education", ".email", ".energy", ".engineer", ".equipment", ".esq", 
            ".estate", ".events", ".exchange", ".expert", ".exposed", ".express", ".fail", ".faith", ".fans", ".farm", ".fashion", ".feedback", ".finance", 
            ".financial", ".fish", ".fishing", ".fit", ".flights", ".florist", ".flowers", ".fly", ".foo", ".forsale", ".foundation", 

        };

        public object Keys { get; private set; }

        public TermPing(string input)
        {
            this.input = input;
        }

        public void getPing()
        {
            


            if (input.Substring(4).Contains("-"))
            {
                address = input.Substring(5, input.LastIndexOf(' ') - 5); // ip address
                string time = input.Substring(input.IndexOf("-") + 1); // how many times to loop ping

                //if (Int32.TryParse(time, out realTime))
                //{
                //    realTime = Int32.Parse(time);
                //}

                if (long.TryParse(time, out realTime))
                {
                    realTime = long.Parse(time);
                }


            }
            else
            {
                address = input.Substring(5); // ip address
                realTime = 1;
            }


            bool dName = false;
            for (int i = 0; i < domainEnd.Length; i++)
            {
                if (address.Contains(domainEnd[i]))
                {
                    dName = true;
                    break;
                }
            }


            //bool inf = false;
            //if (input[input.Length].Equals('e'))
            //{
            //    inf = true;
            //}

            if (dName == true)
            {
                IPAddress[] ip = Dns.GetHostAddresses(address);
                Ping ping = new Ping();

                //if (inf == true)
                //{
                //    bool endless = false;
                //    int i = 0;


                //    while (!endless)
                //    {
                //        for (int j = 0; j < ip.Length; j++)
                //        {
                //            if (i < 1) // handles most packets
                //            {
                //                var reply = ping.Send(ip[j].ToString());
                //                Console.WriteLine("Reply from {0} | Status: {1} | Time: {2}ms | Packet: " + ((i + 1) + (j)),
                //                                  reply.Address,
                //                                  reply.Status,
                //                                  reply.RoundtripTime);

                //            }
                //            else // handles proper packet of (# of packets)
                //            {
                //                var reply = ping.Send(ip[j].ToString());
                //                Console.WriteLine("Reply from {0} | Status: {1} | Time: {2}ms | Packet: " + (((i * ip.Length) + 1) + (j)),
                //                                  reply.Address,
                //                                  reply.Status,
                //                                  reply.RoundtripTime);

                //            }

                //        }
                //    }

                //}


                for (int i = 0; i < realTime; ++i)
                {

                    for (int j = 0; j < ip.Length; j++)
                    {
                        if (i < 1) // handles most packets
                        {
                            var reply = ping.Send(ip[j].ToString());
                            Console.WriteLine("Reply from {0} | Status: {1} | Time: {2}ms | Packet: " + ((i + 1) + (j)) + " of " + (realTime * ip.Length),
                                              reply.Address,
                                              reply.Status,
                                              reply.RoundtripTime);
                            
                        }
                        else // handles proper packet of (# of packets)
                        {
                            var reply = ping.Send(ip[j].ToString());
                            Console.WriteLine("Reply from {0} | Status: {1} | Time: {2}ms | Packet: " + (((i * ip.Length) + 1) + (j)) + " of " + (realTime * ip.Length),
                                              reply.Address,
                                              reply.Status,
                                              reply.RoundtripTime);
                            
                        }
                        
                    }
                    if (Console.KeyAvailable)
                        if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                            break;

                }
                
            }

            else
            {
                IPAddress ip = IPAddress.Parse(address);
                Ping ping = new Ping();
                


                for (int i = 0; i < realTime; ++i)
                {
                    var reply = ping.Send(ip);
                    Console.WriteLine("Reply from {0} | Status: {1} | Time: {2}ms | Packet: " + (i + 1) + " of " + realTime,
                                      reply.Address,
                                      reply.Status,
                                      reply.RoundtripTime);
                    if (Console.KeyAvailable)
                        if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                            break;

                }


            }
            



            
        }


    }
}
