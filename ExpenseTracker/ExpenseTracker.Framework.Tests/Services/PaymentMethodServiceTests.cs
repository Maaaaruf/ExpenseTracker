using Autofac.Extras.Moq;
using ExpenseTracker.Framework.Entities;
using ExpenseTracker.Framework.Exceptions;
using ExpenseTracker.Framework.Repositories;
using ExpenseTracker.Framework.Services;
using ExpenseTracker.Framework.UnitOfWorks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace ExpenseTracker.Framework.Tests.Services
{
    [ExcludeFromCodeCoverage]
    public class PaymentMethodServiceTests : IDisposable
    {
        private readonly AutoMock _mock;
        private readonly Mock<IPaymentMethodRepository> _paymentRepositoryMock;
        private readonly Mock<IExpenseUnitOfWork> _expenseUnitOfWorkMock;
        private readonly IPaymentMethodService _paymentMethodService;
        public PaymentMethodServiceTests()
        {
            _mock = AutoMock.GetLoose();
            _paymentRepositoryMock = _mock.Mock<IPaymentMethodRepository>();
            _expenseUnitOfWorkMock = _mock.Mock<IExpenseUnitOfWork>();
            _paymentMethodService = _mock.Create<PaymentMethodService>();
        }

        public void Dispose()
        {
            _paymentRepositoryMock.Reset();
            _expenseUnitOfWorkMock.Reset();
            _paymentMethodService?.Dispose();

            _mock?.Dispose();
        }

        [Fact]
        public void Create_IsPaymentMethodNull_ThrowsException()
        {
            //Arrange
            PaymentMethod payment = null;

            //Act
            Should.Throw<EntityNullException<PaymentMethod>>(() =>
                _paymentMethodService.Create(payment)
            );

            //Assert

        }
    }
}
