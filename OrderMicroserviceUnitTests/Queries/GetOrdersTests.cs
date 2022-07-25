using AutoFixture;
using AutoMapper;
using Moq;
using OrderMicroservice.Business.Queries.QueryOrders;
using OrderMicroservice.DataAccess.Entities;
using OrderMicroservice.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderMicroserviceUnitTests.Queries
{
    public class GetOrdersTests
    {
        private readonly Mock<IOrderViewRepository> _orderQueryRepository;
        private readonly IMapper _mapper;


        public GetOrdersTests()
        {
            _orderQueryRepository = new Mock<IOrderViewRepository>();
            _mapper = AutoMapperConfig.getMapper();
        }

        [Fact]
        public void Get_Should_ReturnCorrrectNumberOfElements()
        {
            //Arrange

            var fixture = new Fixture();

            fixture.Customize<OrderView>(e => e.WithAutoProperties());
            var orderList = fixture.Build<OrderView>()
                .CreateMany(5);

            var queryStartDate = new DateTime(2022, 6, 10);
            var queryEndDate = new DateTime(2022, 7, 10);


            var queryRequest = fixture.Build<GetOrdersQuery>()
                .With(x => x.StartDate , queryStartDate)
                .With(x => x.EndDate , queryEndDate)
                .Create();

            
            _orderQueryRepository.Setup(x => x.GetOrdersByDate(queryStartDate, queryEndDate)).Returns(Task.FromResult(orderList.ToList()));

            GetOrdersHandler handler = new GetOrdersHandler(_orderQueryRepository.Object, _mapper);

            //Act

            var result = handler.Handle(queryRequest, new System.Threading.CancellationToken()).GetAwaiter().GetResult();

            //Assert

            Assert.Equal(5, result.Count());
        }


    }
}
