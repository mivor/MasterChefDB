using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterChef.DAL.Concrete;
using Xunit;
using MasterChefDb.Models;
using MasterChefDb.Business.Models;

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

            Echipa result = map.Get<EchipaModel, Echipa>(source);

            Assert.Equal(source.Id, result.Id);
        }

        [Fact]
        public void SimpleStringMapping()
        {
            var map = new DbMapper();

            EchipaModel source = new EchipaModel();

            source.Name = "Chef";

            Echipa result = map.Get<EchipaModel, Echipa>(source);

            Assert.Equal(source.Name, result.Name);
        }

        [Fact]
        public void SimpleReferenceMapping()
        {
            var map = new DbMapper();
            map.Map<ChefModel, Chef>();
            EchipaModel source = new EchipaModel();

            source.Chef = new ChefModel { Id = 2, Name = "Ion" };

            Echipa result = map.Get<EchipaModel, Echipa>(source);

            Assert.Equal(source.Chef.Name, result.Chef.Name);
            Assert.Equal(source.Chef.Id, result.Chef.Id);
        }
    }
}
