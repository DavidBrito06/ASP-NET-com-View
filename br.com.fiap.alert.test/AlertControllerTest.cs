using AutoMapper;
using br.com.fiap.alert.Controllers;
using br.com.fiap.alert.Data.Contexts;
using br.com.fiap.alert.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace br.com.fiap.alert.test
{
    public class AlertControllerTest
    {
        private readonly Mock<DatabaseContext> _mockContext;

        private readonly AlertController _alertControler;

        private readonly DbSet<AlertModel> _mockSet;

        private readonly IMapper _mapper;


        public AlertControllerTest()
        {
            _mockContext = new Mock<DatabaseContext>();

            _mockSet = MockDbSet();

            _mockContext.Setup(m => m.Alerts).Returns(_mockSet);

            _alertControler = new AlertController(_mockContext.Object,_mapper);
        }

        private DbSet<AlertModel> MockDbSet()
        {
            // Lista de clientes para simular dados no banco de dados
            var data = new List<AlertModel>
            {
                new AlertModel { AlertId = 1,  TypeAlert = "Type 1", Message = "msg 1", Coords = "c1", Author = "A1" },
                new AlertModel { AlertId = 2,  TypeAlert = "Type 2", Message = "msg 2", Coords = "c2", Author = "A2" },
                new AlertModel { AlertId = 3,  TypeAlert = "Type 3", Message = "msg 3", Coords = "c3", Author = "A3" },
                new AlertModel { AlertId = 4,  TypeAlert = "Type 4", Message = "msg 4", Coords = "c4", Author = "A4" },
                new AlertModel { AlertId = 5,  TypeAlert = "Type 5", Message = "msg 5", Coords = "c5", Author = "A5" },
                new AlertModel { AlertId = 6,  TypeAlert = "Type 6", Message = "msg 6", Coords = "c6", Author = "A6" },
                new AlertModel { AlertId = 7,  TypeAlert = "Type 7", Message = "msg 7", Coords = "c7", Author = "A7" },
                new AlertModel { AlertId = 8,  TypeAlert = "Type 8", Message = "msg 8", Coords = "c8", Author = "A8" },
                new AlertModel { AlertId = 9,  TypeAlert = "Type 9", Message = "msg 9", Coords = "c9", Author = "A9" },
                new AlertModel { AlertId = 10,  TypeAlert = "Type 10", Message = "msg 10", Coords = "c10", Author = "A10" },
                new AlertModel { AlertId = 11,  TypeAlert = "Type 11", Message = "msg 11", Coords = "c11", Author = "A11" },
                new AlertModel { AlertId = 12,  TypeAlert = "Type 12", Message = "msg 12", Coords = "c12", Author = "A12" },
                new AlertModel { AlertId = 13,  TypeAlert = "Type 13", Message = "msg 13", Coords = "c13", Author = "A13" },
            }.AsQueryable();
            // Cria o mock do DbSet
            var mockSet = new Mock<DbSet<AlertModel>>();
            // Configura o comportamento do mock DbSet para simular uma consulta ao banco de dados
            mockSet.As<IQueryable<AlertModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<AlertModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<AlertModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<AlertModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            // Retorna o DbSet mock
            return mockSet.Object;
        }

        [Fact]
        public void Index_ReturnsViewWithAlerts()
        {

            var result = _alertControler.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<AlertModel>>(viewResult.Model);
            Assert.Equal(13, model.Count());
        }

        [Fact]
        public void Index_ReturnsViewWithoutAlerts()
        {

            _mockSet.RemoveRange(_mockSet.ToList());
            _mockContext.Setup( m=> m.Alerts).Returns(_mockSet);
            var result = _alertControler.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<AlertModel>>(viewResult.Model);
            Assert.Empty(model);
        }


    }

}