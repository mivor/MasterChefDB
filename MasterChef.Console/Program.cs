using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterChefDb;
using System.Data.Entity;

namespace MasterChef.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MasterChefDataContext())
            {
                Database.SetInitializer(new MasterChefInitializer());

                var chef_A = new Chef { Name = "Ramsy", Specializare = "Marine", Stele = 5 };
                context.Persoane.Add(chef_A);
                context.SaveChanges();
                var echipa_A = new Echipa("Hey!");
                echipa_A.AddConcurent(chef_A);
                echipa_A.AddConcurent(new Concurent { Name = "Jhon" });
                echipa_A.AddConcurent(new Concurent { Name = "Maria" });
                echipa_A.AddConcurent(new Concurent { Name = "Lyv" });

                var echipa_B = new Echipa("Loosers");

                var jurat_1 = new Jurat { Name = "Bors", Nivel = 3 };

                context.Echipe.AddRange(new[] { echipa_A, echipa_B });
                context.Persoane.Add(jurat_1);

                context.SaveChanges();
            }

            using (var context = new MasterChefDataContext())
            {
                var jurat_2 = new Jurat { Name = "Bors", Nivel = 3 };
                var jurat_4 = new Jurat { Name = "Evil", Nivel = 6 };
                var jurat_3 = new Jurat { Name = "judge", Nivel = 2 };

                var echipaB = context.Echipe.Single(e => e.Nume == "Loosers");
                var chef_loose = new Chef { Name = "Rookie", Stele = 1, Specializare = "iarut" };
                echipaB.AddConcurent(chef_loose);
                echipaB.AddConcurent(new Concurent {Name = "Bob"});
                echipaB.AddConcurent(new Concurent {Name = "AAA"});
                echipaB.AddConcurent(new Concurent {Name = "CCC"});
                echipaB.AddConcurent(new Concurent {Name = "X"});
                echipaB.AddConcurent(new Concurent { Name = "Y" });

                context.Persoane.AddRange(new[] { jurat_2, jurat_3, jurat_4 });

                context.SaveChanges();
            }

            using (var context = new MasterChefDataContext())
            {
                var evilJudge = context.Persoane.OfType<Jurat>().Single( j => j.Name == "Evil");
                var echipaB = context.Echipe.Single(e => e.Nume == "Loosers");
                echipaB.AddEvaluare(evilJudge, 0);

                context.SaveChanges();

                foreach (var judge in context.Persoane.OfType<Jurat>())
                {
                    foreach (var echipa in context.Echipe)
                    {
                        judge.Evalueaza(echipa);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
