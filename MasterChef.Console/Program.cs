using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterChefDb.Models;
using MasterChefDb;
using System.Data.Entity;
using MasterChef.DAL.Concrete;
using MasterChefDb.Business.Models;

namespace MasterChef.App
{
    class Program
    {
        static void Main(string[] args)
        {

            var map = new DbMapper();

            EchipaModel source = new EchipaModel();

            Echipa result = new Echipa();



            //using (var context = new MasterChefDataContext())
            //{
            //    //Database.SetInitializer(new MasterChefInitializer());

            //    var chef_A = new ChefModel { Name = "Ramsy", Specializare = "Marine", Stele = 5 };
            //    var persoane = context.Persoane.ToList();
            //    context.Persoane.Add(chef_A);
            //    //context.SaveChanges();
            //    var echipa_A = new EchipaModel("Hey!");
            //    echipa_A.AddChef(chef_A);
            //    echipa_A.AddConcurent(new ConcurentModel { Name = "Jhon" });
            //    echipa_A.AddConcurent(new ConcurentModel { Name = "Maria" });
            //    echipa_A.AddConcurent(new ConcurentModel { Name = "Lyv" });

            //    var echipa_B = new EchipaModel("Loosers");

            //    var jurat_1 = new JuratModel { Name = "Bors", Nivel = 3 };

            //    context.Echipe.AddRange(new[] { echipa_A, echipa_B });
            //    context.Persoane.Add(jurat_1);

            //    context.SaveChanges();
            //}

            //using (var context = new MasterChefDataContext())
            //{
            //    var jurat_2 = new JuratModel { Name = "Bors", Nivel = 3 };
            //    var jurat_4 = new JuratModel { Name = "Evil", Nivel = 6 };
            //    var jurat_3 = new JuratModel { Name = "judge", Nivel = 2 };

            //    var echipaB = context.Echipe.Single(e => e.Name == "Loosers");
            //    var chef_loose = new ChefModel { Name = "Rookie", Stele = 1, Specializare = "iarut" };
            //    echipaB.AddChef(chef_loose);
            //    echipaB.AddConcurent(new ConcurentModel {Name = "Bob"});
            //    echipaB.AddConcurent(new ConcurentModel {Name = "AAA"});
            //    echipaB.AddConcurent(new ConcurentModel {Name = "CCC"});
            //    echipaB.AddConcurent(new ConcurentModel {Name = "X"});
            //    echipaB.AddConcurent(new ConcurentModel { Name = "Y" });

            //    context.Persoane.AddRange(new[] { jurat_2, jurat_3, jurat_4 });

            //    context.SaveChanges();
            //}

            //using (var context = new MasterChefDataContext())
            //{
            //    var evilJudge = context.Persoane.OfType<JuratModel>().Single( j => j.Name == "Evil");
            //    var echipaB = context.Echipe.Single(e => e.Name == "Loosers");
            //    echipaB.AddEvaluare(evilJudge, 0);

            //    context.SaveChanges();

            //    foreach (var judge in context.Persoane.OfType<JuratModel>())
            //    {
            //        foreach (var echipa in context.Echipe)
            //        {
            //            judge.Evalueaza(echipa);
            //        }
            //    }
            //    context.SaveChanges();
            //}
        }
    }
}
