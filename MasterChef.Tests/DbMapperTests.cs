using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterChef.DAL.Concrete;
using Xunit;
using MasterChefDb.Models;
using MasterChefDb.Business.Models;
using System.Collections.ObjectModel;
using MasterChef.Business.Models;

namespace MasterChef.Tests
{
    public class DALTests
    {
        [Fact]
        public void SimpleValueMapping()
        {
            var map = new DbMapper();

            EchipaModel source = new EchipaModel();

            source.Id = 1;

            Echipa result = map.Get<Echipa, EchipaModel>(source);

            Assert.Equal(source.Id, result.Id);
        }

        [Fact]
        public void SimpleStringMapping()
        {
            var map = new DbMapper();

            EchipaModel source = new EchipaModel();

            source.Name = "Chef";

            Echipa result = map.Get<Echipa, EchipaModel>(source);


            Assert.Equal(source.Name, result.Name);
        }

        [Fact]
        public void SimpleReferenceMapping()
        {
            var map = new DbMapper();
            map.Map<ChefModel, Chef>();
            EchipaModel source = new EchipaModel();

            source.Chef = new ChefModel { Id = 2, Name = "Ion" };

            Echipa result = map.Get<Echipa, EchipaModel>(source);

            Assert.Equal(source.Chef.Name, result.Chef.Name);
            Assert.Equal(source.Chef.Id, result.Chef.Id);
        }

        [Fact]
        public void CollectionReferenceMapping()
        {
            var map = new DbMapper();
            map.Map<EchipaModel, Echipa>();
            var source = new ConcursModel();

            source.Echipe = new Collection<EchipaModel>
            {
                new EchipaModel { Id = 5, Name = "A" }, 
                new EchipaModel { Id = 6, Name = "B" }, 
                new EchipaModel { Id = 3, Name = "C" }, 
            };

            Concurs result = map.Get<Concurs, ConcursModel>(source);

            Assert.True(result.Echipe.All(x => x.GetType() == typeof(Echipa)));
            Assert.True(result.Echipe.Count == 3);
        }

        [Fact]
        public void CircularCollectionMapping()
        {
            var map = new DbMapper();
            map.Map<ConcurentModel, Concurent>();
            map.Map<EchipaModel, Echipa>();
            map.Conflict<EchipaModel, ConcurentModel>();

            var source = new EchipaModel();

            source.Concurenti = new Collection<ConcurentModel>
            {
                new ConcurentModel { Id = 5, Name = "A", Echipa=source }, 
                new ConcurentModel { Id = 6, Name = "B", Echipa=source }, 
                new ConcurentModel { Id = 3, Name = "C", Echipa=source }, 
            };

            Echipa result = map.Get<Echipa, EchipaModel>(source);

            Assert.True(result.Concurenti.All(x => x.GetType() == typeof(Concurent)));
            Assert.True(result.Concurenti.Count == 3);
        }
    }
}
